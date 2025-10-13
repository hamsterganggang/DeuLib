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
            this.search_button = new System.Windows.Forms.Button();
            this.search_textbox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // search_button
            // 
            this.search_button.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_button.BackColor = System.Drawing.Color.White;
            this.search_button.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.search_button.FlatAppearance.BorderSize = 1;
            this.search_button.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.search_button.Image = global::library_support_system.Properties.Resources.search_logo;
            this.search_button.Location = new System.Drawing.Point(582, 300);
            this.search_button.Margin = new System.Windows.Forms.Padding(4);
            this.search_button.Name = "search_button";
            this.search_button.Size = new System.Drawing.Size(40, 40);
            this.search_button.TabIndex = 11;
            this.search_button.UseVisualStyleBackColor = false;
            this.search_button.Click += new System.EventHandler(this.search_button_Click);
            // 
            // search_textbox
            // 
            this.search_textbox.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.search_textbox.BackColor = System.Drawing.Color.White;
            this.search_textbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.search_textbox.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.search_textbox.Location = new System.Drawing.Point(382, 300);
            this.search_textbox.Margin = new System.Windows.Forms.Padding(4);
            this.search_textbox.Multiline = true;
            this.search_textbox.Name = "search_textbox";
            this.search_textbox.Size = new System.Drawing.Size(200, 40);
            this.search_textbox.TabIndex = 10;
            this.search_textbox.TextChanged += new System.EventHandler(this.search_textbox_TextChanged);
            this.search_textbox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.search_textbox_KeyDown);
            // 
            // home_search
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.ClientSize = new System.Drawing.Size(1115, 627);
            this.Controls.Add(this.search_button);
            this.Controls.Add(this.search_textbox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "home_search";
            this.Text = "home_search";
            this.Load += new System.EventHandler(this.book_rental_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button search_button;
        private System.Windows.Forms.TextBox search_textbox;
    }
}