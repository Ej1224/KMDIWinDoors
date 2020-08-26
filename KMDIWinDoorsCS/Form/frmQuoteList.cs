using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KMDIWinDoorsCS
{
    public partial class frmQuoteList : Form
    {
        public frmQuoteList()
        {
            InitializeComponent();
        }
        public DataSet ds = new DataSet();
        public string FileName;
        private void frmQuoteList_Load(object sender, EventArgs e)
        {
            for (int i = 0; i <= ds.Tables["GetCloudFiles"].Rows.Count - 1; i++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = ds.Tables["GetCloudFiles"].Rows[i]["C_File_addr"].ToString();
                lv.Tag = ds.Tables["GetCloudFiles"].Rows[i]["C_File_id"].ToString();
                lv.ImageKey = "file_40px.png";
                listView1.Items.Add(lv);
            }
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileName = @"C:\Users\kmdie\Desktop\Cloud server\" + listView1.SelectedItems[0].Text;
            string tempDir = Path.GetTempPath() + @"wndrTemp\",
                   tempfile = tempDir + listView1.SelectedItems[0].Text;
            Directory.CreateDirectory(tempDir);
            File.Copy(FileName, tempfile, true);
            FileName = tempfile;

            this.DialogResult = DialogResult.OK;
            this.Close();
            //MessageBox.Show("Text: " + listView1.SelectedItems[0].Text + "\n" +
            //                "Tag: " + listView1.SelectedItems[0].Tag);
        }
    }
}
