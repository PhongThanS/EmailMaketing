using FluentValidation;
using MyEmailMaketing.Models;
using System.Text.RegularExpressions;

namespace MyEmailMaketing.Repository.Validators
{
    public class CustomerCreatedValidator : AbstractValidator<Customer>
    {
        public CustomerCreatedValidator()
        {
            RuleFor(c => c.Name).NotEmpty().WithMessage("Tên khách hàng không để trống");
            RuleFor(c => c.Gender).Must(g =>
            {
                if (!string.IsNullOrEmpty(g))
                {
                    List<string> genders = new List<string> { "Nam", "Nữ", "Khác" };
                    return genders.Contains(g);
                }
                else
                {
                    return true;
                }
            }).WithMessage("Giới tính chưa đúng");
            RuleFor(c => c.Phone).Must(p =>
            {
                if (!string.IsNullOrEmpty(p))
                {
                    return Regex.IsMatch(p, @"^(03|05|07|08|09)+([0-9]{8})\b");
                }
                else
                {
                    return true;
                }
            }).WithMessage("Số điện thoại không đúng");
            RuleFor(c => c.Email).Must(e =>
            {
                if (!string.IsNullOrEmpty(e))
                {
                    return Regex.IsMatch(e, "^\\S+@\\S+\\.\\S+$");
                }
                else
                {
                    return true;
                }
            }).WithMessage("Email chưa đúng");
        }
    }
}
