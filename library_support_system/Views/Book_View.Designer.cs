namespace library_support_system.Views
{
    partial class Book_View
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
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Pbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Img = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.Book_ISBN,
            this.Book_Author,
            this.Book_Pbl,
            this.Book_Price,
            this.Book_Link,
            this.Book_Img,
            this.Book_Exp});
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1120, 242);
            this.dataGridView1.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Image = global::library_support_system.Properties.Resources.search_logo;
            this.search_button.Location = new System.Drawing.Point(639, 53);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(44, 41);
            this.search_button.TabIndex = 11;
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.search_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_textbox.Location = new System.Drawing.Point(35, 53);
            this.search_textbox.Multiline = true;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(599, 41);
            this.search_textbox.TabIndex = 10;
            // 
            // select
            // 
            this.select.HeaderText = "선택";
            this.select.MinimumWidth = 6;
            this.select.Name = "select";
            this.select.Width = 125;
            // 
            // Book_ISBN
            // 
            this.Book_ISBN.DataPropertyName = "Book_ISBN";
            this.Book_ISBN.HeaderText = "ISBN";
            this.Book_ISBN.MinimumWidth = 6;
            this.Book_ISBN.Name = "Book_ISBN";
            this.Book_ISBN.Width = 125;
            // 
            // Book_Author
            // 
            this.Book_Author.DataPropertyName = "Book_Author";
            this.Book_Author.HeaderText = "저자";
            this.Book_Author.MinimumWidth = 6;
            this.Book_Author.Name = "Book_Author";
            this.Book_Author.Width = 125;
            // 
            // Book_Pbl
            // 
            this.Book_Pbl.DataPropertyName = "Book_Pbl";
            this.Book_Pbl.HeaderText = "출판사";
            this.Book_Pbl.MinimumWidth = 6;
            this.Book_Pbl.Name = "Book_Pbl";
            this.Book_Pbl.Width = 125;
            // 
            // Book_Price
            // 
            this.Book_Price.DataPropertyName = "Book_Price";
            this.Book_Price.HeaderText = "가격";
            this.Book_Price.MinimumWidth = 6;
            this.Book_Price.Name = "Book_Price";
            this.Book_Price.Width = 125;
            // 
            // Book_Link
            // 
            this.Book_Link.DataPropertyName = "Book_Link";
            this.Book_Link.HeaderText = "관련 URL";
            this.Book_Link.MinimumWidth = 6;
            this.Book_Link.Name = "Book_Link";
            this.Book_Link.Width = 125;
            // 
            // Book_Img
            // 
            this.Book_Img.DataPropertyName = "Book_Img";
            this.Book_Img.HeaderText = "사진";
            this.Book_Img.MinimumWidth = 6;
            this.Book_Img.Name = "Book_Img";
            this.Book_Img.Width = 125;
            // 
            // Book_Exp
            // 
            this.Book_Exp.DataPropertyName = "Book_Exp";
            this.Book_Exp.HeaderText = "도서설명";
            this.Book_Exp.MinimumWidth = 6;
            this.Book_Exp.Name = "Book_Exp";
            this.Book_Exp.Width = 125;
            // 
            // Book_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 576);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Book_View";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.DataGridViewTextBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Pbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Exp;
    }
}