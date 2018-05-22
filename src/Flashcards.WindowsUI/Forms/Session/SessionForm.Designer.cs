namespace Flashcards.WindowsUI.Forms.Session
{
    partial class SessionForm
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
            this.tbTitle = new Flashcards.WindowsUI.Controls.FlashcardsTextBox();
            this.tbQuestion = new System.Windows.Forms.RichTextBox();
            this.btnCategoriesAdd = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.tbAnswer = new System.Windows.Forms.RichTextBox();
            this.btnDoNotYet = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnAlreadyDone = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnNotSure = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.lblProgress = new Flashcards.WindowsUI.Controls.FlashcardsLabel();
            this.pbProgress = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // tbTitle
            // 
            this.tbTitle.Enabled = false;
            this.tbTitle.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbTitle.Location = new System.Drawing.Point(12, 46);
            this.tbTitle.Name = "tbTitle";
            this.tbTitle.ReadOnly = true;
            this.tbTitle.Size = new System.Drawing.Size(634, 27);
            this.tbTitle.TabIndex = 8;
            // 
            // tbQuestion
            // 
            this.tbQuestion.Enabled = false;
            this.tbQuestion.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbQuestion.Location = new System.Drawing.Point(12, 79);
            this.tbQuestion.Name = "tbQuestion";
            this.tbQuestion.ReadOnly = true;
            this.tbQuestion.Size = new System.Drawing.Size(634, 168);
            this.tbQuestion.TabIndex = 9;
            this.tbQuestion.Text = "";
            // 
            // btnCategoriesAdd
            // 
            this.btnCategoriesAdd.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCategoriesAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoriesAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesAdd.Location = new System.Drawing.Point(12, 253);
            this.btnCategoriesAdd.Name = "btnCategoriesAdd";
            this.btnCategoriesAdd.Size = new System.Drawing.Size(634, 30);
            this.btnCategoriesAdd.TabIndex = 10;
            this.btnCategoriesAdd.Text = "Show answer";
            this.btnCategoriesAdd.UseVisualStyleBackColor = false;
            // 
            // tbAnswer
            // 
            this.tbAnswer.Enabled = false;
            this.tbAnswer.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tbAnswer.Location = new System.Drawing.Point(12, 289);
            this.tbAnswer.Name = "tbAnswer";
            this.tbAnswer.ReadOnly = true;
            this.tbAnswer.Size = new System.Drawing.Size(634, 168);
            this.tbAnswer.TabIndex = 11;
            this.tbAnswer.Text = "";
            // 
            // btnDoNotYet
            // 
            this.btnDoNotYet.BackColor = System.Drawing.Color.Moccasin;
            this.btnDoNotYet.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDoNotYet.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDoNotYet.Location = new System.Drawing.Point(12, 463);
            this.btnDoNotYet.Name = "btnDoNotYet";
            this.btnDoNotYet.Size = new System.Drawing.Size(208, 30);
            this.btnDoNotYet.TabIndex = 12;
            this.btnDoNotYet.Text = "I can\'t do it yet";
            this.btnDoNotYet.UseVisualStyleBackColor = false;
            this.btnDoNotYet.Click += new System.EventHandler(this.btnDoNotYet_Click);
            // 
            // btnAlreadyDone
            // 
            this.btnAlreadyDone.BackColor = System.Drawing.Color.SpringGreen;
            this.btnAlreadyDone.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnAlreadyDone.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlreadyDone.Location = new System.Drawing.Point(440, 463);
            this.btnAlreadyDone.Name = "btnAlreadyDone";
            this.btnAlreadyDone.Size = new System.Drawing.Size(206, 30);
            this.btnAlreadyDone.TabIndex = 13;
            this.btnAlreadyDone.Text = "I can do it already";
            this.btnAlreadyDone.UseVisualStyleBackColor = false;
            this.btnAlreadyDone.Click += new System.EventHandler(this.btnAlreadyDone_Click);
            // 
            // btnNotSure
            // 
            this.btnNotSure.BackColor = System.Drawing.Color.SandyBrown;
            this.btnNotSure.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnNotSure.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotSure.Location = new System.Drawing.Point(226, 463);
            this.btnNotSure.Name = "btnNotSure";
            this.btnNotSure.Size = new System.Drawing.Size(208, 30);
            this.btnNotSure.TabIndex = 14;
            this.btnNotSure.Text = "I\'m not sure";
            this.btnNotSure.UseVisualStyleBackColor = false;
            this.btnNotSure.Click += new System.EventHandler(this.btnNotSure_Click);
            // 
            // lblProgress
            // 
            this.lblProgress.BackColor = System.Drawing.Color.Moccasin;
            this.lblProgress.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblProgress.ForeColor = System.Drawing.SystemColors.ControlText;
            this.lblProgress.Location = new System.Drawing.Point(512, 12);
            this.lblProgress.Margin = new System.Windows.Forms.Padding(3);
            this.lblProgress.Name = "lblProgress";
            this.lblProgress.Size = new System.Drawing.Size(134, 23);
            this.lblProgress.TabIndex = 15;
            this.lblProgress.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pbProgress
            // 
            this.pbProgress.Location = new System.Drawing.Point(12, 12);
            this.pbProgress.Name = "pbProgress";
            this.pbProgress.Size = new System.Drawing.Size(494, 23);
            this.pbProgress.TabIndex = 16;
            // 
            // SessionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(658, 506);
            this.Controls.Add(this.pbProgress);
            this.Controls.Add(this.lblProgress);
            this.Controls.Add(this.btnNotSure);
            this.Controls.Add(this.btnAlreadyDone);
            this.Controls.Add(this.btnDoNotYet);
            this.Controls.Add(this.tbAnswer);
            this.Controls.Add(this.btnCategoriesAdd);
            this.Controls.Add(this.tbQuestion);
            this.Controls.Add(this.tbTitle);
            this.Name = "SessionForm";
            this.Text = "SessionForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Controls.FlashcardsTextBox tbTitle;
        private System.Windows.Forms.RichTextBox tbQuestion;
        private Controls.FlashcardsButton btnCategoriesAdd;
        private System.Windows.Forms.RichTextBox tbAnswer;
        private Controls.FlashcardsButton btnDoNotYet;
        private Controls.FlashcardsButton btnAlreadyDone;
        private Controls.FlashcardsButton btnNotSure;
        private Controls.FlashcardsLabel lblProgress;
        private System.Windows.Forms.ProgressBar pbProgress;
    }
}