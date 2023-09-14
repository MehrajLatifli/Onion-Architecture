
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
                name = model.name,
                price = model.price,
                stock = model.stock,
            });

            await _productWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("product")]
        public async Task<IActionResult> Update(VM_Update_Product model)
        {
            if (!Guid.TryParse(model.id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var existingProduct = await _productReadRepository.GetByIdAsync(model.id,false);

            if (existingProduct == null)
            {
                return NotFound(); 
            }

            var productToUpdate = new Product
            {
                id = new Guid(model.id),
                name = model.name,
                price = model.price,
                stock = model.stock,
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
                name = model.name,
            });

            await _customerWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("customer")]
        public async Task<IActionResult> Update2(VM_Update_Customer model)
        {
            if (!Guid.TryParse(model.id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var existing = await _customerReadRepository.GetByIdAsync(model.id, false);

            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Customer
            {
                id = new Guid(model.id),
                name = model.name,
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

            if (model.customerid_fororder== new Guid( "3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            {
                return BadRequest("customeridFororder is not a valid Guid.");
            }

            if (model.productid_fororder == new Guid("3fa85f64-5717-4562-b3fc-2c963f66afa6"))
            {
                return BadRequest("ProductidFororder is not a valid Guid.");
            }

            _orderWriteRepository.AddAsync(new Order
            {
                description = model.description,
                address=model.address,
                customerid_fororder=model.customerid_fororder,
                productid_fororder=model.productid_fororder,
            });

            await _orderWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("order")]
        public async Task<IActionResult> Update3(VM_Update_Order model)
        {
            if (!Guid.TryParse(model.id, out Guid idGuid))
            {
                return BadRequest("Id is not a valid Guid.");
            }


            var existing = await _orderReadRepository.GetByIdAsync(model.id, false);



            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Order
            {
                id = new Guid(model.id),
                description = model.description,
                address = model.address,
                customerid_fororder = new Guid( model.customerid_fororder),
                productid_fororder = new Guid(model.productid_fororder),
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
