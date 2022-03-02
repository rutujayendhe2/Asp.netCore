using Demo.Controllers;
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
            ProductsController controller = new ProductsController();

            var result = controller.Get();

            Assert.IsFalse(result.Count() == 0,"No records returned");
        }
    }
}
