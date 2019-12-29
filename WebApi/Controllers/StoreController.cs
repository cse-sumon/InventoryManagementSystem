using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OA.Data;
using OA.Service.Interfaces;
using WebApi.Models;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StoreController : ControllerBase
    {
        private readonly IStoreService _storeService;

        public StoreController(IStoreService storeService)
        {
            _storeService = storeService;
        }


        // GET: api/Service
        [HttpGet]
        public IActionResult GetAllStores()
        {
            try
            {
                var store = _storeService.GetStores();
                List<StoreViewModel> storeVmList = store.Select(x => new StoreViewModel
                {
                    Id = x.Id,
                    Code = x.Code,
                    Name = x.Name,
                    Email = x.Email,
                    Mobile = x.Mobile,
                    RegistrationNumber = x.RegistrationNumber,
                    Address = x.Address,
                    CreatedAt = x.CreatedAt
                   
                }).ToList();
                return Ok(storeVmList);
            }
            catch (Exception)
            {
                throw;
            }
        }



        // GET: api/Service/1
        [HttpGet("{id}")]
        public IActionResult GetStore(int id)
        {
            try
            {
                var store = _storeService.GetStore(id);
                if (store == null)
                {
                    return NotFound();
                }
                StoreViewModel model = new StoreViewModel()
                {
                    Id = store.Id,
                    Code = store.Code,
                    Name = store.Name,
                    Email = store.Email,
                    Mobile = store.Mobile,
                    RegistrationNumber = store.RegistrationNumber,
                    Address = store.Address,
                    CreatedAt = store.CreatedAt
                };
                return Ok(model);
            }
            catch (Exception)
            {

                throw;
            }
        }



        // Post: api/Service
        [HttpPost]
        public IActionResult PostStore(StoreViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }
            Store store = new Store
            {
                Code = model.Code,
                Name = model.Name,
                Email = model.Email,
                Mobile = model.Email,
                RegistrationNumber = model.RegistrationNumber,
                Address = model.Address,
                CreatedAt = DateTime.UtcNow
            };
            try
            {
                _storeService.InsertStore(store);
                return Ok();
            }
            catch (Exception)
            {

                throw;
            }
        }



        // PUT: api/Service/5
        [HttpPut("{id}")]
        public IActionResult PutStore(int id, StoreViewModel model)
        {
            if (id != model.Id)
            {
                return BadRequest(model);
            }
            if (!ModelState.IsValid)
            {
                return BadRequest(model);
            }

            Store store = new Store()
            {
                Id = model.Id,
                Code = model.Code,
                Name = model.Name,
                Email = model.Email,
                Mobile = model.Email,
                RegistrationNumber = model.RegistrationNumber,
                Address = model.Address,
                CreatedAt = model.CreatedAt
            };

            try
            {
                _storeService.UpdateStore(store);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }



        // Delete: api/Service/5
        [HttpDelete("{id}")]
        public IActionResult DeleteStore(int id)
        {
            if (id <= 0)
            {
                return BadRequest();
            }
            var store = _storeService.GetStore(id);
            if (store == null)
            {
                return NotFound();
            }
            try
            {
                store.IsDeleted = true;
                _storeService.SoftDeleteStore(store);
                return NoContent();
            }
            catch (Exception)
            {
                throw;
            }
        }




        //// Delete: api/Service/5
        //[HttpDelete("{id}")]
        //public IActionResult DeleteService(int id)
        //{
        //    var Service = storeService.GetService(id);
        //    if (Service == null)
        //    {
        //        return BadRequest();
        //    }
        //    try
        //    {
        //        storeService.DeleteService(id);
        //        return NoContent();
        //    }
        //    catch (Exception)
        //    {
        //        throw;
        //    }
        //}
    }
}