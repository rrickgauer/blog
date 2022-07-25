This is the `rollup.config.js` file that is needed to use [rollup.js](https://rollupjs.org/guide/en/):

```js
class RollupConfig
{
    constructor(input, output) {
        this.input = input;

        this.output = {
            format: 'iife',
            compact: true,
            sourcemap: true,
            file: output,
        }
    }
}


// add each entry-point file and its output here:
const configs = [
    new RollupConfig('custom/pages/new-watch/index.js', 'dist/new-watch.bundle.js'),
];


// rollup.config.js
export default configs;
```

Then, in the terminal:

```sh
rollup --config rollup.config.js --watch
```