using System;
using System.Collections.Generic;

using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Common;

using System.IO;
using Microsoft.CodeAnalysis;
using Microsoft.CodeAnalysis.CSharp;

using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

using Microsoft.CodeAnalysis.Emit;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Metadata;

using Microsoft.Extensions.Hosting;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FormDesignerApp
{
    public partial class FmDesigner : Form
    {

        private DbContext dbContext = null;

        public FmDesigner()
        {
            InitializeComponent();

        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {

            this.initDbContext();

            var entityName = "Client";
            var nameSpace = edtEFSpaceName.Text; // "WebAPI.Models";

            var dbModel = this.dbContext.Model;
            var entity = dbModel.FindEntityType(nameSpace + "." + entityName);

            var entityDescriptor = new EntityDescriptor(entity);

            ContextDescriptor contextDescriptor = new ContextDescriptor(this.dbContext);
//            contextDescriptor.entities.Add(entityDescriptor);


            var _result = "GetProperties:" + Environment.NewLine;
            _result = _result + entityDescriptor.ToString() + Environment.NewLine;

            rtbCompiledFiles.AppendText(_result);

            var resultController = FormDesignerApp.Generators.ControllerGenerator.renderController(
                                                                                    entityName, 
                                                                                    contextDescriptor, 
                                                                                    edtDBContextName.Text,
                                                                                    edtTemplateFolder.Text, 
                                                                                    edtAPIControllerFolder.Text
                                                                                    );
            rtbOutput.Clear();
            rtbOutput.AppendText(resultController);
            rtbOutput.AppendText(Environment.NewLine);

            /*
            // Controller View Params
            var _resultTemp = from item in entityDescriptor.properties
                              where item.filterParameter != null
                              select item.CSharpParamType + " " + item.CSharpParamName;

            rtbOutput.AppendText(string.Join("," + Environment.NewLine, _resultTemp) );
            rtbOutput.AppendText(Environment.NewLine);

            // Controller Primary table Select Params
            _resultTemp = from item in entityDescriptor.properties
                              where item.filterParameter != null
                              select  "a." + item.Name;

            rtbOutput.AppendText(string.Join("," + Environment.NewLine, _resultTemp));
            rtbOutput.AppendText(Environment.NewLine);

            var _whereStatements = from item in entityDescriptor.properties
                                   where (item.filterParameter != null) && (item.filterParameter.startsWith)
                                             select // "a." + item.Name;
                                    " if (" + item.CSharpParamName + "!= null)" + Environment.NewLine + 
                                        "result = result.Where(r => r."+ entityDescriptor.CSharpVariableName 
                                        + "." + item.Name + ".StartsWith(" + item.CSharpParamName + ") );";

            rtbOutput.AppendText(string.Join(Environment.NewLine + Environment.NewLine, _whereStatements));
            rtbOutput.AppendText(Environment.NewLine);

            _whereStatements = from item in entityDescriptor.properties
                               where (item.filterParameter != null) && (item.filterParameter.@equals)
                               select // "a." + item.Name;
                      " if (" + item.CSharpParamName + "!= null)" + Environment.NewLine +
                          "result = result.Where(r => r." + entityDescriptor.CSharpVariableName
                          + "." + item.Name + "==" + item.CSharpParamName + " );";

            rtbOutput.AppendText(string.Join(Environment.NewLine + Environment.NewLine, _whereStatements));

            _whereStatements = from item in entityDescriptor.properties
                               where (item.filterParameter != null) && (item.filterParameter.range)
                               select // "a." + item.Name;
                      " if (" + item.CSharpParamName + "!= null)" + Environment.NewLine +
                          "result = result.Where(r => r." + entityDescriptor.CSharpVariableName
                          + "." + item.Name + ">=" + item.CSharpParamName + " );"
                          + Environment.NewLine + Environment.NewLine +
                      " if (" + item.CSharpParamName + "!= null)" + Environment.NewLine +
                          "result = result.Where(r => r." + entityDescriptor.CSharpVariableName
                          + "." + item.Name + "<=" + item.CSharpParamName + " );";


            rtbOutput.AppendText(string.Join(Environment.NewLine + Environment.NewLine, _whereStatements));

            rtbOutput.AppendText(Environment.NewLine);
            rtbOutput.AppendText(Environment.NewLine);

            var a = from prop in entityDescriptor.properties 
                    from item in prop.CSharpFilterParameters 
                    select prop.CSharpParamType + " " + item;

            rtbOutput.AppendText(string.Join("," + Environment.NewLine , a));

            rtbOutput.AppendText(Environment.NewLine);
            rtbOutput.AppendText(Environment.NewLine);

            var b = from prop in entityDescriptor.properties
                    from item in prop.CSharpFilterStatements
                    select item;

            rtbOutput.AppendText(string.Join(Environment.NewLine + Environment.NewLine, b));
            */

        }

        void initDbContext()
        {
            rtbCompiledFiles.Clear();

            if (this.dbContext != null) return;

            string path = tbEntityFrameworkFolder.Text;
            string _path = tbAttributesFolder.Text;

            string[] fileNames = Directory.GetFiles(path, "*.cs");
            string[] _fileNames = Directory.GetFiles(_path + "\\Attributes", "*.cs");
            fileNames = fileNames.Union(_fileNames).ToArray();

            List<SyntaxTree> syntaxTrees = new List<SyntaxTree> { };

            foreach (var filepath in fileNames)
            {
                rtbCompiledFiles.AppendText(Path.GetFileName(filepath));
                rtbCompiledFiles.AppendText(Environment.NewLine);

                var sourceCode = File.ReadAllText(filepath);

                SyntaxTree syntaxTree = CSharpSyntaxTree.ParseText(sourceCode);
                syntaxTrees.Add(syntaxTree);
            }

            var dotNetCoreDir = Path.GetDirectoryName(typeof(object).GetTypeInfo().Assembly.Location);
            rtbCompiledFiles.AppendText(dotNetCoreDir + Environment.NewLine);

            var dotNetLocalDir = Path.GetDirectoryName(typeof(DbContext).GetTypeInfo().Assembly.Location);
            rtbCompiledFiles.AppendText(dotNetLocalDir + Environment.NewLine);

            MetadataReference[] metdataReference = new MetadataReference[]
                {
                            MetadataReference.CreateFromFile(typeof(object).Assembly.Location),
        //                    MetadataReference.CreateFromFile(typeof(Object).Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(DbContext).Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(DbConnection).Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(Attribute).Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(KeyAttribute).Assembly.Location),
                            MetadataReference.CreateFromFile(typeof(DatabaseGeneratedAttribute).Assembly.Location),
                            MetadataReference.CreateFromFile(Path.Combine(dotNetLocalDir, "Microsoft.EntityFrameworkCore.Relational.dll")),
                            MetadataReference.CreateFromFile(Path.Combine(dotNetLocalDir, "Microsoft.EntityFrameworkCore.SqlServer.dll")),
                            MetadataReference.CreateFromFile(typeof(HashSet<>).Assembly.Location),
                            MetadataReference.CreateFromFile(Path.Combine(dotNetCoreDir, "System.Runtime.dll")),
                            MetadataReference.CreateFromFile(Path.Combine(dotNetCoreDir, "netstandard.dll")),
                            MetadataReference.CreateFromFile(Path.Combine(dotNetCoreDir, "System.Linq.Expressions.dll")),

                            MetadataReference.CreateFromFile(typeof(Microsoft.CSharp.RuntimeBinder.CSharpArgumentInfo).Assembly.Location)
                };

            var assemblyName = "dbContextAssembly";

            CSharpCompilation compilation = CSharpCompilation.Create(
                    assemblyName,
                    syntaxTrees,
                    metdataReference,
                    new CSharpCompilationOptions(OutputKind.DynamicallyLinkedLibrary));

            var nameSpace = edtEFSpaceName.Text; // "WebAPI.Models";
            var dbContextName = edtDBContextName.Text; // "PilotDBContext";

            using (var memoryStream = new MemoryStream())
            {
                EmitResult result = compilation.Emit(memoryStream);

                if (result.Success)
                {
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    Assembly assembly = Assembly.Load(memoryStream.ToArray());

                    Type dbContexClass = assembly.GetType(nameSpace + "." + dbContextName);

//                    var _object = Activator.CreateInstance<dbContexClass.BaseType>(DbContextOptions);
                    DbContext dbContext = (DbContext)Activator.CreateInstance(dbContexClass, true);

                    this.dbContext = dbContext;
                }
            }

        }


        private void GenerateController(string entityName)
        {

        }

        private void designerTabControl_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
