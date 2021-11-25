using MVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace MVC.ViewModels
{
    public class ProductCatalogViewModel
    {
        public HttpResponseMessage httpResponseMessage { get; set; }

        public string RawDataFromHttpResponse { get; set; }


        public List<Product> Products { get; set; }
    }
}
