using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class StaffMainWin : Form
    {
        WorkMessage worker;
        public StaffMainWin(String ID)
        {
            worker = new WorkMessage(ID);
            InitializeComponent();
        }

        private void StaffMainWin_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            DataGridViewColumn id = new DataGridViewColumn();
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT (SELECT MNAME FROM MENU m WHERE m.MNO = d.MNO),SNO,TO_CHAR(DTIME,'yyyy-mm-dd hh24:mi:ss')，DNUM,DNO FROM DEAL d WHERE DONE = 'false'AND SHNO = " + worker.shopID);
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                Button b = new Button();
                while (odr.Read())
                {
                    this.dataGridView1.Rows.Add(odr.GetOracleValue(0), odr.GetOracleValue(1).ToString(), odr.GetOracleValue(2).ToString(), odr.GetOracleValue(3).ToString(), b, odr.GetOracleValue(4).ToString());
                }
            }
            odr.Close();

           odr = oracleConn.GetOracleDate("SELECT (SELECT MNAME FROM MENU m WHERE m.MNO = d.MNO),SNO,TO_CHAR(DTIME,'yyyy-mm-dd hh24:mi:ss')，DNUM FROM DEAL d WHERE DONE = 'true' AND SHNO = " + worker.shopID);
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                while (odr.Read())
                {
                    this.dataGridView2.Rows.Add(odr.GetOracleValue(0), odr.GetOracleValue(1).ToString(), odr.GetOracleValue(2).ToString(), odr.GetOracleValue(3).ToString());
                }
            }
            odr.Close();


        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex.Equals(4) && e.RowIndex < dataGridView1.RowCount)
            {
                string menuID = dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString();
                string updateStr = "UPDATE DEAL SET DONE = 'true' WHERE DNO = " + menuID;
                OracleConn oracleConn = new OracleConn();
                oracleConn.InsertOrUpdateDate(updateStr);
                this.dataGridView2.Rows.Add(dataGridView1.Rows[e.RowIndex].Cells[0].Value, dataGridView1.Rows[e.RowIndex].Cells[1].Value, dataGridView1.Rows[e.RowIndex].Cells[2].Value, dataGridView1.Rows[e.RowIndex].Cells[3].Value);
                dataGridView1.Rows.RemoveAt(e.RowIndex);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MenuModify menuModify = new MenuModify(worker.ID);
            menuModify.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            WorkMessagePage workMessagePage = new WorkMessagePage(worker.ID);
            workMessagePage.Show();
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }
    }

    class WorkMessage
    {
        public readonly string ID;
        public string password;
        public readonly string sex;
        public string phoneNum;
        public readonly string name;
        public readonly string shopID;

        public WorkMessage(string workID)
        {
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT * FROM Work WHERE workno = '" + workID +"'");
            if (odr.HasRows == false)
            {
                MessageBox.Show("SELECT * FROM Work WHERE workno = " + workID + "is null");
            }
            else
            {
                odr.Read();
                ID = odr.GetOracleValue(0).ToString();
                password = odr.GetOracleValue(1).ToString();
                sex = odr.GetOracleValue(4).ToString();
                phoneNum = odr.GetOracleValue(5).ToString();
                name = odr.GetOracleValue(3).ToString();
                shopID = odr.GetOracleValue(2).ToString();
            }
            odr.Close();
        }
    }
}
