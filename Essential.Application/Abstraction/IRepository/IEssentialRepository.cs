using Essential.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Application.Abstraction.Repository
{
    public interface IEssentialRepository
    {
        public Task<EssentialModels> Create(EssentialModels model);
        public Task<EssentialModels> UpdateAsync(int id ,EssentialModels model);
        public Task<bool> Delete(int id);
        public Task<List<EssentialModels>> GetAll();
        public Task<EssentialModels> GetById(int id);

        public Task<EssentialModels> GetByEngWord(string name);

        
        public Task<List<EssentialModels>> GetByBookNameAndBookNumberAndUnitNumber(string bookName, int bookNumber, int unitNumber);

    }
}
