using Bootcamp.MS.Library.Domain.Models;
using Bootcamp.MS.Library.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BootCamp.MS.Library.Application.Services
{
    public class EditorialService
    {
        private readonly IEditorialRepository _editorialRepository;
        public EditorialService(IEditorialRepository editorialRepository)
        {
           
            _editorialRepository = editorialRepository;

        }

        public async Task<Result<List<Editorial>>> GetAll()
        {
            try
            {
                var res = await _editorialRepository.GetAll();
                return new Result<List<Editorial>>()
                {
                    Success = true,
                    Data = res.ToList()
                };
            }
            catch (Exception ex)
            {
                return new Result<List<Editorial>>()
                {
                    Message = ex.Message
                };

            }

        }
    }
}
