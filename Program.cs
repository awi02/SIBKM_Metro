using Connection.Context;
using Connection.Controller;
using Connection.Models;
using Connection.Repositories;
using Connection.Views;
using System;
using System.Data.SqlClient;

namespace Connection;

public class Program
{
    public static void Main()
    {
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Database Connectivity=========");
            Console.WriteLine("1. Manage Table Region");
            Console.WriteLine("2. Manage Table Country");
            Console.WriteLine("3. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Region();
                    break;
                case 2:
                    Country();
                    break;
                case 3:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Region()
    {
        RegionControl regionController = new RegionControl(new RegionRepos(), new Vreg());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Region========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    regionController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======Search By Id Region========");
                    Console.Write("Input Id: ");
                    int id = Convert.ToInt32(Console.ReadLine());
                    regionController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Region========");
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    regionController.Insert(new Region
                    {
                        Name = name
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Region========");
                    Console.Write("Input Id: ");
                    int idy = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Input Name: ");
                    var namex = Console.ReadLine();
                    regionController.Update(new Region
                    {
                        Name = namex,
                        Id = idy
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Region========");
                    Console.Write("Input Id: ");
                    int idx = Convert.ToInt32(Console.ReadLine());
                    regionController.Delete(idx);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }

    public static void Country()
    {
        CountryControl countryController = new CountryControl(new CountryRepos(), new Vcont());
        var check = true;
        do
        {
            Console.Clear();
            Console.WriteLine("=======Table Country========");
            Console.WriteLine("1. Get All");
            Console.WriteLine("2. Get By Id");
            Console.WriteLine("3. Insert");
            Console.WriteLine("4. Update");
            Console.WriteLine("5. Delete");
            Console.WriteLine("6. Exit");
            Console.Write("Input: ");
            var input = Convert.ToInt16(Console.ReadLine());
            switch (input)
            {
                case 1:
                    Console.Clear();
                    countryController.GetAll();
                    Console.ReadKey();
                    break;
                case 2:
                    Console.Clear();
                    Console.WriteLine("=======Search By Id Country========");
                    Console.Write("Input Id: ");
                    string id = Console.ReadLine();
                    countryController.GetById(id);
                    Console.ReadKey();
                    break;
                case 3:
                    Console.Clear();
                    Console.WriteLine("=======Insert Country========");
                    Console.Write("Input Id: ");
                    var idy = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var name = Console.ReadLine();
                    Console.Write("Input Region: ");
                    int reg = Convert.ToInt32(Console.ReadLine());
                    countryController.Insert(new Country
                    {
                        Id = idy,
                        Name = name,
                        Region = reg
                    });
                    Console.ReadKey();
                    break;
                case 4:
                    Console.Clear();
                    Console.WriteLine("=======Update Country========");
                    Console.Write("Input Id: ");
                    var idz = Console.ReadLine();
                    Console.Write("Input Name: ");
                    var namez = Console.ReadLine();
                    Console.Write("Input Region: ");
                    int regz = Convert.ToInt32(Console.ReadLine());
                    countryController.Update(new Country
                    {
                        Name = namez,
                        Id = idz,
                        Region = regz
                    });
                    Console.ReadKey();
                    break;
                case 5:
                    Console.Clear();
                    Console.WriteLine("=======Delete Country========");
                    Console.Write("Input Id: ");
                    string idx = Console.ReadLine();
                    countryController.Delete(idx);
                    Console.ReadKey();
                    break;
                case 6:
                    check = false;
                    break;
                default:
                    Console.WriteLine("Input not found!");
                    Console.ReadKey();
                    check = true;
                    break;
            }
        } while (check);
    }
    private static SqlConnection connection;
    private static string connectionstring = "Data Source=LAPTOP-OE2ICFDP;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False;";
    public static void GetAllCountry()
    {
        connection = new SqlConnection(connectionstring);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * from country;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            while (reader.Read())
            {
                Console.WriteLine("id: " + reader[0]);
                Console.WriteLine("Name: " + reader[1]);
                Console.WriteLine("Region: " + reader[2]);
                Console.WriteLine();
            }
        }
        else
        {
            Console.WriteLine("No one");
        }
        reader.Close();
        connection.Close();
    }
    public static void GetbyIdCount(string id)
    {
        connection = new SqlConnection(connectionstring);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * From country Where id = @id;";

        SqlParameter pID = new SqlParameter();
        pID.ParameterName = "@id";
        pID.SqlDbType = System.Data.SqlDbType.VarChar;
        pID.Value = id;
        command.Parameters.Add(pID);

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if (reader.HasRows)
        {
            reader.Read();

            Console.WriteLine("id: " + reader[0]);
            Console.WriteLine("Name: " + reader[1]);
            Console.WriteLine("Region: " + reader[2]);
        }
        else
        {
            Console.WriteLine($"id = {id} is not found!");
        }
        reader.Close();
        connection.Close();

    }
    //INSERT
    public static void Insertcount(string id, string name, int region)
    {
        connection = new SqlConnection(connectionstring);
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
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pReg = new SqlParameter();
            pReg.ParameterName = "@reg";
            pReg.SqlDbType = System.Data.SqlDbType.Int;
            pReg.Value = region;
            command.Parameters.Add(pReg);

            command.ExecuteNonQuery();

            transaction.Commit();
            Console.WriteLine("Insert Success!");
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
    //UPDATE
    public static void Updatecount(string id, string name, int region)
    {
        connection = new SqlConnection(connectionstring);
        connection.Open();

        SqlTransaction transaction = connection.BeginTransaction();

        try
        {
            SqlCommand command = new SqlCommand();
            command.Connection = connection;
            command.CommandText = "Update country Set name= @name, region = @reg Where id = @id;";
            command.Transaction = transaction;

            SqlParameter pId = new SqlParameter();
            pId.ParameterName = "@id";
            pId.SqlDbType = System.Data.SqlDbType.VarChar;
            pId.Value = id;
            command.Parameters.Add(pId);

            SqlParameter pName = new SqlParameter();
            pName.ParameterName = "@name";
            pName.SqlDbType = System.Data.SqlDbType.VarChar;
            pName.Value = name;
            command.Parameters.Add(pName);

            SqlParameter pReg = new SqlParameter();
            pReg.ParameterName = "@reg";
            pReg.SqlDbType = System.Data.SqlDbType.Int;
            pReg.Value = region;
            command.Parameters.Add(pReg);

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Update Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
    //DELETE
    public static void Deletecont(string id)
    {
        connection = new SqlConnection(connectionstring);
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

            int result = command.ExecuteNonQuery();
            if (result > 0)
            {
                Console.WriteLine("Delete Success!");
            }
            else
            {
                Console.WriteLine($"id = {id} is not found!");
            }

            transaction.Commit();
            connection.Close();

        }
        catch (Exception e)
        {
            Console.WriteLine("Something Wrong! : " + e.Message);
            try
            {
                transaction.Rollback();
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }
        }
    }
}