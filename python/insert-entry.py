from cliargs import CliArgs
import db_manager
import sql_commands
import prompts

# gather the database connection credientials from the cli
cli_args = CliArgs()
db_credentials = cli_args.getCredentials()

# connect to the database
db = db_manager.DB(db_credentials)
db.connect()

# retrieve all the topics
topics = sql_commands.getTopics(db)

# prompt for the new entry values (title, link, topic)
entry = prompts.getNewEntry(topics)

# insert the entry into the database
sql_commands.insertEntry(db, entry)



