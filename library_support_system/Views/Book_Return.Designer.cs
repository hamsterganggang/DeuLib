namespace library_support_system.Views
{
    partial class Book_Return
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtWithDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.대여자 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.반납여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel_button = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.ddlSearch = new System.Windows.Forms.ComboBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.chkReturnList = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtWithDR,
            this.txtBth,
            this.txtGender,
            this.대여자,
            this.txtEmail,
            this.txtPicture,
            this.반납여부});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 114);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DividerHeight = 3;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1274, 482);
            this.dataGridView1.TabIndex = 22;
            // 
            // txtWithDR
            // 
            this.txtWithDR.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtWithDR.DataPropertyName = "Book_Title";
            this.txtWithDR.HeaderText = "제목";
            this.txtWithDR.MinimumWidth = 6;
            this.txtWithDR.Name = "txtWithDR";
            this.txtWithDR.ReadOnly = true;
            // 
            // txtBth
            // 
            this.txtBth.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtBth.DataPropertyName = "Book_Author";
            this.txtBth.HeaderText = "저자";
            this.txtBth.MinimumWidth = 6;
            this.txtBth.Name = "txtBth";
            this.txtBth.ReadOnly = true;
            // 
            // txtGender
            // 
            this.txtGender.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtGender.DataPropertyName = "Book_Pbl";
            this.txtGender.HeaderText = "출판사";
            this.txtGender.MinimumWidth = 6;
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            // 
            // 대여자
            // 
            this.대여자.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.대여자.DataPropertyName = "User_Name";
            this.대여자.HeaderText = "대여자";
            this.대여자.Name = "대여자";
            this.대여자.ReadOnly = true;
            // 
            // txtEmail
            // 
            this.txtEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtEmail.DataPropertyName = "Rental_Date";
            this.txtEmail.HeaderText = "대여일";
            this.txtEmail.MinimumWidth = 6;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            // 
            // txtPicture
            // 
            this.txtPicture.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtPicture.DataPropertyName = "Rental_Return_Date";
            this.txtPicture.HeaderText = "반납 예정일";
            this.txtPicture.MinimumWidth = 6;
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.ReadOnly = true;
            // 
            // 반납여부
            // 
            this.반납여부.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.반납여부.DataPropertyName = "Rental_Status";
            this.반납여부.HeaderText = "반납여부";
            this.반납여부.MinimumWidth = 10;
            this.반납여부.Name = "반납여부";
            this.반납여부.ReadOnly = true;
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.Color.White;
            this.cancel_button.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel_button.Location = new System.Drawing.Point(122, 82);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(103, 29);
            this.cancel_button.TabIndex = 24;
            this.cancel_button.Text = "삭제";
            this.cancel_button.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(12, 82);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 29);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "반납";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtSearch
            // 
            this.txtSearch.BackColor = System.Drawing.Color.White;
            this.txtSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtSearch.Location = new System.Drawing.Point(109, 14);
            this.txtSearch.Multiline = true;
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(290, 26);
            this.txtSearch.TabIndex = 25;
            // 
            // ddlSearch
            // 
            this.ddlSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ddlSearch.FormattingEnabled = true;
            this.ddlSearch.Items.AddRange(new object[] {
            "제목",
            "저자"});
            this.ddlSearch.Location = new System.Drawing.Point(12, 13);
            this.ddlSearch.Name = "ddlSearch";
            this.ddlSearch.Size = new System.Drawing.Size(102, 27);
            this.ddlSearch.TabIndex = 26;
            // 
            // btnSearch
            // 
            this.btnSearch.BackColor = System.Drawing.Color.White;
            this.btnSearch.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSearch.Location = new System.Drawing.Point(405, 14);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 29);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "조회";
            this.btnSearch.UseVisualStyleBackColor = false;
            // 
            // chkReturnList
            // 
            this.chkReturnList.AutoSize = true;
            this.chkReturnList.Location = new System.Drawing.Point(231, 85);
            this.chkReturnList.Name = "chkReturnList";
            this.chkReturnList.Size = new System.Drawing.Size(141, 24);
            this.chkReturnList.TabIndex = 28;
            this.chkReturnList.Text = "반납된 도서 조회";
            this.chkReturnList.UseVisualStyleBackColor = true;
            // 
            // Book_Return
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1274, 732);
            this.ControlBox = false;
            this.Controls.Add(this.chkReturnList);
            this.Controls.Add(this.btnSearch);
            this.Controls.Add(this.ddlSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Book_Return";
            this.Text = "book_return";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.ComboBox ddlSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWithDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn 대여자;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn 반납여부;
        private System.Windows.Forms.CheckBox chkReturnList;
    }
}