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
            // Initialize Entity Framework Model Using Classess

            if (lbEntities.SelectedIndex < 0) return;

            foreach (int i in lbEntities.SelectedIndices)
            {
                //                var entityName = lbEntities.SelectedItem.ToString(); // "Client";
                var entityName = lbEntities.Items[i].ToString();
                var nameSpace = edtEFSpaceName.Text; // "WebAPI.Models";

                var dbModel = this.dbContext.Model;
                //            lbEntities.Items.Clear();

                var entity = dbModel.FindEntityType(entityName);
                var entityNameSplited = entityName.Split(".");
                var subFolder = entityNameSplited[entityNameSplited.Length - 2];
                entityName = entity.ShortName();

                var entityDescriptor = new EntityDescriptor(entity);

                ContextDescriptor contextDescriptor = new ContextDescriptor(this.dbContext);

                var _result = "GetProperties:" + Environment.NewLine;
                _result = _result + entityDescriptor.ToString() + Environment.NewLine;

                rtbCompiledFiles.AppendText(_result);

                rtbOutput.Clear();

                if (chbGenerateController.Checked)
                {
                    var resultController = FormDesignerApp.Generators.ControllerGenerator.renderController(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAPIControllerFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultController);
                    rtbOutput.AppendText(Environment.NewLine);
                }

                if (chbGenerateAngular.Checked)
                {
                    _result = FormDesignerApp.Generators.Angular.Component_entity.renderComponentEntityTS(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAngularCompFolder.Text,
                                                                                            subFolder
                                                                                            );

                    rtbOutput.AppendText(_result);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);


                    _result = FormDesignerApp.Generators.Angular.Component_service.renderComponentServiceTS(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAngularCompFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(_result);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);


                    _result = FormDesignerApp.Generators.Angular.Component_list.renderComponentListHTML(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAngularCompFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(_result);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);

                    _result = FormDesignerApp.Generators.Angular.Component_list.renderComponentListTS(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAngularCompFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(_result);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);
                    rtbOutput.AppendText(Environment.NewLine);

                }

                if (chbGenerateRepository.Checked)
                {

                    subFolder = entityDescriptor.ModuleName;

                    var resultRepository = FormDesignerApp.Generators.RepositoryGenerator.renderRepository(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtRepositoryFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultRepository);
                    rtbOutput.AppendText(Environment.NewLine);

                    resultRepository = FormDesignerApp.Generators.RepositoryGenerator.renderIRepository(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtRepositoryFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultRepository);
                    rtbOutput.AppendText(Environment.NewLine);

                }

                if (chbGenerateAppDomain.Checked)
                {

                    subFolder = entityDescriptor.ModuleName;

                    var resultDomain = FormDesignerApp.Generators.AppDomain.AppDomainGenerator.renderCreateCommand(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAppDomainsFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultDomain);
                    rtbOutput.AppendText(Environment.NewLine);

                    resultDomain = FormDesignerApp.Generators.AppDomain.AppDomainGenerator.renderUpdateCommand(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAppDomainsFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultDomain);
                    rtbOutput.AppendText(Environment.NewLine);

                    resultDomain = FormDesignerApp.Generators.AppDomain.AppDomainGenerator.renderDeleteCommand(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAppDomainsFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultDomain);
                    rtbOutput.AppendText(Environment.NewLine);

                    resultDomain = FormDesignerApp.Generators.AppDomain.AppDomainGenerator.renderViewClass(
                                                                                            entityName,
                                                                                            contextDescriptor,
                                                                                            edtDBContextName.Text,
                                                                                            edtTemplateFolder.Text,
                                                                                            edtAppDomainsFolder.Text,
                                                                                            subFolder
                                                                                            );
                    rtbOutput.AppendText(resultDomain);
                    rtbOutput.AppendText(Environment.NewLine);

                }
            }

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

            foreach (var dir in Directory.GetDirectories(path) )
            {
                fileNames = fileNames.Union( Directory.GetFiles(dir, "*.cs") ).ToArray();
            }

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

        private void btnInitModel_Click(object sender, EventArgs e)
        {
            lbEntities.Items.Clear();

            this.initDbContext();
            var dbModel = this.dbContext.Model;

            foreach (var _entityType in dbModel.GetEntityTypes())
            {
//                lbEntities.Items.Add(_entityType.ShortName());
                lbEntities.Items.Add(_entityType.Name);
            }

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
           
        }

        private void chbGenerateAngular_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

            lbEntities.SelectedItems.Clear();

            for (var i=0; i< lbEntities.Items.Count;i++)
            {
                //                lbEntities.Items.Add(_entityType.ShortName());
                lbEntities.SelectedItems.Add(lbEntities.Items[i]);
            }

        }

    }
}
