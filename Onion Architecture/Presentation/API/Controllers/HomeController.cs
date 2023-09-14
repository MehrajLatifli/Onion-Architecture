
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
                Name = model.name,
                Price = model.price,
                Stock = model.stock,
            });

            await _productWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("product")]
        public async Task<IActionResult> Update(VM_Update_Product model)
        {
       


            var existingProduct = await _productReadRepository.GetByIdAsync(model.id.ToString(),false);

            if (existingProduct == null)
            {
                return NotFound(); 
            }

            var productToUpdate = new Product
            {
                Id = model.id,
                Name = model.name,
                Price = model.price,
                Stock = model.stock,
            };

            _productWriteRepository.Update(productToUpdate);
            await _productWriteRepository.SaveAsync();




            return Ok();
        }



        [HttpDelete("product/{id}")]
        public async Task<IActionResult> Delete(string id)
        {

            if (_productReadRepository.GetAll().Any(i => i.Id == Convert.ToInt32(id)))
            {

                await _productWriteRepository.RemoveByIdAsync(id);
                await _productWriteRepository.SaveAsync();

                return Ok();
            }

            else
            {
                return BadRequest();
            }

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
                Name = model.name,
            });

            await _customerWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("customer")]
        public async Task<IActionResult> Update2(VM_Update_Customer model)
        {
      


            var existing = await _customerReadRepository.GetByIdAsync(model.id.ToString(), false);

            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Customer
            {
                Id = model.id,
                Name = model.name,
            };

            _customerWriteRepository.Update(Update);
            await _customerWriteRepository.SaveAsync();




            return Ok();
        }



        [HttpDelete("customer/{id}")]
        public async Task<IActionResult> Delete2(string id)
        {
            if (_customerReadRepository.GetAll().Any(i => i.Id == Convert.ToInt32(id)))
            {

                await _customerWriteRepository.RemoveByIdAsync(id);
                await _customerWriteRepository.SaveAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }

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



            _orderWriteRepository.AddAsync(new Order
            {
                Description = model.description,
                Address=model.address,
                CustomerId_forOrder=model.customerid_fororder,
                ProductId_forOrder=model.productid_fororder,
            });

            await _orderWriteRepository.SaveAsync();

            return Ok();

        }


        [HttpPut("order")]
        public async Task<IActionResult> Update3(VM_Update_Order model)
        {
    


            var existing = await _orderReadRepository.GetByIdAsync(model.id.ToString(), false);



            if (existing == null)
            {
                return NotFound();
            }

            var Update = new Order
            {
                Id = model.id,
                Description = model.description,
                Address = model.address,
                CustomerId_forOrder = model.customerid_fororder,
                ProductId_forOrder =model.customerid_fororder,
            };

            _orderWriteRepository.Update(Update);
            await _orderWriteRepository.SaveAsync();




            return Ok();
        }



        [HttpDelete("order/{id}")]
        public async Task<IActionResult> Delete3(string id)
        {
            if (_orderReadRepository.GetAll().Any(i => i.Id == Convert.ToInt32(id)))
            {


                await _orderWriteRepository.RemoveByIdAsync(id);
                await _orderWriteRepository.SaveAsync();

                return Ok();
            }
            else
            {
                return BadRequest();
            }


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
