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

            templateContext = File.ReadAllText(templateFolder + "\\" + "Controller.txt");

            templateContext = templateContext.Replace("[###entityName###]", _entityDescriptor.CSharpTypeName);

            templateContext = templateContext.Replace("[###entityVariableName###]", _entityDescriptor.CSharpVariableName);

            templateContext = templateContext.Replace("[###dbContextName###]", dbContextName);

            var _entityFilterParameters = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterParameters
                                          select prop.CSharpParamType + " " + item;

            templateContext = templateContext.Replace("public [###entityFilterParameters###]",
                string.Join(" {get;set;}" + Environment.NewLine, _entityFilterParameters));

            var _entityFilterStatements = from prop in _entityDescriptor.properties
                                          from item in prop.CSharpFilterStatements
                                          select item;

            templateContext = templateContext.Replace("[###entityFilterStatements###]",
                string.Join(Environment.NewLine + Environment.NewLine, _entityFilterStatements));

            var _entitySelectPropertiesWithPrefix = from prop in _entityDescriptor.properties
                                                    select "e." + prop.Name;

            templateContext = templateContext.Replace("[###entitySelectPropertiesWithPrefix###]",
                string.Join("," + Environment.NewLine, _entitySelectPropertiesWithPrefix));

            var _entityRelations = from e in contextDescriptor.entities
                                   join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                   from g in e.properties
                                   where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                   select
                                   " join _" + e.CSharpVariableName + " in _context." + e.Name + " on e." + f.Name + " equals _" + e.CSharpVariableName + "." + f.Name + " into __" + e.CSharpVariableName +
                                   Environment.NewLine + " from _" + e.CSharpVariableName + " in __" + e.CSharpVariableName + ".DefaultIfEmpty()";

            templateContext = templateContext.Replace("[###RelatedentitySelect###]",
                string.Join("," + Environment.NewLine, _entityRelations));

            var _entityRelationsWithLookups = from e in contextDescriptor.entities
                                              join f in _entityDescriptor.properties on e.Name equals f.ForeignKeyTable
                                              from g in e.properties
                                              where f.IsForeignKey && (g.Name == f.ForeignKeyColumn)
                                              select e.CSharpVariableName + " = new {" + Environment.NewLine +
                                                string.Join("," + Environment.NewLine,
                                                    (from _e in contextDescriptor.entities
                                                     from _p in _e.properties
                                                     where (_e.Name == e.Name) && (_p.filterParameter != null) && (_p.filterParameter.useInJoin == true)
                                                     select "_" + e.CSharpVariableName + "." + _p.Name
                                                    )
                                                 )
                                              + Environment.NewLine + "}";

            templateContext = templateContext.Replace("[###RelatedentitySelectPropertiesWithPrefix###]",
                string.Join("," + Environment.NewLine, _entityRelationsWithLookups));

            if (!Directory.Exists(outpuPath + "\\" + subFolder)) { Directory.CreateDirectory(outpuPath + "\\" + subFolder); };

            File.WriteAllText(outpuPath + "\\" + subFolder + "\\" + entityName + "Controller.cs", templateContext);

            Console.WriteLine(Environment.NewLine);
            Console.WriteLine(templateContext);

            return templateContext;


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
