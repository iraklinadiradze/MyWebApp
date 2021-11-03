using System;
using System.Collections.Generic;
using System.Text;

using System.IO;
using System.Linq;

namespace FormDesignerApp.Generators
{
    class RepositoryGenerator
    {
        public static string renderRepository(
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

            templateContext = File.ReadAllText(templateFolder + "\\" + "Repository.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            File.WriteAllText(outpuPath + "\\" + subFolder + "\\" + _entityDescriptor.CSharpTypeName + "Repository.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }

        public static string renderIRepository(
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

            templateContext = File.ReadAllText(templateFolder + "\\" + "IRepository.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            File.WriteAllText(outpuPath + "\\" + subFolder + "\\" + "I" + _entityDescriptor.CSharpTypeName + "Repository.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;

        }

    }
}
