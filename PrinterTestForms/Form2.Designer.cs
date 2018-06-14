namespace PrinterTestForms
{
    partial class black_png_form
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.generate_button = new System.Windows.Forms.Button();
            this.startingimgNUD = new System.Windows.Forms.NumericUpDown();
            this.numberofimgNUD = new System.Windows.Forms.NumericUpDown();
            this.label3 = new System.Windows.Forms.Label();
            this.imagePrefixBox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.startingimgNUD)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofimgNUD)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Starting image number";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(21, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(145, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last image number";
            // 
            // generate_button
            // 
            this.generate_button.Location = new System.Drawing.Point(196, 153);
            this.generate_button.Name = "generate_button";
            this.generate_button.Size = new System.Drawing.Size(106, 46);
            this.generate_button.TabIndex = 2;
            this.generate_button.Text = "Generate";
            this.generate_button.UseVisualStyleBackColor = true;
            this.generate_button.Click += new System.EventHandler(this.generate_button_Click);
            // 
            // startingimgNUD
            // 
            this.startingimgNUD.Location = new System.Drawing.Point(222, 18);
            this.startingimgNUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.startingimgNUD.Name = "startingimgNUD";
            this.startingimgNUD.Size = new System.Drawing.Size(89, 26);
            this.startingimgNUD.TabIndex = 3;
            // 
            // numberofimgNUD
            // 
            this.numberofimgNUD.Location = new System.Drawing.Point(222, 50);
            this.numberofimgNUD.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.numberofimgNUD.Name = "numberofimgNUD";
            this.numberofimgNUD.Size = new System.Drawing.Size(89, 26);
            this.numberofimgNUD.TabIndex = 4;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(21, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(140, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Image name prefix";
            // 
            // imagePrefixBox
            // 
            this.imagePrefixBox.Location = new System.Drawing.Point(222, 80);
            this.imagePrefixBox.Name = "imagePrefixBox";
            this.imagePrefixBox.Size = new System.Drawing.Size(268, 26);
            this.imagePrefixBox.TabIndex = 6;
            // 
            // black_png_form
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 211);
            this.Controls.Add(this.imagePrefixBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.numberofimgNUD);
            this.Controls.Add(this.startingimgNUD);
            this.Controls.Add(this.generate_button);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "black_png_form";
            this.Text = "Image Generator";
            ((System.ComponentModel.ISupportInitialize)(this.startingimgNUD)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numberofimgNUD)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button generate_button;
        private System.Windows.Forms.NumericUpDown startingimgNUD;
        private System.Windows.Forms.NumericUpDown numberofimgNUD;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox imagePrefixBox;
    }
}