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
    public partial class PayCheck : Form
    {
        TimeSpan dtTo;
        double sum;
        double balance;
        public PayCheck(double balance,List<string>menus,List<double>prices)
        {
            InitializeComponent();
            dtTo = new TimeSpan(5);

            this.balance = balance;
            sum = 0;
            for(int i = 0;i<menus.Count;i++)
            {
                Label menuLabel = new Label();
                menuPanel.Controls.Add(menuLabel);
                menuLabel.Text = menus[i];
                menuLabel.Font = new Font("宋体", 9);
                menuLabel.Size = new Size(119, 12);
                menuLabel.Location = new Point(11, 7 + i * 28);

                Label pirceLabel = new Label();
                menuPanel.Controls.Add(pirceLabel);
                pirceLabel.Text = "￥" + prices[i].ToString();
                pirceLabel.Font = new Font("宋体", 9);
                pirceLabel.Size = new Size(41, 12);
                pirceLabel.Location = new Point(143, 7 + i * 28);

                sum += prices[i];
            }

            priceTotall.Text = "总价：￥" + sum.ToString();
            balaceLabel.Text = balance.ToString() + " -> " + (balance - sum).ToString();
        }

        private void confirm_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

            timer1.Interval = 1000;
            this.timer1.Enabled = true;
            timer1.Start();
        }

        private void cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            dtTo = dtTo.Subtract(new TimeSpan(1));
            if (dtTo.TotalSeconds < 0.0)
            {
                this.Close();
            }
        }
    }
}
