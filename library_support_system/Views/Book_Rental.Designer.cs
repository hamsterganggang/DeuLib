namespace library_support_system.Views
{
    partial class Book_Rental
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.btnSearch = new System.Windows.Forms.Button();
            this.ddlSearch = new System.Windows.Forms.ComboBox();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.oracleDataAdapter1 = new Oracle.ManagedDataAccess.Client.OracleDataAdapter();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Book_Picture = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtRent = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnRentCheck = new System.Windows.Forms.DataGridViewButtonColumn();
            this.oracleCommandBuilder1 = new Oracle.ManagedDataAccess.Client.OracleCommandBuilder();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(405, 21);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(58, 28);
            this.btnSearch.TabIndex = 30;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // ddlSearch
            // 
            this.ddlSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ddlSearch.FormattingEnabled = true;
            this.ddlSearch.Location = new System.Drawing.Point(14, 21);
            this.ddlSearch.Name = "ddlSearch";
            this.ddlSearch.Size = new System.Drawing.Size(102, 26);
            this.ddlSearch.TabIndex = 29;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(114, 21);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(285, 26);
            this.txtSearch.TabIndex = 28;
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
            this.Book_Picture,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.txtRent,
            this.btnRentCheck});
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 114);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(0);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 82;
            this.dataGridView1.RowTemplate.DividerHeight = 3;
            this.dataGridView1.RowTemplate.Height = 40;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 493);
            this.dataGridView1.TabIndex = 46;
            // 
            // Book_Picture
            // 
            this.Book_Picture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Book_Picture.DataPropertyName = "Book_Img";
            this.Book_Picture.HeaderText = "도서 이미지";
            this.Book_Picture.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Book_Picture.MinimumWidth = 10;
            this.Book_Picture.Name = "Book_Picture";
            this.Book_Picture.ReadOnly = true;
            this.Book_Picture.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Book_Picture.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn9.DataPropertyName = "Book_Title";
            this.dataGridViewTextBoxColumn9.HeaderText = "책 제목";
            this.dataGridViewTextBoxColumn9.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn10.DataPropertyName = "Book_Author";
            this.dataGridViewTextBoxColumn10.HeaderText = "저자";
            this.dataGridViewTextBoxColumn10.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.dataGridViewTextBoxColumn11.DataPropertyName = "Book_Pbl";
            this.dataGridViewTextBoxColumn11.HeaderText = "출판사";
            this.dataGridViewTextBoxColumn11.MinimumWidth = 10;
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            // 
            // txtRent
            // 
            this.txtRent.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtRent.DataPropertyName = "Rental_Status_Text";
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            this.txtRent.DefaultCellStyle = dataGridViewCellStyle2;
            this.txtRent.HeaderText = "대여 여부";
            this.txtRent.MinimumWidth = 10;
            this.txtRent.Name = "txtRent";
            this.txtRent.ReadOnly = true;
            this.txtRent.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            // 
            // btnRentCheck
            // 
            this.btnRentCheck.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.btnRentCheck.DataPropertyName = "btnRentCheck";
            this.btnRentCheck.FillWeight = 50F;
            this.btnRentCheck.HeaderText = "대여조회";
            this.btnRentCheck.Name = "btnRentCheck";
            this.btnRentCheck.Text = "조회";
            this.btnRentCheck.UseColumnTextForButtonValue = true;
            // 
            // Book_Rental
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1274, 732);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlSearch);
            this.Controls.Add(this.txtSearch);
            this.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Book_Rental";
            this.Text = "book_rental";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.ComboBox ddlSearch;
        private System.Windows.Forms.TextBox txtSearch;
        private Oracle.ManagedDataAccess.Client.OracleDataAdapter oracleDataAdapter1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private Oracle.ManagedDataAccess.Client.OracleCommandBuilder oracleCommandBuilder1;
        private System.Windows.Forms.DataGridViewImageColumn Book_Picture;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtRent;
        private System.Windows.Forms.DataGridViewButtonColumn btnRentCheck;
    }
}