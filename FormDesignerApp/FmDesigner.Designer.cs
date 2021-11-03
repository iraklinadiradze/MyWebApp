
namespace FormDesignerApp
{
    partial class FmDesigner
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.designerTabControl = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label11 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.edtAngularCompFolder = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.label7 = new System.Windows.Forms.Label();
            this.tbAttributesFolder = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.edtDBContextName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.edtEFSpaceName = new System.Windows.Forms.TextBox();
            this.button4 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.tbEntityFrameworkFolder = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.edtTemplateFolder = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.edtAPIControllerFolder = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chbGenerateAngular = new System.Windows.Forms.CheckBox();
            this.chbGenerateController = new System.Windows.Forms.CheckBox();
            this.s = new System.Windows.Forms.Button();
            this.lbEntities = new System.Windows.Forms.ListBox();
            this.rtbCompiledFiles = new System.Windows.Forms.RichTextBox();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.rtbOutput = new System.Windows.Forms.RichTextBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.chbGenerateRepository = new System.Windows.Forms.CheckBox();
            this.button7 = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.edtRepositoryFolder = new System.Windows.Forms.TextBox();
            this.designerTabControl.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.SuspendLayout();
            // 
            // designerTabControl
            // 
            this.designerTabControl.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.designerTabControl.Controls.Add(this.tabPage1);
            this.designerTabControl.Controls.Add(this.tabPage2);
            this.designerTabControl.Controls.Add(this.tabPage3);
            this.designerTabControl.Location = new System.Drawing.Point(2, 12);
            this.designerTabControl.Name = "designerTabControl";
            this.designerTabControl.SelectedIndex = 0;
            this.designerTabControl.Size = new System.Drawing.Size(786, 426);
            this.designerTabControl.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.button7);
            this.tabPage1.Controls.Add(this.label10);
            this.tabPage1.Controls.Add(this.edtRepositoryFolder);
            this.tabPage1.Controls.Add(this.label11);
            this.tabPage1.Controls.Add(this.label9);
            this.tabPage1.Controls.Add(this.button6);
            this.tabPage1.Controls.Add(this.label8);
            this.tabPage1.Controls.Add(this.edtAngularCompFolder);
            this.tabPage1.Controls.Add(this.button5);
            this.tabPage1.Controls.Add(this.label7);
            this.tabPage1.Controls.Add(this.tbAttributesFolder);
            this.tabPage1.Controls.Add(this.label6);
            this.tabPage1.Controls.Add(this.edtDBContextName);
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.edtEFSpaceName);
            this.tabPage1.Controls.Add(this.button4);
            this.tabPage1.Controls.Add(this.label4);
            this.tabPage1.Controls.Add(this.tbEntityFrameworkFolder);
            this.tabPage1.Controls.Add(this.button3);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.edtTemplateFolder);
            this.tabPage1.Controls.Add(this.button2);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.edtAPIControllerFolder);
            this.tabPage1.Controls.Add(this.button1);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.textBox1);
            this.tabPage1.Location = new System.Drawing.Point(4, 24);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(778, 398);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Settings";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label11.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label11.Location = new System.Drawing.Point(6, 9);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(123, 15);
            this.label11.TabIndex = 24;
            this.label11.Text = "Project Input Folders";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Segoe UI", 9F, ((System.Drawing.FontStyle)(((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic) 
                | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point);
            this.label9.ForeColor = System.Drawing.SystemColors.Highlight;
            this.label9.Location = new System.Drawing.Point(3, 260);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(90, 15);
            this.label9.TabIndex = 22;
            this.label9.Text = "Output Folders";
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(574, 282);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(47, 23);
            this.button6.TabIndex = 21;
            this.button6.Text = "Open";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(-2, 286);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 15);
            this.label8.TabIndex = 20;
            this.label8.Text = "Angular Component Output";
            // 
            // edtAngularCompFolder
            // 
            this.edtAngularCompFolder.Location = new System.Drawing.Point(156, 282);
            this.edtAngularCompFolder.Name = "edtAngularCompFolder";
            this.edtAngularCompFolder.Size = new System.Drawing.Size(418, 23);
            this.edtAngularCompFolder.TabIndex = 19;
            this.edtAngularCompFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\Result\\Angular";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(575, 130);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(47, 23);
            this.button5.TabIndex = 18;
            this.button5.Text = "Open";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(21, 135);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(125, 15);
            this.label7.TabIndex = 17;
            this.label7.Text = "Attributes Class Folder";
            // 
            // tbAttributesFolder
            // 
            this.tbAttributesFolder.Location = new System.Drawing.Point(157, 130);
            this.tbAttributesFolder.Name = "tbAttributesFolder";
            this.tbAttributesFolder.Size = new System.Drawing.Size(418, 23);
            this.tbAttributesFolder.TabIndex = 16;
            this.tbAttributesFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\SharedLib";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 106);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(102, 15);
            this.label6.TabIndex = 15;
            this.label6.Text = "DB Context Name";
            // 
            // edtDBContextName
            // 
            this.edtDBContextName.Location = new System.Drawing.Point(156, 101);
            this.edtDBContextName.Name = "edtDBContextName";
            this.edtDBContextName.Size = new System.Drawing.Size(418, 23);
            this.edtDBContextName.TabIndex = 14;
            this.edtDBContextName.Text = "CoreDBContext";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(20, 77);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(133, 15);
            this.label5.TabIndex = 13;
            this.label5.Text = "Entity Framework Space";
            // 
            // edtEFSpaceName
            // 
            this.edtEFSpaceName.Location = new System.Drawing.Point(156, 72);
            this.edtEFSpaceName.Name = "edtEFSpaceName";
            this.edtEFSpaceName.Size = new System.Drawing.Size(418, 23);
            this.edtEFSpaceName.TabIndex = 12;
            this.edtEFSpaceName.Text = "DataAccessLayer";
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(574, 43);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(47, 23);
            this.button4.TabIndex = 11;
            this.button4.Text = "Open";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.button4_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(20, 48);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(135, 15);
            this.label4.TabIndex = 10;
            this.label4.Text = "Entity Framework Folder";
            // 
            // tbEntityFrameworkFolder
            // 
            this.tbEntityFrameworkFolder.Location = new System.Drawing.Point(156, 43);
            this.tbEntityFrameworkFolder.Name = "tbEntityFrameworkFolder";
            this.tbEntityFrameworkFolder.Size = new System.Drawing.Size(418, 23);
            this.tbEntityFrameworkFolder.TabIndex = 9;
            this.tbEntityFrameworkFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\DataAccessLayer\\Model";
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(574, 183);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(47, 23);
            this.button3.TabIndex = 8;
            this.button3.Text = "Open";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(20, 188);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(91, 15);
            this.label3.TabIndex = 7;
            this.label3.Text = "Template Folder";
            // 
            // edtTemplateFolder
            // 
            this.edtTemplateFolder.Location = new System.Drawing.Point(156, 183);
            this.edtTemplateFolder.Name = "edtTemplateFolder";
            this.edtTemplateFolder.Size = new System.Drawing.Size(418, 23);
            this.edtTemplateFolder.TabIndex = 6;
            this.edtTemplateFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\FormDesignerApp\\Templates";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(575, 313);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(47, 23);
            this.button2.TabIndex = 5;
            this.button2.Text = "Open";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 318);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "API Controller Folder";
            // 
            // edtAPIControllerFolder
            // 
            this.edtAPIControllerFolder.Location = new System.Drawing.Point(157, 313);
            this.edtAPIControllerFolder.Name = "edtAPIControllerFolder";
            this.edtAPIControllerFolder.Size = new System.Drawing.Size(418, 23);
            this.edtAPIControllerFolder.TabIndex = 3;
            this.edtAPIControllerFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\Result\\BackendControllers";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(574, 215);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(47, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Open";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 220);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "API Address";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(156, 215);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(418, 23);
            this.textBox1.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.chbGenerateRepository);
            this.tabPage2.Controls.Add(this.chbGenerateAngular);
            this.tabPage2.Controls.Add(this.chbGenerateController);
            this.tabPage2.Controls.Add(this.s);
            this.tabPage2.Controls.Add(this.lbEntities);
            this.tabPage2.Controls.Add(this.rtbCompiledFiles);
            this.tabPage2.Controls.Add(this.btnGenerate);
            this.tabPage2.Location = new System.Drawing.Point(4, 24);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(778, 398);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Generator";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // chbGenerateAngular
            // 
            this.chbGenerateAngular.AutoSize = true;
            this.chbGenerateAngular.Checked = true;
            this.chbGenerateAngular.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbGenerateAngular.Location = new System.Drawing.Point(333, 109);
            this.chbGenerateAngular.Name = "chbGenerateAngular";
            this.chbGenerateAngular.Size = new System.Drawing.Size(118, 19);
            this.chbGenerateAngular.TabIndex = 5;
            this.chbGenerateAngular.Text = "Generate Angular";
            this.chbGenerateAngular.UseVisualStyleBackColor = true;
            // 
            // chbGenerateController
            // 
            this.chbGenerateController.AutoSize = true;
            this.chbGenerateController.Checked = true;
            this.chbGenerateController.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbGenerateController.Location = new System.Drawing.Point(161, 109);
            this.chbGenerateController.Name = "chbGenerateController";
            this.chbGenerateController.Size = new System.Drawing.Size(129, 19);
            this.chbGenerateController.TabIndex = 4;
            this.chbGenerateController.Text = "Generate Controller";
            this.chbGenerateController.UseVisualStyleBackColor = true;
            // 
            // s
            // 
            this.s.Location = new System.Drawing.Point(21, 4);
            this.s.Name = "s";
            this.s.Size = new System.Drawing.Size(91, 38);
            this.s.TabIndex = 3;
            this.s.Text = "Init Model";
            this.s.UseVisualStyleBackColor = true;
            this.s.Click += new System.EventHandler(this.btnInitModel_Click);
            // 
            // lbEntities
            // 
            this.lbEntities.FormattingEnabled = true;
            this.lbEntities.ItemHeight = 15;
            this.lbEntities.Location = new System.Drawing.Point(161, 0);
            this.lbEntities.Name = "lbEntities";
            this.lbEntities.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;
            this.lbEntities.Size = new System.Drawing.Size(572, 79);
            this.lbEntities.TabIndex = 2;
            // 
            // rtbCompiledFiles
            // 
            this.rtbCompiledFiles.Location = new System.Drawing.Point(21, 142);
            this.rtbCompiledFiles.Name = "rtbCompiledFiles";
            this.rtbCompiledFiles.Size = new System.Drawing.Size(712, 226);
            this.rtbCompiledFiles.TabIndex = 1;
            this.rtbCompiledFiles.Text = "";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(21, 97);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(91, 39);
            this.btnGenerate.TabIndex = 0;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.rtbOutput);
            this.tabPage3.Location = new System.Drawing.Point(4, 24);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage3.Size = new System.Drawing.Size(778, 398);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "Result";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // rtbOutput
            // 
            this.rtbOutput.Location = new System.Drawing.Point(6, 3);
            this.rtbOutput.Name = "rtbOutput";
            this.rtbOutput.Size = new System.Drawing.Size(772, 392);
            this.rtbOutput.TabIndex = 2;
            this.rtbOutput.Text = "";
            // 
            // chbGenerateRepository
            // 
            this.chbGenerateRepository.AutoSize = true;
            this.chbGenerateRepository.Checked = true;
            this.chbGenerateRepository.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chbGenerateRepository.Location = new System.Drawing.Point(479, 108);
            this.chbGenerateRepository.Name = "chbGenerateRepository";
            this.chbGenerateRepository.Size = new System.Drawing.Size(132, 19);
            this.chbGenerateRepository.TabIndex = 6;
            this.chbGenerateRepository.Text = "Generate Repository";
            this.chbGenerateRepository.UseVisualStyleBackColor = true;
            this.chbGenerateRepository.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button7
            // 
            this.button7.Location = new System.Drawing.Point(574, 342);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(47, 27);
            this.button7.TabIndex = 27;
            this.button7.Text = "Open";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(20, 347);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(99, 15);
            this.label10.TabIndex = 26;
            this.label10.Text = "Repository Folder";
            // 
            // edtRepositoryFolder
            // 
            this.edtRepositoryFolder.Location = new System.Drawing.Point(156, 342);
            this.edtRepositoryFolder.Name = "edtRepositoryFolder";
            this.edtRepositoryFolder.Size = new System.Drawing.Size(418, 23);
            this.edtRepositoryFolder.TabIndex = 25;
            this.edtRepositoryFolder.Text = "C:\\Users\\inadir\\source\\repos\\MyWebApp\\Result\\Repository";
            // 
            // FmDesigner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.designerTabControl);
            this.Name = "FmDesigner";
            this.Text = "Form Designer";
            this.designerTabControl.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.tabPage3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl designerTabControl;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox edtAPIControllerFolder;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox edtTemplateFolder;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox tbEntityFrameworkFolder;
        private System.Windows.Forms.Button btnGenerate;
        private System.Windows.Forms.RichTextBox rtbCompiledFiles;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox edtEFSpaceName;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox edtDBContextName;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.RichTextBox rtbOutput;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tbAttributesFolder;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox edtAngularCompFolder;
        private System.Windows.Forms.ListBox lbEntities;
        private System.Windows.Forms.Button s;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.CheckBox chbGenerateAngular;
        private System.Windows.Forms.CheckBox chbGenerateController;
        private System.Windows.Forms.CheckBox chbGenerateRepository;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox edtRepositoryFolder;
    }
}

