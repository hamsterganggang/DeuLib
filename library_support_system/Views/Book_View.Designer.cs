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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Book_Img = new System.Windows.Forms.DataGridViewImageColumn();
            this.txtBookTitle = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Pbl = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Link = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Book_Exp = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.search_option_combobox = new System.Windows.Forms.ComboBox();
            this.btnChange = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Book_Img,
            this.txtBookTitle,
            this.Book_ISBN,
            this.Book_Author,
            this.Book_Pbl,
            this.Book_Price,
            this.Book_Link,
            this.Book_Exp});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 114);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DividerHeight = 3;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1275, 346);
            this.dataGridView1.TabIndex = 0;
            // 
            // Book_Img
            // 
            this.Book_Img.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Img.DataPropertyName = "Book_Img";
            this.Book_Img.HeaderText = "사진";
            this.Book_Img.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Book_Img.MinimumWidth = 6;
            this.Book_Img.Name = "Book_Img";
            this.Book_Img.ReadOnly = true;
            this.Book_Img.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Book_Img.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // txtBookTitle
            // 
            this.txtBookTitle.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtBookTitle.DataPropertyName = "Book_Title";
            this.txtBookTitle.HeaderText = "도서 제목";
            this.txtBookTitle.MinimumWidth = 6;
            this.txtBookTitle.Name = "txtBookTitle";
            this.txtBookTitle.ReadOnly = true;
            // 
            // Book_ISBN
            // 
            this.Book_ISBN.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_ISBN.DataPropertyName = "Book_ISBN";
            this.Book_ISBN.HeaderText = "ISBN";
            this.Book_ISBN.MinimumWidth = 6;
            this.Book_ISBN.Name = "Book_ISBN";
            this.Book_ISBN.ReadOnly = true;
            // 
            // Book_Author
            // 
            this.Book_Author.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Author.DataPropertyName = "Book_Author";
            this.Book_Author.HeaderText = "저자";
            this.Book_Author.MinimumWidth = 6;
            this.Book_Author.Name = "Book_Author";
            this.Book_Author.ReadOnly = true;
            // 
            // Book_Pbl
            // 
            this.Book_Pbl.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Pbl.DataPropertyName = "Book_Pbl";
            this.Book_Pbl.HeaderText = "출판사";
            this.Book_Pbl.MinimumWidth = 6;
            this.Book_Pbl.Name = "Book_Pbl";
            this.Book_Pbl.ReadOnly = true;
            // 
            // Book_Price
            // 
            this.Book_Price.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Price.DataPropertyName = "Book_Price";
            this.Book_Price.HeaderText = "가격";
            this.Book_Price.MinimumWidth = 6;
            this.Book_Price.Name = "Book_Price";
            this.Book_Price.ReadOnly = true;
            // 
            // Book_Link
            // 
            this.Book_Link.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Link.DataPropertyName = "Book_Link";
            this.Book_Link.HeaderText = "관련 URL";
            this.Book_Link.MinimumWidth = 6;
            this.Book_Link.Name = "Book_Link";
            this.Book_Link.ReadOnly = true;
            // 
            // Book_Exp
            // 
            this.Book_Exp.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Exp.DataPropertyName = "Book_Exp";
            this.Book_Exp.HeaderText = "도서설명";
            this.Book_Exp.MinimumWidth = 6;
            this.Book_Exp.Name = "Book_Exp";
            this.Book_Exp.ReadOnly = true;
            // 
            // search_button
            // 
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Image = global::library_support_system.Properties.Resources.search_logo;
            this.search_button.Location = new System.Drawing.Point(720, 15);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(50, 31);
            this.search_button.TabIndex = 11;
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox.BackColor = System.Drawing.Color.White;
            this.search_textbox.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textbox.Location = new System.Drawing.Point(136, 12);
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(563, 32);
            this.search_textbox.TabIndex = 10;
            // 
            // search_option_combobox
            // 
            this.search_option_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_option_combobox.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_option_combobox.FormattingEnabled = true;
            this.search_option_combobox.Location = new System.Drawing.Point(12, 12);
            this.search_option_combobox.Name = "search_option_combobox";
            this.search_option_combobox.Size = new System.Drawing.Size(129, 27);
            this.search_option_combobox.TabIndex = 14;
            // 
            // btnChange
            // 
            this.btnChange.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnChange.Location = new System.Drawing.Point(12, 82);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(104, 29);
            this.btnChange.TabIndex = 12;
            this.btnChange.Text = "도서수정";
            this.btnChange.UseVisualStyleBackColor = true;
            // 
            // btnDel
            // 
            this.btnDel.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnDel.Location = new System.Drawing.Point(122, 82);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(103, 29);
            this.btnDel.TabIndex = 13;
            this.btnDel.Text = "도서삭제";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // Book_View
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 732);
            this.Controls.Add(this.search_option_combobox);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        private System.Windows.Forms.ComboBox search_option_combobox;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.DataGridViewImageColumn Book_Img;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBookTitle;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Author;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Pbl;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Link;
        private System.Windows.Forms.DataGridViewTextBoxColumn Book_Exp;
    }
}