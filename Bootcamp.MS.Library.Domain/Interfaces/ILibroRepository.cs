using Bootcamp.MS.Library.Domain.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain
{
    public interface ILibroRepository
    {
        Task<IEnumerable<Libro>> GetAll();
        Task Create(Libro libro);

        Task Update(Libro libro);
    }
}
