using BSWTranslationTools.API.Data;
using BSWTranslationTools.API.Entities;
using BSWTranslationTools.API.Repository.Contracts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
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
        public async Task<bool> Create(JsonDetailsKey entity)
        {
            await _db.jsonDetailsKey.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(JsonDetailsKey entity)
        {
            _db.jsonDetailsKey.Remove(entity);
            return await Save();
        }

        public int ExecuteProcJsonSimulation()
        {
            string SQLQuery = $"EXECUTE ProcJsonSimulation";
            var JsonDetails = _db.Database.ExecuteSqlRaw(SQLQuery);
            return JsonDetails;
        }

        [Obsolete]
        public string ExportRecords()
        {
            Microsoft.Data.SqlClient.SqlParameter Param1 = new Microsoft.Data.SqlClient.SqlParameter();
            Param1.ParameterName = "@result";
            Param1.SqlDbType = SqlDbType.NVarChar;
            Param1.Size = 2048;
            Param1.Direction = ParameterDirection.Output;
            Param1.Value = -1;
            var sprocResponse =  _db.Database.ExecuteSqlCommand("[dbo].[ExportRecordFromJSonTables]  @result = @result OUTPUT", new object[] { Param1 });
            string outPutVal = Param1.Value.ToString();
            return outPutVal;
        }

        public  void WriteToFile(string filePath,string content)
        {
            //using (var writer = File.CreateText(filePAth))
            //{
            //    await writer.WriteLineAsync(content);
            //}
            if (File.Exists(filePath))
            {
                File.Delete(filePath);
            }

            // Create a new file     
            using (StreamWriter sw = File.CreateText(filePath))
            {
                sw.WriteLine(content);
                
            }
        }
        public async Task<IList<JsonDetailsKey>> FindAll()
        {
            var JsonDetails = await _db.jsonDetailsKey.ToListAsync();
            return JsonDetails;
        }

        public async Task<JsonDetailsKey> FindById(int id)
        {
            var JsonDetails = await _db.jsonDetailsKey.FindAsync(id);
            return JsonDetails;
        }

        public async Task<IList<JsonDetailsKey>> FindFaultStatus()
        {
            var JsonDetails = await _db.jsonDetailsKey.Where(q => q.Status != "Ok").ToListAsync();
            return JsonDetails;
        }

        public async Task<bool> isExist(int id)
        {
            return await _db.jsonDetailsKey.AnyAsync(q => q.JsonKeyID == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(JsonDetailsKey entity)
        {
            _db.jsonDetailsKey.Update(entity);
            return await Save();
        }
    }
}
