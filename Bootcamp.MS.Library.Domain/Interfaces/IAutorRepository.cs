using Bootcamp.MS.Library.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain
{
    public interface IAutorRepository
    {
        Task<IEnumerable<Autor>> GetAll();
    }
}
