using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;
using MyEmailMaketing.Common.Models;
using MyEmailMaketing.Models;
using MyEmailMaketing.Repository.Interfaces;

namespace MyEmailMaketing.Repository
{
    public abstract class BaseRepos<TModel> : IBaseRepos<TModel> where TModel : BaseModel
    {
        private readonly IMongoCollection<TModel> _collection;

        public BaseRepos(IConfiguration configuration)
        {
            var url = configuration.GetSection("MongoDB:ConnectionURI").Value;
            MongoClient client = new MongoClient(configuration.GetSection("MongoDB:ConnectionURI").Value);
            IMongoDatabase database = client.GetDatabase(configuration.GetSection("MongoDB:DatabaseName").Value);
            _collection = database.GetCollection<TModel>(typeof(TModel).Name);
        }

        public async Task<MethodResult<IEnumerable<TModel>>> GetAllAsync()
        {
            try
            {
                var data = await _collection.Find(new BsonDocument()).ToListAsync();
                return MethodResult<IEnumerable<TModel>>.ResultWithData(data);
            }
            catch (Exception ex)
            {
                return MethodResult<IEnumerable<TModel>>.ResultWithError(ex.ToString());
            }
        }

        public async Task<MethodResult<TModel>> GetByIdAsync(string id)
        {
            try
            {
                FilterDefinition<TModel> filter = Builders<TModel>.Filter.Eq("Id", id);
                var data = await _collection.Find(filter).ToListAsync();
                if (data is not null)
                {
                    return MethodResult<TModel>.ResultWithData(data.FirstOrDefault());
                }
                else
                {
                    return MethodResult<TModel>.ResultWithNotFound();
                }
            }
            catch (Exception ex)
            {
                return MethodResult<TModel>.ResultWithError(ex.ToString());
            }
        }

        public async Task<MethodResult> CreateAsync(TModel TModel)
        {
            try
            {
                await _collection.InsertOneAsync(TModel);
                return MethodResult.ResultWithSuccess();
            }
            catch (Exception ex)
            {
                return MethodResult.ResultWithError(ex.ToString());
            }
        }

        public async Task<MethodResult> UpdateAsync(TModel TModel)
        {
            try
            {
                var result = await _collection.ReplaceOneAsync(t => t.Id == TModel.Id, TModel);
                return MethodResult.ResultWithSuccess(result + "");
            }
            catch (Exception ex)
            {
                return MethodResult.ResultWithError(ex.ToString());
            }
        }

        public async Task<MethodResult> DeleteAsync(string id)
        {
            try
            {
                FilterDefinition<TModel> filter = Builders<TModel>.Filter.Eq("Id", id);
                await _collection.DeleteOneAsync(filter);
                return MethodResult.ResultWithSuccess();
            }
            catch (Exception ex)
            {
                return MethodResult.ResultWithError(ex.ToString());
            }
        }
    }
}
