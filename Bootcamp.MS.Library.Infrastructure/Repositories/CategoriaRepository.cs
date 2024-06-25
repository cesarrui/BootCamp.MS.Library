using Bootcamp.MS.Library.Domain;
using Bootcamp.MS.Library.Domain.Models;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Infrastructure
{
    public class CategoriaRepository : ICategoriaRepository
    {
        private readonly IDataAccesRepository _dataAccesRepository;
        private readonly IConfiguration _configuration;

        public CategoriaRepository(IDataAccesRepository dataAccesRepository, IConfiguration configuration)
        {

            _dataAccesRepository = dataAccesRepository;
            _configuration = configuration;

        }
        public async Task<IEnumerable<Categoria>> GetAll()
        {
            return await _dataAccesRepository.Execute<Categoria>(_configuration["GetAllCategories"]!, null!, CommandType.StoredProcedure);
        }
    }
}
