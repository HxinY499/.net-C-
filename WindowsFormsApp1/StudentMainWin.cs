using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace WindowsFormsApp1
{

    public partial class StudentMainWin : Form
    {
        private UserMessage user;
        private string nowShowStall = "1";
        
        List<MenuBar> menuList = new List<MenuBar>();
        List<StallBar> stallList = new List<StallBar>();

        public StudentMainWin(string ID)
        {
            user = new UserMessage(ID);
            InitializeComponent();
            this.WindowState = FormWindowState.Maximized;

            stallList.Clear();
            stallPanel.Controls.Clear();
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT * FROM SHOP");
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                int i = 0;
                while (odr.Read())
                {
                    StallBar stall = new StallBar(i, odr.GetOracleValue(1).ToString(), odr.GetOracleValue(0).ToString(),stallPanel);
                    if (i != 0)
                        stall.SetInitColor();
                    i++;
                    stall.showNewStallDel += ShowNewStall;
                    stallList.Add(stall);
                }
            }
            odr.Close();
            ShowMenuOfStall("1");
            balanceLabel.Text = user.balance.ToString();
        }
        private void ShowMenuOfStall(string Stall)
        {
            menuList.Clear();
            menuPanel.Controls.Clear();
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT * FROM MENU WHERE SHNO = " + Stall);
            if (odr.HasRows == false)
            {
                MessageBox.Show("NULL");
            }
            else
            {
                int i = 0;
                while (odr.Read())
                {
                    MenuBar menu = new MenuBar(i, odr.GetOracleValue(2).ToString(), odr.GetOracleValue(3).ToString(), odr.GetOracleValue(4).ToString(), odr.GetOracleValue(0).ToString(), menuPanel);
                    i++;
                    menu.clickDel += CalculateSum;
                    menuList.Add(menu);
                }
            }
            odr.Close();
        }
        private void CalculateSum()
        {
            double sum = 0;
            foreach (var c in menuList)
            {
                sum += c.totalPrice;
            }
            priceSum.Text = sum.ToString();
        }
        private void ShowNewStall(string stallID)
        {
            foreach (var c in stallList)
                c.SetInitColor();
            ShowMenuOfStall(stallID);
            nowShowStall = stallID;
            priceSum.Text = "0";
        }

        private void BuyButton_Click(object sender, EventArgs e)
        {
            double paySum = 0;
            bool sale = false;
            List<string> insertStrings = new List<string>();
            List<string> updateStrings = new List<string>();
            List<string> selectMenuStrs = new List<string>();
            List<double> selectMenuPrices = new List<double>();

            OracleConn IDoracleConn = new OracleConn();
            OracleDataReader odr = IDoracleConn.GetOracleDate("SELECT MAX(DNO) FROM DEAL");
            string nextID = null;
            if (odr.HasRows == false)
            {
                nextID = "1000";
            }
            else
            {
                odr.Read();
                nextID = (int.Parse(odr.GetOracleValue(0).ToString()) + 1).ToString();
            }
            odr.Close();
            foreach (var menu in menuList)
            {
                if(menu.count!=0)
                {
                    sale = true;                    
                    string insertString = "INSERT INTO DEAL(MNO, DNO, DTIME, SNO, SHNO, DNUM, DONE) VALUES ('" + menu.menuID + "', '" + nextID + "', " + "to_date('"+DateTime.Now.ToString()+ "','YYYY-MM-DD HH24:MI:SS')" + ", '" + user.ID + "', '" + nowShowStall + "', " + menu.count + ", 'false')";
                    //oracleConn.InsertOrUpdateDate(insertString);
                    insertStrings.Add(insertString);
                    string updateString = "UPDATE MENU SET MSALE = '" + (menu.saleNum + menu.count).ToString() + "' WHERE MNO = '" + menu.menuID + "' AND SHNO = '" + nowShowStall + "'";
                    //oracleConn.InsertOrUpdateDate(updateString);
                    updateStrings.Add(updateString);
                    selectMenuPrices.Add(menu.totalPrice);
                    selectMenuStrs.Add(menu.menuName + " x" + menu.count);
                    paySum += menu.totalPrice;

                    nextID = (int.Parse(nextID) + 1).ToString();
                }
            }
            if (!sale)
                return;
            if (paySum > user.balance)
            {
                MessageBox.Show("!余额不足");
                return;
            }
            PayCheck pc = new PayCheck(user.balance, selectMenuStrs, selectMenuPrices);
            pc.ShowDialog();
            if (pc.DialogResult == DialogResult.Cancel)
                return;
            else if(pc.DialogResult == DialogResult.OK)
            {
                OracleConn oracleConn = new OracleConn();
                for (int i = 0;i<insertStrings.Count;i++)
                {
                    oracleConn.InsertOrUpdateDate(insertStrings[i]);
                    oracleConn.InsertOrUpdateDate(updateStrings[i]);
                }
                for(int i = 0;i<menuList.Count;i++)
                {
                    menuList[i].RestAndAdd();
                }
                CalculateSum();
                user.balance = user.balance - paySum;
                oracleConn.InsertOrUpdateDate("UPDATE STUDENT SET SBALANCE = " + user.balance.ToString() + " WHERE SNO = '" + user.ID + "'");
                balanceLabel.Text = user.balance.ToString();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StudentMessagePage studentMessagePage = new StudentMessagePage(user.ID);
            studentMessagePage.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UserOrder userOrder = new UserOrder(user.ID);
            userOrder.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }

    public delegate void ClickDel();
    public delegate void ShowNewStallDel(string ID);
    class MenuBar
    {
        public event ClickDel clickDel;
        public readonly string menuName;
        public double totalPrice;//总价
        public int count;   //购买数量
        public readonly string menuID;
        public int saleNum; //销量
        public readonly double menuPrice;
        Label menuNameLabel = new Label();
        Label saleVolumeLabel = new Label();
        Label signLabel = new Label();
        Label priceLabel = new Label();
        Button minuButton = new Button();
        Button addButton = new Button();
        Label countNumLabel = new Label();
        public MenuBar(int p, string name, string price, string saleCount, string ID, Panel panel)
        {

            count = 0; menuPrice = Double.Parse(price); totalPrice = 0; menuID = ID; saleNum = int.Parse(saleCount);menuName = name;
            panel.Controls.Add(menuNameLabel);
            menuNameLabel.Text = name;
            menuNameLabel.Font = new Font("宋体", 20);
            menuNameLabel.Size = new Size(174, 27);
            menuNameLabel.Location = new Point(41, 19 + p * 73);

            panel.Controls.Add(saleVolumeLabel);
            saleVolumeLabel.Text = "销量:" + saleCount;
            saleVolumeLabel.Font = new Font("宋体", 10);
            saleVolumeLabel.Size = new Size(63, 14);
            saleVolumeLabel.Location = new Point(49, 54 + p * 73);

            panel.Controls.Add(signLabel);
            signLabel.Text = "￥";
            signLabel.Font = new Font("宋体", 11);
            signLabel.ForeColor = Color.Red;
            signLabel.Size = new Size(22, 15);
            signLabel.Location = new Point(270, 27 + p * 73);

            panel.Controls.Add(priceLabel);
            priceLabel.Font = new Font("宋体", 20);
            priceLabel.Size = new Size(40, 27);
            priceLabel.ForeColor = Color.Red;
            priceLabel.Text = price;
            //priceLabel.Top = 28 + p * 110;
            // priceLabel.Left = 433;
            priceLabel.Location = new Point(289, 19 + p * 73);

            panel.Controls.Add(countNumLabel);
            countNumLabel.Text = "0";
            countNumLabel.Font = new Font("宋体", 11);
            countNumLabel.Size = new Size(25, 15);
            countNumLabel.Location = new Point(541, 29 + p * 73);

            panel.Controls.Add(minuButton);
            minuButton.Text = "-";
            minuButton.Font = new Font("宋体", 8);
            minuButton.Size = new Size(19, 17);
            minuButton.Location = new Point(510, 28 + p * 73);
            minuButton.Click += new EventHandler(Minu_Click);

            panel.Controls.Add(addButton);
            addButton.Text = "+";
            addButton.Font = new Font("宋体", 8);
            addButton.Size = new Size(19, 17);
            addButton.Location = new Point(573, 27 + p * 73);
            addButton.Click += new EventHandler(Add_Click);
        }

        private void Minu_Click(object sender, EventArgs e)
        {
            if (count <= 0)
                return;
            count--;
            countNumLabel.Text = count.ToString();
            totalPrice = menuPrice * count;
            clickDel();
        }
        private void Add_Click(object sender, EventArgs e)
        {
            if (count >= 99)
                return;
            count++;
            countNumLabel.Text = count.ToString();
            totalPrice = menuPrice * count;
            clickDel();
        }

        public void Rest()
        {
            totalPrice = 0;
            count = 0;
        }

        public void RestAndAdd()
        {
            totalPrice = 0;
            saleNum = saleNum + count;
            saleVolumeLabel.Text = saleNum.ToString();
            countNumLabel.Text = "0";
            count = 0;
        }
    }

    class StallBar
    {
        public event ShowNewStallDel showNewStallDel;
        string ID;
        Label stallNameLabel;
        public StallBar(int p, string name, string stallId, Panel panel)
        {
            ID = stallId;
            stallNameLabel = new Label();
            panel.Controls.Add(stallNameLabel);
            stallNameLabel.Text = name;
            stallNameLabel.Font = new Font("宋体", 20);
            stallNameLabel.Size = new Size(174, 27);
            stallNameLabel.Location = new Point(40, 19 + p * 60);
            stallNameLabel.ForeColor = Color.Orange;
            stallNameLabel.Click += new EventHandler(StallClick);
        }
        private void StallClick(object sender, EventArgs e)
        {
            showNewStallDel(ID);
            stallNameLabel.ForeColor = Color.Orange;
        }
        public void SetInitColor()
        {
            stallNameLabel.ForeColor = Color.Black;
        }
    }

    class UserMessage
    {
        public readonly string name;
        public readonly string ID;
        public string password;
        public string phoneNum;
        public readonly string college;
        public readonly string sex;
        public double balance;

        public UserMessage(string userID)
        {
            OracleConn oracleConn = new OracleConn();
            OracleDataReader odr = oracleConn.GetOracleDate("SELECT * FROM STUDENT WHERE SNO = '" + userID + "'");
            if (odr.HasRows == false)
            {
                MessageBox.Show("SELECT * FROM STUDENT WHERE SNO = '" + userID +"'is null");
            }
            else
            {
                odr.Read();
                ID = odr.GetOracleValue(0).ToString();
                password = odr.GetOracleValue(1).ToString();
                balance = double.Parse(odr.GetOracleValue(2).ToString());
                name = odr.GetOracleValue(3).ToString();  
                phoneNum = odr.GetOracleValue(4).ToString();
                college = odr.GetOracleValue(5).ToString();
                sex = odr.GetOracleValue(6).ToString();
                
            }
            odr.Close();
        }
    }

}
