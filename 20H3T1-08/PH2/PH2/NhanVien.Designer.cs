namespace PH2
{
    partial class NhanVien
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
            this.dataGridTable = new System.Windows.Forms.DataGridView();
            this.labelTable = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.bntXemPC = new System.Windows.Forms.Button();
            this.bntXemPB = new System.Windows.Forms.Button();
            this.bntXemDA = new System.Windows.Forms.Button();
            this.bntXemTTCaNhan = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridTable
            // 
            this.dataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridTable.Location = new System.Drawing.Point(46, 66);
            this.dataGridTable.Name = "dataGridTable";
            this.dataGridTable.RowHeadersWidth = 51;
            this.dataGridTable.RowTemplate.Height = 24;
            this.dataGridTable.Size = new System.Drawing.Size(735, 207);
            this.dataGridTable.TabIndex = 0;
            this.dataGridTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.infoNV_CellContentClick);
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTable.Location = new System.Drawing.Point(248, 25);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(356, 38);
            this.labelTable.TabIndex = 1;
            this.labelTable.Text = "THÔNG TIN CÁ NHÂN";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(523, 403);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(104, 42);
            this.button1.TabIndex = 2;
            this.button1.Text = "Thay đổi";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(255, 331);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(207, 22);
            this.txtNgaySinh.TabIndex = 3;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(255, 376);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(207, 22);
            this.txtDiaChi.TabIndex = 4;
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(255, 423);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(207, 22);
            this.txtSDT.TabIndex = 5;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(146, 331);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Ngày sinh";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(146, 382);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 7;
            this.label3.Text = "Địa chỉ";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(146, 429);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 8;
            this.label4.Text = "Số điện thoại";
            // 
            // bntXemPC
            // 
            this.bntXemPC.Location = new System.Drawing.Point(219, 522);
            this.bntXemPC.Name = "bntXemPC";
            this.bntXemPC.Size = new System.Drawing.Size(152, 59);
            this.bntXemPC.TabIndex = 9;
            this.bntXemPC.Text = "Phân công";
            this.bntXemPC.UseVisualStyleBackColor = true;
            this.bntXemPC.Click += new System.EventHandler(this.bntXemPC_Click);
            // 
            // bntXemPB
            // 
            this.bntXemPB.Location = new System.Drawing.Point(435, 522);
            this.bntXemPB.Name = "bntXemPB";
            this.bntXemPB.Size = new System.Drawing.Size(148, 59);
            this.bntXemPB.TabIndex = 11;
            this.bntXemPB.Text = "Phòng ban";
            this.bntXemPB.UseVisualStyleBackColor = true;
            this.bntXemPB.Click += new System.EventHandler(this.bntXemPB_Click);
            // 
            // bntXemDA
            // 
            this.bntXemDA.Location = new System.Drawing.Point(650, 522);
            this.bntXemDA.Name = "bntXemDA";
            this.bntXemDA.Size = new System.Drawing.Size(150, 59);
            this.bntXemDA.TabIndex = 12;
            this.bntXemDA.Text = "Đề án";
            this.bntXemDA.UseVisualStyleBackColor = true;
            this.bntXemDA.Click += new System.EventHandler(this.bntXemDA_Click);
            // 
            // bntXemTTCaNhan
            // 
            this.bntXemTTCaNhan.Location = new System.Drawing.Point(29, 522);
            this.bntXemTTCaNhan.Name = "bntXemTTCaNhan";
            this.bntXemTTCaNhan.Size = new System.Drawing.Size(147, 59);
            this.bntXemTTCaNhan.TabIndex = 13;
            this.bntXemTTCaNhan.Text = "Xem Thông Tin Cá Nhân";
            this.bntXemTTCaNhan.UseVisualStyleBackColor = true;
            this.bntXemTTCaNhan.Click += new System.EventHandler(this.bntXemTTCaNhan_Click);
            // 
            // NhanVien
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(836, 593);
            this.Controls.Add(this.bntXemTTCaNhan);
            this.Controls.Add(this.bntXemDA);
            this.Controls.Add(this.bntXemPB);
            this.Controls.Add(this.bntXemPC);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.labelTable);
            this.Controls.Add(this.dataGridTable);
            this.Name = "NhanVien";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridTable;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button bntXemPC;
        private System.Windows.Forms.Button bntXemPB;
        private System.Windows.Forms.Button bntXemDA;
        private System.Windows.Forms.Button bntXemTTCaNhan;
    }
}

