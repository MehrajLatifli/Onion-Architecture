
using Application.Repositories.Custom;
using Application.ViewModels.Products;
using Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Custom;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;

        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }



        [HttpPost("product")]
        public async Task<IActionResult> AddAsync(VM_Create_Product model)
        {

            _productWriteRepository.AddAsync(new Product
            {
                Name = model.Name,
                Price = model.Price,
                Stock = model.Stock,
            });

            await _productWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("product")]
        public async Task<IActionResult> Update(VM_Update_Product model)
        {
            if (!Guid.TryParse(model.Id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var product = await _productReadRepository.GetByIdAsync(model.Id,false);
          
                var productToUpdate = new Product
                {
                    Id = new Guid( model.Id),
                    Name = model.Name,
                    Price = model.Price,
                    Stock = model.Stock,
                };

                _productWriteRepository.Update(productToUpdate);
                await _productWriteRepository.SaveAsync();


            return Ok();
        }



        [HttpDelete("product/{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            if (!Guid.TryParse(id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }

            await _productWriteRepository.RemoveByIdAsync(id);
            await _productWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpGet("product")]
        public async Task<IActionResult> GetProducts()
        {

            IQueryable<Product> datas = null;

            await  Task.Run(() => {

               datas = _productReadRepository.GetAll(false);
          });


            if (datas.Count()<=0)
            {
                return NotFound();
            }


            return Ok(datas);

        }


        [HttpGet("product/{id}")]
        public async Task<IActionResult> GetProductById(string id)
        {


            var product = await _productReadRepository.GetByIdAsync(id,false);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product);

        }
    }
}
