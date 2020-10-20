using BSWTranslationTools.API.Data;
using BSWTranslationTools.API.Entities;
using BSWTranslationTools.API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BSWTranslationTools.API.Repository
{
    public class JsonDetailsKeyRepository : IJsonDetailsKeyRepository
    {
        private readonly JsonDbContext _db;

        public JsonDetailsKeyRepository(JsonDbContext db)
        {
            _db = db;
        }
        public Task<bool> Create(JsonDetailsKey entity)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Delete(JsonDetailsKey entity)
        {
            throw new NotImplementedException();
        }

        public int ExecuteProcJsonSimulation()
        {
            throw new NotImplementedException();
        }

        public Task<IList<JsonDetailsKey>> FindAll()
        {
            throw new NotImplementedException();
        }

        public Task<JsonDetailsKey> FindById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IList<JsonDetailsKey>> FindFaultStatus()
        {
            var JsonDetails = await _db.jsonDetailsKey.Where(q => q.Status != "Ok").ToListAsync();
            return JsonDetails;
        }

        public Task<bool> isExist(int id)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Save()
        {
            throw new NotImplementedException();
        }

        public Task<bool> Update(JsonDetailsKey entity)
        {
            throw new NotImplementedException();
        }
    }
}
