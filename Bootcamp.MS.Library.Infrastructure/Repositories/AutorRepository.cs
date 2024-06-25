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
    public class AutorRepository : IAutorRepository
    {
        private readonly IDataAccesRepository _dataAccesRepository;
        private readonly IConfiguration _configuration;

        public AutorRepository(IDataAccesRepository dataAccesRepository, IConfiguration configuration)
        {

            _dataAccesRepository = dataAccesRepository;
            _configuration = configuration;

        }
        public async Task<IEnumerable<Autor>> GetAll()
        {
            return await _dataAccesRepository.Execute<Autor>(_configuration["GetAllAutors"]!, null!, CommandType.StoredProcedure);
        }
    }
}
