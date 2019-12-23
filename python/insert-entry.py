
import mysql.connector
import getpass
import sys

# print(sys.argv[1])
# print(sys.argv[2])

hostInput     = input('host: ')
userInput     = input('user: ')
passwdInput   = getpass.getpass('password: ')
databaseInput = input('database: ')





mydb = mysql.connector.connect(
  host     = hostInput,
  user     = str(userInput),
  passwd   = str(passwdInput),
  database = str(databaseInput)
)

mycursor = mydb.cursor()

mycursor.execute("SELECT * FROM Entries")

myresult = mycursor.fetchall()

for x in myresult:
  print(x)




























# eof
