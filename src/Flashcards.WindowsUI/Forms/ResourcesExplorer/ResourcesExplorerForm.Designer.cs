using Flashcards.WindowsUI.Controls;

namespace Flashcards.WindowsUI.Forms.ResourcesExplorer
{
    partial class ResourcesExplorerForm
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
            this.lbCategories = new Flashcards.WindowsUI.Controls.FlashcardsListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategoriesAdd = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnCategoriesEdit = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDecks = new Flashcards.WindowsUI.Controls.FlashcardsListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCards = new Flashcards.WindowsUI.Controls.FlashcardsListBox();
            this.btnCategoriesDelete = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnDecksDelete = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnDecksEdit = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnDecksAdd = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnCardsDelete = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnCardsEdit = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.btnCardsAdd = new Flashcards.WindowsUI.Controls.FlashcardsButton();
            this.SuspendLayout();
            // 
            // lbCategories
            // 
            this.lbCategories.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.ItemHeight = 19;
            this.lbCategories.Location = new System.Drawing.Point(12, 37);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(256, 441);
            this.lbCategories.TabIndex = 0;
            this.lbCategories.SelectedIndexChanged += new System.EventHandler(this.LbCategories_SelectedIndexChanged);
            this.lbCategories.DoubleClick += new System.EventHandler(this.BtnCategoriesEdit_Click);
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Moccasin;
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label1.Location = new System.Drawing.Point(12, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCategoriesAdd
            // 
            this.btnCategoriesAdd.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCategoriesAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoriesAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesAdd.Location = new System.Drawing.Point(12, 489);
            this.btnCategoriesAdd.Name = "btnCategoriesAdd";
            this.btnCategoriesAdd.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesAdd.TabIndex = 5;
            this.btnCategoriesAdd.Text = "Add";
            this.btnCategoriesAdd.UseVisualStyleBackColor = false;
            this.btnCategoriesAdd.Click += new System.EventHandler(this.BtnCategoriesAdd_Click);
            // 
            // btnCategoriesEdit
            // 
            this.btnCategoriesEdit.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCategoriesEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoriesEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesEdit.Location = new System.Drawing.Point(143, 489);
            this.btnCategoriesEdit.Name = "btnCategoriesEdit";
            this.btnCategoriesEdit.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesEdit.TabIndex = 6;
            this.btnCategoriesEdit.Text = "Edit";
            this.btnCategoriesEdit.UseVisualStyleBackColor = false;
            this.btnCategoriesEdit.Click += new System.EventHandler(this.BtnCategoriesEdit_Click);
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.Color.Moccasin;
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(274, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(256, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "Decks";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbDecks
            // 
            this.lbDecks.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDecks.FormattingEnabled = true;
            this.lbDecks.ItemHeight = 19;
            this.lbDecks.Location = new System.Drawing.Point(274, 37);
            this.lbDecks.Name = "lbDecks";
            this.lbDecks.Size = new System.Drawing.Size(256, 441);
            this.lbDecks.TabIndex = 7;
            this.lbDecks.SelectedIndexChanged += new System.EventHandler(this.LbDecks_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.Color.Moccasin;
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(536, 11);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(256, 23);
            this.label3.TabIndex = 12;
            this.label3.Text = "Cards";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbCards
            // 
            this.lbCards.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCards.FormattingEnabled = true;
            this.lbCards.ItemHeight = 19;
            this.lbCards.Location = new System.Drawing.Point(536, 37);
            this.lbCards.Name = "lbCards";
            this.lbCards.Size = new System.Drawing.Size(256, 441);
            this.lbCards.TabIndex = 11;
            // 
            // btnCategoriesDelete
            // 
            this.btnCategoriesDelete.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCategoriesDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCategoriesDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesDelete.Location = new System.Drawing.Point(12, 525);
            this.btnCategoriesDelete.Name = "btnCategoriesDelete";
            this.btnCategoriesDelete.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesDelete.TabIndex = 13;
            this.btnCategoriesDelete.Text = "Delete";
            this.btnCategoriesDelete.UseVisualStyleBackColor = false;
            this.btnCategoriesDelete.Click += new System.EventHandler(this.BtnCategoriesDelete_Click);
            // 
            // btnDecksDelete
            // 
            this.btnDecksDelete.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDecksDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecksDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksDelete.Location = new System.Drawing.Point(274, 525);
            this.btnDecksDelete.Name = "btnDecksDelete";
            this.btnDecksDelete.Size = new System.Drawing.Size(125, 30);
            this.btnDecksDelete.TabIndex = 16;
            this.btnDecksDelete.Text = "Delete";
            this.btnDecksDelete.UseVisualStyleBackColor = false;
            this.btnDecksDelete.Click += new System.EventHandler(this.BtnDecksDelete_Click);
            // 
            // btnDecksEdit
            // 
            this.btnDecksEdit.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDecksEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecksEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksEdit.Location = new System.Drawing.Point(405, 489);
            this.btnDecksEdit.Name = "btnDecksEdit";
            this.btnDecksEdit.Size = new System.Drawing.Size(125, 30);
            this.btnDecksEdit.TabIndex = 15;
            this.btnDecksEdit.Text = "Edit";
            this.btnDecksEdit.UseVisualStyleBackColor = false;
            this.btnDecksEdit.Click += new System.EventHandler(this.BtnDecksEdit_Click);
            // 
            // btnDecksAdd
            // 
            this.btnDecksAdd.BackColor = System.Drawing.Color.SandyBrown;
            this.btnDecksAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnDecksAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksAdd.Location = new System.Drawing.Point(274, 489);
            this.btnDecksAdd.Name = "btnDecksAdd";
            this.btnDecksAdd.Size = new System.Drawing.Size(125, 30);
            this.btnDecksAdd.TabIndex = 14;
            this.btnDecksAdd.Text = "Add";
            this.btnDecksAdd.UseVisualStyleBackColor = false;
            this.btnDecksAdd.Click += new System.EventHandler(this.BtnDecksAdd_Click);
            // 
            // btnCardsDelete
            // 
            this.btnCardsDelete.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCardsDelete.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCardsDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsDelete.Location = new System.Drawing.Point(536, 525);
            this.btnCardsDelete.Name = "btnCardsDelete";
            this.btnCardsDelete.Size = new System.Drawing.Size(125, 30);
            this.btnCardsDelete.TabIndex = 19;
            this.btnCardsDelete.Text = "Delete";
            this.btnCardsDelete.UseVisualStyleBackColor = false;
            // 
            // btnCardsEdit
            // 
            this.btnCardsEdit.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCardsEdit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCardsEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsEdit.Location = new System.Drawing.Point(667, 489);
            this.btnCardsEdit.Name = "btnCardsEdit";
            this.btnCardsEdit.Size = new System.Drawing.Size(125, 30);
            this.btnCardsEdit.TabIndex = 18;
            this.btnCardsEdit.Text = "Edit";
            this.btnCardsEdit.UseVisualStyleBackColor = false;
            // 
            // btnCardsAdd
            // 
            this.btnCardsAdd.BackColor = System.Drawing.Color.SandyBrown;
            this.btnCardsAdd.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnCardsAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsAdd.Location = new System.Drawing.Point(536, 489);
            this.btnCardsAdd.Name = "btnCardsAdd";
            this.btnCardsAdd.Size = new System.Drawing.Size(125, 30);
            this.btnCardsAdd.TabIndex = 17;
            this.btnCardsAdd.Text = "Add";
            this.btnCardsAdd.UseVisualStyleBackColor = false;
            // 
            // ResourcesExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(804, 561);
            this.Controls.Add(this.btnCardsDelete);
            this.Controls.Add(this.btnCardsEdit);
            this.Controls.Add(this.btnCardsAdd);
            this.Controls.Add(this.btnDecksDelete);
            this.Controls.Add(this.btnDecksEdit);
            this.Controls.Add(this.btnDecksAdd);
            this.Controls.Add(this.btnCategoriesDelete);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbCards);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbDecks);
            this.Controls.Add(this.btnCategoriesEdit);
            this.Controls.Add(this.btnCategoriesAdd);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbCategories);
            this.Name = "ResourcesExplorerForm";
            this.Text = "ResourcesExplorerForm";
            this.ResumeLayout(false);

        }

        #endregion

        private FlashcardsListBox lbCategories;
        private System.Windows.Forms.Label label1;
        private FlashcardsButton btnCategoriesAdd;
        private FlashcardsButton btnCategoriesEdit;
        private System.Windows.Forms.Label label2;
        private FlashcardsListBox lbDecks;
        private System.Windows.Forms.Label label3;
        private FlashcardsListBox lbCards;
        private FlashcardsButton btnCategoriesDelete;
        private FlashcardsButton btnDecksDelete;
        private FlashcardsButton btnDecksEdit;
        private FlashcardsButton btnDecksAdd;
        private FlashcardsButton btnCardsDelete;
        private FlashcardsButton btnCardsEdit;
        private FlashcardsButton btnCardsAdd;
    }
}
