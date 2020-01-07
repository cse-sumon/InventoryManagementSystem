using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Repository.Interfaces;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreRepository _storeRepository;

        public StoreController(IStoreRepository storeRepository)
        {
            _storeRepository = storeRepository;
        }


        // GET: api/store
        [HttpGet]
        public IActionResult GetAllStores()
        {
            try
            {
                return Ok(_storeRepository.GetAll());
            }
            catch (Exception)
            {

                throw;
            }
        }



        // GET: api/store/1
        [HttpGet("{id}")]
        public IActionResult GetStore(int id)
        {
            if (id !> 0)
                return BadRequest();
            try
            {
                var store = _storeRepository.Get(id);
                if (store == null)
                    return NotFound();
                return Ok(store);
            }
            catch (Exception)
            {

                throw;
            }
               
        }



        // Post: api/store
        [HttpPost]
        public IActionResult PostStore(Store model)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _storeRepository.Update(model);
                    return Ok();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return BadRequest(model);
        }



        // PUT: api/store/5
        [HttpPut("{id}")]
        public IActionResult PutStore(int id, Store model)
        {
            if (id != model.Id)
            {
                return BadRequest(model);
            }
            if (ModelState.IsValid)
            {
                Store store = new Store()
                {
                    Id = model.Id,
                    Code = model.Code,
                    Name = model.Name,
                    Email = model.Email,
                    Mobile = model.Email,
                    RegistrationNumber = model.RegistrationNumber,
                    Address = model.Address,
                    CreatedAt = model.CreatedAt,
                    IsActive = model.IsActive
                };

                try
                {
                    _storeRepository.Update(store);
                    return Ok();
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return BadRequest(model);

        }



        // Delete: api/store/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            if (id !> 0)
            {
                return BadRequest();
            }

            try
            {
                var store = _storeRepository.Get(id);
                if (store == null)
                {
                    return NotFound();
                }
                _storeRepository.Delete(store);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }




        // Delete: api/store/5
        [HttpDelete("{id}")]
        public IActionResult ChangeStatus(int id)
        {
            var store = _storeRepository.Get(id);
            if (store == null)
            {
                return BadRequest();
            }
            try
            {
                if(store.IsActive==true? store.IsActive=false : store.IsActive = true)
                _storeRepository.Update(store);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}