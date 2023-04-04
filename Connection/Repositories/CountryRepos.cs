using Connection.Context;
using Connection.Models;
using Connection.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Connection.Repositories
{
    internal class CountryRepos : ICountryRepos
    {
        public int Delete(string id)
        {
            var result = 0;
            Country country = null;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete From country Where id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = id;
                command.Parameters.Add(pId);

                result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }

        public int Update(Country country)
        {
            var result = 0;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update country Set name= @name, region = @reg Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = country.Id;
                command.Parameters.Add(pId);

                SqlParameter pReg = new SqlParameter();
                pReg.ParameterName = "@reg";
                pReg.SqlDbType = System.Data.SqlDbType.Int;
                pReg.Value = country.Region;
                command.Parameters.Add(pReg);

                result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }
            return result;
        }

        public List<Country> GetAll()
        {
            List<Country> countrys = new List<Country>();
            var connection = OurContext.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From country;";
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    countrys.Add(new Country
                    {
                        Id = reader.GetString(0),
                        Name = reader.GetString(1),
                        Region = reader.GetInt32(2)
                    });
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
            return countrys;
        }
        public Country GetById(string id)
        {
            Country country = null;
            var connection = OurContext.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From country Where id = @id;";

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                country = new Country
                {
                    Id = reader.GetString(0),
                    Name = reader.GetString(1),
                    Region = reader.GetInt32(2)
                };
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
            return country;
        }

        public int Insert(Country country)
        {
            var result = 0;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into country (id,name,region) Values (@id,@name,@reg);";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.VarChar;
                pId.Value = country.Id;
                command.Parameters.Add(pId);

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = country.Name;
                command.Parameters.Add(pName);

                SqlParameter pReg = new SqlParameter();
                pReg.ParameterName = "@reg";
                pReg.SqlDbType = System.Data.SqlDbType.Int;
                pReg.Value = country.Region;
                command.Parameters.Add(pReg);

                result = command.ExecuteNonQuery();

                transaction.Commit();
                connection.Close();

            }
            catch
            {
                try
                {
                    transaction.Rollback();
                }
                catch (Exception exception)
                {
                    throw;
                }
            }

            return result;
        }
    }
}
