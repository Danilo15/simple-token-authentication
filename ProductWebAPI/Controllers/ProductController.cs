using ProductWebAPI.DAL;
using ProductWebAPI.Filters;
using ProductWebAPI.Models;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Results;
using System.Web.Mvc;

namespace ProductWebAPI.Controllers
{
    [CustomAuthorize]
    public class ProductController : ApiController
    {
        // GET api/values
        public IHttpActionResult GetProducts()
        {
            SistranContext context = new SistranContext();

            var products = context.Products.ToList().Select(p => new { p.Id, p.Nome, p.Descricao, p.Preco });

            return Ok(products);
        }
    }
}