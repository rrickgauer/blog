
[Babel](https://babeljs.io/) is a JavaScript compiler. This is how to set it up in a project. 

## Installation

In the terminal, cd into the project directory. Then, you need to create a `package.json` via:

```
npm init
```

Now it's time to install the Babel.js [core](https://babeljs.io/docs/en/usage#core-library) and [CLI](https://babeljs.io/docs/en/babel-cli) libaries:

```
npm install --save-dev @babel/core @babel/cli
```


*Optional*. Install the [plugin-proposal-class-properties plugin](https://babeljs.io/docs/en/babel-plugin-proposal-class-properties):

```
npm install --save-dev @babel/plugin-proposal-class-properties
```


## Usage

Compile the entire src directory and output it to the lib directory by using either `--out-dir` or `-d`. This doesn't overwrite any other files or directories in lib.

```
npx babel src --out-dir lib
```

Compile the entire src directory and output it as a single concatenated file.

```
npx babel src --out-file script-compiled.js
```

To compile a file every time that you change it, use the `--watch` or `-w` option:

```
npx babel script.js --watch --out-file script-compiled.js
```

Use the `--plugins` option to specify plugins to use in compilation:

```
npx babel script.js --out-file script-compiled.js --plugins=@babel/proposal-class-properties,@babel/transform-modules-amd
```

Use the `--presets` option to specify presets to use in compilation

```
npx babel script.js --out-file script-compiled.js --presets=@babel/preset-env,@babel/flow
```


## Further Reading


* https://babeljs.io/docs/en/babel-cli
