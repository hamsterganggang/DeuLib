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
            this.TimeRent.Location = new System.Drawing.Point(12, 68);
            this.TimeRent.Name = "TimeRent";
            this.TimeRent.Size = new System.Drawing.Size(319, 22);
            this.TimeRent.TabIndex = 0;
            // 
            // lblRent
            // 
            this.lblRent.AutoSize = true;
            this.lblRent.Location = new System.Drawing.Point(12, 51);
            this.lblRent.Name = "lblRent";
            this.lblRent.Size = new System.Drawing.Size(57, 14);
            this.lblRent.TabIndex = 1;
            this.lblRent.Text = "대여일자 :";
            // 
            // lblReturn
            // 
            this.lblReturn.AutoSize = true;
            this.lblReturn.Location = new System.Drawing.Point(13, 93);
            this.lblReturn.Name = "lblReturn";
            this.lblReturn.Size = new System.Drawing.Size(57, 14);
            this.lblReturn.TabIndex = 2;
            this.lblReturn.Text = "반납일자 :";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(12, 138);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(86, 34);
            this.btnSave.TabIndex = 3;
            this.btnSave.Text = "대여하기";
            this.btnSave.UseVisualStyleBackColor = true;
            // 
            // TimeReturn
            // 
            this.TimeReturn.Location = new System.Drawing.Point(12, 110);
            this.TimeReturn.Name = "TimeReturn";
            this.TimeReturn.Size = new System.Drawing.Size(319, 22);
            this.TimeReturn.TabIndex = 4;
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(13, 9);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(93, 14);
            this.lblName.TabIndex = 5;
            this.lblName.Text = "대여자 전화번호 :";
            // 
            // txtPhoneNum
            // 
            this.txtPhoneNum.Location = new System.Drawing.Point(12, 26);
            this.txtPhoneNum.Name = "txtPhoneNum";
            this.txtPhoneNum.Size = new System.Drawing.Size(121, 22);
            this.txtPhoneNum.TabIndex = 6;
            // 
            // btnNumCheck
            // 
            this.btnNumCheck.Location = new System.Drawing.Point(139, 26);
            this.btnNumCheck.Name = "btnNumCheck";
            this.btnNumCheck.Size = new System.Drawing.Size(75, 23);
            this.btnNumCheck.TabIndex = 7;
            this.btnNumCheck.Text = "사용자 인증";
            this.btnNumCheck.UseVisualStyleBackColor = true;
            // 
            // Rental_Popup
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(372, 201);
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