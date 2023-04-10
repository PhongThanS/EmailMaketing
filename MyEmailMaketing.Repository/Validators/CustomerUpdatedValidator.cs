using FluentValidation;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;

namespace MyEmailMaketing.Repository.Validators
{
    public class CustomerUpdatedValidator : AbstractValidator<Customer>
    {
        private readonly ICustomerRepos _customerRepos;
        public CustomerUpdatedValidator(ICustomerRepos customerRepos)
        {
            _customerRepos = customerRepos;
            RuleFor(c => c.Id).NotNull().NotEmpty().MustAsync(async (id, token) =>
            {
                var result = await _customerRepos.GetByIdAsync(id ?? string.Empty);
                return result.Success;
            }).WithMessage("Không tìm thấy khách hàng");
            Include(new CustomerCreatedValidator());
        }
    }
}
