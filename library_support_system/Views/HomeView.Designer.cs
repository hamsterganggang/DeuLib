using System.Drawing;

namespace library_support_system.Views
{
    partial class HomeView
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HomeView));
            this.home_label = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.rental_panel = new System.Windows.Forms.Panel();
            this.book_rental_button = new System.Windows.Forms.Button();
            this.book_return_button = new System.Windows.Forms.Button();
            this.rental_button = new System.Windows.Forms.Button();
            this.account_panel = new System.Windows.Forms.Panel();
            this.user_check_button = new System.Windows.Forms.Button();
            this.btnUserRes = new System.Windows.Forms.Button();
            this.account_button = new System.Windows.Forms.Button();
            this.book_panel = new System.Windows.Forms.Panel();
            this.book_check_button = new System.Windows.Forms.Button();
            this.book_enroll_button = new System.Windows.Forms.Button();
            this.book_button = new System.Windows.Forms.Button();
            this.panel2 = new System.Windows.Forms.Panel();
            this.home_picturebox = new System.Windows.Forms.PictureBox();
            this.home_button = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.labelCurrentMenu2 = new System.Windows.Forms.Label();
            this.exit_button = new System.Windows.Forms.Button();
            this.top_panel = new System.Windows.Forms.Panel();
            this.labelCurrentMenu1 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.main_panel = new System.Windows.Forms.Panel();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.panel1.SuspendLayout();
            this.rental_panel.SuspendLayout();
            this.account_panel.SuspendLayout();
            this.book_panel.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.home_picturebox)).BeginInit();
            this.panel3.SuspendLayout();
            this.top_panel.SuspendLayout();
            this.panel4.SuspendLayout();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // home_label
            // 
            this.home_label.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.home_label.Enabled = false;
            this.home_label.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.home_label.ForeColor = System.Drawing.Color.White;
            this.home_label.Location = new System.Drawing.Point(0, 0);
            this.home_label.Name = "home_label";
            this.home_label.Size = new System.Drawing.Size(88, 32);
            this.home_label.TabIndex = 0;
            this.home_label.Text = "도서관리\r\n시스템";
            this.home_label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.rental_panel);
            this.panel1.Controls.Add(this.rental_button);
            this.panel1.Controls.Add(this.account_panel);
            this.panel1.Controls.Add(this.account_button);
            this.panel1.Controls.Add(this.book_panel);
            this.panel1.Controls.Add(this.book_button);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Location = new System.Drawing.Point(-5, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(155, 681);
            this.panel1.TabIndex = 1;
            // 
            // rental_panel
            // 
            this.rental_panel.Controls.Add(this.book_rental_button);
            this.rental_panel.Controls.Add(this.book_return_button);
            this.rental_panel.Location = new System.Drawing.Point(5, 502);
            this.rental_panel.Name = "rental_panel";
            this.rental_panel.Size = new System.Drawing.Size(150, 95);
            this.rental_panel.TabIndex = 6;
            // 
            // book_rental_button
            // 
            this.book_rental_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.book_rental_button.FlatAppearance.BorderSize = 0;
            this.book_rental_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.book_rental_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.book_rental_button.ForeColor = System.Drawing.Color.White;
            this.book_rental_button.Location = new System.Drawing.Point(-3, 0);
            this.book_rental_button.Name = "book_rental_button";
            this.book_rental_button.Size = new System.Drawing.Size(150, 40);
            this.book_rental_button.TabIndex = 6;
            this.book_rental_button.Text = "도서대여";
            this.book_rental_button.UseVisualStyleBackColor = false;
            // 
            // book_return_button
            // 
            this.book_return_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.book_return_button.FlatAppearance.BorderSize = 0;
            this.book_return_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.book_return_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.book_return_button.ForeColor = System.Drawing.Color.White;
            this.book_return_button.Location = new System.Drawing.Point(-2, 55);
            this.book_return_button.Name = "book_return_button";
            this.book_return_button.Size = new System.Drawing.Size(150, 40);
            this.book_return_button.TabIndex = 5;
            this.book_return_button.Text = "도서반납";
            this.book_return_button.UseVisualStyleBackColor = false;
            // 
            // rental_button
            // 
            this.rental_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.rental_button.FlatAppearance.BorderSize = 0;
            this.rental_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.rental_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.rental_button.ForeColor = System.Drawing.Color.White;
            this.rental_button.Location = new System.Drawing.Point(5, 435);
            this.rental_button.Name = "rental_button";
            this.rental_button.Size = new System.Drawing.Size(150, 61);
            this.rental_button.TabIndex = 7;
            this.rental_button.Text = "대여관리";
            this.rental_button.UseVisualStyleBackColor = false;
            // 
            // account_panel
            // 
            this.account_panel.Controls.Add(this.user_check_button);
            this.account_panel.Controls.Add(this.btnUserRes);
            this.account_panel.Location = new System.Drawing.Point(6, 343);
            this.account_panel.Name = "account_panel";
            this.account_panel.Size = new System.Drawing.Size(151, 93);
            this.account_panel.TabIndex = 4;
            // 
            // user_check_button
            // 
            this.user_check_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.user_check_button.FlatAppearance.BorderSize = 0;
            this.user_check_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.user_check_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.user_check_button.ForeColor = System.Drawing.Color.White;
            this.user_check_button.Location = new System.Drawing.Point(-1, 0);
            this.user_check_button.Name = "user_check_button";
            this.user_check_button.Size = new System.Drawing.Size(151, 40);
            this.user_check_button.TabIndex = 4;
            this.user_check_button.Text = "회원조회";
            this.user_check_button.UseVisualStyleBackColor = false;
            // 
            // btnUserRes
            // 
            this.btnUserRes.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.btnUserRes.FlatAppearance.BorderSize = 0;
            this.btnUserRes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUserRes.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.btnUserRes.ForeColor = System.Drawing.Color.White;
            this.btnUserRes.Location = new System.Drawing.Point(-1, 46);
            this.btnUserRes.Name = "btnUserRes";
            this.btnUserRes.Size = new System.Drawing.Size(150, 40);
            this.btnUserRes.TabIndex = 3;
            this.btnUserRes.Text = "회원등록";
            this.btnUserRes.UseVisualStyleBackColor = false;
            // 
            // account_button
            // 
            this.account_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.account_button.FlatAppearance.BorderSize = 0;
            this.account_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.account_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.account_button.ForeColor = System.Drawing.Color.White;
            this.account_button.Location = new System.Drawing.Point(5, 283);
            this.account_button.Name = "account_button";
            this.account_button.Size = new System.Drawing.Size(150, 61);
            this.account_button.TabIndex = 5;
            this.account_button.Text = "회원관리";
            this.account_button.UseVisualStyleBackColor = false;
            // 
            // book_panel
            // 
            this.book_panel.Controls.Add(this.book_check_button);
            this.book_panel.Controls.Add(this.book_enroll_button);
            this.book_panel.Location = new System.Drawing.Point(4, 191);
            this.book_panel.Name = "book_panel";
            this.book_panel.Size = new System.Drawing.Size(151, 93);
            this.book_panel.TabIndex = 3;
            // 
            // book_check_button
            // 
            this.book_check_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.book_check_button.FlatAppearance.BorderSize = 0;
            this.book_check_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.book_check_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.book_check_button.ForeColor = System.Drawing.Color.White;
            this.book_check_button.Location = new System.Drawing.Point(1, 0);
            this.book_check_button.Name = "book_check_button";
            this.book_check_button.Size = new System.Drawing.Size(151, 40);
            this.book_check_button.TabIndex = 2;
            this.book_check_button.Text = "도서조회";
            this.book_check_button.UseVisualStyleBackColor = false;
            // 
            // book_enroll_button
            // 
            this.book_enroll_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.book_enroll_button.FlatAppearance.BorderSize = 0;
            this.book_enroll_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.book_enroll_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.book_enroll_button.ForeColor = System.Drawing.Color.White;
            this.book_enroll_button.Location = new System.Drawing.Point(0, 46);
            this.book_enroll_button.Name = "book_enroll_button";
            this.book_enroll_button.Size = new System.Drawing.Size(150, 40);
            this.book_enroll_button.TabIndex = 1;
            this.book_enroll_button.Text = "도서등록";
            this.book_enroll_button.UseVisualStyleBackColor = false;
            // 
            // book_button
            // 
            this.book_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(45)))), ((int)(((byte)(49)))), ((int)(((byte)(54)))));
            this.book_button.FlatAppearance.BorderSize = 0;
            this.book_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.book_button.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.book_button.ForeColor = System.Drawing.Color.White;
            this.book_button.Location = new System.Drawing.Point(6, 132);
            this.book_button.Name = "book_button";
            this.book_button.Size = new System.Drawing.Size(150, 61);
            this.book_button.TabIndex = 3;
            this.book_button.Text = "도서관리";
            this.book_button.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.panel2.Controls.Add(this.home_label);
            this.panel2.Controls.Add(this.home_picturebox);
            this.panel2.Controls.Add(this.home_button);
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(150, 51);
            this.panel2.TabIndex = 2;
            // 
            // home_picturebox
            // 
            this.home_picturebox.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.home_picturebox.Enabled = false;
            this.home_picturebox.Image = global::library_support_system.Properties.Resources.deu_logo;
            this.home_picturebox.Location = new System.Drawing.Point(86, 1);
            this.home_picturebox.Name = "home_picturebox";
            this.home_picturebox.Size = new System.Drawing.Size(68, 52);
            this.home_picturebox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.home_picturebox.TabIndex = 1;
            this.home_picturebox.TabStop = false;
            // 
            // home_button
            // 
            this.home_button.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.home_button.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.home_button.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.home_button.FlatAppearance.BorderSize = 0;
            this.home_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.home_button.ForeColor = System.Drawing.Color.White;
            this.home_button.Location = new System.Drawing.Point(0, 0);
            this.home_button.Name = "home_button";
            this.home_button.Size = new System.Drawing.Size(150, 55);
            this.home_button.TabIndex = 9;
            this.home_button.Text = "bb";
            this.home_button.UseVisualStyleBackColor = false;
            this.home_button.Click += new System.EventHandler(this.home_button_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.panel3.Controls.Add(this.labelCurrentMenu2);
            this.panel3.Controls.Add(this.exit_button);
            this.panel3.ForeColor = System.Drawing.Color.White;
            this.panel3.Location = new System.Drawing.Point(149, 0);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1114, 53);
            this.panel3.TabIndex = 2;
            // 
            // labelCurrentMenu2
            // 
            this.labelCurrentMenu2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCurrentMenu2.ForeColor = System.Drawing.Color.White;
            this.labelCurrentMenu2.Location = new System.Drawing.Point(7, 1);
            this.labelCurrentMenu2.Name = "labelCurrentMenu2";
            this.labelCurrentMenu2.Size = new System.Drawing.Size(175, 52);
            this.labelCurrentMenu2.TabIndex = 2;
            this.labelCurrentMenu2.Text = "홈";
            this.labelCurrentMenu2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // exit_button
            // 
            this.exit_button.BackColor = System.Drawing.Color.Crimson;
            this.exit_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.exit_button.ForeColor = System.Drawing.Color.Red;
            this.exit_button.Image = global::library_support_system.Properties.Resources.exit_logo1;
            this.exit_button.Location = new System.Drawing.Point(1061, 1);
            this.exit_button.Name = "exit_button";
            this.exit_button.Size = new System.Drawing.Size(54, 52);
            this.exit_button.TabIndex = 0;
            this.exit_button.UseVisualStyleBackColor = false;
            // 
            // top_panel
            // 
            this.top_panel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(23)))), ((int)(((byte)(24)))), ((int)(((byte)(29)))));
            this.top_panel.Controls.Add(this.labelCurrentMenu1);
            this.top_panel.Controls.Add(this.label1);
            this.top_panel.Location = new System.Drawing.Point(2, 54);
            this.top_panel.Name = "top_panel";
            this.top_panel.Size = new System.Drawing.Size(148, 74);
            this.top_panel.TabIndex = 8;
            // 
            // labelCurrentMenu1
            // 
            this.labelCurrentMenu1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.labelCurrentMenu1.ForeColor = System.Drawing.Color.White;
            this.labelCurrentMenu1.Location = new System.Drawing.Point(24, 31);
            this.labelCurrentMenu1.Name = "labelCurrentMenu1";
            this.labelCurrentMenu1.Size = new System.Drawing.Size(97, 18);
            this.labelCurrentMenu1.TabIndex = 1;
            this.labelCurrentMenu1.Text = "홈";
            this.labelCurrentMenu1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(46, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "현재메뉴";
            // 
            // panel4
            // 
            this.panel4.Controls.Add(this.main_panel);
            this.panel4.Location = new System.Drawing.Point(149, 54);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1115, 627);
            this.panel4.TabIndex = 9;
            // 
            // main_panel
            // 
            this.main_panel.Controls.Add(this.search_button);
            this.main_panel.Controls.Add(this.search_textbox);
            this.main_panel.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1115, 627);
            this.main_panel.TabIndex = 0;
            // 
            // search_button
            // 
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Image = global::library_support_system.Properties.Resources.search_logo;
            this.search_button.Location = new System.Drawing.Point(669, 192);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(39, 31);
            this.search_button.TabIndex = 9;
            this.search_button.UseVisualStyleBackColor = true;
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.search_textbox.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.search_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_textbox.Location = new System.Drawing.Point(143, 192);
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(506, 31);
            this.search_textbox.TabIndex = 8;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // HomeView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(1264, 681);
            this.ControlBox = false;
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.top_panel);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HomeView";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.home_Load);
            this.panel1.ResumeLayout(false);
            this.rental_panel.ResumeLayout(false);
            this.account_panel.ResumeLayout(false);
            this.book_panel.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.home_picturebox)).EndInit();
            this.panel3.ResumeLayout(false);
            this.top_panel.ResumeLayout(false);
            this.top_panel.PerformLayout();
            this.panel4.ResumeLayout(false);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label home_label;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox home_picturebox;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button book_button;
        private System.Windows.Forms.Panel book_panel;
        private System.Windows.Forms.Panel rental_panel;
        private System.Windows.Forms.Button rental_button;
        private System.Windows.Forms.Panel account_panel;
        private System.Windows.Forms.Button account_button;
        private System.Windows.Forms.Button exit_button;
        private System.Windows.Forms.Panel top_panel;
        private System.Windows.Forms.Button home_button;
        private System.Windows.Forms.Button book_check_button;
        private System.Windows.Forms.Button book_enroll_button;
        private System.Windows.Forms.Button book_rental_button;
        private System.Windows.Forms.Button book_return_button;
        private System.Windows.Forms.Button user_check_button;
        private System.Windows.Forms.Button btnUserRes;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.Label labelCurrentMenu1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label labelCurrentMenu2;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
    }
}

