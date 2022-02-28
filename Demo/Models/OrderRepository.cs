using Sabji_MartDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class OrderRepository
    {
        Sabji_MartContext context = new Sabji_MartContext();



        public IEnumerable<Order> AddOrderRecord(Order order)
        {
            var order1 = new Order();
            order1.Fullname = order.Fullname;
            order1.Address = order.Address;
            order1.City = order.City;
            order1.Country = order.Country;
            order1.Email = order.Email;
            order1.Phone = order.Phone;
            order1.State = order.State;
            order1.Status = order.Status;
            order1.Totalprice = order.Totalprice;
            order1.UpdatedAt = order.UpdatedAt;
            order1.CreatedAt = order.CreatedAt;
            order1.Zip = order.Zip;
            order1.UserId = order.UserId;

            try
            {
                context.Orders.Add(order);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var orderinfo = context.Orders.ToList();
            return orderinfo;
        }



        public void DeleteOrderRecord(int id)
        {
            var entity = context.Orders.FirstOrDefault(t => t.Id == id);
            context.Orders.Remove(entity);
            context.SaveChanges();
        }

        public IEnumerable<Order> GetOrderRecord()
        {
            var order1 =  context.Orders.ToList();

            if (order1.Count == 0)
            {
                return null;
            }

            return order1;

            //return JsonConvert.DeserializeObject<List<Order>>(order1);
            // return _context.orders.ToList();
        }

        public Order GetOrderSingleRecord(int id)
        {
            return context.Orders.FirstOrDefault(t => t.Id == id);
        }

        public void UpdateOrderRecord(Order order)
        {
            context.Orders.Update(order);
            context.SaveChanges();
        }








    }
}
