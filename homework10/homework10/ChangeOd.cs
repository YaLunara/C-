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
    public partial class FrmChangeOdMsg : Form
    {
        ListView orderList = new ListView();
        private string odId;
        private string detailId;
        private OrderService os;
        public FrmChangeOdMsg()
        {
            InitializeComponent();
        }

        public void ShowF3(string customerName,string goodName,string quantity,string odId,string detailId,MainForm1 form,OrderService os)
        {
            this.txtCustomer.Text = customerName;
            this.txtGoods.Text = goodName;
            this.txtNums.Text = quantity;
            this.odId = odId;
            this.detailId = detailId;
            this.orderList = form.orderList;
            this.Show();
            this.os = os;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(txtCustomer != null && txtGoods != null && txtNums.Text != null)
            {
                Order changedOd = os.GetOrder(odId);
                changedOd.Customer.Name = txtCustomer.Text;
                foreach(OrderDetail odDetail in changedOd.Details)
                {
                    if(odDetail.Id.Equals(detailId))
                    {
                        odDetail.Goods.Name = txtGoods.Text;
                        odDetail.Quantity = Convert.ToUInt32(txtNums.Text);
                        break;
                    }
                }
                os.Update(changedOd);
                List<Order> SaveOrders = os.SaveOrders;
                foreach(Order order in SaveOrders)
                {
                    if(order.Id.Equals(changedOd.Id))
                    {
                        order.Customer.Name = changedOd.Customer.Name;
                        order.Details = changedOd.Details;
                        break;
                    }
                }
                ShowMessage.showOrderMessages(SaveOrders,orderList);
            }    
        }

        private void FrmChangeOdMsg_Load(object sender, EventArgs e)
        {

        }
        private void txtCustomer_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
