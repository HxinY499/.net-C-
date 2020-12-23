using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class WorkMessagePage : Form
    {
        WorkMessage worker;
        public WorkMessagePage(string userID)
        {
            this.worker = new WorkMessage(userID);
            InitializeComponent();
            nameLa.Text = worker.name;
            IDLa.Text = worker.ID;
            phoneBt.Text = worker.phoneNum;             
        }

        private void passwordBT_TextChanged(object sender, EventArgs e)
        {
            if (passwordBT.Text == null || passwordBT.Text =="")
            {
                passwordOldBT.Visible = false;
                passwordEnterLa.Visible = false;
                return;
            }
            passwordOldBT.Visible = true;
            passwordEnterLa.Visible = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (passwordBT.Text != null && passwordBT.Text != "")
            {
                if (passwordOldBT.Text.Trim() != worker.password)
                {
                    MessageBox.Show("密码错误!");
                    return;
                }
                else
                {
                    OracleConn oracleConn = new OracleConn();
                    oracleConn.InsertOrUpdateDate("UPDATE WORK SET WPASSWORD = '" + passwordBT.Text.Trim() + "'WHERE WORKNO = '" + worker.ID + "'");
                    passwordBT.Text = "";
                }
            }

            if (phoneBt.Text != worker.phoneNum)
            {
                OracleConn oracleConn = new OracleConn();
                worker.phoneNum = phoneBt.Text.Trim();
                oracleConn.InsertOrUpdateDate("UPDATE WORK SET WNUMBER = '" + phoneBt.Text.Trim() + "'WHERE WORKNO = '" + worker.ID + "'");
            }
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passwordBT.Text = null;
            phoneBt.Text = worker.phoneNum;
            this.Close();
        }

        private void phoneBt_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
