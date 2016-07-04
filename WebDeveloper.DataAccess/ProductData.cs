using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class ProductData : BaseDataAccess<Products>
    {
        public Products GetProductById(int? id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Products.Find(id);
            }
        }
    }
}
