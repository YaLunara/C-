using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    public partial class FrmSearchOd : Form
    {
        private string key;
        ListView orderList = new ListView();
        List<Order> orders = new List<Order>();
        private OrderService os;
        public FrmSearchOd()
        {
            InitializeComponent();
        }

        private void FrmSearchOd_Load(object sender, EventArgs e)
        {
            
        }

        private void SearchBy_SelectedIndexChanged(object sender, EventArgs e)
        {
            key = SearchBy.Text;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            switch(key)
            {
                case "全部订单":
                    orders = os.GetAllOrders();
                    break;
                case "OrderId":
                    Order order = os.GetOrder(txtKeyWord.Text);
                    orders.Clear();
                    orders.Add(order);
                    break;
                case "CustomerName":
                    orders = os.QueryByCustormer(txtKeyWord.Text);
                    break;
                case "GoodsName":
                    orders = os.QueryByGoods(txtKeyWord.Text);
                    break;
            }
            ShowMessage.showOrderMessages(orders, orderList);
        }

        public void ShowF4(MainForm1 form,OrderService os)
        {
            this.Show();
            orderList = form.orderList;
            this.os = os;
            
        }
    }
}
