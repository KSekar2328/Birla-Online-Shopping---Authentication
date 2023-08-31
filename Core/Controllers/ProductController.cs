using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using CoreAuthentication.Interface;
using CoreAuthentication.Models;
using CoreAuthentication.Repository;
using CoreAuthentication.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Writers;

namespace CoreAuthentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProduct iProductRepository;

        public ProductController(IProduct iProductRepository)
        {
            this.iProductRepository = iProductRepository;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var products = await iProductRepository.GetAllProductAsync();

            return Ok(products);
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] Product product)
        {
            var createProduct = await iProductRepository.CreateAsync(product);

            return Ok(createProduct);
        }

        [HttpPut("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id, [FromBody] Product product)
        {
            var updateProduct = await iProductRepository.UpdateAsync(Id, product);

            if (updateProduct == null)
            {
                return NotFound();
            }

            return Ok(updateProduct);
        }

        [HttpDelete("{Id:int}")]
        public async Task<IActionResult> Update([FromRoute] int Id)
        {
            var deleteProduct = await iProductRepository.DeleteAsync(Id);

            if (deleteProduct == null)
            {
                return NotFound();
            }

            return Ok(deleteProduct);
        }
    }
}
