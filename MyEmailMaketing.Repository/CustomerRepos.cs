using Microsoft.Extensions.Configuration;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;

namespace MyEmailMaketing.Repository
{
    public class CustomerRepos : BaseRepos<Customer>, ICustomerRepos
    {
        public CustomerRepos(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
