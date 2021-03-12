using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

using System.Data;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EntitySchemaController : ControllerBase
    {

        private readonly PilotDBContext _context;

        public EntitySchemaController(PilotDBContext context)
        {
            _context = context;
        }

        [HttpGet("{entityName}")]
        public ActionResult<string> GetEntityschema(string entityName)
        {
            //            var entity = typeof(PilotDBContext).GetProperty(entityName).GetValue(this._context,null);// .FindAnnotation(entityName);
            var entity = _context.Model.FindEntityType("WebAPI.Models." + entityName).GetProperties();

            var result = "GetProperties:" + Environment.NewLine;

            foreach (var e in entity)
            {
                result = result + "  Name:" + e.Name + Environment.NewLine;

                if (e.ClrType.GenericTypeArguments.Length > 0)
                    result = result + "  Type:" + e.ClrType.GenericTypeArguments[0].Name + Environment.NewLine;
                else
                    result = result + "  Type:" + e.ClrType.Name + Environment.NewLine;

                result = result + "  GetMaxLength :" + e.GetMaxLength() + Environment.NewLine;
                result = result + "  GetColumnType :" + e.GetColumnType() + Environment.NewLine;
//                result = result + "  GetDefaultValue :" + e.GetDefaultValue().ToString() + Environment.NewLine;
                result = result + "  IsColumnNullable :" + e.IsColumnNullable().ToString() + Environment.NewLine;
                result = result + "  IsKey :" + e.IsKey().ToString() + Environment.NewLine;
                if ( !(e.GetDefaultValue()==null) ) 
//                   result = result + "  IsKey :" + e.GetDefaultValue + Environment.NewLine
//                else
                result = result + "  GetDefaultValue :" + e.GetDefaultValue().ToString() + Environment.NewLine;
//                result = result + "  GetRelationalTypeMapping :" + e.GetRelationalTypeMapping().ToString() + Environment.NewLine;

                result = result + "  IsForeignKey :" + e.IsForeignKey().ToString() + Environment.NewLine;
                if (e.IsForeignKey())
                {
                    result = result + "  Foreign Key Table :" + e.GetContainingForeignKeys().First().PrincipalToDependent.Name + Environment.NewLine;
                    result = result + "  Foreign Key Field:" + e.GetContainingForeignKeys().First().PrincipalToDependent.ForeignKey.PrincipalKey.Properties.First().Name + Environment.NewLine;
                }
                result = result + Environment.NewLine;
            }

            var annotations = _context.Model.FindEntityType("WebAPI.Models." + entityName);

//            result = result  + Environment.NewLine +Environment.NewLine + "GetAnnotations:" + Environment.NewLine;
//            foreach (var e in annotations)
//            {
//                result = result + e.Name + " Name:" + e.Name + " Value:" + e.Value + " GetType:" + e.GetType() + Environment.NewLine;
//            }

            return result.ToString();  //"sssss";
        }



    }
}
