using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using WebApi.Helpers;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using WebApi.Services;
using WebApi.Entities;
using WebApi.Models.Users;
using WebApi.Models.Retail;

namespace WebApi.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class RetailController : ControllerBase
    {
        private IUserService _userService;
        private IRetailService _retailService;
        private IMapper _mapper;
        private readonly AppSettings _appSettings;

        public RetailController(
            IRetailService retailService,
            IUserService userService,
            IMapper mapper,
            IOptions<AppSettings> appSettings)
        {
            _retailService = retailService;
            _userService = userService;
            _mapper = mapper;
            _appSettings = appSettings.Value;
        }

        [HttpPost("uploadHouseholds")]
        public IActionResult UploadHouseholds([FromBody]List<HouseholdModel> model)
        {
            var households = _mapper.Map<IList<Households>>(model);
            try
            {
                _retailService.UploadHousholds(households);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.StackTrace });
            }
        }    

        [HttpPost("uploadProducts")]
        public IActionResult UploadProducts([FromBody]List<ProductModel> model)
        {
            var products = _mapper.Map<IList<Products>>(model);
            try
            {
                _retailService.UploadProducts(products);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }    
        [RequestFormLimits(ValueLengthLimit = int.MaxValue, MultipartBodyLengthLimit = int.MaxValue)] 
        [DisableRequestSizeLimit] 
        [HttpPost("uploadTransactions")]
        public IActionResult UploadTransactions([FromBody]List<TransactionModel> model)
        {
            var transactions  = _mapper.Map<IList<Transactions>>(model);
            try
            {
                _retailService.UploadTransactions(transactions);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }    

        [HttpGet("{hshdNum}")]
        public IActionResult GetTransactionsByHshdNum(int hshdNum)
        {
            var household = _retailService.GetByHshdNum(hshdNum);
            var model = _mapper.Map<IList<TransactionModel>>(household);
            return Ok(model);
        }

        [AllowAnonymous]
        [HttpGet("test")]
        public IActionResult Test([FromBody]List<HouseholdModel> model)
        {
            var households = _mapper.Map<IList<Households>>(model);
            try
            {
                // create user
                _retailService.UploadHousholds(households);
                return Ok();
            }
            catch (AppException ex)
            {
                // return error message if there was an exception
                return BadRequest(new { message = ex.Message });
            }
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _retailService.Delete(id);
            return Ok();
        }

    }
}
