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
    public class LibroRepoitory : ILibroRepository
    {
        private readonly IDataAccesRepository _dataAccesRepository;
        private readonly IConfiguration _configuration;
        public LibroRepoitory(IDataAccesRepository dataAccesRepository, IConfiguration configuration ) { 

            _dataAccesRepository = dataAccesRepository;
            _configuration = configuration;
        
        }

        public async Task Create(Libro libro)
        {
            await _dataAccesRepository.ExecuteFirst<object>(_configuration["CreateNewBook"]!, libro, CommandType.StoredProcedure);
        }

        public async Task Update(Libro libro)
        {
            await _dataAccesRepository.ExecuteFirst<object>(_configuration["UpdateBook"]!, libro, CommandType.StoredProcedure);
        }
        public async Task<IEnumerable<Libro>> GetAll()
        {
            return await _dataAccesRepository.Execute<Libro>(_configuration["GetAllLibros"]!, null!, CommandType.StoredProcedure);
        }
    }
}
