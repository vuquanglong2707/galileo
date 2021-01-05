namespace BaiTapLonN6
{
    partial class FrmXemDiemRL
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Masodiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MSV = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Hoten = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Lop = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NamHoc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HocKy = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TongDiem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.XepLoai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cbboxChonkhoa = new System.Windows.Forms.ComboBox();
            this.cbboxChonlop = new System.Windows.Forms.ComboBox();
            this.cbboxNamHoc = new System.Windows.Forms.ComboBox();
            this.radioButtonHK2 = new System.Windows.Forms.RadioButton();
            this.radioButtonHK1 = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.radioButtonCaNam = new System.Windows.Forms.RadioButton();
            this.btnLoadDanhSach = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.btnChonDuongDan = new System.Windows.Forms.Button();
            this.lblDuongDan = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblDuongDanFile = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.ControlLightLight;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Masodiem,
            this.MSV,
            this.Hoten,
            this.Lop,
            this.NamHoc,
            this.HocKy,
            this.TongDiem,
            this.XepLoai});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dataGridView1.DefaultCellStyle = dataGridViewCellStyle2;
            this.dataGridView1.EnableHeadersVisualStyles = false;
            this.dataGridView1.Location = new System.Drawing.Point(12, 159);
            this.dataGridView1.Name = "dataGridView1";
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dataGridView1.RowHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dataGridView1.RowHeadersVisible = false;
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(1509, 551);
            this.dataGridView1.TabIndex = 0;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dataGridView1_DataBindingComplete);
            // 
            // Masodiem
            // 
            this.Masodiem.DataPropertyName = "Masodiem";
            this.Masodiem.HeaderText = "Mã Số Điểm";
            this.Masodiem.MinimumWidth = 6;
            this.Masodiem.Name = "Masodiem";
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
            this.Hoten.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.Hoten.DataPropertyName = "Hoten";
            this.Hoten.HeaderText = "Họ Tên";
            this.Hoten.MinimumWidth = 6;
            this.Hoten.Name = "Hoten";
            // 
            // Lop
            // 
            this.Lop.DataPropertyName = "Tenlop";
            this.Lop.HeaderText = "Lớp";
            this.Lop.MinimumWidth = 6;
            this.Lop.Name = "Lop";
            // 
            // NamHoc
            // 
            this.NamHoc.DataPropertyName = "Namhoc";
            this.NamHoc.HeaderText = "Năm Học";
            this.NamHoc.MinimumWidth = 6;
            this.NamHoc.Name = "NamHoc";
            // 
            // HocKy
            // 
            this.HocKy.DataPropertyName = "Hocky";
            this.HocKy.HeaderText = "Học Kỳ";
            this.HocKy.MinimumWidth = 6;
            this.HocKy.Name = "HocKy";
            // 
            // TongDiem
            // 
            this.TongDiem.DataPropertyName = "Tongdiem";
            this.TongDiem.HeaderText = "Tổng Điểm";
            this.TongDiem.MinimumWidth = 6;
            this.TongDiem.Name = "TongDiem";
            // 
            // XepLoai
            // 
            this.XepLoai.DataPropertyName = "Xeploai";
            this.XepLoai.HeaderText = "Xếp Loại";
            this.XepLoai.MinimumWidth = 6;
            this.XepLoai.Name = "XepLoai";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label1.Location = new System.Drawing.Point(30, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(55, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "KHOA :";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label2.Location = new System.Drawing.Point(36, 82);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 17);
            this.label2.TabIndex = 2;
            this.label2.Text = "LỚP :";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label3.Location = new System.Drawing.Point(403, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(80, 17);
            this.label3.TabIndex = 3;
            this.label3.Text = "NĂM HỌC :";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.label4.Location = new System.Drawing.Point(350, 82);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 17);
            this.label4.TabIndex = 4;
            this.label4.Text = "HỌC KỲ :";
            // 
            // cbboxChonkhoa
            // 
            this.cbboxChonkhoa.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxChonkhoa.FormattingEnabled = true;
            this.cbboxChonkhoa.Location = new System.Drawing.Point(91, 32);
            this.cbboxChonkhoa.Name = "cbboxChonkhoa";
            this.cbboxChonkhoa.Size = new System.Drawing.Size(247, 24);
            this.cbboxChonkhoa.TabIndex = 5;
            this.cbboxChonkhoa.SelectedIndexChanged += new System.EventHandler(this.cbboxChonkhoa_SelectedIndexChanged);
            // 
            // cbboxChonlop
            // 
            this.cbboxChonlop.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxChonlop.FormattingEnabled = true;
            this.cbboxChonlop.Location = new System.Drawing.Point(91, 79);
            this.cbboxChonlop.Name = "cbboxChonlop";
            this.cbboxChonlop.Size = new System.Drawing.Size(201, 24);
            this.cbboxChonlop.TabIndex = 6;
            this.cbboxChonlop.SelectedIndexChanged += new System.EventHandler(this.cbboxChonlop_SelectedIndexChanged);
            // 
            // cbboxNamHoc
            // 
            this.cbboxNamHoc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbboxNamHoc.FormattingEnabled = true;
            this.cbboxNamHoc.Location = new System.Drawing.Point(483, 32);
            this.cbboxNamHoc.Name = "cbboxNamHoc";
            this.cbboxNamHoc.Size = new System.Drawing.Size(201, 24);
            this.cbboxNamHoc.TabIndex = 7;
            this.cbboxNamHoc.SelectedIndexChanged += new System.EventHandler(this.cbboxNamHoc_SelectedIndexChanged);
            // 
            // radioButtonHK2
            // 
            this.radioButtonHK2.AutoSize = true;
            this.radioButtonHK2.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonHK2.Location = new System.Drawing.Point(541, 82);
            this.radioButtonHK2.Name = "radioButtonHK2";
            this.radioButtonHK2.Size = new System.Drawing.Size(84, 21);
            this.radioButtonHK2.TabIndex = 17;
            this.radioButtonHK2.TabStop = true;
            this.radioButtonHK2.Text = "Học Kỳ II";
            this.radioButtonHK2.UseVisualStyleBackColor = true;
            // 
            // radioButtonHK1
            // 
            this.radioButtonHK1.AutoSize = true;
            this.radioButtonHK1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonHK1.Location = new System.Drawing.Point(424, 82);
            this.radioButtonHK1.Name = "radioButtonHK1";
            this.radioButtonHK1.Size = new System.Drawing.Size(81, 21);
            this.radioButtonHK1.TabIndex = 16;
            this.radioButtonHK1.TabStop = true;
            this.radioButtonHK1.Text = "Học Kỳ I";
            this.radioButtonHK1.UseVisualStyleBackColor = true;
            this.radioButtonHK1.CheckedChanged += new System.EventHandler(this.radioButtonHK1_CheckedChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox1.Controls.Add(this.radioButtonCaNam);
            this.groupBox1.Controls.Add(this.btnLoadDanhSach);
            this.groupBox1.Controls.Add(this.radioButtonHK2);
            this.groupBox1.Controls.Add(this.radioButtonHK1);
            this.groupBox1.Controls.Add(this.cbboxNamHoc);
            this.groupBox1.Controls.Add(this.cbboxChonlop);
            this.groupBox1.Controls.Add(this.cbboxChonkhoa);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(71, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(974, 128);
            this.groupBox1.TabIndex = 19;
            this.groupBox1.TabStop = false;
            // 
            // radioButtonCaNam
            // 
            this.radioButtonCaNam.AutoSize = true;
            this.radioButtonCaNam.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.radioButtonCaNam.Location = new System.Drawing.Point(659, 82);
            this.radioButtonCaNam.Name = "radioButtonCaNam";
            this.radioButtonCaNam.Size = new System.Drawing.Size(79, 21);
            this.radioButtonCaNam.TabIndex = 19;
            this.radioButtonCaNam.TabStop = true;
            this.radioButtonCaNam.Text = "Cả Năm";
            this.radioButtonCaNam.UseVisualStyleBackColor = true;
            this.radioButtonCaNam.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // btnLoadDanhSach
            // 
            this.btnLoadDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLoadDanhSach.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.btnLoadDanhSach.Image = global::BaiTapLonN6.Properties.Resources.icons8_refresh_40;
            this.btnLoadDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnLoadDanhSach.Location = new System.Drawing.Point(778, 36);
            this.btnLoadDanhSach.Name = "btnLoadDanhSach";
            this.btnLoadDanhSach.Size = new System.Drawing.Size(178, 67);
            this.btnLoadDanhSach.TabIndex = 18;
            this.btnLoadDanhSach.Text = "    CẬP NHẬT";
            this.btnLoadDanhSach.UseVisualStyleBackColor = true;
            this.btnLoadDanhSach.Click += new System.EventHandler(this.btnLoadDanhSach_Click);
            // 
            // button1
            // 
            this.button1.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.button1.Location = new System.Drawing.Point(218, 25);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(159, 49);
            this.button1.TabIndex = 20;
            this.button1.Text = "XUẤT EXCEL";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btnChonDuongDan
            // 
            this.btnChonDuongDan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnChonDuongDan.Location = new System.Drawing.Point(18, 44);
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
            this.lblDuongDan.Location = new System.Drawing.Point(15, 86);
            this.lblDuongDan.Name = "lblDuongDan";
            this.lblDuongDan.Size = new System.Drawing.Size(24, 17);
            this.lblDuongDan.TabIndex = 103;
            this.lblDuongDan.Text = "=>";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.groupBox2.Controls.Add(this.lblDuongDanFile);
            this.groupBox2.Controls.Add(this.lblDuongDan);
            this.groupBox2.Controls.Add(this.btnChonDuongDan);
            this.groupBox2.Controls.Add(this.button1);
            this.groupBox2.Location = new System.Drawing.Point(1057, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(412, 127);
            this.groupBox2.TabIndex = 104;
            this.groupBox2.TabStop = false;
            // 
            // lblDuongDanFile
            // 
            this.lblDuongDanFile.AutoSize = true;
            this.lblDuongDanFile.Location = new System.Drawing.Point(45, 86);
            this.lblDuongDanFile.Name = "lblDuongDanFile";
            this.lblDuongDanFile.Size = new System.Drawing.Size(0, 17);
            this.lblDuongDanFile.TabIndex = 104;
            // 
            // FrmXemDiemRL
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1533, 722);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmXemDiemRL";
            this.Text = "Xem Điểm RL";
            this.Load += new System.EventHandler(this.FrmXemDiemRL_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbboxChonkhoa;
        private System.Windows.Forms.ComboBox cbboxChonlop;
        private System.Windows.Forms.ComboBox cbboxNamHoc;
        private System.Windows.Forms.RadioButton radioButtonHK2;
        private System.Windows.Forms.RadioButton radioButtonHK1;
        private System.Windows.Forms.Button btnLoadDanhSach;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.RadioButton radioButtonCaNam;
        private System.Windows.Forms.Button btnChonDuongDan;
        private System.Windows.Forms.Label lblDuongDan;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblDuongDanFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Masodiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn MSV;
        private System.Windows.Forms.DataGridViewTextBoxColumn Hoten;
        private System.Windows.Forms.DataGridViewTextBoxColumn Lop;
        private System.Windows.Forms.DataGridViewTextBoxColumn NamHoc;
        private System.Windows.Forms.DataGridViewTextBoxColumn HocKy;
        private System.Windows.Forms.DataGridViewTextBoxColumn TongDiem;
        private System.Windows.Forms.DataGridViewTextBoxColumn XepLoai;
    }
}