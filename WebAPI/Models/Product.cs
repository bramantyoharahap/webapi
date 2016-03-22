using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Serialization;

namespace WebAPI.Models
{
    
    public class Product
    {
        [XmlElement("Id")]
        public int Id { get; set; }

        [XmlElement("Description")]
        public string Description { get; set; }
    }
}