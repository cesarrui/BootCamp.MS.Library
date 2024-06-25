using Bootcamp.MS.Library.Domain.Models;
using Bootcamp.MS.Library.Domain;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Infrastructure
{
    public class EditorialRepository: IEditorialRepository
    {
        private readonly IDataAccesRepository _dataAccesRepository;
        private readonly IConfiguration _configuration;

        public EditorialRepository(IDataAccesRepository dataAccesRepository, IConfiguration configuration)
        {

            _dataAccesRepository = dataAccesRepository;
            _configuration = configuration;

        }
        public async Task<IEnumerable<Editorial>> GetAll()
        {
            return await _dataAccesRepository.Execute<Editorial>(_configuration["GetAllEditorials"]!, null!, CommandType.StoredProcedure);
        }
    }
}
