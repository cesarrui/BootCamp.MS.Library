using Bootcamp.MS.Library.Domain.Models;
using Bootcamp.MS.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.MS.Library.Application.Services
{
    public class AutorService
    {
        private readonly IAutorRepository _autorRepository;
        public AutorService(IAutorRepository autorRepository)
        {
            _autorRepository = autorRepository;

        }

        public async Task<Result<List<Autor>>> GetAll()
        {
            try
            {
                var res = await _autorRepository.GetAll();
                return new Result<List<Autor>>()
                {
                    Success = true,
                    Data = res.ToList()
                };
            }
            catch (Exception ex)
            {
                return new Result<List<Autor>>()
                {
                    Message = ex.Message
                };

            }

        }
    }
}
