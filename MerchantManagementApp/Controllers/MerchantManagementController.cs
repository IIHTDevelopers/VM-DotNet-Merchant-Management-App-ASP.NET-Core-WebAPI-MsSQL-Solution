using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MerchantManagementApp.BusinessLayer.Interfaces;
using MerchantManagementApp.BusinessLayer.ViewModels;
using MerchantManagementApp.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;
using ManagementApp.Entities;

namespace MerchantManagementApp.Controllers
{
    [ApiController]
    public class MerchantManagementController : ControllerBase
    {
        private readonly IMerchantManagementService  _merchantService;
        public MerchantManagementController(IMerchantManagementService merchantservice)
        {
             _merchantService = merchantservice;
        }

        [HttpPost]
        [Route("create-merchant")]
        [AllowAnonymous]
        public async Task<IActionResult> CreateMerchant([FromBody] Merchant model)
        {
            var MerchantExists = await  _merchantService.GetMerchantById(model.MerchantId);
            if (MerchantExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Merchant already exists!" });
            var result = await  _merchantService.CreateMerchant(model);
            if (result == null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Status = "Error", Message = "Merchant creation failed! Please check details and try again." });

            return Ok(new Response { Status = "Success", Message = "Merchant created successfully!" });

        }


        [HttpPut]
        [Route("update-merchant")]
        public async Task<IActionResult> UpdateMerchant([FromBody] MerchantViewModel model)
        {
            var Merchant = await  _merchantService.UpdateMerchant(model);
            if (Merchant == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Merchant With Id = {model.MerchantId} cannot be found" });
            }
            else
            {
                var result = await  _merchantService.UpdateMerchant(model);
                return Ok(new Response { Status = "Success", Message = "Merchant updated successfully!" });
            }
        }

      
        [HttpDelete]
        [Route("delete-merchant")]
        public async Task<IActionResult> DeleteMerchant(long id)
        {
            var Merchant = await  _merchantService.GetMerchantById(id);
            if (Merchant == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Merchant With Id = {id} cannot be found" });
            }
            else
            {
                var result = await  _merchantService.DeleteMerchantById(id);
                return Ok(new Response { Status = "Success", Message = "Merchant deleted successfully!" });
            }
        }


        [HttpGet]
        [Route("get-merchant-by-id")]
        public async Task<IActionResult> GetMerchantById(long id)
        {
            var Merchant = await  _merchantService.GetMerchantById(id);
            if (Merchant == null)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new Response
                { Status = "Error", Message = $"Merchant With Id = {id} cannot be found" });
            }
            else
            {
                return Ok(Merchant);
            }
        }

        [HttpGet]
        [Route("get-all-merchants")]
        public async Task<IEnumerable<Merchant>> GetAllMerchants()
        {
            return   _merchantService.GetAllMerchants();
        }
    }
}
