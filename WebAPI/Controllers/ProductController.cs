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
        private IEnumerable<Product> products;
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
            XmlTextReader reader = new XmlTextReader(HttpContext.Current.Server.MapPath("~/App_Data/Product.xml"));
            XmlSerializer serializer = new XmlSerializer(typeof(List<Product>));
            using (FileStream stream = File.OpenRead(HttpContext.Current.Server.MapPath("~/App_Data/Product.xml")))
            {
                products = (List<Product>)serializer.Deserialize(stream);
            }

            //var productList = from c in XElement.Load(System.Web.Hosting.HostingEnvironment.MapPath("~/App_Data/Product.xml")).Elements("Products")
            //           select c;
            //List<Product> _productsList = new List<Product>();

            //foreach (var item in productList)
            //{
            //    _productsList.Add(new Product() {
            //        Id = int.Parse(item.Element("Id").Value),
            //        Description = item.Element("Description").Value
            //    });

            //}
            //products = _productsList;
        }
    }
}
