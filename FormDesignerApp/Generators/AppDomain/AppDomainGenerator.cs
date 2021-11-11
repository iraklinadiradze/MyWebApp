using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Linq;

namespace FormDesignerApp.Generators.AppDomain
{
    class AppDomainGenerator
    {
        public static string renderCreateCommand(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName,
            string templateFolder,
            string outpuPath,
            string subFolder
            )
        {

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\" + "CreateCommand.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Commands";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Create" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\" + "Create" + _entityDescriptor.CSharpTypeName + "Command.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }

        public static string renderUpdateCommand(
            string entityName,
            ContextDescriptor contextDescriptor,
            string dbContextName,
            string templateFolder,
            string outpuPath,
            string subFolder
            )
        {

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\" + "UpdateCommand.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Commands";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Update" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\" + "Update" + _entityDescriptor.CSharpTypeName + "Command.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }


        public static string renderDeleteCommand(
                    string entityName,
                    ContextDescriptor contextDescriptor,
                    string dbContextName,
                    string templateFolder,
                    string outpuPath,
                    string subFolder
                    )
        {

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\" + "DeleteCommand.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Commands";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Delete" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\" + "Delete" + _entityDescriptor.CSharpTypeName + "Command.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }


        public static string renderViewClass(
                    string entityName,
                    ContextDescriptor contextDescriptor,
                    string dbContextName,
                    string templateFolder,
                    string outpuPath,
                    string subFolder
                    )
        {

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Queries\\" + "ViewClass.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);


            var _entityProperties = from prop in _entityDescriptor.properties
                                    select "e." + prop.Name;

            templateContext = templateContext.Replace("[###enityproperties###]",
                string.Join(Environment.NewLine, _entityProperties));


            var _RelatedentityClasses = from e in contextDescriptor.entities
                                        join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                        from g in e.properties
                                        where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                        select "private class " + e.CSharpTypeName + Environment.NewLine
                                              + "{" + Environment.NewLine +
                                          string.Join(Environment.NewLine,
                                              (from _e in contextDescriptor.entities
                                               from _p in _e.properties
                                               where (_e.Name == e.Name) && (_p.filterParameter != null) && (_p.filterParameter.useInJoin == true)
                                               select _p.CSharpType + " " + _p.Name + " {get; set;} "
                                              )
                                           )
                                        + Environment.NewLine + "}";

            templateContext = templateContext.Replace("[###RelatedentityClasses###]",
                string.Join("," + Environment.NewLine, _RelatedentityClasses));

            var _entityReledClassProperties = from e in contextDescriptor.entities
                                              join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                              select
                                              e.CSharpTypeName + " " + e.CSharpVariableName + " {get; set;} ";

            templateContext = templateContext.Replace("[###RelatedentityClassProperties###]",
                string.Join("," + Environment.NewLine, _entityReledClassProperties));

            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Queries";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Get" + _entityDescriptor.CSharpTypeName + "List";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\" + _entityDescriptor.CSharpTypeName + "View.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }

        public static string renderListQuery(
                    string entityName,
                    ContextDescriptor contextDescriptor,
                    string dbContextName,
                    string templateFolder,
                    string outpuPath,
                    string subFolder
                    )
        {

            return "";
        }

    }


}
