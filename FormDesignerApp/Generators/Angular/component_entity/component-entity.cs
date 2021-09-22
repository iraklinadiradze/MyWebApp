using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;

namespace FormDesignerApp.Generators.Angular
{
    class Component_entity
    {
        public static string renderComponentEntityTS(
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

            var _entityWithColumnsAndTypes = from prop in _entityDescriptor.properties
                                             select prop.TSName + ":" + prop.TSType + ";" ;

            templateContext = templateContext.Replace("[###entityWithColumnsAndTypes###]",
                string.Join(Environment.NewLine, _entityWithColumnsAndTypes));

            var _entityWithFilterParamsAndTypes = from prop in _entityDescriptor.properties
                                                  from item in prop.TSFilterParameters
                                                  select item + ":" + prop.TSType + ";";

            templateContext = templateContext.Replace("[###entityWithFilterParamsAndTypes###]",
                string.Join(Environment.NewLine, _entityWithFilterParamsAndTypes));

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            var targetPath = outpuPath + "\\" + subFolder + "\\" + _entityDescriptor.CSharpVariableName;
            if (!Directory.Exists(targetPath))
                Directory.CreateDirectory(targetPath);


            File.WriteAllText(targetPath + "\\" + _entityDescriptor.CSharpVariableName + "-entity.ts", templateContext);


            _result = templateContext;

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(_result);

            return _result;
        }


    }
}
