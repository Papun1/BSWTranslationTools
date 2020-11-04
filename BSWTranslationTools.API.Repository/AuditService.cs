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
    public class AuditService : IAudit_logs
    {
        private readonly JsonDbContext _db;

        public AuditService(JsonDbContext db)
        {
            _db = db;
        }

        public async Task<bool> Create(Audit_logs entity)
        {
            await _db.audit_Logs.AddAsync(entity);
            return await Save();
        }

        public async Task<bool> Delete(Audit_logs entity)
        {
            _db.audit_Logs.Remove(entity);
            return await Save();
        }

        public int ExecuteProcJsonSimulation()
        {
            throw new NotImplementedException();
        }

        public string ExportRecords()
        {
            throw new NotImplementedException();
        }

        public async Task<IList<Audit_logs>> FindAll()
        {
            var Users = await _db.audit_Logs.ToListAsync();
            return Users;
        }

        

        public async Task<Audit_logs> FindById(int id)
        {
            var Users = await _db.audit_Logs.FindAsync(id);
            return Users;
        }

        public Task<IList<Audit_logs>> FindByUserName(string UserName)
        {
            throw new NotImplementedException();
        }

        public Task<IList<Audit_logs>> FindFaultStatus()
        {
            throw new NotImplementedException();
        }

        public async Task<bool> isExist(int id)
        {
            return await _db.audit_Logs.AnyAsync(q => q.id == id);
        }

        public async Task<bool> Save()
        {
            var changes = await _db.SaveChangesAsync();
            return changes > 0;
        }

        public async Task<bool> Update(Audit_logs entity)
        {
            _db.audit_Logs.Update(entity);
            return await Save();
        }

        public void WriteToFile(string filePAth, string content)
        {
            throw new NotImplementedException();
        }
    }
  

}
