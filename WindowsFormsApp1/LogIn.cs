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
    public partial class LogIn : Form
    {
        public string userID = null;

        public LogIn()
        {
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
        }

        private void logInButton_Click(object sender, EventArgs e)
        {
            OracleConn oracleConn = new OracleConn();
            userID = userNameText.Text;
            string password = userPasswordText.Text;
            if (userID == "" || password == "")
            {
                WarningMessage.Visible = true;
                WarningMessage.Text = "!账号或密码不能为空";
                return;
            }
            string conneString = "SELECT * FROM STUDENT WHERE SNO = '" + userID + "' AND SPASSWORD = '" + password + "'";
            OracleDataReader odr = oracleConn.GetOracleDate(conneString);
            if (odr.HasRows == false)
            {
                odr.Close();
                conneString = "SELECT * FROM WORK WHERE WORKNO = '" + userID + "' AND WPASSWORD = '" + password + "'";
                odr = oracleConn.GetOracleDate(conneString);
                if (odr.HasRows == false)
                {
                    WarningMessage.Visible = true;
                    WarningMessage.Text = "!用户名或密码错误";
                }
                else
                {
                    this.DialogResult = DialogResult.Yes;//职工
                }
            }
            else
            {
                this.DialogResult = DialogResult.OK;//学生
            }
            odr.Close();
        }
    }
}
