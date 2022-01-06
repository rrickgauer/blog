from __future__ import annotations
import prettytable

#----------------------------------------------------------
# Print a list of dictionaries to the console
#----------------------------------------------------------
def listDict(outdata: list[dict]):
    if not outdata:
        print("Data is null")
        return
    
    if len(outdata) < 1:
        print("Data is empty")
        return

    keys = outdata[0].keys()
    table = prettytable.PrettyTable(keys)
    table.align = "l"

    for record in outdata:
        table.add_row(record.values())
    
    print(table)


