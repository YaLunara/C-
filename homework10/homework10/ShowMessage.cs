using ordertest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace homework10
{
    class ShowMessage
    {

        public static void showOrderMessages(List<Order> orders,ListView orderList)
        {
            orderList.Items.Clear();
            foreach (Order od in orders)
            {
                foreach (OrderDetail odDetails in od.Details)
                {
                    ListViewItem item = new ListViewItem(od.Id);
                    item.SubItems.Add(od.Customer.Name);
                    item.SubItems.Add(od.Amount.ToString());
                    item.SubItems.Add(odDetails.Id.ToString());
                    item.SubItems.Add(od.Customer.Id);
                    item.SubItems.Add(odDetails.Goods.Name);
                    item.SubItems.Add(odDetails.Goods.Price.ToString());
                    item.SubItems.Add(odDetails.Quantity.ToString());
                    orderList.Items.Add(item);
                }
            }
        }
    }
}
