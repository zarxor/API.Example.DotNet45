// -------------------------------------------------------------------------------------------------
//  <copyright file="ProductsController.cs">
//      © 2017
//  </copyright>
// -------------------------------------------------------------------------------------------------

namespace API.Example.DotNet45.Controllers
{
    using System.Web.Http;
    using Microsoft.Web.Http;

    [ApiVersion("1.0")]
    [RoutePrefix("products")]
    public class ProductsController : ApiController
    {
        [HttpGet]
        [Route]
        public IHttpActionResult GetProducts()
        {
            return Ok(new[]
            {
                new Product
                {
                    Id = 1,
                    Name = "Test 1"
                },
                new Product
                {
                    Id = 2,
                    Name = "Test 2"
                }
            });
        }

        public class Product
        {
            public int Id { get; set; }
            public string Name { get; set; }
        }
    }
}