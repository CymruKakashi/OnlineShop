using System;
using System.Collections.Generic;
using System.Linq;
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
    }
}
