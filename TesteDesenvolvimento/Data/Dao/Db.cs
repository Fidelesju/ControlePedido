using System.Collections.Specialized;
using System.Data.Common;
using System.Data.SqlClient;
using System.Data;
using System.Text.RegularExpressions;

namespace TesteDesenvolvimento.Data.Dao
{
    public abstract class Db<T> 
    {
        private readonly IDictionary<string, int> _integerBinds;
        private readonly IDictionary<string, string> _stringBinds;
        private bool _queryIsPaginated;
        private List<T> _queryResultList;
        private DbDataReader _reader;

        protected Db() 

        {
            _integerBinds = new Dictionary<string, int>();
            _stringBinds = new Dictionary<string, string>();
        }

        protected abstract T Mapper(DbDataReader reader);

        protected async Task<List<T>> GetQueryResultList()
        {
            T mappedObject;
            try
            {
                _queryResultList = new List<T>();
                while (await _reader.ReadAsync())
                {
                    mappedObject = Mapper(_reader);
                    _queryResultList.Add(mappedObject);
                }

                await _reader.CloseAsync();

                /*
                    A non-paged query does not clear the binds because these will be used
                    in the second query to return the number of records in the table, whi
                    ch will be just a change to the existing query and, therefore, will n
                    eed the binds to work correctly.
                 */
                if (!_queryIsPaginated)
                {
                    ClearBinds();
                }

                return _queryResultList;
            }
            catch (Exception)
            {
                Console.WriteLine("Failure on reading.");
                throw;
            }
        }

        protected void ClearBinds()
        {
            _integerBinds.Clear();
            _stringBinds.Clear();
        }

        protected async Task<T> GetQueryResultObject()
        {
            T mappedObject;
            mappedObject = default(T);
            try
            {
                if (await _reader.ReadAsync())
                {
                    mappedObject = Mapper(_reader);
                }

                await _reader.CloseAsync();

                ClearBinds();
                return mappedObject;
            }
            catch (Exception)
            {
                Console.WriteLine("Failure on reading.");
                throw;
            }
        }


        protected void AddIntegerBind(string key, int value)
        {
            _integerBinds.Add(key, value);
        }

        protected void AddStringBind(string key, string value)
        {
            _stringBinds.Add(key, value);
        }


        protected async Task<DbDataReader> GetDataReader()
        {
            return _reader;
        }

        protected string GetParametersList(List<int> numbers)
        {
            string sql;
            int length;
            length = numbers.Count;
            switch (length)
            {
                case 0:
                    return "()";
                case 1:
                    return "(" + numbers[0] + ")";
                default:
                    sql = "(";
                    for (int i = 0; i < length; i++)
                    {
                        sql += numbers[i];
                        if (i == length - 1)
                        {
                            continue;
                        }
                        sql += ",";
                    }

                    sql += ")";
                    return sql;
            }
        }

        protected string GetParametersList(List<string> numbers)
        {
            string sql;
            int length;
            length = numbers.Count;
            sql = "(";
            for (int i = 0; i < length; i++)
            {
                sql += $"'{numbers[i]}'";
                if (i == length - 1)
                {
                    continue;
                }

                sql += ",";
            }

            sql += ")";
            return sql;
        }

        protected void AddIntegerParameterToEntityCommand(DbCommand command, string parameterName, int value)
        {
            DbParameter parameter = command.CreateParameter();
            parameter.ParameterName = $"@{parameterName}";
            parameter.DbType = DbType.Int32;
            parameter.Direction = ParameterDirection.Input;
            parameter.Value = value;
            command.Parameters.Add(parameter);
        }
    }
}
