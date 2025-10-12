namespace library_support_system
{
    partial class book_check
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
            this.select = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ISBN = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.author = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.publisher = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.URL = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.explain = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.select,
            this.ISBN,
            this.author,
            this.publisher,
            this.price,
            this.URL,
            this.picture,
            this.explain});
            this.dataGridView1.Location = new System.Drawing.Point(0, 145);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1120, 242);
            this.dataGridView1.TabIndex = 0;
            // 
            // select
            // 
            this.select.HeaderText = "선택";
            this.select.MinimumWidth = 6;
            this.select.Name = "select";
            this.select.Width = 125;
            // 
            // ISBN
            // 
            this.ISBN.HeaderText = "ISBN";
            this.ISBN.MinimumWidth = 6;
            this.ISBN.Name = "ISBN";
            this.ISBN.Width = 125;
            // 
            // author
            // 
            this.author.HeaderText = "저자";
            this.author.MinimumWidth = 6;
            this.author.Name = "author";
            this.author.Width = 125;
            // 
            // publisher
            // 
            this.publisher.HeaderText = "출판사";
            this.publisher.MinimumWidth = 6;
            this.publisher.Name = "publisher";
            this.publisher.Width = 125;
            // 
            // price
            // 
            this.price.HeaderText = "가격";
            this.price.MinimumWidth = 6;
            this.price.Name = "price";
            this.price.Width = 125;
            // 
            // URL
            // 
            this.URL.HeaderText = "관련URL";
            this.URL.MinimumWidth = 6;
            this.URL.Name = "URL";
            this.URL.Width = 125;
            // 
            // picture
            // 
            this.picture.HeaderText = "사진";
            this.picture.MinimumWidth = 6;
            this.picture.Name = "picture";
            this.picture.Width = 125;
            // 
            // explain
            // 
            this.explain.HeaderText = "도서설명";
            this.explain.MinimumWidth = 6;
            this.explain.Name = "explain";
            this.explain.Width = 125;
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
            // book_check
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(1120, 576);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "book_check";
            this.Load += new System.EventHandler(this.book_check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn select;
        private System.Windows.Forms.DataGridViewTextBoxColumn ISBN;
        private System.Windows.Forms.DataGridViewTextBoxColumn author;
        private System.Windows.Forms.DataGridViewTextBoxColumn publisher;
        private System.Windows.Forms.DataGridViewTextBoxColumn price;
        private System.Windows.Forms.DataGridViewTextBoxColumn URL;
        private System.Windows.Forms.DataGridViewTextBoxColumn picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn explain;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
    }
}