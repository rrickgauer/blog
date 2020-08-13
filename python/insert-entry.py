import tkinter as tk
import mysql.connector
import requests
from datetime import date

ENTRY_WIDTH = 100
ROW_PADDING = 10
ROW_PADDING_Y = 5

def submit_entry():
    data = getData()

    mydb = mysql.connector.connect(
      host     = data['host'],
      user     = data['user'],
      passwd   = data['password'],
      database = data['database']
    )

    # connect to database
    mycursor = mydb.cursor()

    # prepare sql statement
    sql = "INSERT INTO Entries (date, title, link) VALUES (%s, %s, %s)"

    # bind values
    val = (date.today(), data['title'], data['link'])

    # execute insert statement
    mycursor.execute(sql, val)
    mydb.commit()

    displaySubmittedWindow()

    

def getData():
    return {
        "title": entry_title.get(),
        "link": entry_link.get(),
        "host": entry_host.get(),
        "database": entry_database.get(),
        "user": entry_user.get(),
        "password": entry_password.get(),
    }

def displaySubmittedWindow():
    master.destroy()
    newMaster = tk.Tk()
    tk.Label(newMaster, text='Submitted').grid(row=0)
    newMaster.mainloop()
    

# setup display window
master = tk.Tk()
tk.Label(master, text="Title").grid(row=0, padx=ROW_PADDING, sticky='w')
tk.Label(master, text="Link", anchor='w').grid(row=1, padx=ROW_PADDING, sticky='w')
tk.Label(master, text="Host").grid(row=2, padx=ROW_PADDING, sticky='w')
tk.Label(master, text="Database").grid(row=3, padx=ROW_PADDING, sticky='w')
tk.Label(master, text="User").grid(row=4, padx=ROW_PADDING, sticky='w')
tk.Label(master, text="Password").grid(row=5, padx=ROW_PADDING, sticky='w')


entry_title    = tk.Entry(master)
entry_link     = tk.Entry(master)
entry_host     = tk.Entry(master)
entry_database = tk.Entry(master)
entry_user     = tk.Entry(master)
entry_password = tk.Entry(master, show="*")


entry_title.grid(row=0, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)
entry_link.grid(row=1, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)
entry_host.grid(row=2, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)
entry_database.grid(row=3, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)
entry_user.grid(row=4, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)
entry_password.grid(row=5, column=1, ipadx=ENTRY_WIDTH, pady=ROW_PADDING_Y)

b = tk.Button(master, text="Submit", command=submit_entry).grid(row=6, column=1, sticky='e')

master.mainloop()