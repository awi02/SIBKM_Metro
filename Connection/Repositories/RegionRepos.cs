
//
using Connection.Models;
using Connection.Context;
using Connection.Repositories.Interfaces;
using System.Data.SqlClient;

namespace Connection.Repositories
{
    internal class RegionRepos : IRegionRepos
    {
        public int Delete(int id)
        {
            var result = 0;
            Region region = null;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Delete From region Where id = @id";
                command.Transaction = transaction;

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
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

        public int Update(Region region)
        {
            var result = 0;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Update region Set name= @name Where id = @id;";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.Name;
                command.Parameters.Add(pName);

                SqlParameter pId = new SqlParameter();
                pId.ParameterName = "@id";
                pId.SqlDbType = System.Data.SqlDbType.Int;
                pId.Value = region.Id;
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
    
    public List<Region> GetAll()
        {
            List<Region> regions = new List<Region>();
            var connection = OurContext.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From region;";
            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    regions.Add(new Region
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                    });
                }
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
            return regions;
        }
        public Region GetById(int id)
        {
            Region region = null;
            var connection = OurContext.GetConnection();
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Select * From region Where id = @id;";

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.Int;
            pId.Value = id;
            command.Parameters.Add(pId);

            connection.Open();
            using SqlDataReader reader = command.ExecuteReader();
            if (reader.HasRows)
            {
                reader.Read();
                region = new Region
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                };
            }
            else
            {
                return null;
            }
            reader.Close();
            connection.Close();
            return region;
        }

        public int Insert(Region region)
        {
            var result = 0;
            var connection = OurContext.GetConnection();
            connection.Open();

            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                SqlCommand command = new SqlCommand();
                command.Connection = connection;
                command.CommandText = "Insert Into region (name) Values (@name);";
                command.Transaction = transaction;

                SqlParameter pName = new SqlParameter();
                pName.ParameterName = "@name";
                pName.SqlDbType = System.Data.SqlDbType.VarChar;
                pName.Value = region.Name;
                command.Parameters.Add(pName);

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
