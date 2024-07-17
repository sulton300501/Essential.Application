using Essential.Application.Abstraction.Repository;
using Essential.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Infrastructure.Persistance.Repository
{
    public class EssentialRepository : IEssentialRepository
    {
        private readonly EssentialDbContext _context;

        public EssentialRepository(EssentialDbContext context)
        {
            _context = context;
        }

        public async Task<EssentialModels> Create(EssentialModels model)
        {
            var result = await _context.Essential.AddAsync(model);
            await _context.SaveChangesAsync();
            return result.Entity;
        }

        public async Task<bool> Delete(int id)
        {

            var result = await _context.Essential.FirstOrDefaultAsync(x => x.Id == id);
            _context.Essential.Remove(result);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<List<EssentialModels>> GetAll()
        {
               var result = await _context.Essential.ToListAsync();
            return result;
        }

        public async Task<EssentialModels> GetById(int id)
        {
            var result = await _context.Essential.FirstOrDefaultAsync(x => x.Id == id);
           
            return result;
        }

        public async Task<EssentialModels> GetByEngWord(string engWord)
        {
            // ToLower() ni ishlatib, qidiruv har ikkala tomon uchun ham kichik harflarda bo'lishini ta'minlash
            var result = await _context.Essential
                                       .Where(e => e.EngWord.ToLower() == engWord.ToLower())
                                       .FirstOrDefaultAsync();

            return result;
        }


        public async Task<EssentialModels> UpdateAsync(int id ,EssentialModels model)
        {
            var result = await _context.Essential.FirstOrDefaultAsync(x => x.Id == id);


         

            var actor = new EssentialModels()
            {
                BookName = model.BookName,
                BookNumber = model.BookNumber,
                UnitNumber= model.UnitNumber,
                EngWord = model.EngWord,
                UzbWord = model.UzbWord,
                RusWord = model.RusWord,
            };

            var result2 = _context.Essential.Update(actor);
            await _context.SaveChangesAsync();
            return result2.Entity;

        }

        public async Task<List<EssentialModels>> GetByBookNameAndBookNumberAndUnitNumber(string bookName, int bookNumber, int unitNumber)
        {

            var result = await _context.Essential
                .Where(x => (x.BookName.ToLower() == bookName.ToLower() && x.BookNumber == bookNumber) &&  x.UnitNumber == unitNumber).ToListAsync();
            return result;

        }
    }
}
