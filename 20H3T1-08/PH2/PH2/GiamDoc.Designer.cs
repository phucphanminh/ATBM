namespace PH2
{
    partial class GiamDoc
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
            this.DataGridTable = new System.Windows.Forms.DataGridView();
            this.labelTable = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtSDT = new System.Windows.Forms.TextBox();
            this.txtDiaChi = new System.Windows.Forms.TextBox();
            this.txtNgaySinh = new System.Windows.Forms.TextBox();
            this.bntCapNhatTTCaNhan = new System.Windows.Forms.Button();
            this.bntDSNV = new System.Windows.Forms.Button();
            this.bntDSDA = new System.Windows.Forms.Button();
            this.bntDSPC = new System.Windows.Forms.Button();
            this.bntDSPB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTable)).BeginInit();
            this.SuspendLayout();
            // 
            // DataGridTable
            // 
            this.DataGridTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridTable.Location = new System.Drawing.Point(40, 76);
            this.DataGridTable.Name = "DataGridTable";
            this.DataGridTable.RowHeadersWidth = 51;
            this.DataGridTable.RowTemplate.Height = 24;
            this.DataGridTable.Size = new System.Drawing.Size(735, 179);
            this.DataGridTable.TabIndex = 1;
            // 
            // labelTable
            // 
            this.labelTable.AutoSize = true;
            this.labelTable.Font = new System.Drawing.Font("Microsoft Sans Serif", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(163)));
            this.labelTable.Location = new System.Drawing.Point(218, 20);
            this.labelTable.Name = "labelTable";
            this.labelTable.Size = new System.Drawing.Size(356, 38);
            this.labelTable.TabIndex = 2;
            this.labelTable.Text = "THÔNG TIN CÁ NHÂN";
            this.labelTable.Click += new System.EventHandler(this.label1_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(37, 336);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(85, 16);
            this.label4.TabIndex = 15;
            this.label4.Text = "Số điện thoại";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(442, 292);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(47, 16);
            this.label3.TabIndex = 14;
            this.label3.Text = "Địa chỉ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 292);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 16);
            this.label2.TabIndex = 13;
            this.label2.Text = "Ngày sinh";
            // 
            // txtSDT
            // 
            this.txtSDT.Location = new System.Drawing.Point(130, 336);
            this.txtSDT.Name = "txtSDT";
            this.txtSDT.Size = new System.Drawing.Size(207, 22);
            this.txtSDT.TabIndex = 12;
            // 
            // txtDiaChi
            // 
            this.txtDiaChi.Location = new System.Drawing.Point(523, 292);
            this.txtDiaChi.Name = "txtDiaChi";
            this.txtDiaChi.Size = new System.Drawing.Size(207, 22);
            this.txtDiaChi.TabIndex = 11;
            // 
            // txtNgaySinh
            // 
            this.txtNgaySinh.Location = new System.Drawing.Point(130, 295);
            this.txtNgaySinh.Name = "txtNgaySinh";
            this.txtNgaySinh.Size = new System.Drawing.Size(207, 22);
            this.txtNgaySinh.TabIndex = 10;
            // 
            // bntCapNhatTTCaNhan
            // 
            this.bntCapNhatTTCaNhan.Location = new System.Drawing.Point(523, 329);
            this.bntCapNhatTTCaNhan.Name = "bntCapNhatTTCaNhan";
            this.bntCapNhatTTCaNhan.Size = new System.Drawing.Size(134, 36);
            this.bntCapNhatTTCaNhan.TabIndex = 9;
            this.bntCapNhatTTCaNhan.Text = "Cập Nhật";
            this.bntCapNhatTTCaNhan.UseVisualStyleBackColor = true;
            this.bntCapNhatTTCaNhan.Click += new System.EventHandler(this.bntCapNhatTTCaNhan_Click);
            // 
            // bntDSNV
            // 
            this.bntDSNV.Location = new System.Drawing.Point(12, 384);
            this.bntDSNV.Name = "bntDSNV";
            this.bntDSNV.Size = new System.Drawing.Size(136, 54);
            this.bntDSNV.TabIndex = 16;
            this.bntDSNV.Text = "Xem DS Nhân Viên";
            this.bntDSNV.UseVisualStyleBackColor = true;
            this.bntDSNV.Click += new System.EventHandler(this.button2_Click);
            // 
            // bntDSDA
            // 
            this.bntDSDA.Location = new System.Drawing.Point(207, 384);
            this.bntDSDA.Name = "bntDSDA";
            this.bntDSDA.Size = new System.Drawing.Size(136, 54);
            this.bntDSDA.TabIndex = 17;
            this.bntDSDA.Text = "Xem DS Đề Án";
            this.bntDSDA.UseVisualStyleBackColor = true;
            this.bntDSDA.Click += new System.EventHandler(this.button3_Click);
            // 
            // bntDSPC
            // 
            this.bntDSPC.Location = new System.Drawing.Point(409, 384);
            this.bntDSPC.Name = "bntDSPC";
            this.bntDSPC.Size = new System.Drawing.Size(136, 54);
            this.bntDSPC.TabIndex = 18;
            this.bntDSPC.Text = "Xem DS Phân Công";
            this.bntDSPC.UseVisualStyleBackColor = true;
            this.bntDSPC.Click += new System.EventHandler(this.bntDSPC_Click);
            // 
            // bntDSPB
            // 
            this.bntDSPB.Location = new System.Drawing.Point(612, 384);
            this.bntDSPB.Name = "bntDSPB";
            this.bntDSPB.Size = new System.Drawing.Size(136, 54);
            this.bntDSPB.TabIndex = 19;
            this.bntDSPB.Text = "Xem DS Phòng Ban";
            this.bntDSPB.UseVisualStyleBackColor = true;
            this.bntDSPB.Click += new System.EventHandler(this.bntDSPB_Click);
            // 
            // GiamDoc
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.bntDSPB);
            this.Controls.Add(this.bntDSPC);
            this.Controls.Add(this.bntDSDA);
            this.Controls.Add(this.bntDSNV);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtSDT);
            this.Controls.Add(this.txtDiaChi);
            this.Controls.Add(this.txtNgaySinh);
            this.Controls.Add(this.bntCapNhatTTCaNhan);
            this.Controls.Add(this.labelTable);
            this.Controls.Add(this.DataGridTable);
            this.Name = "GiamDoc";
            this.Text = "GiamDoc";
            ((System.ComponentModel.ISupportInitialize)(this.DataGridTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView DataGridTable;
        private System.Windows.Forms.Label labelTable;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtSDT;
        private System.Windows.Forms.TextBox txtDiaChi;
        private System.Windows.Forms.TextBox txtNgaySinh;
        private System.Windows.Forms.Button bntCapNhatTTCaNhan;
        private System.Windows.Forms.Button bntDSNV;
        private System.Windows.Forms.Button bntDSDA;
        private System.Windows.Forms.Button bntDSPC;
        private System.Windows.Forms.Button bntDSPB;
    }
}