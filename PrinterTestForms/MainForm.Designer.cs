namespace PrinterTestForms
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.mat1list = new System.Windows.Forms.ListBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.mat2list = new System.Windows.Forms.ListBox();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.mat3list = new System.Windows.Forms.ListBox();
            this.tabPage4 = new System.Windows.Forms.TabPage();
            this.mat4list = new System.Windows.Forms.ListBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.checkBox3 = new System.Windows.Forms.CheckBox();
            this.checkBox4 = new System.Windows.Forms.CheckBox();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.statusText = new System.Windows.Forms.Label();
            this.serialBox = new System.Windows.Forms.TextBox();
            this.messageBox = new System.Windows.Forms.TextBox();
            this.sendButton = new System.Windows.Forms.Button();
            this.previewTabs = new System.Windows.Forms.TabControl();
            this.tabpreview1 = new System.Windows.Forms.TabPage();
            this.previewPic1 = new System.Windows.Forms.PictureBox();
            this.tabpreview2 = new System.Windows.Forms.TabPage();
            this.previewPic2 = new System.Windows.Forms.PictureBox();
            this.tabpreview3 = new System.Windows.Forms.TabPage();
            this.previewPic3 = new System.Windows.Forms.PictureBox();
            this.tabpreview4 = new System.Windows.Forms.TabPage();
            this.previewPic4 = new System.Windows.Forms.PictureBox();
            this.PreviewBar = new System.Windows.Forms.VScrollBar();
            this.staticLayerText = new System.Windows.Forms.Label();
            this.layerText = new System.Windows.Forms.Label();
            this.showPreviewButton = new System.Windows.Forms.Button();
            this.showBlankButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.homeXButton = new System.Windows.Forms.Button();
            this.homeZButton = new System.Windows.Forms.Button();
            this.homeYButton = new System.Windows.Forms.Button();
            this.resetButton = new System.Windows.Forms.Button();
            this.homeXYButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.baudBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.tabPage3.SuspendLayout();
            this.tabPage4.SuspendLayout();
            this.previewTabs.SuspendLayout();
            this.tabpreview1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic1)).BeginInit();
            this.tabpreview2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic2)).BeginInit();
            this.tabpreview3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic3)).BeginInit();
            this.tabpreview4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.previewPic4)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Controls.Add(this.tabPage4);
            this.tabControl1.ItemSize = new System.Drawing.Size(5, 25);
            this.tabControl1.Location = new System.Drawing.Point(873, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(373, 277);
            this.tabControl1.TabIndex = 15;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.mat1list);
            this.tabPage1.Location = new System.Drawing.Point(4, 29);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Size = new System.Drawing.Size(365, 244);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "---";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // mat1list
            // 
            this.mat1list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mat1list.FormattingEnabled = true;
            this.mat1list.ItemHeight = 20;
            this.mat1list.Location = new System.Drawing.Point(3, 3);
            this.mat1list.Name = "mat1list";
            this.mat1list.Size = new System.Drawing.Size(366, 240);
            this.mat1list.TabIndex = 0;
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.mat2list);
            this.tabPage2.Location = new System.Drawing.Point(4, 29);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(365, 244);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "---";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // mat2list
            // 
            this.mat2list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mat2list.FormattingEnabled = true;
            this.mat2list.ItemHeight = 20;
            this.mat2list.Location = new System.Drawing.Point(-4, 0);
            this.mat2list.Name = "mat2list";
            this.mat2list.Size = new System.Drawing.Size(366, 240);
            this.mat2list.TabIndex = 0;
            // 
            // tabPage3
            // 
            this.tabPage3.Controls.Add(this.mat3list);
            this.tabPage3.Location = new System.Drawing.Point(4, 29);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(365, 244);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "---";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // mat3list
            // 
            this.mat3list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mat3list.FormattingEnabled = true;
            this.mat3list.ItemHeight = 20;
            this.mat3list.Location = new System.Drawing.Point(2, -2);
            this.mat3list.Name = "mat3list";
            this.mat3list.Size = new System.Drawing.Size(362, 260);
            this.mat3list.TabIndex = 0;
            // 
            // tabPage4
            // 
            this.tabPage4.Controls.Add(this.mat4list);
            this.tabPage4.Location = new System.Drawing.Point(4, 29);
            this.tabPage4.Name = "tabPage4";
            this.tabPage4.Size = new System.Drawing.Size(365, 244);
            this.tabPage4.TabIndex = 3;
            this.tabPage4.Text = "---";
            this.tabPage4.UseVisualStyleBackColor = true;
            // 
            // mat4list
            // 
            this.mat4list.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.mat4list.FormattingEnabled = true;
            this.mat4list.ItemHeight = 20;
            this.mat4list.Location = new System.Drawing.Point(4, 0);
            this.mat4list.Name = "mat4list";
            this.mat4list.Size = new System.Drawing.Size(358, 240);
            this.mat4list.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(760, 137);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(104, 24);
            this.checkBox1.TabIndex = 16;
            this.checkBox1.Text = "Material 1";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // checkBox2
            // 
            this.checkBox2.AutoSize = true;
            this.checkBox2.Location = new System.Drawing.Point(760, 107);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Size = new System.Drawing.Size(104, 24);
            this.checkBox2.TabIndex = 17;
            this.checkBox2.Text = "Material 2";
            this.checkBox2.UseVisualStyleBackColor = true;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // checkBox3
            // 
            this.checkBox3.AutoSize = true;
            this.checkBox3.Location = new System.Drawing.Point(760, 77);
            this.checkBox3.Name = "checkBox3";
            this.checkBox3.Size = new System.Drawing.Size(104, 24);
            this.checkBox3.TabIndex = 18;
            this.checkBox3.Text = "Material 3";
            this.checkBox3.UseVisualStyleBackColor = true;
            this.checkBox3.CheckedChanged += new System.EventHandler(this.checkBox3_CheckedChanged);
            // 
            // checkBox4
            // 
            this.checkBox4.AutoSize = true;
            this.checkBox4.Location = new System.Drawing.Point(760, 47);
            this.checkBox4.Name = "checkBox4";
            this.checkBox4.Size = new System.Drawing.Size(104, 24);
            this.checkBox4.TabIndex = 19;
            this.checkBox4.Text = "Material 4";
            this.checkBox4.UseVisualStyleBackColor = true;
            this.checkBox4.CheckedChanged += new System.EventHandler(this.checkBox4_CheckedChanged);
            // 
            // comboBox1
            // 
            this.comboBox1.BackColor = System.Drawing.SystemColors.HighlightText;
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(106, 7);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(121, 28);
            this.comboBox1.TabIndex = 20;
            this.comboBox1.DropDown += new System.EventHandler(this.comboBox1_DropDown);
            this.comboBox1.SelectionChangeCommitted += new System.EventHandler(this.comboBox1_SelectionChangeCommitted);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 765);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Status: ";
            // 
            // statusText
            // 
            this.statusText.AutoSize = true;
            this.statusText.Location = new System.Drawing.Point(72, 765);
            this.statusText.Name = "statusText";
            this.statusText.Size = new System.Drawing.Size(0, 20);
            this.statusText.TabIndex = 23;
            // 
            // serialBox
            // 
            this.serialBox.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.serialBox.Location = new System.Drawing.Point(811, 315);
            this.serialBox.Multiline = true;
            this.serialBox.Name = "serialBox";
            this.serialBox.ReadOnly = true;
            this.serialBox.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.serialBox.Size = new System.Drawing.Size(431, 397);
            this.serialBox.TabIndex = 24;
            this.serialBox.WordWrap = false;
            // 
            // messageBox
            // 
            this.messageBox.Location = new System.Drawing.Point(811, 727);
            this.messageBox.Name = "messageBox";
            this.messageBox.Size = new System.Drawing.Size(350, 26);
            this.messageBox.TabIndex = 25;
            this.messageBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.messageBox_KeyDown);
            // 
            // sendButton
            // 
            this.sendButton.AutoSize = true;
            this.sendButton.Location = new System.Drawing.Point(1167, 725);
            this.sendButton.Name = "sendButton";
            this.sendButton.Size = new System.Drawing.Size(75, 30);
            this.sendButton.TabIndex = 26;
            this.sendButton.Text = "Send";
            this.sendButton.UseVisualStyleBackColor = true;
            this.sendButton.Click += new System.EventHandler(this.sendButton_Click);
            // 
            // previewTabs
            // 
            this.previewTabs.Controls.Add(this.tabpreview1);
            this.previewTabs.Controls.Add(this.tabpreview2);
            this.previewTabs.Controls.Add(this.tabpreview3);
            this.previewTabs.Controls.Add(this.tabpreview4);
            this.previewTabs.Location = new System.Drawing.Point(16, 295);
            this.previewTabs.Multiline = true;
            this.previewTabs.Name = "previewTabs";
            this.previewTabs.SelectedIndex = 0;
            this.previewTabs.Size = new System.Drawing.Size(481, 397);
            this.previewTabs.TabIndex = 28;
            // 
            // tabpreview1
            // 
            this.tabpreview1.Controls.Add(this.previewPic1);
            this.tabpreview1.Location = new System.Drawing.Point(4, 29);
            this.tabpreview1.Name = "tabpreview1";
            this.tabpreview1.Padding = new System.Windows.Forms.Padding(3);
            this.tabpreview1.Size = new System.Drawing.Size(473, 364);
            this.tabpreview1.TabIndex = 0;
            this.tabpreview1.Text = "---";
            this.tabpreview1.UseVisualStyleBackColor = true;
            // 
            // previewPic1
            // 
            this.previewPic1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPic1.Location = new System.Drawing.Point(3, 3);
            this.previewPic1.Name = "previewPic1";
            this.previewPic1.Size = new System.Drawing.Size(467, 358);
            this.previewPic1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPic1.TabIndex = 0;
            this.previewPic1.TabStop = false;
            // 
            // tabpreview2
            // 
            this.tabpreview2.Controls.Add(this.previewPic2);
            this.tabpreview2.Location = new System.Drawing.Point(4, 29);
            this.tabpreview2.Name = "tabpreview2";
            this.tabpreview2.Padding = new System.Windows.Forms.Padding(3);
            this.tabpreview2.Size = new System.Drawing.Size(473, 364);
            this.tabpreview2.TabIndex = 1;
            this.tabpreview2.Text = "---";
            this.tabpreview2.UseVisualStyleBackColor = true;
            // 
            // previewPic2
            // 
            this.previewPic2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPic2.Location = new System.Drawing.Point(3, 3);
            this.previewPic2.Name = "previewPic2";
            this.previewPic2.Size = new System.Drawing.Size(467, 358);
            this.previewPic2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPic2.TabIndex = 1;
            this.previewPic2.TabStop = false;
            // 
            // tabpreview3
            // 
            this.tabpreview3.Controls.Add(this.previewPic3);
            this.tabpreview3.Location = new System.Drawing.Point(4, 29);
            this.tabpreview3.Name = "tabpreview3";
            this.tabpreview3.Size = new System.Drawing.Size(473, 364);
            this.tabpreview3.TabIndex = 2;
            this.tabpreview3.Text = "---";
            this.tabpreview3.UseVisualStyleBackColor = true;
            // 
            // previewPic3
            // 
            this.previewPic3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPic3.Location = new System.Drawing.Point(0, 0);
            this.previewPic3.Name = "previewPic3";
            this.previewPic3.Size = new System.Drawing.Size(473, 364);
            this.previewPic3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPic3.TabIndex = 1;
            this.previewPic3.TabStop = false;
            // 
            // tabpreview4
            // 
            this.tabpreview4.Controls.Add(this.previewPic4);
            this.tabpreview4.Location = new System.Drawing.Point(4, 29);
            this.tabpreview4.Name = "tabpreview4";
            this.tabpreview4.Size = new System.Drawing.Size(473, 364);
            this.tabpreview4.TabIndex = 3;
            this.tabpreview4.Text = "---";
            this.tabpreview4.UseVisualStyleBackColor = true;
            // 
            // previewPic4
            // 
            this.previewPic4.Dock = System.Windows.Forms.DockStyle.Fill;
            this.previewPic4.Location = new System.Drawing.Point(0, 0);
            this.previewPic4.Name = "previewPic4";
            this.previewPic4.Size = new System.Drawing.Size(473, 364);
            this.previewPic4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.previewPic4.TabIndex = 1;
            this.previewPic4.TabStop = false;
            // 
            // PreviewBar
            // 
            this.PreviewBar.Location = new System.Drawing.Point(500, 324);
            this.PreviewBar.Name = "PreviewBar";
            this.PreviewBar.Size = new System.Drawing.Size(26, 368);
            this.PreviewBar.TabIndex = 29;
            this.PreviewBar.Scroll += new System.Windows.Forms.ScrollEventHandler(this.PreviewBar_Scroll);
            // 
            // staticLayerText
            // 
            this.staticLayerText.AutoSize = true;
            this.staticLayerText.Location = new System.Drawing.Point(16, 695);
            this.staticLayerText.Name = "staticLayerText";
            this.staticLayerText.Size = new System.Drawing.Size(56, 20);
            this.staticLayerText.TabIndex = 30;
            this.staticLayerText.Text = "Layer: ";
            // 
            // layerText
            // 
            this.layerText.AutoSize = true;
            this.layerText.Location = new System.Drawing.Point(67, 695);
            this.layerText.Name = "layerText";
            this.layerText.Size = new System.Drawing.Size(0, 20);
            this.layerText.TabIndex = 31;
            // 
            // showPreviewButton
            // 
            this.showPreviewButton.Location = new System.Drawing.Point(251, 698);
            this.showPreviewButton.Name = "showPreviewButton";
            this.showPreviewButton.Size = new System.Drawing.Size(137, 38);
            this.showPreviewButton.TabIndex = 33;
            this.showPreviewButton.Text = "Project Preview";
            this.showPreviewButton.UseVisualStyleBackColor = true;
            this.showPreviewButton.Click += new System.EventHandler(this.showPreviewButton_Click);
            // 
            // showBlankButton
            // 
            this.showBlankButton.Location = new System.Drawing.Point(389, 698);
            this.showBlankButton.Name = "showBlankButton";
            this.showBlankButton.Size = new System.Drawing.Size(137, 38);
            this.showBlankButton.TabIndex = 34;
            this.showBlankButton.Text = "Project Blank";
            this.showBlankButton.UseVisualStyleBackColor = true;
            this.showBlankButton.Click += new System.EventHandler(this.showBlankButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(10, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 20);
            this.label2.TabIndex = 36;
            this.label2.Text = "Serial Port: ";
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.serialPort1_DataReceived);
            // 
            // homeXButton
            // 
            this.homeXButton.Location = new System.Drawing.Point(23, 205);
            this.homeXButton.Name = "homeXButton";
            this.homeXButton.Size = new System.Drawing.Size(95, 34);
            this.homeXButton.TabIndex = 37;
            this.homeXButton.Text = "Home X";
            this.homeXButton.UseVisualStyleBackColor = true;
            this.homeXButton.Click += new System.EventHandler(this.homeXButton_Click);
            // 
            // homeZButton
            // 
            this.homeZButton.Location = new System.Drawing.Point(241, 205);
            this.homeZButton.Name = "homeZButton";
            this.homeZButton.Size = new System.Drawing.Size(95, 34);
            this.homeZButton.TabIndex = 38;
            this.homeZButton.Text = "Home Z";
            this.homeZButton.UseVisualStyleBackColor = true;
            this.homeZButton.Click += new System.EventHandler(this.homeZButton_Click);
            // 
            // homeYButton
            // 
            this.homeYButton.Location = new System.Drawing.Point(132, 205);
            this.homeYButton.Name = "homeYButton";
            this.homeYButton.Size = new System.Drawing.Size(95, 34);
            this.homeYButton.TabIndex = 39;
            this.homeYButton.Text = "Home Y";
            this.homeYButton.UseVisualStyleBackColor = true;
            this.homeYButton.Click += new System.EventHandler(this.homeYButton_Click);
            // 
            // resetButton
            // 
            this.resetButton.Location = new System.Drawing.Point(241, 4);
            this.resetButton.Name = "resetButton";
            this.resetButton.Size = new System.Drawing.Size(128, 34);
            this.resetButton.TabIndex = 40;
            this.resetButton.Text = "Reset Printer";
            this.resetButton.UseVisualStyleBackColor = true;
            this.resetButton.Click += new System.EventHandler(this.resetButton_Click);
            // 
            // homeXYButton
            // 
            this.homeXYButton.Location = new System.Drawing.Point(79, 244);
            this.homeXYButton.Name = "homeXYButton";
            this.homeXYButton.Size = new System.Drawing.Size(91, 34);
            this.homeXYButton.TabIndex = 41;
            this.homeXYButton.Text = "Home XY";
            this.homeXYButton.UseVisualStyleBackColor = true;
            this.homeXYButton.Click += new System.EventHandler(this.homeXYButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(16, 57);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(102, 32);
            this.settingsButton.TabIndex = 42;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // baudBox
            // 
            this.baudBox.Location = new System.Drawing.Point(517, 7);
            this.baudBox.Name = "baudBox";
            this.baudBox.Size = new System.Drawing.Size(100, 26);
            this.baudBox.TabIndex = 43;
            this.baudBox.TextChanged += new System.EventHandler(this.baudBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(421, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(94, 20);
            this.label1.TabIndex = 44;
            this.label1.Text = "Baud Rate: ";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1258, 794);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.baudBox);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.homeXYButton);
            this.Controls.Add(this.resetButton);
            this.Controls.Add(this.homeYButton);
            this.Controls.Add(this.homeZButton);
            this.Controls.Add(this.homeXButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.showBlankButton);
            this.Controls.Add(this.showPreviewButton);
            this.Controls.Add(this.layerText);
            this.Controls.Add(this.staticLayerText);
            this.Controls.Add(this.PreviewBar);
            this.Controls.Add(this.previewTabs);
            this.Controls.Add(this.sendButton);
            this.Controls.Add(this.messageBox);
            this.Controls.Add(this.serialBox);
            this.Controls.Add(this.statusText);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.checkBox4);
            this.Controls.Add(this.checkBox3);
            this.Controls.Add(this.checkBox2);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.tabControl1);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "SLA Printer Application";
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.tabPage3.ResumeLayout(false);
            this.tabPage4.ResumeLayout(false);
            this.previewTabs.ResumeLayout(false);
            this.tabpreview1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPic1)).EndInit();
            this.tabpreview2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPic2)).EndInit();
            this.tabpreview3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPic3)).EndInit();
            this.tabpreview4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.previewPic4)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.TabPage tabPage4;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.CheckBox checkBox3;
        private System.Windows.Forms.CheckBox checkBox4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label statusText;
        private System.Windows.Forms.ListBox mat1list;
        private System.Windows.Forms.ListBox mat2list;
        private System.Windows.Forms.ListBox mat3list;
        private System.Windows.Forms.ListBox mat4list;
        private System.Windows.Forms.TextBox serialBox;
        private System.Windows.Forms.TextBox messageBox;
        private System.Windows.Forms.Button sendButton;
        private System.Windows.Forms.TabControl previewTabs;
        private System.Windows.Forms.TabPage tabpreview1;
        private System.Windows.Forms.TabPage tabpreview2;
        private System.Windows.Forms.VScrollBar PreviewBar;
        private System.Windows.Forms.TabPage tabpreview3;
        private System.Windows.Forms.TabPage tabpreview4;
        private System.Windows.Forms.PictureBox previewPic1;
        private System.Windows.Forms.PictureBox previewPic2;
        private System.Windows.Forms.PictureBox previewPic3;
        private System.Windows.Forms.PictureBox previewPic4;
        private System.Windows.Forms.Label staticLayerText;
        private System.Windows.Forms.Label layerText;
        private System.Windows.Forms.Button showPreviewButton;
        private System.Windows.Forms.Button showBlankButton;
        private System.Windows.Forms.Label label2;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button homeXButton;
        private System.Windows.Forms.Button homeZButton;
        private System.Windows.Forms.Button homeYButton;
        private System.Windows.Forms.Button resetButton;
        private System.Windows.Forms.Button homeXYButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.TextBox baudBox;
        private System.Windows.Forms.Label label1;
    }
}

