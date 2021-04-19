using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FormDesignerApp.Generators.Angular
{
    static class Component_list
    {

        public static string renderComponentList(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName ,
            string templateFolder,
            string outpuPath
        )
        {
            var _result = "";

            renderComponentListHTML(
                entityName,
                contextDescriptor,
                dbContextName,
                templateFolder,
                outpuPath
            );

            renderComponentListTS(
                entityName,
                contextDescriptor,
                dbContextName,
                templateFolder,
                outpuPath
            );

            return _result;
        }


        public static string renderComponentListHTML(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName,
            string templateFolder,
            string outpuPath
        )
        {
            var _result = "";

            string templateContext = "";
            templateContext = File.ReadAllText(templateFolder + "\\Angular\\" + "component-list-html.txt");

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);

            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);

            var targetPath = outpuPath + "\\" + _entityDescriptor.CSharpVariableName;
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            targetPath = targetPath + "\\" + _entityDescriptor.CSharpVariableName + "-list";
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            File.WriteAllText(targetPath + "\\" + _entityDescriptor.CSharpVariableName + "-list.component.html", templateContext);

            _result = templateContext;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return _result;
        }


        public static string renderComponentListTS(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName,
            string templateFolder,
            string outpuPath
        )
        {
            var _result = "";

            string templateContext = "";
            templateContext = File.ReadAllText(templateFolder + "\\Angular\\" + "component-list-ts.txt");

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);

            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);

            var targetPath = outpuPath + "\\" + _entityDescriptor.CSharpVariableName;
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            targetPath = targetPath + "\\" + _entityDescriptor.CSharpVariableName + "-list";
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);

            File.WriteAllText(targetPath + "\\" + _entityDescriptor.CSharpVariableName + "-list.component.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            _result = templateContext;

            return _result;
        }

    }
}
