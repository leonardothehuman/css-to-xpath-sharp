# A wrapper to run css-to-xpath on .net with Jint

This is a library that converts css selector to xpath using the css-to-xpath package from node.

## How to use:

1. Install the package `tk.crazylab.csstoxpath` or compile from source
2. Get a instance of the conversor with `var conversor = Conversor.getInstance();` , don't forget to use the namespace `tk.crazylab.csstoxpath`.
* By default, the conversor instance is a singleton created when you  get the conversor for the first time, you can pass false on the first parameter to get additional instances.
3. Add an error handler with `conversor.javascriptError += delegate (object sender, JavascriptErrorEventArgs args) {/*Do something*/}`.
4. Use the function `conversor.cssToXpath(string css)` to convert css selectors into xpath

## How to build this project:
1. Install the node dependencies
2. Run "node build.js build" to generate the css-to-xpath javascript
3. Open cs-project/cs-project.sln with visual studio 2017
4. Select the file css-to-xpath/JavascriptString.tt and save it to generate the cs file from template
5. Build the project