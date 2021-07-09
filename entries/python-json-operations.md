This post will demonstrate how to work with json data in python. The full python documentation can be found [here](https://docs.python.org/3/library/json.html).

## Basic Operations


### Reading JSON Data

To retrieve data written to a json file:

```py
def getJsonData(fileName: str):
    inputFile = open(fileName, 'r')
    jsonData = json.loads(inputFile.read())
    inputFile.close()

    return jsonData
```

This returns a `dict` made up of the json data.


### Writing JSON Data

To transform a `dict` into a json string, then write it to an output file:

```py
def writeJsonToFile(outputData: dict, fileName: str) -> None:
    jsonString = json.dumps(outputData, sort_keys=True, indent=4)

    with open(fileName, "w") as outputFile:
        outputFile.write(jsonString)
```

## Transforming an object to a json string


If you try to write an object to json using the method above, you will get an error. To fix this, just add a simple part to `writeJsonToFile()`:

```py
def writeJsonToFile(outputData: dict, fileName: str) -> None:
    jsonString = json.dumps(object, indent=4, sort_keys=True, default=lambda o: getattr(o, '__dict__', str(o)))

    with open(fileName, "w") as outputFile:
        outputFile.write(jsonString)
```
