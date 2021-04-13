using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FormDesignerApp.Generators
{
    static class ControllerGenerator
    {

        public static string renderController(string entityName, string dbContextName, DbContext dbContext, string templateFolder, string outpuPath )
        {
            string templateContext = "";

            templateContext = File.ReadAllText(templateFolder + "\\" + "Controller.txt");

            templateContext = templateContext.Replace("[###entityName###]", entityName);

            var entityVariableName = entityName.Substring(1, 1).ToLower() + entityName.Remove(1, 1);
            templateContext = templateContext.Replace("[###entityVariableName###]", entityName);

            templateContext = templateContext.Replace("[###dbContextName###]", dbContextName);

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
