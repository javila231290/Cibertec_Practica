using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebDeveloper.DataAccess;
using WebDeveloper.Model;

namespace WebDeveloper.Helpers
{
    public static class CustomHelpers
    {
        public static List<Categories> DisplayCategoriesExtension(this HtmlHelper helper)
        {            
            return new CategorieData().GetList();
        }
        public static List<Categories> DisplayCategoriesStatic()
        {
            return new CategorieData().GetList();
        }

        public static List<Employees> DisplayEmployeesExtension(this HtmlHelper helper)
        {
            return new EmployeeData().GetList();
        }
        public static List<Employees> DisplayEmployeesStatic()
        {
            return new EmployeeData().GetList();
        }

        public static List<Customers> DisplayCustomersExtension(this HtmlHelper helper)
        {
            return new CustomerData().GetList();
        }
        public static List<Customers> DisplayCustomersStatic()
        {
            return new CustomerData().GetList();
        }

        //public static IHtmlString DisplayImageExtension(this HtmlHelper helper)
        //{
        //    return new HtmlString(GetHtmlImage(date));
        //}
        //private static string GetHtmlImage(DateTime? date)
        //{
        //    return $"<img width='100' height='100' src='@Url.Action("GetImage", "Categorie", new { id = item.CategoryID })' />";
        //}
    }
}