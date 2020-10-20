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
        public List<object> info = new List<object>();

        private void AddToListView(DataSet ds)
        {
            for (int i = 0; i <= ds.Tables["GetCloudFiles"].Rows.Count - 1; i++)
            {
                ListViewItem lv = new ListViewItem();
                lv.Text = Path.GetFileName(ds.Tables["GetCloudFiles"].Rows[i]["C_File_addr"].ToString());
                lv.Tag = ds.Tables["GetCloudFiles"].Rows[i]["C_File_id"].ToString();
                lv.ImageKey = "file_40px.png";
                lv.Name = ds.Tables["GetCloudFiles"].Rows[i]["C_File_addr"].ToString();
                listView1.Items.Add(lv);
            }
        }

        private void frmQuoteList_Load(object sender, EventArgs e)
        {
            AddToListView(ds);
        }

        private void listView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            FileName = Environment.GetFolderPath(Environment.SpecialFolder.Desktop) + @"\Cloud server\" + listView1.SelectedItems[0].Name;
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

        private void btn_Search_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            csQueries csq = new csQueries();

            var objds = csq.CostingQuery_ReturnDS("GetCloudFiles", txt_Search.Text, (int)info[0]);
            if (objds.Item1 == "Committed")
            {
                AddToListView(objds.Item2);
            }

        }

        private void btn_Reset_Click(object sender, EventArgs e)
        {
            txt_Search.Clear();
            listView1.Items.Clear();
            csQueries csq = new csQueries();

            var objds = csq.CostingQuery_ReturnDS("GetCloudFiles", "", (int)info[0]);
            if (objds.Item1 == "Committed")
            {
                AddToListView(objds.Item2);
            }
        }

        private void btn_Search_MouseEnter(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Font = new Font("Segoe UI", 9.0f ,FontStyle.Underline);
        }

        private void btn_Search_MouseLeave(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Font = new Font("Segoe UI", 9.0f, FontStyle.Regular);
        }
    }
}
