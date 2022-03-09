using Demo.Controllers;
using Demo.Models;
using Microsoft.AspNetCore.Mvc;
using NUnit.Framework;
using System;
using System.Linq;

namespace Sabji
{
    [TestFixture]
    public class Class1
    {
        [Test]
        public void Test()
        {
            //Arrange
            ProductsController controller = new ProductsController();
            //Act
            var result = controller.Get();
            //Assert
            Assert.IsTrue(result.Count() > 0,"No records returned");
        }

      [Test]
        public void GetUser()
        {
            UsersController usersController = new UsersController();
            var result1 = usersController.Get();
            Assert.IsTrue(result1.Count() > 0, "User not found");
        }

        [Test]
        public void GetOrder()
        {
            OrdersController ordersController = new OrdersController();
            var result2 = ordersController.GetOrderRecord();
            Assert.IsTrue(result2.Equals(result2));
        }


        [Test]
        public void GetUserByid()
        {
            UsersController usersController = new UsersController();
            var id = 2;
            var result1 = usersController.Details(id);
            Assert.IsTrue(result1.Equals(result1));
        }

        [Test]
        public void GetProductByid()
        {
            ProductsController controller = new ProductsController();
            var id = 2;
            var result = controller.Details(id);
            Assert.IsTrue(result.Equals(result));
        }

        [Test]
        public void GetOrderByid()
        {
            OrdersController ordersController = new OrdersController();
            var id = 4;
            var result3 = ordersController.Details(id);
            Assert.IsTrue(result3.Equals(result3));
        }

        [Test]
        public void DeleteProductByid()
        {
            ProductsController controller = new ProductsController();
            var id = 7;
            var result4 = controller.DeleteConfirmed(id);
            Assert.IsTrue(result4.Equals(result4));
        }


        [Test]
        public void DeleteOrderByid()
        {
            OrdersController ordersController = new OrdersController();
            var id = 6;
            var result4 = ordersController.DeleteConfirmed(id);
            Assert.IsTrue(result4.Equals(result4));
        }


        [Test]
        public void CreateOrder()
        {
            OrdersController ordersController = new OrdersController();
            var data=new Order();
            data.Fullname = "Pooja";
            data.Email = "pooja@gmail.com";
            data.Phone = "7689532576";
            data.City = "Mumbai";
            data.Zip = "42612";
            data.Address = "Mumbai";
            data.State = "Maharashtra";
            data.Country = "India";
            data.Status = "Pending";
            data.Totalprice = 545;
            data.CreatedAt = DateTime.Now;
            data.UpdatedAt = DateTime.Now;
            data.UserId = 3;

            var result4 = ordersController.AddOrderRecord(data);
            Assert.IsTrue(result4.Equals(result4),"data updated");
        }


        //[Test]
        //public void UpdateOrder()
        //{
        //    OrdersController ordersController = new OrdersController();

        //    var result = ordersController.Details(12);

        //    var data = new Order();
        //    data.Id = result.Id;
        //    data.Fullname = "Pooja";
        //    data.Email = result.Email;
        //    data.Phone = result.Phone;
        //    data.City = result.City;
        //    data.Zip = result.Zip;
        //    data.Address = "Nagpur";
        //    data.State = result.State;
        //    data.Country = result.Country;
        //    data.Status = result.Status;
        //    data.Totalprice = result.Totalprice;
        //    data.CreatedAt = DateTime.Now;
        //    data.UpdatedAt = DateTime.Now;
        //    data.UserId = result.UserId;

        //    var result4 = ordersController.Edit(data);

        //    Assert.IsTrue(result4.Equals(result4), "data is not updated");
        //}


    }
}
