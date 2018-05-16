namespace Flashcards.WindowsUI.Forms.Decks
{
    partial class DeckEditForm
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
            this.label2 = new Flashcards.WindowsUI.Controls.FlashcardsLabel();
            this.label1 = new Flashcards.WindowsUI.Controls.FlashcardsLabel();
            this.btnSave = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.tbDescription = new Flashcards.WindowsUI.Controls.FlashcardsTextBox();
            this.tbName = new Flashcards.WindowsUI.Controls.FlashcardsTextBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Location = new System.Drawing.Point(12, 41);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Description";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Name";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Location = new System.Drawing.Point(285, 72);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbDescription
            // 
            this.tbDescription.Location = new System.Drawing.Point(152, 40);
            this.tbDescription.Name = "tbDescription";
            this.tbDescription.Size = new System.Drawing.Size(258, 26);
            this.tbDescription.TabIndex = 8;
            // 
            // tbName
            // 
            this.tbName.Location = new System.Drawing.Point(152, 11);
            this.tbName.Name = "tbName";
            this.tbName.Size = new System.Drawing.Size(258, 26);
            this.tbName.TabIndex = 7;
            // 
            // DeckAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 109);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbDescription);
            this.Controls.Add(this.tbName);
            this.Name = "DeckAddForm";
            this.Text = "Add deck";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FlashcardsLabel label2;
        private Controls.FlashcardsLabel label1;
        private Controls.FlashcardsButton btnSave;
        private Controls.FlashcardsTextBox tbDescription;
        private Controls.FlashcardsTextBox tbName;
    }
}