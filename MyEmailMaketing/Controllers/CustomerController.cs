using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyEmailMaketing.Common.Models;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;
using MyEmailMaketing.Repository.Validators;

namespace MyEmailMaketing.Controllers
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [AllowAnonymous]
    [ApiController]
    [ApiVersion("1.0")]
    public class CustomerController : Controller
    {
        ICustomerRepos _customerRepos;
        public CustomerController(ICustomerRepos customerRepos) : base()
        {
            _customerRepos = customerRepos;
        }

        [HttpGet("GetAll")]
        public async Task<MethodResult<IEnumerable<Customer>>> GetAll()
        {
            return await _customerRepos.GetAllAsync();
        }

        [HttpPost("Insert")]
        public async Task<MethodResult> Insert([FromBody] Customer customer)
        {
            var validator = new CustomerCreatedValidator();
            var validatorResult = await validator.ValidateAsync(customer);
            if (validatorResult.IsValid == false)
            {
                return MethodResult.ResultWithError(validatorResult.ToString());
            }
            return await _customerRepos.CreateAsync(customer);
        }

        [HttpPost("Update")]
        public async Task<MethodResult> Update([FromBody] Customer customer)
        {
            var validator = new CustomerUpdatedValidator(_customerRepos);
            var validatorResult = await validator.ValidateAsync(customer);
            if (validatorResult.IsValid == false)
            {
                return MethodResult.ResultWithError(validatorResult.ToString());
            }
            return await _customerRepos.UpdateAsync(customer);
        }

        [HttpPost("Delete")]
        public async Task<MethodResult> Delete(string id)
        {
            return await _customerRepos.DeleteAsync(id);
        }
    }
}
