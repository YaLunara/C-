﻿using ordertest;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework7
{
    public partial class FrmAddOdMsg : Form
    {
        ListView orderList = new ListView();
        static int goodID = 1;
        static int customerID = 1;
        static int orderDetailID = 1;
        static int orderID = 1;

        public FrmAddOdMsg()
        {
            InitializeComponent();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            //获取文本框信息
            String txtCustomerMsg = txtCustomer.Text;
            String txtGoodsMsg = txtGoods.Text;
            int txtNumsMsg = Convert.ToInt32(txtNums.Text);

            if (txtCustomerMsg != null && txtGoodsMsg != null && txtNums.Text != null)
            {
                Customer customer = new Customer((uint)customerID, txtCustomerMsg);
                customerID++;
                Goods good = new Goods((uint)goodID, txtGoodsMsg, 0);
                goodID++;
                OrderDetail orderDetail = new OrderDetail((uint)orderDetailID, good, (uint)txtNumsMsg);
                orderDetailID++;
                Order order = new Order((uint)orderID, customer);
                orderID++;
                order.AddDetails(orderDetail);

                MainForm1.os.AddOrder(order);
            }

            getListMessages();
        }

        public void getListMessages()
        {
            orderList.Items.Clear();
            List<Order> orders = MainForm1.os.QueryAllOrders();
            foreach (Order od in orders)
            {
                foreach (OrderDetail odDetails in od.Details)
                {
                    ListViewItem item = new ListViewItem(od.Id.ToString());
                    item.SubItems.Add(od.Customer.Name);
                    item.SubItems.Add(od.Amount.ToString());
                    item.SubItems.Add(odDetails.Id.ToString());
                    item.SubItems.Add(odDetails.Goods.Id.ToString());
                    item.SubItems.Add(odDetails.Goods.Name);
                    item.SubItems.Add(odDetails.Goods.Price.ToString());
                    item.SubItems.Add(odDetails.Quantity.ToString());
                    orderList.Items.Add(item);
                }
            }
        }

        public void ShowF2(MainForm1 form1)
        {
            this.Show();
            this.orderList = form1.orderList;
        }

        private void FrmAddOdMsg_Load(object sender, EventArgs e)
        {

        }

        private void labCustomer_Click(object sender, EventArgs e)
        {

        }
    }
}
