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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtWithDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPhonenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.반납여부 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel_button = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.txtBthDate = new System.Windows.Forms.TextBox();
            this.cmbGen = new System.Windows.Forms.ComboBox();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.txtWithDR,
            this.name,
            this.txtBth,
            this.txtGender,
            this.txtPhonenum,
            this.txtEmail,
            this.txtPicture,
            this.반납여부,
            this.Column1});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Noto Sans KR", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle5;
            this.dataGridView1.GridColor = System.Drawing.Color.White;
            this.dataGridView1.Location = new System.Drawing.Point(0, 98);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle6;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.DividerHeight = 3;
            this.dataGridView1.RowTemplate.Height = 30;
            this.dataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridView1.Size = new System.Drawing.Size(1116, 406);
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
            // name
            // 
            this.name.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.name.DataPropertyName = "Book_Explain";
            this.name.HeaderText = "상세정보";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
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
            // txtPhonenum
            // 
            this.txtPhonenum.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.txtPhonenum.DataPropertyName = "User";
            this.txtPhonenum.HeaderText = "회원정보";
            this.txtPhonenum.MinimumWidth = 6;
            this.txtPhonenum.Name = "txtPhonenum";
            this.txtPhonenum.ReadOnly = true;
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
            this.반납여부.DataPropertyName = "Return";
            this.반납여부.HeaderText = "반납여부";
            this.반납여부.MinimumWidth = 10;
            this.반납여부.Name = "반납여부";
            this.반납여부.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Column1.DataPropertyName = "management";
            this.Column1.HeaderText = "관리";
            this.Column1.MinimumWidth = 10;
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.Color.White;
            this.cancel_button.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel_button.Location = new System.Drawing.Point(118, 63);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(100, 30);
            this.cancel_button.TabIndex = 24;
            this.cancel_button.Text = "삭제";
            this.cancel_button.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.White;
            this.btnSave.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(12, 63);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "반납";
            this.btnSave.UseVisualStyleBackColor = false;
            // 
            // txtBthDate
            // 
            this.txtBthDate.BackColor = System.Drawing.Color.White;
            this.txtBthDate.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtBthDate.Location = new System.Drawing.Point(109, 14);
            this.txtBthDate.Multiline = true;
            this.txtBthDate.Name = "txtBthDate";
            this.txtBthDate.Size = new System.Drawing.Size(290, 28);
            this.txtBthDate.TabIndex = 25;
            // 
            // cmbGen
            // 
            this.cmbGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGen.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbGen.FormattingEnabled = true;
            this.cmbGen.Items.AddRange(new object[] {
            "제목",
            "저자"});
            this.cmbGen.Location = new System.Drawing.Point(12, 13);
            this.cmbGen.Name = "cmbGen";
            this.cmbGen.Size = new System.Drawing.Size(102, 29);
            this.cmbGen.TabIndex = 26;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.White;
            this.button1.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(405, 14);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 29);
            this.button1.TabIndex = 27;
            this.button1.Text = "조회";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // Book_Return
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1115, 627);
            this.ControlBox = false;
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cmbGen);
            this.Controls.Add(this.txtBthDate);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Font = new System.Drawing.Font("Noto Sans KR", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
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
        private System.Windows.Forms.TextBox txtBthDate;
        private System.Windows.Forms.ComboBox cmbGen;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWithDR;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPhonenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn 반납여부;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
    }
}