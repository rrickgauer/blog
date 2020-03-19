from beautifultable import BeautifulTable

class Utilities:
    def space(numSpaces = 1):
        for x in range(numSpaces):
            print('')

    def getTable(data, columns=[]):
        table = BeautifulTable(max_width=1000)
        table.set_style(BeautifulTable.STYLE_COMPACT)
        table.column_headers = columns

        for row in data:
            table.append_row(row)

        table.column_alignments = BeautifulTable.ALIGN_LEFT
        return table
