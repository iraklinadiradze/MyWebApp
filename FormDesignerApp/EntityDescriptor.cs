using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using SharedLib.Attributes;


namespace FormDesignerApp
{
    public class PropertyDesciptor
    {
        public string Name;
        public string CSharpParamName;

        public string Type;
        public string CSharpType;
        public string CSharpParamType;

        public int? MaxLength;
        public string ColumnType;
        public bool IsNullable;
        public bool IsKey;
        public string DefaultValue;

        public bool IsForeignKey;
        public string ForeignKeyTable;
        public string ForeignKeyColumn;

        public FilterParamAttribute filterParameter;
        public LookupDisplayAttribute lookupDisplay;

        public List<string> CSharpFilterParameters;
        public List<string> CSharpFilterStatements;
        public List<string> LookupEntities;

    }

    class EntityDescriptor
    {
        public string Name;
        public string CSharpVariableName;
        public string CSharpTypeName;

        public List<PropertyDesciptor> properties = new List<PropertyDesciptor>();

        public EntityDescriptor(IEntityType entity)
        {
            Name = entity.ClrType.Name;
            CSharpVariableName = Name.Substring(0, 1).ToLower() + Name.Remove(0, 1);
            CSharpTypeName = Name.Substring(0, 1).ToUpper() + Name.Remove(0, 1);

            foreach (var _e in entity.GetProperties())
            {
                PropertyDesciptor propertyDesciptor = new PropertyDesciptor();

                propertyDesciptor.Name = _e.Name;
                propertyDesciptor.CSharpParamName = _e.Name.Substring(0, 1).ToLower() + _e.Name.Remove(0, 1);

                foreach (var _att in _e.PropertyInfo.CustomAttributes)
                {
                    if (_att.AttributeType.Name== "FilterParamAttribute")
                    {
                        propertyDesciptor.filterParameter = new FilterParamAttribute();

                          var   r= (from item in _att.NamedArguments
                                where item.MemberName == "equals"
                                select item.TypedValue.Value);

                        if (r.Count() > 0) propertyDesciptor.filterParameter.equals = (bool)r.FirstOrDefault();

                          r = (from item in _att.NamedArguments
                              where item.MemberName == "startsWith"
                              select item.TypedValue.Value);

                        if (r.Count() > 0) propertyDesciptor.filterParameter.startsWith = (bool)r.FirstOrDefault();

                        r = (from item in _att.NamedArguments
                             where item.MemberName == "range"
                             select item.TypedValue.Value);

                        if (r.Count() > 0) propertyDesciptor.filterParameter.range = (bool)r.FirstOrDefault();

                        r = (from item in _att.NamedArguments
                             where item.MemberName == "useInJoin"
                             select item.TypedValue.Value);

                        if (r.Count() > 0) propertyDesciptor.filterParameter.useInJoin = (bool)r.FirstOrDefault();

                    }


                    if (_att.AttributeType.Name == "LookupDisplayAttribute") {
                        propertyDesciptor.lookupDisplay = new LookupDisplayAttribute();
                    }
                }

                if (_e.ClrType.GenericTypeArguments.Length > 0)
                    propertyDesciptor.Type = _e.ClrType.GenericTypeArguments[0].Name;
                else
                    propertyDesciptor.Type = _e.ClrType.Name;

                propertyDesciptor.MaxLength = _e.GetMaxLength();
                propertyDesciptor.ColumnType = _e.GetColumnType();
                propertyDesciptor.IsNullable = _e.IsColumnNullable();
                propertyDesciptor.IsKey = _e.IsKey();

                if (!(_e.GetDefaultValue() == null))
                    propertyDesciptor.DefaultValue = _e.GetDefaultValue().ToString();

                propertyDesciptor.CSharpType = propertyDesciptor.Type;

                if ( (propertyDesciptor.IsNullable) && (propertyDesciptor.CSharpType.ToLower()!="string") )
                    propertyDesciptor.CSharpType = propertyDesciptor.CSharpType + "?";

                propertyDesciptor.CSharpParamType = propertyDesciptor.Type;

                if (propertyDesciptor.CSharpType.ToLower() != "string")
                    propertyDesciptor.CSharpParamType = propertyDesciptor.CSharpParamType + "?";

                propertyDesciptor.IsForeignKey = _e.IsForeignKey();

                if (_e.IsForeignKey())
                {
                    propertyDesciptor.ForeignKeyTable = _e.GetContainingForeignKeys().First().PrincipalToDependent.Name;
                    propertyDesciptor.ForeignKeyColumn = _e.GetContainingForeignKeys().First().PrincipalToDependent.ForeignKey.PrincipalKey.Properties.First().Name;
                }

                propertyDesciptor.CSharpFilterParameters = new List<string>();
                propertyDesciptor.CSharpFilterStatements = new List<string>();

                if (propertyDesciptor.filterParameter != null)
                {
                    if (propertyDesciptor.filterParameter.startsWith || propertyDesciptor.filterParameter.equals)
                        propertyDesciptor.CSharpFilterParameters.Add(propertyDesciptor.CSharpParamName);

                    if (propertyDesciptor.filterParameter.equals)
                        propertyDesciptor.CSharpFilterStatements.Add(
                            "if (" + propertyDesciptor.CSharpParamName + "!= null) " + Environment.NewLine +
                                        " result = result.Where(r => r." + CSharpVariableName + "." + propertyDesciptor.Name + "== " + propertyDesciptor.CSharpParamName + ");"
                            );

                    if (propertyDesciptor.filterParameter.startsWith)
                        propertyDesciptor.CSharpFilterStatements.Add(
                            "if (" + propertyDesciptor.CSharpParamName + "!= null) " + Environment.NewLine +
                                        " result = result.Where(r => r." + CSharpVariableName + "." + propertyDesciptor.Name + ".StartsWith(" + propertyDesciptor.CSharpParamName + "));"
                            );

                    if (propertyDesciptor.filterParameter.range)
                        {
                            var fieldNameFrom = propertyDesciptor.CSharpParamName + "_from";
                            var fieldNameTo = propertyDesciptor.CSharpParamName + "_to";

                            propertyDesciptor.CSharpFilterParameters.Add(fieldNameFrom);
                            propertyDesciptor.CSharpFilterParameters.Add(fieldNameTo);

                            propertyDesciptor.CSharpFilterStatements.Add(
                                "if (" + fieldNameFrom + "!= null) " + Environment.NewLine +
                                            " result = result.Where(r => r." + CSharpVariableName + "." + propertyDesciptor.Name + ">= " + fieldNameFrom + ");"
                                );

                            propertyDesciptor.CSharpFilterStatements.Add(
                                "if (" + fieldNameTo + "!= null) " + Environment.NewLine +
                                            " result = result.Where(r => r." + CSharpVariableName + "." + propertyDesciptor.Name + "<= " + fieldNameTo + ");"
                                );

                        }

                }

                this.properties.Add(propertyDesciptor);

            }

        }

    }

    class ContextDescriptor
    {
        public List<EntityDescriptor> entities;
    }


}

