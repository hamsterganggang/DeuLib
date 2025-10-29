namespace library_support_system.Views
{
    partial class Home_Search
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
            if (disposing)
            {
                // Presenter 정리
                presenter?.Dispose();

                if (components != null)
                {
                    components.Dispose();
                }
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
            this.main_panel = new System.Windows.Forms.Panel();
            this.search_option_combobox = new System.Windows.Forms.ComboBox();
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.main_panel.SuspendLayout();
            this.SuspendLayout();
            // 
            // main_panel
            // 
            this.main_panel.BackColor = System.Drawing.Color.White;
            this.main_panel.Controls.Add(this.search_option_combobox);
            this.main_panel.Controls.Add(this.search_button);
            this.main_panel.Controls.Add(this.search_textbox);
            this.main_panel.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.main_panel.Location = new System.Drawing.Point(0, 0);
            this.main_panel.Name = "main_panel";
            this.main_panel.Size = new System.Drawing.Size(1274, 732);
            this.main_panel.TabIndex = 0;
            this.main_panel.Paint += new System.Windows.Forms.PaintEventHandler(this.main_panel_Paint);
            // 
            // search_option_combobox
            // 
            this.search_option_combobox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_option_combobox.BackColor = System.Drawing.Color.White;
            this.search_option_combobox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.search_option_combobox.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_option_combobox.FormattingEnabled = true;
            this.search_option_combobox.Location = new System.Drawing.Point(322, 329);
            this.search_option_combobox.Margin = new System.Windows.Forms.Padding(4);
            this.search_option_combobox.Name = "search_option_combobox";
            this.search_option_combobox.Size = new System.Drawing.Size(73, 27);
            this.search_option_combobox.TabIndex = 12;
            // 
            // search_button
            // 
            this.search_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_button.BackColor = System.Drawing.Color.White;
            this.search_button.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.search_button.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_button.Location = new System.Drawing.Point(778, 329);
            this.search_button.Margin = new System.Windows.Forms.Padding(4);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(74, 27);
            this.search_button.TabIndex = 11;
            this.search_button.Text = "조회";
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_textbox.BackColor = System.Drawing.Color.White;
            this.search_textbox.Font = new System.Drawing.Font("페이퍼로지 4 Regular", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.search_textbox.Location = new System.Drawing.Point(394, 329);
            this.search_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.search_textbox.Multiline = true;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(367, 27);
            this.search_textbox.TabIndex = 10;
            this.search_textbox.TextChanged += new System.EventHandler(this.search_textbox_TextChanged);
            this.search_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textbox_KeyDown);
            // 
            // Home_Search
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1274, 732);
            this.Controls.Add(this.main_panel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Home_Search";
            this.Text = "home_search";
            this.Load += new System.EventHandler(this.book_rental_Load);
            this.main_panel.ResumeLayout(false);
            this.main_panel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel main_panel;
        private System.Windows.Forms.ComboBox search_option_combobox;
        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
    }
}