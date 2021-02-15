using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityFrameWork
{
    class ProductDal
    {
        public List<Product> GetAll()
        {
            using (ETraceContext context = new ETraceContext()) //method bittiği zaman dat.net in memory yöneticisi bunu bellekten atmaya başlar
                                                                //using ,dispose ediyor atmaya çalışıyor bunu memoryden önce
            {
                return context.Products.ToList(); //veritabanındaki tabloya erişim kodu
            }
        }

        public void Add(Product product)
        {
            using (ETraceContext context = new ETraceContext()) //method bittiği zaman dat.net in memory yöneticisi bunu bellekten atmaya başlar
                                                                //using ,dispose ediyor atmaya çalışıyor bunu memoryden önce
            {
                context.Products.Add(product);
                context.SaveChanges();
            }
        }

        public void Update(Product product)
        {
            using (ETraceContext context = new ETraceContext()) //method bittiği zaman dat.net in memory yöneticisi bunu bellekten atmaya başlar
                                                                //using ,dispose ediyor atmaya çalışıyor bunu memoryden önce
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Modified;
                context.SaveChanges();
            }
        }

        public void Delete(Product product)
        {
            using (ETraceContext context = new ETraceContext()) //method bittiği zaman dat.net in memory yöneticisi bunu bellekten atmaya başlar
                                                                //using ,dispose ediyor atmaya çalışıyor bunu memoryden önce
            {
                var entity = context.Entry(product);
                entity.State = EntityState.Deleted;
                context.SaveChanges();
            }
        }
    }
}
