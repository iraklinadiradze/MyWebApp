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
            string outpuPath,
            string subFolder
        )
        {
            var _result = "";

            renderComponentListHTML(
                entityName,
                contextDescriptor,
                dbContextName,
                templateFolder,
                outpuPath,
                subFolder
            );

            renderComponentListTS(
                entityName,
                contextDescriptor,
                dbContextName,
                templateFolder,
                outpuPath,
                subFolder
            );

            return _result;
        }


        public static string renderComponentListHTML(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName,
            string templateFolder,
            string outpuPath,
            string subFolder
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

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            var targetPath = outpuPath + "\\" + subFolder + "\\" + _entityDescriptor.CSharpVariableName;
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
            string outpuPath,
            string subFolder
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

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            var targetPath = outpuPath + "\\" + subFolder + "\\" + _entityDescriptor.CSharpVariableName;
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


        public static string renderGridColumns(
            string entityName,
            ContextDescriptor contextDescriptor,
            string templateFolder
            )
        {
            string templateContext = "";
            templateContext = File.ReadAllText(templateFolder + "\\Angular\\" + "component-list-html-GridColumn.txt");

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            var _result = "";

            //            from prop in _entityDescriptor.properties
            //            select "e." + prop.Name;

            /*
            var _entityRelations = from e in contextDescriptor.entities
                                   join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                   from g in e.properties
                                   where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                   select
                                   " join _" + e.CSharpVariableName + " in _context." + e.Name + " on e." + f.Name + " equals _" + e.CSharpVariableName + "." + f.Name + " into __" + e.CSharpVariableName +
                                   Environment.NewLine + " from _" + e.CSharpVariableName + " in __" + e.CSharpVariableName + ".DefaultIfEmpty()";
            */

            foreach (var _e in _entityDescriptor.properties)
            {
                string _templateContext = "";

                _templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);

                _templateContext = templateContext.Replace("[###entityColumnName###]", _e.TSName);
                _templateContext = templateContext.Replace("[###entityColumnsTitle###]", _e.TSName);

                if (_e.TSType == "Date")
                    _templateContext = templateContext.Replace("[###entityColumnFormat###]", "MM-dd-yyyy");
                else
                    _templateContext = templateContext.Replace("[###entityColumnFormat###]", "");

                _templateContext = templateContext.Replace("[###entityColumnWidth###]", "120");

                _result = _result + Environment.NewLine + Environment.NewLine  + _templateContext;
            }

            return _result;
        }
    }
}
