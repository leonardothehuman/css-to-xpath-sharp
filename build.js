var program = require('commander');
var shell = require('shelljs');

program
  .command('build')
  .description('Build the selected version')
  .option('-d, --debug', 'Build the debug variant')
  .action(function(opt){
	var webpack = require('webpack');
	var wpConfig = {
		entry: __dirname + '/JavascriptString.js',
		output:{
			"filename": "JavascriptString.js"
		},
		node: {
			fs: 'empty'
		}
	}
	var cb = function(){
		console.log("Js file generated ...");
		console.log("Now you can open the project \"cs-project/cs-project.sln\" on visual studio 2017");
	}
	shell.rm('cs-project/css-to-xpath/JavascriptString.js');
	shell.rm('cs-project/css-to-xpath/JavascriptString.cs');
	if(opt.debug){
		wpConfig["mode"] = "development";
		wpConfig.output.path = __dirname + '/cs-project/css-to-xpath';
        var build = webpack(wpConfig);
        build.run(cb);
	}else{
		wpConfig["mode"] = "production";
		wpConfig.output.path = __dirname + '/cs-project/css-to-xpath';
        var build = webpack(wpConfig);
        build.run(cb);
	}
  });
program
  .command('clean')
  .description('Clean the project')
  .action(function(){
	  shell.rm('cs-project/css-to-xpath/JavascriptString.js');
	  shell.rm('cs-project/css-to-xpath/JavascriptString.cs');
	  shell.rm('-R', 'cs-project/css-to-xpath/bin');
	  shell.rm('-R', 'cs-project/css-to-xpath/obj');
	  shell.rm('-R', 'cs-project/packages');
	  shell.rm('-R', 'cs-project/WindowsFormsApp1/bin');
	  shell.rm('-R', 'cs-project/WindowsFormsApp1/obj');
	  console.log('Project cleaned');
  });

program.parse(process.argv);