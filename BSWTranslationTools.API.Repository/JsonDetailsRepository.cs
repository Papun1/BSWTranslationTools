using BSWTranslationTools.API.Data;
using BSWTranslationTools.API.Entities;
using BSWTranslationTools.API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace BSWTranslationTools.API.Repository
{
   
    public class JsonDetailsRepository : IJsonDetailsRepository
    {
        private readonly JsonDbContext _db;

        public JsonDetailsRepository(JsonDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(JsonDetails entity)
        {

            await _db.jsonDetails.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(JsonDetails entity)
        {
            _db.jsonDetails.Remove(entity);
            return await Save();
        }

        public async Task<IList<JsonDetails>> FindAll()
        {
            var JsonDetails = await _db.jsonDetails.ToListAsync();
            return JsonDetails;
        }

        public async Task<JsonDetails> FindById(int id)
        {
            var JsonDetails = await _db.jsonDetails.FindAsync(id);
            return JsonDetails;
        }


        public async Task<bool> isExist(int id)
        {
            return await _db.jsonDetails.AnyAsync(q => q.JsonID == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }
      

        public async Task<bool> Update(JsonDetails entity)
        {
            _db.jsonDetails.Update(entity);
            return await Save();
        }

        public  int ExecuteProcJsonSimulation()
        {
            string SQLQuery = $"EXECUTE ProcJsonSimulation";
            var JsonDetails=  _db.Database.ExecuteSqlRaw(SQLQuery);
            return JsonDetails;
        }

        public async Task<IList<JsonDetails>> FindFaultStatus()
        {
            var JsonDetails = await _db.jsonDetails.Where(q=>q.Status !="Ok").ToListAsync();
            return JsonDetails;
        }
    }
    
}
