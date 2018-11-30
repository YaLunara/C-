using ordertest;
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

namespace homework10
{
    public partial class FrmAddOdMsg : Form
    {
        ListView orderList = new ListView();
        private int goodID;
        private int orderDetailID;
        private static int orderID = 1;
        private Order order = new Order();
        private Customer customer = new Customer();
        private OrderService os = new OrderService();
        private string dateString = DateTime.Now.ToString().Replace(@"[^\d]*", "");

        public FrmAddOdMsg()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //获取文本框信息
            string txtCustomerMsg = txtCustomer.Text;
            string txtGoodsMsg = txtGoods.Text; 
            string txtNumsMsg = txtNums.Text;
            string txtCustomerIdMsg = txtCustomerId.Text;

            //判断电话号码输入是否符合格式
            Regex rx = new Regex("[0-9]{11}");
            bool ok = rx.IsMatch(txtCustomerIdMsg);
            if (!ok)
            {
                errorProvider1.SetError(txtCustomerId, "电话号码格式错误");
            }

            //判断文本框信息是否为空
            if (txtCustomerMsg != null && txtGoodsMsg != null && txtNums.Text != null)
            {
                
                customer.Id = txtCustomerIdMsg;
                customer.Name = txtCustomerMsg;
                txtCustomerId.Enabled = false;
                txtCustomer.Enabled = false;

                Goods good = new Goods(goodID.ToString() + dateString, txtGoodsMsg, 0);
                goodID++;
                OrderDetail orderDetail = new OrderDetail(orderDetailID.ToString()+dateString, good, (uint)Convert.ToInt32(txtNumsMsg));
                orderDetailID++;

                order.Customer = customer;
                order.Details.Add(orderDetail); 
            }

            
        }


        public void ShowF2(MainForm1 form1,OrderService os)
        {
            this.Show();
            this.orderList = form1.orderList;
            this.os = os;
        }

        private void FrmAddOdMsg_Load(object sender, EventArgs e)
        { 
            goodID = 1;
            orderDetailID = 1;
            order.Id = orderID.ToString() + dateString;
        }

        private void labCustomer_Click(object sender, EventArgs e)
        {

        }

        private void FrmAddOdMsg_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void FrmAddOdMsg_FormClosed(object sender, FormClosedEventArgs e)
        {
            os.Add(order);
            orderID++;
            List<Order> orders = os.SaveOrders;
            ShowMessage.showOrderMessages(orders, orderList);//显示信息
        }
    }
}
