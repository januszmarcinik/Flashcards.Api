namespace Flashcards.WindowsUI.Forms.Cards
{
    partial class CardAddForm
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
            this.tbTitle = new Flashcards.WindowsUI.Controls.FlashcardsTextBox();
            this.tbQuestion = new System.Windows.Forms.RichTextBox();
            this.tbAnswer = new System.Windows.Forms.RichTextBox();
            this.flashcardsLabel1 = new Flashcards.WindowsUI.Controls.FlashcardsLabel();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Moccasin;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 50);
            this.label2.Margin = new System.Windows.Forms.Padding(3);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(134, 23);
            this.label2.TabIndex = 11;
            this.label2.Text = "Question";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Moccasin;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 23);
            this.label1.TabIndex = 10;
            this.label1.Text = "Title";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.SandyBrown;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnSave.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.Location = new System.Drawing.Point(280, 443);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(125, 30);
            this.btnSave.TabIndex = 9;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.BtnSave_Click);
            // 
            // tbTitle
            // 
            this.tbTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(152, 11);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.Size = new System.Drawing.Size(253, 27);
            this.tbTitle.TabIndex = 7;
            // 
            // tbQuestion
            // 
            this.tbQuestion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuestion.Location = new System.Drawing.Point(12, 79);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.Size = new System.Drawing.Size(393, 152);
            this.tbQuestion.TabIndex = 8;
            this.tbQuestion.Text = "";
            // 
            // tbAnswer
            // 
            this.tbAnswer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAnswer.Location = new System.Drawing.Point(12, 275);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.Size = new System.Drawing.Size(393, 152);
            this.tbAnswer.TabIndex = 9;
            this.tbAnswer.Text = "";
            // 
            // flashcardsLabel1
            // 
            this.flashcardsLabel1.BackColor = System.Drawing.Color.Moccasin;
            this.flashcardsLabel1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.flashcardsLabel1.Location = new System.Drawing.Point(12, 246);
            this.flashcardsLabel1.Margin = new System.Windows.Forms.Padding(3);
            this.flashcardsLabel1.Name = "flashcardsLabel1";
            this.flashcardsLabel1.Size = new System.Drawing.Size(134, 23);
            this.flashcardsLabel1.TabIndex = 13;
            this.flashcardsLabel1.Text = "Answer";
            this.flashcardsLabel1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CardAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 482);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.flashcardsLabel1);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.tbTitle);
            this.Name = "CardAddForm";
            this.Text = "Add card";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FlashcardsLabel label2;
        private Controls.FlashcardsLabel label1;
        private Controls.FlashcardsButton btnSave;
        private Controls.FlashcardsTextBox tbTitle;
        private System.Windows.Forms.RichTextBox tbQuestion;
        private System.Windows.Forms.RichTextBox tbAnswer;
        private Controls.FlashcardsLabel flashcardsLabel1;
    }
}