namespace Flashcards.WindowsUI.Forms.Dashboard
{
    partial class DashboardForm
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
            this.btnIt = new System.Windows.Forms.Button();
            this.btnEnPl = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 48F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(776, 86);
            this.label1.TabIndex = 0;
            this.label1.Text = "Flashcards";
            this.label1.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // btnIt
            // 
            this.btnIt.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnIt.Location = new System.Drawing.Point(12, 98);
            this.btnIt.Name = "btnIt";
            this.btnIt.Size = new System.Drawing.Size(776, 66);
            this.btnIt.TabIndex = 2;
            this.btnIt.Text = "IT";
            this.btnIt.UseVisualStyleBackColor = true;
            // 
            // btnEnPl
            // 
            this.btnEnPl.Font = new System.Drawing.Font("Calibri", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEnPl.Location = new System.Drawing.Point(12, 170);
            this.btnEnPl.Name = "btnEnPl";
            this.btnEnPl.Size = new System.Drawing.Size(776, 66);
            this.btnEnPl.TabIndex = 3;
            this.btnEnPl.Text = "English-Polish";
            this.btnEnPl.UseVisualStyleBackColor = true;
            // 
            // DashboardForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 246);
            this.Controls.Add(this.btnEnPl);
            this.Controls.Add(this.btnIt);
            this.Controls.Add(this.label1);
            this.Name = "DashboardForm";
            this.Text = "DashboardForm";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnIt;
        private System.Windows.Forms.Button btnEnPl;
    }
}