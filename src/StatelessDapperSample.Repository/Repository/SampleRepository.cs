using Dapper;
using Microsoft.Extensions.Configuration;
using StatelessDapperSample.Domain.Data;
using StatelessDapperSample.Repository.Context;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace StatelessDapperSample.Repository
{
    public class SampleRepository
    {
        protected readonly ConnectionFactory ConnectionFactory;

        public SampleRepository(ConnectionString connectionString)
        {
            ConnectionFactory = new ConnectionFactory(connectionString);
        }

        public IEnumerable<SampleData> GetData()
        {
            var conn = ConnectionFactory.GetConnection();

            try
            {
                conn.Open();

                var sql = "Select * from public.sample";

                var result = conn.Query<SampleData>(sql);

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

        public SampleData InsertData(SampleData sample)
        {
            var conn = ConnectionFactory.GetConnection();

            try
            {
                conn.Open();
                var sql =  "INSERT INTO public.sample ( status)  VALUES (@status) ";

                var parameters = new DynamicParameters();

                parameters.Add("@status", sample.Status);

                var result = conn.Query<SampleData>(sql, parameters).FirstOrDefault();

                return result;
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            finally
            {
                conn.Close();
            }
        }

    }
}
