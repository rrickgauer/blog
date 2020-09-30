import mysql.connector
import getpass
import os.path
from os import path
import argparse
from sys import platform
import webbrowser
import json

def createNewConfigFile():
    configFileUserInput = {
        "user"     : input('User: '),
        "host"     : input('Host: '),
        "database" : input('Database: '),
        "passwd"   : getpass.getpass(),
    }

    jsonString = json.dumps(configFileUserInput)
    with open(".tables-mysql-info.json", "w") as newConfigFile:
        newConfigFile.write(jsonString)

# return the data from the local .tables.config file
def getConfigData():
    with open('.tables-mysql-info.json') as configFile:
        configData = json.loads(configFile.read())
        return configData

def getTableRow(row):
    dict = {
        "field"   : row[0],
        "type"    : row[1],
    }
    return dict

def processData(queryData):
    rows = []
    for row in queryData:
        rows.append(getTableRow(row))
    return rows

def printLine(field, type):
    return (f'| {field:30} | {type:50} |')

def printDottedLine():
    dashes1 = '-' * 32
    dashes2 = '-' * 52
    return('+' + dashes1 + '+' + dashes2 + '+')

def writeOutputToFile(output):
    with open("tables.output.txt", "w") as file:
        for line in output:
            file.write(line + '\n')

    print('\nOutput written to tables.output.txt')

def clearTerminalScreen():
    print("\n" * 200)


#################################### MAIN #######################################
# assign command line arguments
parser = argparse.ArgumentParser(description="View your database table's fields and types")
parser.add_argument('-t', '--tables', nargs="+", help="list of tables you want displayed")
parser.add_argument('-o', '--output', choices=['display', 'save', 'both'], help="choose if you want to print the output to the terminal [display], save it in a text file [save], or both [both] (default)")
args = parser.parse_args()

# create new config file if one does not exist in the local directory
if not path.exists('.tables-mysql-info.json'):
    createNewConfigFile()

# connect to database
configData = getConfigData()
mydb = mysql.connector.connect(**configData)
mycursor = mydb.cursor()

output = [] # initial list

# if no table arguments print list of all tables
if args.tables == None:
    sql = "show tables"
    mycursor.execute(sql)
    myResult = mycursor.fetchall()
    for x in myResult:
        # print(x[0])
        output.append(x[0])


# print schema of all tables listed in the arguments
else:
    tables = []

    # print all tables
    if '*' in args.tables:
        sql = "show tables"
        mycursor.execute(sql)
        myResult = mycursor.fetchall()
        for x in myResult: tables.append(x[0])

    # print tables given in the command line
    else:
        tables = args.tables.copy()

    # print out selected tables
    for table in tables:
        sql = "describe " + table
        mycursor.execute(sql)
        myResult = mycursor.fetchall()
        rows = processData(myResult)

        # print header
        output.append('\n\n' + table + ':')
        output.append(printDottedLine())
        output.append(printLine("Field", "Type"))
        output.append(printDottedLine())

        # print out all values per table
        for row in rows:
            output.append(printLine(row["field"], row["type"]))

        output.append(printDottedLine())

# determine desired output
if args.output == None or args.output == 'display':
    clearTerminalScreen()
    for line in output: print(line)
elif args.output == 'both':
    clearTerminalScreen()
    for line in output: print(line)
    writeOutputToFile(output)
    webbrowser.open("tables.output.txt")
else:
    writeOutputToFile(output)
    webbrowser.open("tables.output.txt")
