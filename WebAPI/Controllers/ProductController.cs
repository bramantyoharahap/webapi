using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using WebAPI.Models;
using System.Xml;
using System.IO;
using System.Web;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace WebAPI.Controllers
{
    public class ProductController : ApiController
    {
        private List<Product> products;
        protected override void Initialize(HttpControllerContext controllerContext)
        {
            base.Initialize(controllerContext);
            GetProducts();
        }

        public Product Get(int Id)
        {
            return products.SingleOrDefault(p => p.Id == Id);
        }

        public List<Product> GetAll()
        {
            return products.ToList();
        }

        private void GetProducts()
        {
            XmlSerializer deserializer = new XmlSerializer(typeof(List<Product>), new XmlRootAttribute("Products"));
            
            //var doc = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Product.xml"));
            //products = (from r in doc.Root.Elements("Product")
            //            select new Product()
            //            {
            //                Id = (int)r.Element("Id"),
            //                Description = (string)r.Element("Description")
            //            }).ToList();

            using (var stream = new StreamReader(HttpContext.Current.Server.MapPath("~/App_Data/Product.xml")))
            //var xmlString = XDocument.Load(HttpContext.Current.Server.MapPath("~/App_Data/Product.xml")).ToString();
            //using (var stream = new StringReader(xmlString))
            {
                products = (List<Product>)deserializer.Deserialize(stream);
            }
            
        }
    }
}
