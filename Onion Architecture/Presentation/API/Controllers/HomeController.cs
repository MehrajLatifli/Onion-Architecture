
using Application.Repositories.Custom;
using Application.ViewModels.Products;
using Domain.Entities;
using Domain.Entities.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Persistence.Repositories.Custom;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {

        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository  _productReadRepository;
        readonly private ICustomerWriteRepository _customerWriteRepository;
        readonly private ICustomerReadRepository _customerReadRepository;
        readonly private IOrderWriteRepository _orderWriteRepository;
        readonly private IOrderReadRepository _orderReadRepository;

        public HomeController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository, ICustomerWriteRepository customerWriteRepository, ICustomerReadRepository customerReadRepository, IOrderWriteRepository orderWriteRepository, IOrderReadRepository orderReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
            _customerWriteRepository = customerWriteRepository;
            _customerReadRepository = customerReadRepository;
            _orderWriteRepository = orderWriteRepository;
            _orderReadRepository = orderReadRepository;
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


            var existingProduct = await _productReadRepository.GetByIdAsync(model.Id,false);

            if (existingProduct == null)
            {
                return NotFound(); 
            }

            var productToUpdate = new Product
            {
                Id = new Guid(model.Id),
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
        public async Task<IActionResult> Get()
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
        public async Task<IActionResult> GetById(string id)
        {


            var product = await _productReadRepository.GetByIdAsync(id,false);

            if (product == null)
            {
                return NotFound(); 
            }

            return Ok(product);

        }





        [HttpPost("customer")]
        public async Task<IActionResult> AddAsync2(VM_Create_Customer model)
        {

            _customerWriteRepository.AddAsync(new Customer
            {
                Name = model.Name,
            });

            await _customerWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("customer")]
        public async Task<IActionResult> Update2(VM_Update_Customer model)
        {
            if (!Guid.TryParse(model.Id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var existing = await _customerReadRepository.GetByIdAsync(model.Id, false);

            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Customer
            {
                Id = new Guid(model.Id),
                Name = model.Name,
            };

            _customerWriteRepository.Update(Update);
            await _customerWriteRepository.SaveAsync();




            return Ok();
        }



        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> Delete2(string id)
        {
            if (!Guid.TryParse(id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }

            await _customerWriteRepository.RemoveByIdAsync(id);
            await _customerWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpGet("customer")]
        public async Task<IActionResult> Get2()
        {

            IQueryable<Customer> datas = null;

            await Task.Run(() => {

                datas = _customerReadRepository.GetAll(false);
            });



            if (datas.Count() <= 0)
            {
                return NotFound();
            }


            return Ok(datas);

        }


        [HttpGet("customer/{id}")]
        public async Task<IActionResult> GetById2(string id)
        {


            var item = await _customerReadRepository.GetByIdAsync(id, false);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

        }




        [HttpPost("order")]
        public async Task<IActionResult> AddAsync3(VM_Create_Order model)
        {

            if (model.CustomeridFororder== new Guid( "3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            {
                return BadRequest("CustomeridFororder is not a valid Guid.");
            }

            if (model.ProductidFororder == new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            {
                return BadRequest("ProductidFororder is not a valid Guid.");
            }

            _orderWriteRepository.AddAsync(new Order
            {
                Description = model.Description,
                Address=model.Description,
                CustomeridFororder=model.CustomeridFororder,
                ProductidFororder=model.ProductidFororder,
            });

            await _orderWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("order")]
        public async Task<IActionResult> Update3(VM_Update_Order model)
        {
            if (!Guid.TryParse(model.Id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var existing = await _orderReadRepository.GetByIdAsync(model.Id, false);



            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Order
            {
                Id = new Guid(model.Id),
                Description = model.Description,
                Address = model.Description,
                CustomeridFororder = new Guid( model.CustomeridFororder),
                ProductidFororder = new Guid(model.ProductidFororder),
            };

            _orderWriteRepository.Update(Update);
            await _orderWriteRepository.SaveAsync();




            return Ok();
        }



        [HttpDelete("order/{id}")]
        public async Task<IActionResult> Delete3(string id)
        {
            if (!Guid.TryParse(id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }

            await _orderWriteRepository.RemoveByIdAsync(id);
            await _orderWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpGet("order")]
        public async Task<IActionResult> Get3()
        {

            IQueryable<Order> datas = null;

            await Task.Run(() => {

                datas = _orderReadRepository.GetAll(false);
            });



            if (datas.Count() <= 0)
            {
                return NotFound();
            }


            return Ok(datas);

        }


        [HttpGet("order/{id}")]
        public async Task<IActionResult> GetById3(string id)
        {


            var item = await _orderReadRepository.GetByIdAsync(id, false);

            if (item == null)
            {
                return NotFound();
            }

            return Ok(item);

        }
    }
}
