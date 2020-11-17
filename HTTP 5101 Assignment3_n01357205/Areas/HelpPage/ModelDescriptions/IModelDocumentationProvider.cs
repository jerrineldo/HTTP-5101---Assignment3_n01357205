using System;
using System.Reflection;

namespace HTTP_5101_Assignment3_n01357205.Areas.HelpPage.ModelDescriptions
{
    public interface IModelDocumentationProvider
    {
        string GetDocumentation(MemberInfo member);

        string GetDocumentation(Type type);
    }
}