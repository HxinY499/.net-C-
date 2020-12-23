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
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{
    public partial class MenuModify : Form
    {
        WorkMessage worker;
        int i = 0;
        List<ShopMenuBar> shopMenuBar_List = new List<ShopMenuBar>();
        public MenuModify(string workID)
        {
            worker = new WorkMessage(workID);
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;
            menuPanel.Controls.Clear();
            UpdateMenu();
        }

        public void UpdateMenu()
        {
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT * FROM Menu WHERE shno = '" + worker.shopID + "'");
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                i = 0;
                while (odr.Read())
                {
                    ShopMenuBar stall = new ShopMenuBar(i, odr.GetOracleValue(2).ToString(), odr.GetOracleValue(3).ToString(), odr.GetOracleValue(4).ToString(), odr.GetOracleValue(0).ToString(), worker, menuPanel);
                    stall.shopMenuBarDelete += ShopMenuBarDelete;
                    shopMenuBar_List.Add(stall);
                    i++;
                }
            }
            odr.Close();
        }

        private void menuNameAddTB_Click(object sender, EventArgs e)
        {
            warningNameMessage.Visible = false;
            warningPriceMessage.Visible = false;
        }

        private void menuPriceAddTB_Click(object sender, EventArgs e)
        {
            warningNameMessage.Visible = false;
            warningPriceMessage.Visible = false;
        }

        private void ShopMenuBarDelete(object sender, EventArgs e, int p)
        {
            shopMenuBar_List[p].Remove(menuPanel);
            shopMenuBar_List.RemoveAt(p);
            for(int i = 0;i <shopMenuBar_List.Count;i++)
            {
                shopMenuBar_List[i].SetPos(i);
            }
            i = shopMenuBar_List.Count;
        }

        private void MenuAddBu_Click(object sender, EventArgs e)
        {
            if (menuPriceAddTB.Text.Trim() == null || !Regex.Match(menuPriceAddTB.Text.Trim(), @"^\d+$").Success)
            {
                warningPriceMessage.Visible = true;
                return;
            }
            if (menuNameAddTB.Text.Trim() == null || menuNameAddTB.Text.Trim() == "")
            {
                warningNameMessage.Visible = true;
                return;
            }

            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT MAX(MNO) FROM Menu WHERE SHNO = '" + worker.shopID + "'");
            string nextID = null;
            if(odr.HasRows == false)
            {
                nextID = "1000";
            }
            else
            {
                odr.Read();
                int num = new Random().Next(1,1000);
                nextID = (int.Parse(odr.GetOracleValue(0).ToString().Trim()) + num).ToString();
            }
            odr.Close();
            string inStr = "INSERT INTO MENU(MNO, SHNO, MNAME, MPRICE, MSALE, WORKNO) VALUES ('"
                          + nextID + "', '" + worker.shopID + "', '" + menuNameAddTB.Text.Trim() + "', '" + menuPriceAddTB.Text.Trim() + "', '0', '" + worker.ID + "')";
            oracleConn.InsertOrUpdateDate(inStr);
            ShopMenuBar stall = new ShopMenuBar(i, menuNameAddTB.Text.Trim(), menuPriceAddTB.Text.Trim(), "0", nextID, worker, menuPanel);
            stall.shopMenuBarDelete += ShopMenuBarDelete;
            shopMenuBar_List.Add(stall);
            i++;
            menuPriceAddTB.Text = "";
            menuNameAddTB.Text = "";
        }
    }

    public delegate void ShopMenuBarDelete(object sender, EventArgs e, int p);
    class ShopMenuBar
    {
        public event ShopMenuBarDelete shopMenuBarDelete;
        public int pos;
        public string menuName;
        public string menuID;
        public readonly int saleNum; //销量
        public double menuPrice;
        private WorkMessage work;
        TextBox menuNameTextBox = new TextBox();
        Label saleVolumeLabel = new Label();
        TextBox priceTextBoxl = new TextBox();
        Label signLabel = new Label();
        Button saveButton = new Button();
        Button cancleButton = new Button();
        Button deleteButton = new Button();

        public ShopMenuBar(int p, string name, string price, string saleCount, string ID, WorkMessage work, Panel panel)
        {
            pos = p;
            menuPrice = Double.Parse(price); menuID = ID; saleNum = int.Parse(saleCount); menuName = name;
            this.work = work;
            panel.Controls.Add(menuNameTextBox);
            menuNameTextBox.Text = name;
            menuNameTextBox.Font = new Font("宋体", 20);
            menuNameTextBox.Size = new Size(174, 38);
            menuNameTextBox.Location = new Point(41, 19 + p * 73);
            menuNameTextBox.TextChanged += new EventHandler(MenuTextChange);

            panel.Controls.Add(saleVolumeLabel);
            saleVolumeLabel.Text = "销量:" + saleCount;
            saleVolumeLabel.Font = new Font("宋体", 10);
            saleVolumeLabel.Size = new Size(63, 14);
            saleVolumeLabel.Location = new Point(49, 58 + p * 73);

            panel.Controls.Add(signLabel);
            signLabel.Text = "价格：";
            signLabel.Font = new Font("宋体", 11);
            signLabel.ForeColor = Color.Red;
            signLabel.Size = new Size(52, 15);
            signLabel.Location = new Point(248, 41 + p * 73);

            panel.Controls.Add(priceTextBoxl);
            priceTextBoxl.Font = new Font("宋体", 20);
            priceTextBoxl.Size = new Size(38, 24);
            priceTextBoxl.ForeColor = Color.Red;
            priceTextBoxl.Text = price;
            priceTextBoxl.Location = new Point(306, 25 + p * 73);
            priceTextBoxl.TextChanged += new EventHandler(PriceTextChange);

            panel.Controls.Add(cancleButton);
            cancleButton.Text = "取消";
            cancleButton.Font = new Font("宋体", 11);
            cancleButton.Size = new Size(75, 23);
            cancleButton.Location = new Point(484, 33 + p * 73);
            cancleButton.Click += new EventHandler(Cancle_Click);

            panel.Controls.Add(saveButton);
            saveButton.Text = "保存";
            saveButton.Font = new Font("宋体", 11);
            saveButton.Size = new Size(75, 23);
            saveButton.Location = new Point(572, 33 + p * 73);
            saveButton.Click += new EventHandler(Save_Click);

            panel.Controls.Add(deleteButton);
            deleteButton.Text = "删除";
            deleteButton.Font = new Font("宋体", 11);
            deleteButton.Size = new Size(75, 23);
            deleteButton.Location = new Point(393, 33 + p * 73);
            deleteButton.Click += new EventHandler(Delete_Click);
        }

        public void SetPos(int p)
        {
            pos = p;
            menuNameTextBox.Location = new Point(41, 19 + p * 73);
            saleVolumeLabel.Location = new Point(49, 58 + p * 73);
            signLabel.Location = new Point(248, 41 + p * 73);
            priceTextBoxl.Location = new Point(306, 25 + p * 73);
            cancleButton.Location = new Point(484, 33 + p * 73);
            saveButton.Location = new Point(572, 33 + p * 73);
            deleteButton.Location = new Point(393, 33 + p * 73);
        }
        public void Remove(Panel panel)
        {            
            panel.Controls.Remove(menuNameTextBox);
            panel.Controls.Remove(saleVolumeLabel);
            panel.Controls.Remove(priceTextBoxl);
            panel.Controls.Remove(signLabel);
            panel.Controls.Remove(saveButton);
            panel.Controls.Remove(cancleButton);
            panel.Controls.Remove(deleteButton);
        }

        private void PriceTextChange(object sender, EventArgs e)
        {
            if (menuPrice != double.Parse(priceTextBoxl.Text))
            {
                priceTextBoxl.ForeColor = Color.Orange;
            }
            else
                priceTextBoxl.ForeColor = Color.Red;
            //1900302
        }

        private void MenuTextChange(object sender, EventArgs e)
        {
            if (menuName != menuNameTextBox.Text)
            {
                menuNameTextBox.ForeColor = Color.Orange;
            }
            else
                menuNameTextBox.ForeColor = Color.Black;
        }

        private void Cancle_Click(object sender, EventArgs e)
        {
            menuNameTextBox.Text = menuName;
            priceTextBoxl.Text = menuPrice.ToString();
            menuNameTextBox.ForeColor = Color.Black;
            priceTextBoxl.ForeColor = Color.Red;
        }
        private void Save_Click(object sender, EventArgs e)
        {
            if (menuName != menuNameTextBox.Text)
            {
                menuName = menuNameTextBox.Text;
                OracleConn oracleConn = new OracleConn();
                string updateStr = "UPDATE MENU SET MNAME = '" + menuName + "' WHERE MNO = '" + menuID + "' AND SHNO = '" + work.shopID + "'";
                oracleConn.InsertOrUpdateDate(updateStr);
                menuNameTextBox.Text = menuName;
                menuNameTextBox.ForeColor = Color.Black;
            }
            if (menuPrice != double.Parse(priceTextBoxl.Text))
            {
                menuPrice = double.Parse(priceTextBoxl.Text);
                OracleConn oracleConn = new OracleConn();
                string updateStr = "UPDATE MENU SET MPrice = '" + menuPrice + "' WHERE MNO = '" + menuID + "' AND SHNO = '" + work.shopID + "'";
                oracleConn.InsertOrUpdateDate(updateStr);
                priceTextBoxl.Text = menuPrice.ToString();
                priceTextBoxl.ForeColor = Color.Red;
            }
        }
        private void Delete_Click(object sender, EventArgs e)
        {                    
            
            shopMenuBarDelete(sender, e, pos);
            string delStr = "DELETE FROM MENU WHERE MNO = '"+ menuID + "' AND SHNO = '"+ work.shopID + "'";
            OracleConn oracleConn = new OracleConn();
            oracleConn.InsertOrUpdateDate(delStr);
        }
    }
}
