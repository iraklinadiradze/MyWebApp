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

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Commands\\" + "CreateCommand.txt");

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

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Commands\\" + "UpdateCommand.txt");

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

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Commands\\" + "DeleteCommand.txt");

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

            //            var _entityProperties = from prop in _entityDescriptor.properties
            //                                    select " public " + prop.CSharpType + " " + prop.Name + " {get; set;} ";

            //            templateContext = templateContext.Replace("[###enityproperties###]",
            //                string.Join(Environment.NewLine, _entityProperties));

            var _RelatedentityClasses = from e in contextDescriptor.entities
                                        join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                        from g in e.properties
                                        where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                        select "public class _" + e.CSharpTypeName + Environment.NewLine
                                              + "{" + Environment.NewLine +
                                          string.Join(Environment.NewLine,
                                              (from _e in contextDescriptor.entities
                                               from _p in _e.properties
                                               where (_e.Name == e.Name) && (_p.filterParameter != null) && (_p.filterParameter.useInJoin == true)
                                               select " public " + _p.CSharpType + " " + _p.Name + " {get; set;} "
                                              )
                                           )
                                        + Environment.NewLine + "}";

            templateContext = templateContext.Replace("[###RelatedentityClasses###]",
                string.Join(Environment.NewLine + Environment.NewLine, _RelatedentityClasses));

            var _entityReledClassProperties = from e in contextDescriptor.entities
                                              join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                              select
                                              " public _" + e.CSharpTypeName + " " + e.CSharpVariableName + " {get; set;} ";

            templateContext = templateContext.Replace("[###RelatedentityClassProperties###]",
                string.Join(Environment.NewLine + Environment.NewLine, _entityReledClassProperties));

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

            var _entityDescriptor = (from p in contextDescriptor.entities
                                     where (p.Name == entityName)
                                     select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Queries\\" + "GetListCommand.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _entityFilterParameters = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterParameters
                                          select "public " + ((prop.CSharpParamType.ToLower()== "string")? prop.CSharpParamType : prop.CSharpParamType.Replace("?","") + "?") + " " + item + " {get;set;}";

            templateContext = templateContext.Replace("[###entityFilterParameters###]",
                string.Join(Environment.NewLine, _entityFilterParameters));

            var _entityRelations = from e in contextDescriptor.entities
                                   join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                   from g in e.properties
                                   where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                   select
                                   " join _" + e.CSharpVariableName + " in _context." + e.Name + " on e." + f.Name + " equals _" + e.CSharpVariableName + "." + g.Name + " into __" + e.CSharpVariableName +
                                   Environment.NewLine + " from _" + e.CSharpVariableName + " in __" + e.CSharpVariableName + ".DefaultIfEmpty()";

            templateContext = templateContext.Replace("[###RelatedentitySelect###]",
                string.Join(Environment.NewLine, _entityRelations));

            var _entitySelectPropertiesWithPrefix = from prop in _entityDescriptor.properties
                                                    select prop.Name + "= e." + prop.Name;

            var _entityRelationsWithLookups = from e in contextDescriptor.entities
                                              join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                              from g in e.properties
                                              where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                              select e.CSharpVariableName + " = new " + _entityDescriptor.CSharpTypeName + "View._" + e.CSharpTypeName + "{" + Environment.NewLine +
                                                string.Join("," + Environment.NewLine,
                                                    (from _e in contextDescriptor.entities
                                                     from _p in _e.properties
                                                     where (_e.Name == e.Name) && (_p.filterParameter != null) && (_p.filterParameter.useInJoin == true)
                                                     select _p.Name + "= _" + e.CSharpVariableName + "." + _p.Name
                                                    )
                                                 )
                                              + Environment.NewLine + "}";


            var _EntityProperties = _entitySelectPropertiesWithPrefix.Union(_entityRelationsWithLookups);

            templateContext = templateContext.Replace("[###EntityProperties###]",
                string.Join("," + Environment.NewLine, _EntityProperties));


            var _entityFilterStatements = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterStatements
                                          select item.Replace("[###prefix###]", "request.");

            templateContext = templateContext.Replace("[###entityFilterStatements###]",
                string.Join(Environment.NewLine + Environment.NewLine, _entityFilterStatements));


            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Queries";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Get" + _entityDescriptor.CSharpTypeName + "List";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\Get" + _entityDescriptor.CSharpTypeName + "List.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;
        }


        public static string renderGetQuery(
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

            templateContext = File.ReadAllText(templateFolder + "\\AppDomain\\Queries\\" + "GetCommand.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _path = outpuPath + "\\" + subFolder;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + _entityDescriptor.CSharpTypeName;
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Queries";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            _path = _path + "\\" + "Get" + _entityDescriptor.CSharpTypeName + "";
            if (!Directory.Exists(_path)) { Directory.CreateDirectory(_path); };

            File.WriteAllText(_path + "\\Get" + _entityDescriptor.CSharpTypeName + ".cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;
        }

    }

}
