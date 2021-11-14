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
        public string TSName;

        public string CSharpParamName;
        public string TSParamName;

        public string Type;
        public string CSharpType;
        public string CSharpParamType;
        public string TSType;
        public string TSParamType;

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

        public List<string> TSFilterParameters;

        public List<string> LookupEntities;


    }

    public class EntityDescriptor
    {
        public string Name;
        public string CSharpVariableName;
        public string CSharpTypeName;
        public string ModuleName;

        public List<PropertyDesciptor> properties = new List<PropertyDesciptor>();

        public EntityDescriptor(IEntityType entity)
        {
            Name = entity.ClrType.Name;
            CSharpVariableName = Name.Substring(0, 1).ToLower() + Name.Remove(0, 1);
            CSharpTypeName = Name.Substring(0, 1).ToUpper() + Name.Remove(0, 1);
            ModuleName = entity.ClrType.Namespace.Substring(entity.ClrType.Namespace.LastIndexOf(".") + 1 );
            
            foreach (var _e in entity.GetProperties())
            {
                PropertyDesciptor propertyDesciptor = new PropertyDesciptor();

                propertyDesciptor.Name = _e.Name;
                propertyDesciptor.CSharpParamName = _e.Name.Substring(0, 1).ToUpper() + _e.Name.Remove(0, 1);
                propertyDesciptor.TSName = _e.Name.Substring(0, 1).ToLower() + _e.Name.Remove(0, 1);

                if (_e.PropertyInfo!=null)
                foreach (var _att in _e.PropertyInfo.CustomAttributes)
                {
                    if (_att.AttributeType.Name== "FilterParamAttribute")
                    {
                        propertyDesciptor.filterParameter = new FilterParamAttribute();

                          var   r = (from item in _att.NamedArguments
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

                propertyDesciptor.TSType = Helper.GetPrimitiveMemberType(propertyDesciptor.Type);

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
                    propertyDesciptor.ForeignKeyTable = _e.GetContainingForeignKeys().First().DependentToPrincipal.Name;
                    propertyDesciptor.ForeignKeyColumn = _e.GetContainingForeignKeys().First().PrincipalKey.Properties.First().Name;//  DependentToPrincipal.ForeignKey.PrincipalKey.Properties.First().Name;
                }

                propertyDesciptor.CSharpFilterParameters = new List<string>();
                propertyDesciptor.CSharpFilterStatements = new List<string>();

                propertyDesciptor.TSFilterParameters = new List<string>();

                if (propertyDesciptor.filterParameter != null)
                {
                    if (propertyDesciptor.filterParameter.startsWith || propertyDesciptor.filterParameter.equals)
                    {
                        propertyDesciptor.CSharpFilterParameters.Add(propertyDesciptor.CSharpParamName);
                        propertyDesciptor.TSFilterParameters.Add(propertyDesciptor.TSName);
                    }

                    if (propertyDesciptor.filterParameter.equals)
                        propertyDesciptor.CSharpFilterStatements.Add(
                            "                if (" + "[###prefix###]" + propertyDesciptor.CSharpParamName + "!= null) " + Environment.NewLine +
                                        " result = result.Where(r => r." + propertyDesciptor.Name + "== [###prefix###]" + propertyDesciptor.CSharpParamName + ");"
                            );

                    if (propertyDesciptor.filterParameter.startsWith)
                        propertyDesciptor.CSharpFilterStatements.Add(
                            "                if (" + "[###prefix###]" + propertyDesciptor.CSharpParamName + "!= null) " + Environment.NewLine +
                                        " result = result.Where(r => r." + propertyDesciptor.Name + ".StartsWith([###prefix###]" + propertyDesciptor.CSharpParamName + "));"
                            );

                    if (propertyDesciptor.filterParameter.range)
                        {   
                            var fieldNameFrom = propertyDesciptor.CSharpParamName + "_from";
                            var fieldNameTo = propertyDesciptor.CSharpParamName + "_to";

                            propertyDesciptor.CSharpFilterParameters.Add(fieldNameFrom);
                            propertyDesciptor.CSharpFilterParameters.Add(fieldNameTo);

                            var fieldNameFromTS = propertyDesciptor.TSName + "_from";
                            var fieldNameToTS = propertyDesciptor.TSName + "_to";

                            propertyDesciptor.TSFilterParameters.Add(fieldNameFromTS);
                            propertyDesciptor.TSFilterParameters.Add(fieldNameToTS);

                        propertyDesciptor.CSharpFilterStatements.Add(
                                "                if (" + "[###prefix###]" + fieldNameFrom + "!= null) " + Environment.NewLine +
                                            " result = result.Where(r => r." + propertyDesciptor.Name + ">= [###prefix###]" + fieldNameFrom + ");"
                                );

                            propertyDesciptor.CSharpFilterStatements.Add(
                                "                if (" + "[###prefix###]" + fieldNameTo + "!= null) " + Environment.NewLine +
                                            " result = result.Where(r => r." + propertyDesciptor.Name + "<= [###prefix###]" + fieldNameTo + ");"
                                );

                        }

                }

                this.properties.Add(propertyDesciptor);

            }

        }

    }

    public class ContextDescriptor
    {
        public List<EntityDescriptor> entities;


        public ContextDescriptor()
        {
            entities = new List<EntityDescriptor>();
        } 

        public ContextDescriptor(DbContext dbContext)
        {
            entities = new List<EntityDescriptor>();

            foreach (var _entity in dbContext.Model.GetEntityTypes())
            {
                entities.Add(new EntityDescriptor(_entity));
            }
        }

    }


}

