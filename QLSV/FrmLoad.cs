using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using app = Microsoft.Office.Interop.Excel.Application;
namespace BaiTapLonN6
{
    public partial class FrmLoad : Form
    {
        private DataGridView data;
        private String ddan;
        private static float Number;
        public FrmLoad(DataGridView g, String duongdan)
        {
            InitializeComponent();
            data = g;
            ddan = duongdan;
            Control.CheckForIllegalCrossThreadCalls = false;
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e) //dowork thực hiện xong, completed sẽ được gọi
        {
            Number = data.Rows.Count;
            //progressBar1.Invoke((Action)(() => progressBar1.Maximum = Number));
            progressBar1.Maximum = (int)Number;
            app obj = new app();
            obj.Application.Workbooks.Add(Type.Missing);
            obj.Columns.ColumnWidth = 25;
            for (int k = 1; k < data.Columns.Count + 1; k++)
            {
                obj.Cells[1, k] = data.Columns[k - 1].HeaderText;
            }
            for (int i = 0; i < data.Rows.Count; i++)
            {
                int tt = (int)(i / Number * 100);
                backgroundWorker1.ReportProgress(tt);
                for (int j = 0; j < data.Columns.Count; j++)
                {
                    if (data.Rows[i].Cells[j].Value != null)
                    {
                        obj.Cells[i + 2, j + 1] = data.Rows[i].Cells[j].Value.ToString();
                    }
                }
            }
            obj.ActiveWorkbook.SaveCopyAs(ddan);
            obj.ActiveWorkbook.Saved = true;
        }

        private void backgroundWorker1_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            if (!backgroundWorker1.CancellationPending)
            {
                percentageLabel.Text = e.ProgressPercentage + " %";
                progressBar1.Value = (int)((float)e.ProgressPercentage / 100 * (float)Number);
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            progressBar1.Value = (int)Number;
            percentageLabel.Text = "100%";
            MessageBox.Show("Done :)");
            this.Close();
        }
   
        private void button1_Click(object sender, EventArgs e)
        {
            backgroundWorker1.RunWorkerAsync(); //khi runworkerasync được chạy thì nó sẽ gọi method dowork
        }

        private void button2_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
        }

        private void FrmLoad_Load(object sender, EventArgs e)
        {
            button1_Click(sender,e);
        }
    }
}
