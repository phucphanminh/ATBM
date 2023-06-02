namespace PH2
{
    partial class TaiChinh_CapNhat_LuongPhuCaptrenNhanVien
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
            this.label8 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.Password = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.dsUser = new System.Windows.Forms.DataGridView();
            this.UserName = new System.Windows.Forms.TextBox();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dsUser)).BeginInit();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(322, 107);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(199, 16);
            this.label8.TabIndex = 53;
            this.label8.Text = "Chọn mã nhân viên cần cập nhật";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(548, 104);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(173, 24);
            this.comboBox1.TabIndex = 52;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(322, 209);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(116, 16);
            this.label2.TabIndex = 49;
            this.label2.Text = "Nhập phụ cấp mới";
            // 
            // Password
            // 
            this.Password.Location = new System.Drawing.Point(479, 206);
            this.Password.Margin = new System.Windows.Forms.Padding(4);
            this.Password.Name = "Password";
            this.Password.Size = new System.Drawing.Size(242, 22);
            this.Password.TabIndex = 48;
            this.Password.UseSystemPasswordChar = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(322, 155);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(101, 16);
            this.label1.TabIndex = 47;
            this.label1.Text = "Nhập lương mới";
            // 
            // dsUser
            // 
            this.dsUser.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dsUser.Location = new System.Drawing.Point(96, 313);
            this.dsUser.Margin = new System.Windows.Forms.Padding(4);
            this.dsUser.Name = "dsUser";
            this.dsUser.RowHeadersWidth = 51;
            this.dsUser.Size = new System.Drawing.Size(832, 218);
            this.dsUser.TabIndex = 46;
            // 
            // UserName
            // 
            this.UserName.Location = new System.Drawing.Point(479, 152);
            this.UserName.Margin = new System.Windows.Forms.Padding(4);
            this.UserName.Name = "UserName";
            this.UserName.Size = new System.Drawing.Size(242, 22);
            this.UserName.TabIndex = 45;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(602, 263);
            this.button3.Margin = new System.Windows.Forms.Padding(4);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 28);
            this.button3.TabIndex = 44;
            this.button3.Text = "Cập nhật";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // TaiChinh_CapNhat_LuongPhuCaptrenNhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1014, 594);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Password);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.dsUser);
            this.Controls.Add(this.UserName);
            this.Controls.Add(this.button3);
            this.Name = "TaiChinh_CapNhat_LuongPhuCaptrenNhanVien";
            this.Text = "TaiChinh_CapNhat_LuongPhuCaptrenNhanVien";
            ((System.ComponentModel.ISupportInitialize)(this.dsUser)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox Password;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView dsUser;
        private System.Windows.Forms.TextBox UserName;
        private System.Windows.Forms.Button button3;
    }
}