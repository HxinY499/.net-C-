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
    public partial class UserOrder : Form
    {
        UserMessage user;
        public UserOrder(string userID)
        {
            InitializeComponent();
            user = new UserMessage(userID);

            string connStr = "SELECT  s.SHNAME,TO_CHAR(d.DTIME,'YYYY-MM-DD'),TO_CHAR(d.DTIME,'hh24:mi:ss'),m.MNAME,d.DNUM, d.DNUM*m.MPRICE  FROM SHOP s, DEAL d,MENU m WHERE d.SNO = '"
                + user.ID +"' AND s.SHNO = d.SHNO AND m.SHNO = d.SHNO AND m.MNO = d.MNO AND d.DONE = 'false' ORDER BY d.DTIME DESC";
            Init(connStr, panel1);
            connStr = "SELECT  s.SHNAME,TO_CHAR(d.DTIME,'YYYY-MM-DD '),TO_CHAR(d.DTIME,'hh24:mi:ss'),m.MNAME,d.DNUM, d.DNUM*m.MPRICE  FROM SHOP s, DEAL d,MENU m WHERE d.SNO = '"
                + user.ID + "' AND s.shno = d.shno AND m.shno = d.shno AND m.mno = d.mno AND d.done = 'true' ORDER BY d.dtime DESC";
            Init(connStr, panel2);
        }

        private void Init(string connStr,Panel panel)
        {
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate(connStr);
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                int i = 0;
                while (odr.Read())
                {
                    Panel proPanel = new Panel();
                    panel.Controls.Add(proPanel);
                    proPanel.Size = new Size(250, 63);
                    proPanel.BackColor = SystemColors.Control;
                    proPanel.Location = new Point(10, 3 + i * 69);

                    Label porName = new Label();
                    proPanel.Controls.Add(porName);
                    porName.Text = odr.GetOracleValue(0).ToString();
                    porName.Font = new Font("宋体", 11);
                    porName.Size = new Size(67, 15);
                    porName.Location = new Point(7, 14);

                    Label porTime = new Label();
                    proPanel.Controls.Add(porTime);
                    porTime.Text = odr.GetOracleString(1).ToString();
                    porTime.Font = new Font("宋体", 9);
                    porTime.Size = new Size(71, 12);
                    porTime.Location = new Point(116, 14);

                    Label porTime2 = new Label();
                    proPanel.Controls.Add(porTime2);
                    porTime2.Text = odr.GetOracleString(2).ToString();
                    porTime2.Font = new Font("宋体", 9);
                    porTime2.Size = new Size(53, 12);
                    porTime2.Location = new Point(185, 14);

                    Label proMenuName = new Label();
                    proPanel.Controls.Add(proMenuName);
                    proMenuName.Text = odr.GetOracleValue(3).ToString() + "  x" + odr.GetOracleValue(4).ToString();
                    proMenuName.Font = new Font("宋体", 9);
                    //proMenuName.ForeColor = Color.Yellow;
                    proMenuName.Size = new Size(89, 12);
                    proMenuName.Location = new Point(30, 39);

                    Label porPrice = new Label();
                    proPanel.Controls.Add(porPrice);
                    porPrice.Text = "￥" + odr.GetOracleValue(5).ToString();
                    porPrice.Font = new Font("宋体", 9);
                    porPrice.Size = new Size(35, 12);
                    porPrice.Location = new Point(200, 35);
                    i++;
                }
            }
            odr.Close();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
