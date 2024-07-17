using AutoMapper;
using Essential.Application.Abstraction.Repository;
using Essential.Domain.DTOs;
using Essential.Domain.Models;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Essential.Application.Abstraction.Services
{
    public class EssentialService : IEssentialService
    {

        private readonly IEssentialRepository _essentRepo;
        private readonly IMapper _mapper;
        
        public EssentialService(IEssentialRepository essentRepo, IMapper mapper)
        {
            _essentRepo = essentRepo;
            _mapper = mapper;
        }

        public async Task<EssentialModels> Create(EssentialModelDTO model)
        {
            var result = new EssentialModels()
            {
                BookName = model.BookName,
                BookNumber = model.BookNumber,
                UnitNumber = model.UnitNumber,
                EngWord = model.EngWord,
                UzbWord = model.UzbWord,
                RusWord= model.RusWord,
            };



          /*  var result2 = await _essentRepo.Create(result);
            return result2;*/

           /* var natija =  _mapper.Map<EssentialModels>(result);
            var result2 = await _essentRepo.Create(natija);

            return result2;*/

            var natija = model.Adapt<EssentialModels>();
            var result2 = await _essentRepo.Create(natija);
            return result2;

        }

        public async Task<bool> Delete(int id)
        {
            var result = await _essentRepo.Delete(id);
            return result;
        }

        public async Task<List<EssentialModels>> GetAll()
        {
            var result = await _essentRepo.GetAll();
            return result;
        }

        public async Task<List<EssentialModels>> GetByBookNameAndBookNumberAndUnitNumber(string bookName, int bookNumber, int unitNumber)
        {
            var result = await _essentRepo.GetByBookNameAndBookNumberAndUnitNumber(bookName, bookNumber, unitNumber);
            return result;
        }

        public async Task<EssentialModels> GetByEngWord(string name)
        {
           
            var result = await _essentRepo.GetByEngWord(name);
            return result;

        }

        public async Task<EssentialModels> GetById(int id)
        {
            var result = await _essentRepo.GetById(id);
            return result;
        }



        public async Task<EssentialModels> UpdateAsync(int id, EssentialModelDTO model)
        {

            var essent = new EssentialModels()
            {
                BookName = model.BookName,
                BookNumber = model.BookNumber,
                UnitNumber = model.UnitNumber,
                EngWord = model.EngWord,
                UzbWord = model.UzbWord,
            };

            var result = _essentRepo.UpdateAsync(id, essent);
            return result.Result;

        }


       /* public async Task<EssentialModels>*/




    }
}
