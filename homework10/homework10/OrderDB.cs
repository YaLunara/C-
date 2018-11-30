namespace homework10
{
    using ordertest;
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class OrderDB : DbContext
    {
        public OrderDB()
            : base("OrderDataBase")
        {
        }

        public DbSet<Order> Order { set; get; }

        public DbSet<OrderDetail> OrderDetail { set; get; }

        public DbSet<Customer> Customer { set; get; }

        public DbSet<Goods> Goods { set; get; }

    }
}