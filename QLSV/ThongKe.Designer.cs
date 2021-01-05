namespace BaiTapLonN6
{
    partial class ThongKe
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cbboxlop = new System.Windows.Forms.ComboBox();
            this.cbboxkhoa = new System.Windows.Forms.ComboBox();
            this.txtTongSo = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.radiotatcalop = new System.Windows.Forms.RadioButton();
            this.radiodatotnghiep = new System.Windows.Forms.RadioButton();
            this.radiodanghoclop = new System.Windows.Forms.RadioButton();
            this.radiotatca = new System.Windows.Forms.RadioButton();
            this.radiototnghiep = new System.Windows.Forms.RadioButton();
            this.radiodanghoc = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.btnThongKeSV = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.MSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Ngaysinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.tinhtrang = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnChonDuongDan = new System.Windows.Forms.Button();
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.btnXuatExel = new System.Windows.Forms.Button();
            this.lblDuongDanFile = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(680, 33);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 5;
            this.label2.Text = "LỚP :";
            // 
            // label1
            // 
            this.label1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(8, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 4;
            this.label1.Text = "KHOA :";
            // 
            // cbboxlop
            // 
            this.cbboxlop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbboxlop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxlop.FormattingEnabled = true;
            this.cbboxlop.Location = new System.Drawing.Point(725, 30);
            this.cbboxlop.Name = "cbboxlop";
            this.cbboxlop.Size = new System.Drawing.Size(234, 24);
            this.cbboxlop.TabIndex = 2;
            // 
            // cbboxkhoa
            // 
            this.cbboxkhoa.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.cbboxkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxkhoa.FormattingEnabled = true;
            this.cbboxkhoa.Location = new System.Drawing.Point(69, 27);
            this.cbboxkhoa.Name = "cbboxkhoa";
            this.cbboxkhoa.Size = new System.Drawing.Size(233, 24);
            this.cbboxkhoa.TabIndex = 1;
            this.cbboxkhoa.SelectedIndexChanged += new System.EventHandler(this.cbboxkhoa_SelectedIndexChanged);
            // 
            // txtTongSo
            // 
            this.txtTongSo.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.txtTongSo.Location = new System.Drawing.Point(607, 48);
            this.txtTongSo.Name = "txtTongSo";
            this.txtTongSo.ReadOnly = true;
            this.txtTongSo.Size = new System.Drawing.Size(49, 22);
            this.txtTongSo.TabIndex = 17;
            // 
            // label3
            // 
            this.label3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(528, 51);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 17);
            this.label3.TabIndex = 16;
            this.label3.Text = "TỔNG SV :";
            // 
            // radiotatcalop
            // 
            this.radiotatcalop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiotatcalop.AutoSize = true;
            this.radiotatcalop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiotatcalop.Location = new System.Drawing.Point(664, 73);
            this.radiotatcalop.Name = "radiotatcalop";
            this.radiotatcalop.Size = new System.Drawing.Size(71, 21);
            this.radiotatcalop.TabIndex = 13;
            this.radiotatcalop.TabStop = true;
            this.radiotatcalop.Text = "Tất Cả";
            this.radiotatcalop.UseVisualStyleBackColor = true;
            // 
            // radiodatotnghiep
            // 
            this.radiodatotnghiep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiodatotnghiep.AutoSize = true;
            this.radiodatotnghiep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiodatotnghiep.Location = new System.Drawing.Point(838, 73);
            this.radiodatotnghiep.Name = "radiodatotnghiep";
            this.radiodatotnghiep.Size = new System.Drawing.Size(121, 21);
            this.radiodatotnghiep.TabIndex = 12;
            this.radiodatotnghiep.TabStop = true;
            this.radiodatotnghiep.Text = "Đã Tốt Nghiệp";
            this.radiodatotnghiep.UseVisualStyleBackColor = true;
            // 
            // radiodanghoclop
            // 
            this.radiodanghoclop.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiodanghoclop.AutoSize = true;
            this.radiodanghoclop.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiodanghoclop.Location = new System.Drawing.Point(741, 73);
            this.radiodanghoclop.Name = "radiodanghoclop";
            this.radiodanghoclop.Size = new System.Drawing.Size(92, 21);
            this.radiodanghoclop.TabIndex = 11;
            this.radiodanghoclop.TabStop = true;
            this.radiodanghoclop.Text = "Đang Học";
            this.radiodanghoclop.UseVisualStyleBackColor = true;
            // 
            // radiotatca
            // 
            this.radiotatca.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiotatca.AutoSize = true;
            this.radiotatca.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiotatca.Location = new System.Drawing.Point(27, 73);
            this.radiotatca.Name = "radiotatca";
            this.radiotatca.Size = new System.Drawing.Size(71, 21);
            this.radiotatca.TabIndex = 10;
            this.radiotatca.TabStop = true;
            this.radiotatca.Text = "Tất Cả";
            this.radiotatca.UseVisualStyleBackColor = true;
            // 
            // radiototnghiep
            // 
            this.radiototnghiep.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiototnghiep.AutoSize = true;
            this.radiototnghiep.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiototnghiep.Location = new System.Drawing.Point(202, 73);
            this.radiototnghiep.Name = "radiototnghiep";
            this.radiototnghiep.Size = new System.Drawing.Size(121, 21);
            this.radiototnghiep.TabIndex = 9;
            this.radiototnghiep.TabStop = true;
            this.radiototnghiep.Text = "Đã Tốt Nghiệp";
            this.radiototnghiep.UseVisualStyleBackColor = true;
            // 
            // radiodanghoc
            // 
            this.radiodanghoc.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.radiodanghoc.AutoSize = true;
            this.radiodanghoc.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radiodanghoc.Location = new System.Drawing.Point(104, 73);
            this.radiodanghoc.Name = "radiodanghoc";
            this.radiodanghoc.Size = new System.Drawing.Size(92, 21);
            this.radiodanghoc.TabIndex = 8;
            this.radiodanghoc.TabStop = true;
            this.radiodanghoc.Text = "Đang Học";
            this.radiodanghoc.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Image = global::BaiTapLonN6.Properties.Resources.icons8_estimate_30;
            this.button1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.button1.Location = new System.Drawing.Point(981, 30);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 64);
            this.button1.TabIndex = 14;
            this.button1.Text = "      THỐNG KÊ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnThongKeSV
            // 
            this.btnThongKeSV.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.btnThongKeSV.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThongKeSV.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnThongKeSV.Image = global::BaiTapLonN6.Properties.Resources.icons8_estimate_30;
            this.btnThongKeSV.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnThongKeSV.Location = new System.Drawing.Point(342, 27);
            this.btnThongKeSV.Name = "btnThongKeSV";
            this.btnThongKeSV.Size = new System.Drawing.Size(135, 64);
            this.btnThongKeSV.TabIndex = 3;
            this.btnThongKeSV.Text = "      THỐNG KÊ";
            this.btnThongKeSV.UseVisualStyleBackColor = true;
            this.btnThongKeSV.Click += new System.EventHandler(this.btnThongKeSV_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MSV,
            this.Hoten,
            this.Ngaysinh,
            this.tinhtrang});
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 144);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1752, 679);
            this.dataGridView1.TabIndex = 15;
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // MSV
            // 
            this.MSV.DataPropertyName = "MSV";
            this.MSV.HeaderText = "Mã SV";
            this.MSV.MinimumWidth = 6;
            this.MSV.Name = "MSV";
            // 
            // Hoten
            // 
            this.Hoten.DataPropertyName = "Hoten";
            this.Hoten.HeaderText = "Họ Tên";
            this.Hoten.MinimumWidth = 6;
            this.Hoten.Name = "Hoten";
            // 
            // Ngaysinh
            // 
            this.Ngaysinh.DataPropertyName = "GioiTinh";
            this.Ngaysinh.HeaderText = "Giới Tính";
            this.Ngaysinh.MinimumWidth = 6;
            this.Ngaysinh.Name = "Ngaysinh";
            // 
            // tinhtrang
            // 
            this.tinhtrang.DataPropertyName = "Tinhtrang";
            this.tinhtrang.HeaderText = "Tình Trạng";
            this.tinhtrang.MinimumWidth = 6;
            this.tinhtrang.Name = "tinhtrang";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.pictureBox1.Image = global::BaiTapLonN6.Properties.Resources.icons8_user_301;
            this.pictureBox1.Location = new System.Drawing.Point(482, 41);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(40, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 20;
            this.pictureBox1.TabStop = false;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.pictureBox1);
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.radiodanghoclop);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.radiototnghiep);
            this.groupBox1.Controls.Add(this.radiotatcalop);
            this.groupBox1.Controls.Add(this.cbboxkhoa);
            this.groupBox1.Controls.Add(this.cbboxlop);
            this.groupBox1.Controls.Add(this.radiodatotnghiep);
            this.groupBox1.Controls.Add(this.radiodanghoc);
            this.groupBox1.Controls.Add(this.btnThongKeSV);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.txtTongSo);
            this.groupBox1.Controls.Add(this.radiotatca);
            this.groupBox1.Location = new System.Drawing.Point(21, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(1136, 116);
            this.groupBox1.TabIndex = 106;
            this.groupBox1.TabStop = false;
            // 
            // btnChonDuongDan
            // 
            this.btnChonDuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDuongDan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnChonDuongDan.Location = new System.Drawing.Point(18, 36);
            this.btnChonDuongDan.Name = "btnChonDuongDan";
            this.btnChonDuongDan.Size = new System.Drawing.Size(169, 30);
            this.btnChonDuongDan.TabIndex = 102;
            this.btnChonDuongDan.Text = "Chọn Đường Dẫn";
            this.btnChonDuongDan.UseVisualStyleBackColor = true;
            this.btnChonDuongDan.Click += new System.EventHandler(this.btnChonDuongDan_Click);
            // 
            // lblDuongDan
            // 
            this.lblDuongDan.AutoSize = true;
            this.lblDuongDan.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDuongDan.Location = new System.Drawing.Point(37, 79);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(24, 17);
            this.lblDuongDan.TabIndex = 103;
            this.lblDuongDan.Text = "=>";
            // 
            // btnXuatExel
            // 
            this.btnXuatExel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXuatExel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXuatExel.ForeColor = System.Drawing.SystemColors.Desktop;
            this.btnXuatExel.Location = new System.Drawing.Point(200, 21);
            this.btnXuatExel.Name = "btnXuatExel";
            this.btnXuatExel.Size = new System.Drawing.Size(202, 45);
            this.btnXuatExel.TabIndex = 19;
            this.btnXuatExel.Text = "XUẤT EXCEL";
            this.btnXuatExel.UseVisualStyleBackColor = true;
            this.btnXuatExel.Click += new System.EventHandler(this.btnXuatExel_Click);
            // 
            // lblDuongDanFile
            // 
            this.lblDuongDanFile.AutoSize = true;
            this.lblDuongDanFile.ForeColor = System.Drawing.SystemColors.Desktop;
            this.lblDuongDanFile.Location = new System.Drawing.Point(67, 79);
            this.lblDuongDanFile.Name = "lblDuongDanFile";
            this.lblDuongDanFile.Size = new System.Drawing.Size(0, 17);
            this.lblDuongDanFile.TabIndex = 104;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.lblDuongDanFile);
            this.groupBox2.Controls.Add(this.btnXuatExel);
            this.groupBox2.Controls.Add(this.lblDuongDan);
            this.groupBox2.Controls.Add(this.btnChonDuongDan);
            this.groupBox2.Location = new System.Drawing.Point(1163, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(421, 116);
            this.groupBox2.TabIndex = 105;
            this.groupBox2.TabStop = false;
            // 
            // ThongKe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1610, 835);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dataGridView1);
            this.ForeColor = System.Drawing.SystemColors.InactiveCaption;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ThongKe";
            this.Text = "Thống Kê Báo Cáo";
            this.Load += new System.EventHandler(this.ThongKe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThongKeSV;
        private System.Windows.Forms.ComboBox cbboxlop;
        private System.Windows.Forms.ComboBox cbboxkhoa;
        private System.Windows.Forms.TextBox txtTongSo;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton radiotatcalop;
        private System.Windows.Forms.RadioButton radiodatotnghiep;
        private System.Windows.Forms.RadioButton radiodanghoclop;
        private System.Windows.Forms.RadioButton radiotatca;
        private System.Windows.Forms.RadioButton radiototnghiep;
        private System.Windows.Forms.RadioButton radiodanghoc;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Ngaysinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn tinhtrang;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnChonDuongDan;
        private System.Windows.Forms.Label lblDuongDan;
        private System.Windows.Forms.Button btnXuatExel;
        private System.Windows.Forms.Label lblDuongDanFile;
        private System.Windows.Forms.GroupBox groupBox2;
    }
}