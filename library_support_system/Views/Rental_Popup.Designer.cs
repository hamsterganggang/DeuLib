namespace library_support_system.Views
{
    partial class Rental_Popup
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
            this.TimeRent = new System.Windows.Forms.DateTimePicker();
            this.lblRent = new System.Windows.Forms.Label();
            this.lblReturn = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.TimeReturn = new System.Windows.Forms.DateTimePicker();
            this.lblName = new System.Windows.Forms.Label();
            this.txtPhoneNum = new System.Windows.Forms.TextBox();
            this.btnNumCheck = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // TimeRent
            // 
            this.TimeRent.Location = new System.Drawing.Point(16, 82);
            this.TimeRent.Name = "TimeRent";
            this.TimeRent.Size = new System.Drawing.Size(319, 22);
            this.TimeRent.TabIndex = 0;
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = true;
            this.lblRent.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblRent.Location = new System.Drawing.Point(14, 60);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(73, 19);
            this.lblRent.TabIndex = 1;
            this.lblRent.Text = "대여일자 :";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblReturn.Location = new System.Drawing.Point(14, 107);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(73, 19);
            this.lblReturn.TabIndex = 2;
            this.lblReturn.Text = "반납일자 :";
            // 
            // btnSave
            // 
            this.btnSave.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnSave.Location = new System.Drawing.Point(132, 194);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "대여하기";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // TimeReturn
            // 
            this.TimeReturn.Location = new System.Drawing.Point(16, 129);
            this.TimeReturn.Name = "TimeReturn";
            this.TimeReturn.Size = new System.Drawing.Size(319, 22);
            this.TimeReturn.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.lblName.Location = new System.Drawing.Point(14, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(119, 19);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "대여자 전화번호 :";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.txtPhoneNum.Location = new System.Drawing.Point(16, 31);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(181, 26);
            this.txtPhoneNum.TabIndex = 6;
            // 
            // btnNumCheck
            // 
            this.btnNumCheck.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnNumCheck.Location = new System.Drawing.Point(203, 31);
            this.btnNumCheck.Name = "btnNumCheck";
            this.btnNumCheck.Size = new System.Drawing.Size(102, 26);
            this.btnNumCheck.TabIndex = 7;
            this.btnNumCheck.Text = "사용자 인증";
            this.btnNumCheck.UseVisualStyleBackColor = true;
            // 
            // Rental_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 240);
            this.Controls.Add(this.btnNumCheck);
            this.Controls.Add(this.txtPhoneNum);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.TimeReturn);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.lblReturn);
            this.Controls.Add(this.lblRent);
            this.Controls.Add(this.TimeRent);
            this.Name = "Rental_Popup";
            this.Text = "Rental_Popup";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker TimeRent;
        private System.Windows.Forms.Label lblRent;
        private System.Windows.Forms.Label lblReturn;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.DateTimePicker TimeReturn;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.TextBox txtPhoneNum;
        private System.Windows.Forms.Button btnNumCheck;
    }
}