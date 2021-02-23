using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace Api
{
    public class ProductGet
    {
        private readonly IProductData productData;
        public ProductGet(IProductData productData)
        {
            this.productData = productData;
        }
        [FunctionName("ProductGet")]
        public async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req)
        {
            var products = await productData.GetProducts();
            return new OkObjectResult(products);
        }
    }
}
