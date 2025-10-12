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
            this.cmbGen = new System.Windows.Forms.ComboBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.withdraw = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.name = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.birth = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gender = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.phonenumber = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.picture = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cancel_button = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.search_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_textbox.Location = new System.Drawing.Point(151, 21);
            this.search_textbox.Multiline = true;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(270, 28);
            this.search_textbox.TabIndex = 9;
            // 
            // cmbGen
            // 
            this.cmbGen.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbGen.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cmbGen.FormattingEnabled = true;
            this.cmbGen.Items.AddRange(new object[] {
            "이름",
            "전화번호"});
            this.cmbGen.Location = new System.Drawing.Point(18, 21);
            this.cmbGen.Name = "cmbGen";
            this.cmbGen.Size = new System.Drawing.Size(121, 29);
            this.cmbGen.TabIndex = 19;
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
            this.withdraw,
            this.name,
            this.birth,
            this.gender,
            this.phonenumber,
            this.email,
            this.picture});
            this.dataGridView1.Location = new System.Drawing.Point(1, 76);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 27;
            this.dataGridView1.Size = new System.Drawing.Size(1043, 473);
            this.dataGridView1.TabIndex = 21;
            // 
            // withdraw
            // 
            // withdraw
            // 
            this.withdraw.HeaderText = "회원탈퇴";
            this.withdraw.MinimumWidth = 6;
            this.withdraw.Name = "withdraw";
            this.withdraw.Width = 125;
            this.withdraw.DataPropertyName = "User_WithDR"; // 💡 이 부분 추가 확인
            // 
            // name
            // 
            this.name.HeaderText = "이름";
            this.name.MinimumWidth = 6;
            this.name.Name = "name";
            this.name.Width = 125;
            this.name.DataPropertyName = "User_Name"; // 💡 이 부분 추가 확인
            // 
            // birth
            // 
            this.birth.HeaderText = "생일";
            this.birth.MinimumWidth = 6;
            this.birth.Name = "birth";
            this.birth.Width = 125;
            this.birth.DataPropertyName = "User_Birthdate"; // 💡 이 부분 추가 확인
            // 
            // gender
            // 
            this.gender.HeaderText = "성별";
            this.gender.MinimumWidth = 6;
            this.gender.Name = "gender";
            this.gender.Width = 125;
            this.gender.DataPropertyName = "User_Gender"; // 💡 이 부분 추가 확인
            // 
            // phonenumber
            // 
            this.phonenumber.HeaderText = "휴대전화번호";
            this.phonenumber.MinimumWidth = 6;
            this.phonenumber.Name = "phonenumber";
            this.phonenumber.Width = 125;
            this.phonenumber.DataPropertyName = "User_Phone"; // 💡 이 부분 추가 확인
            // 
            // email
            // 
            this.email.HeaderText = "이메일 주소";
            this.email.MinimumWidth = 6;
            this.email.Name = "email";
            this.email.Width = 125;
            this.email.DataPropertyName = "User_Mail"; // 💡 이 부분 추가 확인
            // 
            // picture
            // 
            this.picture.HeaderText = "사진";
            this.picture.MinimumWidth = 6;
            this.picture.Name = "picture";
            this.picture.Width = 125;
            this.picture.DataPropertyName = "User_Image";
            // 
            // cancel_button
            // 
            this.cancel_button.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.cancel_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cancel_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cancel_button.Location = new System.Drawing.Point(1002, 584);
            this.cancel_button.Name = "cancel_button";
            this.cancel_button.Size = new System.Drawing.Size(100, 30);
            this.cancel_button.TabIndex = 23;
            this.cancel_button.Text = "탈퇴";
            this.cancel_button.UseVisualStyleBackColor = false;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.SystemColors.ButtonShadow;
            this.btnSave.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSave.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(895, 584);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(100, 30);
            this.btnSave.TabIndex = 22;
            this.btnSave.Text = "수정";
            this.btnSave.UseVisualStyleBackColor = false;
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
            // User_View
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 550);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.cancel_button);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.cmbGen);
            this.Controls.Add(this.search_textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "User_View";
            this.Text = "user_check";
            this.Load += new System.EventHandler(this.user_check_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox search_textbox;
        private System.Windows.Forms.ComboBox cmbGen;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn withdraw;
        private System.Windows.Forms.DataGridViewTextBoxColumn name;
        private System.Windows.Forms.DataGridViewTextBoxColumn birth;
        private System.Windows.Forms.DataGridViewTextBoxColumn gender;
        private System.Windows.Forms.DataGridViewTextBoxColumn phonenumber;
        private System.Windows.Forms.DataGridViewTextBoxColumn email;
        private System.Windows.Forms.DataGridViewTextBoxColumn picture;
        private System.Windows.Forms.Button cancel_button;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button button1;
    }
}