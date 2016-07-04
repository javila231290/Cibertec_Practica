using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebDeveloper.Model;

namespace WebDeveloper.DataAccess
{
    public class EmployeeData : BaseDataAccess<Employees>
    {
        public Employees GetEmployeeById(int? id)
        {
            using (var dbContext = new WebContextDb())
            {
                return dbContext.Employees.Find(id);
            }
        }
    }
}
