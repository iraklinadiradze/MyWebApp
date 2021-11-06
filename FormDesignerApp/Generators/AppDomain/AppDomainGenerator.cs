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

    }
}
