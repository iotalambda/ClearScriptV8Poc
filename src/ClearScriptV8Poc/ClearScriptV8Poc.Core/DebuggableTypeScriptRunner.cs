using ClearScriptV8Poc.Core.ClearScript;
using Microsoft.ClearScript;
using Microsoft.ClearScript.V8;

namespace ClearScriptV8Poc.Core;

public sealed class DebuggableTypeScriptRunner : IDisposable
{
    private readonly V8ScriptEngine engine;

    static DebuggableTypeScriptRunner() => HostSettings.CustomAttributeLoader = new PascalCaseAttributeLoader();

    public DebuggableTypeScriptRunner()
    {
        this.engine = new(V8ScriptEngineFlags.EnableDebugging);
        this.engine.DocumentSettings.AccessFlags |= DocumentAccessFlags.EnableFileLoading;
    }

    public void Dispose() => this.engine.Dispose();

    public void RunFile(string path) => this.engine.ExecuteDocument(path);
}
