﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Domain
{
    public interface IDataAccesRepository
    {
        Task<TOutput> ExecuteFirst<TOutput>(string storedProcedureKey, object obj, CommandType commandType);

        Task<IEnumerable<TOutput>> Execute<TOutput>(string storedProcedureKey, object obj, CommandType commandType);

    }
}
