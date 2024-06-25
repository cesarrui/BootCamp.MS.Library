using Bootcamp.MS.Library.Domain.Models;
using Bootcamp.MS.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.MS.Library.Application.Services
{
    public class CategoriaService
    {
        private readonly ICategoriaRepository  _categoriaRepository;
        public CategoriaService(ICategoriaRepository categoriaRepository)
        {
            
            _categoriaRepository = categoriaRepository;

        }

        public async Task<Result<List<Categoria>>> GetAll()
        {
            try
            {
                var res = await _categoriaRepository.GetAll();
                return new Result<List<Categoria>>()
                {
                    Success = true,
                    Data = res.ToList()
                };
            }
            catch (Exception ex)
            {
                return new Result<List<Categoria>>()
                {
                    Message = ex.Message
                };

            }

        }
    }
}
