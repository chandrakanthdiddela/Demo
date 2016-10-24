namespace Xmlsample
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
            this.CreateXML = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // CreateXML
            // 
            this.CreateXML.Location = new System.Drawing.Point(74, 62);
            this.CreateXML.Name = "CreateXML";
            this.CreateXML.Size = new System.Drawing.Size(75, 23);
            this.CreateXML.TabIndex = 0;
            this.CreateXML.Text = "CreateXML";
            this.CreateXML.UseVisualStyleBackColor = true;
            this.CreateXML.Click += new System.EventHandler(this.button1_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.Controls.Add(this.CreateXML);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button CreateXML;
    }
}

