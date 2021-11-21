using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace FormDesignerApp.Generators
{
    static class ControllerGenerator
    {

        public static string renderController(
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

            templateContext = File.ReadAllText(templateFolder + "\\WebAPI\\" + "Controller.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);

            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);
            templateContext = templateContext.Replace("[###moduleName###]", _entityDescriptor.ModuleName);

            var _entityFilterParameters = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterParameters
                                          select ((prop.CSharpParamType.ToLower() == "string") ? prop.CSharpParamType : prop.CSharpParamType.Replace("?", "") + "?") + " " + item ;

            templateContext = templateContext.Replace("[###FilterParameters###]",
                string.Join("," + Environment.NewLine, _entityFilterParameters));

            var _commandQueryParameters = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterParameters
                                          select item + " = " + item;

            templateContext = templateContext.Replace("[###CommandQueryParameters###]",
                string.Join("," + Environment.NewLine, _commandQueryParameters));

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            File.WriteAllText(outpuPath + "\\" + subFolder + "\\" + entityName + "Controller.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;


        }


        static string renderViewParameters()
        {
            var resut = "";


            return resut;
        }
        public static string generateEntityView(string entityName, DbContext dbContext)
        {

            var result = "";



            return result;
        }

    }
}
