using System;
using System.Reflection;

namespace HTTP5101_Cumulative1_UditeshJha.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}