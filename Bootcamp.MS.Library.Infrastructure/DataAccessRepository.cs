using Dapper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bootcamp.MS.Library.Infrastructure
{
    public class DataAccessRepository
    {
        private readonly IDbConnection _dbConnection;
        public DataAccessRepository(IDbConnection connection) { 

            _dbConnection = connection;
        
        }

        internal async Task<TOutput> ExecFirst<TInput, TOutput>(string spName, TInput inputObject, CommandType command) where TInput : class {

            using(IDbConnection conn = _dbConnection)
            {
                var json = JsonConvert.SerializeObject(inputObject, Formatting.None);
                var result = await conn.QueryFirstOrDefaultAsync<TOutput>(spName, inputObject == null ? null : new { json }, commandType: command);
                return result!;
            }
        
        }

        internal async Task<IEnumerable<TOutput>> Exec<TInput, TOutput>(string spName, TInput inputObject, CommandType command) where TInput : class
        {

            using (IDbConnection conn = _dbConnection)
            {
                var json = JsonConvert.SerializeObject(inputObject, Formatting.None);
                var result = await conn.QueryAsync<TOutput>(spName, inputObject == null ? null : new { json }, commandType: command);
                return result!;
            }

        }
    }
}
