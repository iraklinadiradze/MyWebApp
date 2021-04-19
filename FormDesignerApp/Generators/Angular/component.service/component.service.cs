using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FormDesignerApp.Generators.Angular
{
    class Component_service
    {
        public static string renderComponentServiceTS(
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

            File.WriteAllText(targetPath + "\\" + _entityDescriptor.CSharpVariableName + ".service.ts", templateContext);

            _result = templateContext;

            return _result;
        }

    }
}
