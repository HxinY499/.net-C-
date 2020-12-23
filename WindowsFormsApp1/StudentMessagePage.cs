using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class StudentMessagePage : Form
    {
        UserMessage user;
        public StudentMessagePage(string userID)
        {
            this.user = new UserMessage(userID);
            InitializeComponent();
            nameLa.Text = user.name;
            IDLa.Text = user.ID;
            phoneBt.Text = user.phoneNum;
            collegeLa.Text = user.college;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (passwordBT.Text != null && passwordBT.Text != "")
            {
                if (passwordOldBT.Text.Trim() != user.password)
                {
                    MessageBox.Show("密码错误!");
                    return;
                }
                else
                {
                    OracleConn oracleConn = new OracleConn();
                    oracleConn.InsertOrUpdateDate("UPDATE STUDENT SET SPASSWORD = '" + passwordBT.Text.Trim() + "'WHERE SNO = '" + user.ID + "'");
                    passwordBT.Text = "";
                }
            }

            if (phoneBt.Text != user.phoneNum)
            {
                OracleConn oracleConn = new OracleConn();
                user.phoneNum = phoneBt.Text.Trim();
                oracleConn.InsertOrUpdateDate("UPDATE STUDENTS SET SNUMBER = '" + phoneBt.Text.Trim() + "'WHERE SNO = '" + user.ID + "'");
            }
            MessageBox.Show("保存成功！");
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            passwordBT.Text = null;
            phoneBt.Text = user.phoneNum;
            this.Close();
        }

        private void passwordBT_TextChanged(object sender, EventArgs e)
        {
            if (passwordBT.Text == null || passwordBT.Text == "")
            {
                passwordOldBT.Visible = false;
                passwordEnterLa.Visible = false;
                return;
            }
            passwordOldBT.Visible = true;
            passwordEnterLa.Visible = true;
        }

        private void collegeLa_Click(object sender, EventArgs e)
        {

        }

        private void nameLa_Click(object sender, EventArgs e)
        {

        }
    }
}
