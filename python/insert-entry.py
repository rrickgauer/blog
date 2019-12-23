import mysql.connector
import getpass
import sys
import requests
from datetime import date
import argparse

# assign command line arguments
parser = argparse.ArgumentParser(description='Insert a new blog entry')
parser.add_argument('--title', action='store')
parser.add_argument('--link', action='store')
parser.add_argument('--host', action='store')
parser.add_argument('--user', action='store')
parser.add_argument('--password', action='store')
parser.add_argument('--database', action='store')

# get the arguments
args = parser.parse_args()

# get title
if args.title == None:
  title = input('title: ')
else:
  title = args.title

# get link
if args.link == None:
  link = input('link: ')
else:
  link = args.link

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

# download the content
content = requests.get(link).text

# initialize database connection
mydb = mysql.connector.connect(
  host     = host,
  user     = user,
  passwd   = password,
  database = database
)

# connect to database
mycursor = mydb.cursor()

# prepare sql statement
sql = "INSERT INTO Entries (date, title, content) VALUES (%s, %s, %s)"

# bind values
val = (date.today(), title, content)

# execute insert statement
mycursor.execute(sql, val)
mydb.commit()

# print number of inserted records
print(mycursor.rowcount, "record inserted.")
