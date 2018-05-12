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
            this.lbCategories = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCategoriesAdd = new System.Windows.Forms.Button();
            this.btnCategoriesEdit = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.lbDecks = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.lbCards = new System.Windows.Forms.ListBox();
            this.btnCategoriesDelete = new System.Windows.Forms.Button();
            this.btnDecksDelete = new System.Windows.Forms.Button();
            this.btnDecksEdit = new System.Windows.Forms.Button();
            this.btnDecksAdd = new System.Windows.Forms.Button();
            this.btnCardsDelete = new System.Windows.Forms.Button();
            this.btnCardsEdit = new System.Windows.Forms.Button();
            this.btnCardsAdd = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lbCategories
            // 
            this.lbCategories.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbCategories.FormattingEnabled = true;
            this.lbCategories.ItemHeight = 19;
            this.lbCategories.Location = new System.Drawing.Point(20, 35);
            this.lbCategories.Name = "lbCategories";
            this.lbCategories.Size = new System.Drawing.Size(256, 441);
            this.lbCategories.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(16, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(256, 23);
            this.label1.TabIndex = 1;
            this.label1.Text = "Categories";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnCategoriesAdd
            // 
            this.btnCategoriesAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesAdd.Location = new System.Drawing.Point(20, 487);
            this.btnCategoriesAdd.Name = "btnCategoriesAdd";
            this.btnCategoriesAdd.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesAdd.TabIndex = 5;
            this.btnCategoriesAdd.Text = "Add";
            this.btnCategoriesAdd.UseVisualStyleBackColor = true;
            // 
            // btnCategoriesEdit
            // 
            this.btnCategoriesEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesEdit.Location = new System.Drawing.Point(151, 487);
            this.btnCategoriesEdit.Name = "btnCategoriesEdit";
            this.btnCategoriesEdit.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesEdit.TabIndex = 6;
            this.btnCategoriesEdit.Text = "Edit";
            this.btnCategoriesEdit.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(278, 9);
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
            this.lbDecks.Location = new System.Drawing.Point(282, 35);
            this.lbDecks.Name = "lbDecks";
            this.lbDecks.Size = new System.Drawing.Size(256, 441);
            this.lbDecks.TabIndex = 7;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(540, 9);
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
            this.lbCards.Location = new System.Drawing.Point(544, 35);
            this.lbCards.Name = "lbCards";
            this.lbCards.Size = new System.Drawing.Size(256, 441);
            this.lbCards.TabIndex = 11;
            // 
            // btnCategoriesDelete
            // 
            this.btnCategoriesDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCategoriesDelete.Location = new System.Drawing.Point(20, 523);
            this.btnCategoriesDelete.Name = "btnCategoriesDelete";
            this.btnCategoriesDelete.Size = new System.Drawing.Size(125, 30);
            this.btnCategoriesDelete.TabIndex = 13;
            this.btnCategoriesDelete.Text = "Delete";
            this.btnCategoriesDelete.UseVisualStyleBackColor = true;
            // 
            // btnDecksDelete
            // 
            this.btnDecksDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksDelete.Location = new System.Drawing.Point(282, 523);
            this.btnDecksDelete.Name = "btnDecksDelete";
            this.btnDecksDelete.Size = new System.Drawing.Size(125, 30);
            this.btnDecksDelete.TabIndex = 16;
            this.btnDecksDelete.Text = "Delete";
            this.btnDecksDelete.UseVisualStyleBackColor = true;
            // 
            // btnDecksEdit
            // 
            this.btnDecksEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksEdit.Location = new System.Drawing.Point(413, 487);
            this.btnDecksEdit.Name = "btnDecksEdit";
            this.btnDecksEdit.Size = new System.Drawing.Size(125, 30);
            this.btnDecksEdit.TabIndex = 15;
            this.btnDecksEdit.Text = "Edit";
            this.btnDecksEdit.UseVisualStyleBackColor = true;
            // 
            // btnDecksAdd
            // 
            this.btnDecksAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDecksAdd.Location = new System.Drawing.Point(282, 487);
            this.btnDecksAdd.Name = "btnDecksAdd";
            this.btnDecksAdd.Size = new System.Drawing.Size(125, 30);
            this.btnDecksAdd.TabIndex = 14;
            this.btnDecksAdd.Text = "Add";
            this.btnDecksAdd.UseVisualStyleBackColor = true;
            // 
            // btnCardsDelete
            // 
            this.btnCardsDelete.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsDelete.Location = new System.Drawing.Point(544, 523);
            this.btnCardsDelete.Name = "btnCardsDelete";
            this.btnCardsDelete.Size = new System.Drawing.Size(125, 30);
            this.btnCardsDelete.TabIndex = 19;
            this.btnCardsDelete.Text = "Delete";
            this.btnCardsDelete.UseVisualStyleBackColor = true;
            // 
            // btnCardsEdit
            // 
            this.btnCardsEdit.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsEdit.Location = new System.Drawing.Point(675, 487);
            this.btnCardsEdit.Name = "btnCardsEdit";
            this.btnCardsEdit.Size = new System.Drawing.Size(125, 30);
            this.btnCardsEdit.TabIndex = 18;
            this.btnCardsEdit.Text = "Edit";
            this.btnCardsEdit.UseVisualStyleBackColor = true;
            // 
            // btnCardsAdd
            // 
            this.btnCardsAdd.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCardsAdd.Location = new System.Drawing.Point(544, 487);
            this.btnCardsAdd.Name = "btnCardsAdd";
            this.btnCardsAdd.Size = new System.Drawing.Size(125, 30);
            this.btnCardsAdd.TabIndex = 17;
            this.btnCardsAdd.Text = "Add";
            this.btnCardsAdd.UseVisualStyleBackColor = true;
            // 
            // ResourcesExplorerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(822, 561);
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

        private System.Windows.Forms.ListBox lbCategories;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCategoriesAdd;
        private System.Windows.Forms.Button btnCategoriesEdit;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox lbDecks;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ListBox lbCards;
        private System.Windows.Forms.Button btnCategoriesDelete;
        private System.Windows.Forms.Button btnDecksDelete;
        private System.Windows.Forms.Button btnDecksEdit;
        private System.Windows.Forms.Button btnDecksAdd;
        private System.Windows.Forms.Button btnCardsDelete;
        private System.Windows.Forms.Button btnCardsEdit;
        private System.Windows.Forms.Button btnCardsAdd;
    }
}