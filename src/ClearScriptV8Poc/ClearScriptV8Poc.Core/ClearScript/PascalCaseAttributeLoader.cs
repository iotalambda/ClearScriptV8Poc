using Microsoft.ClearScript;
using System.Reflection;

namespace ClearScriptV8Poc.Core.ClearScript;

internal class PascalCaseAttributeLoader : CustomAttributeLoader
{
    public override T[] LoadCustomAttributes<T>(ICustomAttributeProvider resource, bool inherit)
    {
        var declaredAttributes = base.LoadCustomAttributes<T>(resource, inherit);
        if (!declaredAttributes.Any() && typeof(T) == typeof(ScriptMemberAttribute) && resource is MemberInfo member)
        {
            var lowerCamelCaseName = char.ToLowerInvariant(member.Name[0]) + member.Name.Substring(1);
            return new[] { new ScriptMemberAttribute(lowerCamelCaseName) }.Cast<T>().ToArray();
        }
        return declaredAttributes;
    }
}
