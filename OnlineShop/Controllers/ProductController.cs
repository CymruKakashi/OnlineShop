using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using OnlineShop.DataTransferModels;
using OnlineShop.Interfaces;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProductController : BaseApiController
    {

        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _service;

        public ProductController(ILogger<ProductController> logger, IProductService productService)
        {
            _logger = logger;
            _service = productService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                List<Product> products = await _service.GetProductsAsync();
                return Ok(products);
            }
            catch (Exception e) {
                _logger.LogError(e,$"Error getting Products. Exception: {e}");
                return ServerError(new MessageResponse() { Message = "Unexpected error has occurred" });
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody]ProductPriceUpdate priceUpdate)
        {
            try
            {
                await _service.SetProductPrice(priceUpdate);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error setting new Product price. Exception: {e}");
                return ServerError(new MessageResponse() { Message = "Unexpected error has occurred" });
            }
        }

        [HttpPost]
        [Route("upload")]
        public async Task<IActionResult> Upload([FromBody] List<ProductUpload> products)
        {
            try
            {
                await _service.UploadProducts(products);
                return Ok();
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error setting new Product price. Exception: {e}");
                return ServerError(new MessageResponse() { Message = "Unexpected error has occurred" });
            }
        }

        [HttpGet]
        [Route("export")]
        public async Task<IActionResult> Export()
        {
            try
            {
                string csv = await _service.ExportProducts();
                byte[] bytes = Encoding.ASCII.GetBytes(csv);
                return File(bytes, "text/csv", "Products.csv");
            }
            catch (Exception e)
            {
                _logger.LogError(e, $"Error setting new Product price. Exception: {e}");
                return ServerError(new MessageResponse() { Message = "Unexpected error has occurred" });
            }
        }
    }
}
