## Docs

* [ICU User Guide](https://unicode-org.github.io/icu/userguide/)
* [List of available character sets (codepages)](https://www.iana.org/assignments/character-sets/character-sets.xhtml)
* [Faqs](https://unicode-org.github.io/icu/userguide/icufaq/#using-icu)

## Converter Life Cycle

https://unicode-org.github.io/icu/userguide/conversion/converters.html#converter-life-cycle

1. First, open up the converter with a specified name (or alias name).
2. Convert the data
3. Clean up (close) the converter.



## Creating a converter

https://unicode-org.github.io/icu/userguide/conversion/converters.html#creating-a-converter

You can create a converter 4 different ways, but the first two seem to be the best option for us:

1. By name
2. By codepage number

#### By name

```cpp
UConverter *conv = ucnv_open("shift_jis", &myError);
```

The list of available names can be found [here](https://www.iana.org/assignments/character-sets/character-sets.xhtml).


#### By codepage number


```cpp
ucnv_openCCSID(37, UCNV_IBM, &myErr);
```


## Conversion Methods

https://unicode-org.github.io/icu/userguide/conversion/converters.html#modes-of-conversion

The appropriate conversion methods are `ucnv_fromUChars` and `ucnv_toUChars`.


**Converting From UTF**

```cpp
len = ucnv_fromUChars(conv, target, targetLen, source, sourceLen, &status);
```


**Converting to UTF**

```cpp
len = ucnv_toUChars(conv, target, targetSize, source, sourceLen, &status);
```


## Closing the converter

To close the converter, you can do:

```cpp
ucnv_close(conv);
```

## Notes

After reading through the docs, I believe we must first convert the Ascii data to UTF-16 first, then convert it to UTF-8. 

> Since ICU uses Unicode (UTF-16) internally, all converters convert between UTF-16 (with the endianness according to the current platform) and another encoding.

Also,

> In order to use the collation, text boundary analysis, formatting or other ICU APIs, you must use Unicode strings. In order to get Unicode strings from your native > codepage, you can use the conversion API.

This might be the solution:

```cpp

UConverter *conv;                             // icu converter
const char *source;                           // ascii data array
int32_t sourceSize = sizeof(source);          // size of ascii array data
UErrorCode status = U_ZERO_ERROR;             // error flag
UChar *targetUnicode;                         // icu utf-16 array
char *targetUtf8;                             // array holding the utf-8 data
int32_t targetSize = sizeof(targetUnicode);   // size of the utf-16 array

// Create a converter to handle ascii to unicode
conv = ucnv_open("US-ASCII", &status);

// Convert the ascii to utf-16
ucnv_toUChars(conv, targetUnicode, targetSize, source, sourceSize, &status);

// Set the converter to convert to utf-8 data
conv = ucnv_open("utf-8", &status);

// Convert the utf-16 to utf-8
ucnv_fromUChars(conv, targetUtf8, sizeof(targetUtf8), targetUnicode, targetSize, &status);

// Close the converter
ucnv_close(conv);
```




## Examples

https://github.com/unicode-org/icu/blob/master/icu4c/source/samples/ucnv/convsamp.cpp


