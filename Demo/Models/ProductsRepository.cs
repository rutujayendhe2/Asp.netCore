using Microsoft.EntityFrameworkCore;
using Sabji_MartDbContext;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.Models
{
    public class ProductsRepository
    {
        Sabji_MartContext context = new Sabji_MartContext();


        public IEnumerable<Productlist> GetProducts()
        {
            return context.Productlists.ToList();
        }

        public IEnumerable<Productlist> AddProductlist(Productlist productlist)
        {
            var product1 = new Productlist();
            product1.Title = productlist.Title;
            product1.Price = productlist.Price;
            product1.Description = productlist.Description;
            product1.Category = productlist.Category;
            product1.Image = productlist.Image;
            product1.UpdatedAt = productlist.UpdatedAt;
            product1.CreatedAt = productlist.CreatedAt;

            try
            {
                context.Productlists.Add(productlist);
                context.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            var productinfo = context.Productlists.ToList();
            return productinfo;
        }

        //public void AddProductlist(Productlist productlist)
        //{
        //    context.Productlists.Add(productlist);
        //    context.SaveChanges();
        //}

        public Productlist GetProductId(int id)
        {
            return context.Productlists.Where(productlist => productlist.Id == id).FirstOrDefault();

        }
        public int getCount()
        {
            var count = context.Productlists.Count();
            return count;

        }


        public void UpdateProductlist(Productlist productlist)
        {
            context.Entry<Productlist>(productlist).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void DeleteProductRecord(int id)
        {
            var entity = context.Productlists.FirstOrDefault(t => t.Id == id);
            context.Productlists.Remove(entity);
            context.SaveChanges();
        }

    }
}

