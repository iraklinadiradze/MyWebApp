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
            string outpuPath 
            )
        {
            var _entityDescriptor = (from p in contextDescriptor.entities
                                    where (p.Name==entityName)
                                    select p).First();

            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\" + "Controller.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);

            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);

            templateContext = templateContext.Replace("[###dbContextName###]", dbContextName);

            var _entityFilterParameters = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterParameters
                                          select prop.CSharpParamType + " " + item;

            templateContext = templateContext.Replace("[###entityFilterParameters###]", 
                string.Join("," + Environment.NewLine , _entityFilterParameters));

            var _entityFilterStatements = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterStatements
                                          select item;

            templateContext = templateContext.Replace("[###entityFilterStatements###]",
                string.Join(Environment.NewLine + Environment.NewLine, _entityFilterStatements));

            var _entitySelectPropertiesWithPrefix = from prop in _entityDescriptor.properties
                                                    select "e." + prop.Name;

            templateContext = templateContext.Replace("[###entitySelectPropertiesWithPrefix###]",
                string.Join("," + Environment.NewLine, _entitySelectPropertiesWithPrefix));

            //            

            var relatedEntityNames = from prop in _entityDescriptor.properties
                                     where prop.IsForeignKey
                                     select prop.ForeignKeyTable;

            return templateContext;

//            File.WriteAllText(outpuPath + "\\" + entityName +"Controller1.cs", templateContext);

        }


        static string renderViewParameters()
        {
            var resut="";


            return resut;
        }
        public static string generateEntityView(string entityName, DbContext dbContext)
        {

            var result = "";



            return result;
        }
    }
}
