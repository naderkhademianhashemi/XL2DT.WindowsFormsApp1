using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace XL2DT.WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
        }
        private DataTable XlS2DT(string path)
        {
            var nameSHT = "Sheet1";
            var strCN = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=" + path +
                            ";Extended Properties='Excel 8.0;HDR=YES;';";
            strCN = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path +
                ";Extended Properties=Excel 12.0 Xml;HDR=YES";

            var CN = new OleDbConnection(strCN);
            var CMD = new OleDbCommand("Select * From [" + nameSHT + "$]", CN);
            var ADP = new OleDbDataAdapter(CMD);
            var DT = new DataTable();
            ADP.Fill(DT);
            return DT;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            btnCount.Enabled = false;

        }

        private void btnBrws_Click(object sender, EventArgs e)
        {
            txtPath.Text= GetPath();
            btnCount.Enabled= true;
        }

        private string GetPath()
        {
            return "D:\\Desktop-1401\\Excel Northwind\\2.xlsx";
        }

        private void btnCount_Click(object sender, EventArgs e)
        {
            DataTable DT = new DataTable();
            DT = XlS2DT(txtPath.Text);
            MessageBox.Show(DT.Rows.Count.ToString());
        }

        
    }
}
