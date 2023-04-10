using MyEmailMaketing.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyEmailMaketing.Repository.Interfaces
{
    public interface IBaseRepos<TModel>
    {
        Task<MethodResult<IEnumerable<TModel>>> GetAllAsync();
        Task<MethodResult<TModel>> GetByIdAsync(string id);
        Task<MethodResult> CreateAsync(TModel TModel);
        Task<MethodResult> UpdateAsync(TModel TModel);
        Task<MethodResult> DeleteAsync(string id);
    }
}
