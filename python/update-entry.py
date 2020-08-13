import mysql.connector
import getpass
import sys
import requests
from datetime import date
import argparse
from Utilities import Utilities as util

# assign command line arguments
parser = argparse.ArgumentParser(description='Insert a new blog entry')
parser.add_argument('--title', action='store')
parser.add_argument('--link', action='store')
parser.add_argument('--host', action='store')
parser.add_argument('--user', action='store')
parser.add_argument('--password', action='store')
parser.add_argument('--database', action='store')
parser.add_argument('--id', action='store')

# get the arguments
args = parser.parse_args()


# get host
if args.host == None:
  host = input('host: ')
else:
  host = args.host

# get user
if args.user == None:
  user = input('user: ')
else:
  user = args.user

# get database
if args.database == None:
  database = input('database: ')
else:
  database = args.database

# get password
if args.password == None:
  password = getpass.getpass()
else:
  password = args.password

# initialize database connection
mydb = mysql.connector.connect(
  host     = host,
  user     = user,
  passwd   = password,
  database = database
 )

# connect to database
mycursor = mydb.cursor()

# get entry id
if args.id == None:

    # retrieve all entry id's and their titles
    sql = 'SELECT id, title from Entries ORDER BY title asc'
    mycursor.execute(sql)
    myresult = mycursor.fetchall()

    # print the entries and their ids
    table = util.getTable(myresult, ['Entry ID', 'Title'])
    util.space(2)
    print(table)

    # get user input for id
    entryID = input('\nEntry ID: ')

else:
  entryID = args.id

# get link
if args.link == None:
  link = input('link: ')
else:
  link = args.link

# get title
if args.title == None:
  title = input('title: ')
else:
  title = args.title


# choose sql statement
if len(title) == 0:
  sql = "UPDATE Entries SET link = %s WHERE id = %s"
  val = (link, entryID)
else :
  sql = "UPDATE Entries SET title = %s, content = %s WHERE id = %s"
  val = (title, content, entryID)

# execute insert statement
mycursor.execute(sql, val)
mydb.commit()

# print number of inserted records
print(mycursor.rowcount, "record updated.")
