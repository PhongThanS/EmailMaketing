using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmailMaketing.Repository
{
    public class EmailRepos : BaseRepos<Email>, IEmailRepos
    {
        public EmailRepos(IConfiguration configuration) : base(configuration)
        {
        }
    }
}
