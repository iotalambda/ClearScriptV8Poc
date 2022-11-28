using Microsoft.ClearScript;
using Microsoft.ClearScript.JavaScript;
using Microsoft.ClearScript.V8;

var engine = new V8ScriptEngine(V8ScriptEngineFlags.EnableDebugging, 9229);
dynamic setupConsole = engine.Evaluate("writeLine => console = { log: message => writeLine(message) }");
setupConsole(new Action<string>(Console.WriteLine));

var js = File.ReadAllText("..\\..\\..\\..\\..\\demo\\dist\\bundle.js");
engine.DocumentSettings.AddSystemDocument("bundle", ModuleCategory.Standard, js);
dynamic exports = engine.Evaluate(new DocumentInfo { Category = ModuleCategory.Standard }, "import * as exports from 'bundle'; exports");

Console.WriteLine("Open your debugger and hit enter");
Console.ReadLine();
exports.run();
