namespace library_support_system
{
    partial class User_View
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
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.ddlSearch = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtBth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtGender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPhonenum = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtPicture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.txtWithDR = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnChange = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnDel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.search_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_textbox.Location = new System.Drawing.Point(139, 13);
            this.search_textbox.Multiline = true;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(270, 28);
            this.search_textbox.TabIndex = 9;
            // 
            // ddlSearch
            // 
            this.ddlSearch.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.ddlSearch.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.ddlSearch.FormattingEnabled = true;
            this.ddlSearch.Items.AddRange(new object[] {
            "전체",
            "이름",
            "전화번호"});
            this.ddlSearch.Location = new System.Drawing.Point(12, 12);
            this.ddlSearch.Name = "ddlSearch";
            this.ddlSearch.Size = new System.Drawing.Size(121, 29);
            this.ddlSearch.TabIndex = 19;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(1087, 28);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(15, 14);
            this.checkBox1.TabIndex = 20;
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.name,
            this.txtBth,
            this.txtGender,
            this.txtPhonenum,
            this.txtEmail,
            this.txtPicture,
            this.txtWithDR});
            this.dataGridView1.Location = new System.Drawing.Point(0, 72);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1045, 184);
            this.dataGridView1.TabIndex = 21;
            // 
            // name
            // 
            this.name.DataPropertyName = "User_Name";
            this.name.HeaderText = "이름";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.ReadOnly = true;
            this.name.Width = 125;
            // 
            // txtBth
            // 
            this.txtBth.DataPropertyName = "User_Birthdate";
            this.txtBth.HeaderText = "생일";
            this.txtBth.MinimumWidth = 6;
            this.txtBth.Name = "txtBth";
            this.txtBth.ReadOnly = true;
            this.txtBth.Width = 125;
            // 
            // txtGender
            // 
            this.txtGender.DataPropertyName = "GenderDisplay";
            this.txtGender.HeaderText = "성별";
            this.txtGender.MinimumWidth = 6;
            this.txtGender.Name = "txtGender";
            this.txtGender.ReadOnly = true;
            this.txtGender.Width = 125;
            // 
            // txtPhonenum
            // 
            this.txtPhonenum.DataPropertyName = "User_Phone";
            this.txtPhonenum.HeaderText = "휴대전화번호";
            this.txtPhonenum.MinimumWidth = 6;
            this.txtPhonenum.Name = "txtPhonenum";
            this.txtPhonenum.ReadOnly = true;
            this.txtPhonenum.Width = 125;
            // 
            // txtEmail
            // 
            this.txtEmail.DataPropertyName = "User_Mail";
            this.txtEmail.HeaderText = "이메일 주소";
            this.txtEmail.MinimumWidth = 6;
            this.txtEmail.Name = "txtEmail";
            this.txtEmail.ReadOnly = true;
            this.txtEmail.Width = 125;
            // 
            // txtPicture
            // 
            this.txtPicture.DataPropertyName = "User_Image";
            this.txtPicture.HeaderText = "사진";
            this.txtPicture.MinimumWidth = 6;
            this.txtPicture.Name = "txtPicture";
            this.txtPicture.ReadOnly = true;
            this.txtPicture.Width = 125;
            // 
            // txtWithDR
            // 
            this.txtWithDR.DataPropertyName = "WTHDRDisplay";
            this.txtWithDR.HeaderText = "상태";
            this.txtWithDR.MinimumWidth = 6;
            this.txtWithDR.Name = "txtWithDR";
            this.txtWithDR.ReadOnly = true;
            this.txtWithDR.Width = 125;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnCancel.Location = new System.Drawing.Point(1002, 584);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 30);
            this.btnCancel.TabIndex = 23;
            this.btnCancel.Text = "탈퇴";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnChange
            // 
            this.btnChange.Location = new System.Drawing.Point(12, 47);
            this.btnChange.Name = "btnChange";
            this.btnChange.Size = new System.Drawing.Size(87, 20);
            this.btnChange.TabIndex = 25;
            this.btnChange.Text = "회원수정";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.button1.Location = new System.Drawing.Point(789, 584);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(100, 30);
            this.button1.TabIndex = 24;
            this.button1.Text = "등록";
            this.button1.UseVisualStyleBackColor = false;
            // 
            // btnDel
            // 
            this.btnDel.Location = new System.Drawing.Point(114, 47);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(83, 19);
            this.btnDel.TabIndex = 26;
            this.btnDel.Text = "회원탈퇴";
            this.btnDel.UseVisualStyleBackColor = true;
            // 
            // User_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 550);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnChange);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.ddlSearch);
            this.Controls.Add(this.search_textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_View";
            this.Text = "user_View";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.ComboBox ddlSearch;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtName;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnChange;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtBth;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtGender;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPhonenum;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtPicture;
        private System.Windows.Forms.DataGridViewTextBoxColumn txtWithDR;
        private System.Windows.Forms.Button btnDel;
    }
}