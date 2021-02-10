This post is to demonstrate how to read and write JSON using 2 python functions. 

There are many more operations python can do, and you can check out the full documentation [here](https://docs.python.org/3/library/json.html)



## Read JSON Data

To retrieve data written to a json file:

```py
def getJsonData(fileName):
    inputFile = open(fileName, 'r')
    jsonData = json.loads(inputFile.read())
    inputFile.close()

    return jsonData
```


## Write JSON Data

To write a `Dict` as json to an output file:


```py
def writeJsonToFile(outputData, fileName):
    jsonString = json.dumps(outputData, sort_keys=True, indent=4)

    with open(fileName, "w") as outputFile:
        outputFile.write(jsonString)
```
