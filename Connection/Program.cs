// See https://aka.ms/new-console-template for more information

using System.Data.SqlClient;
using System.Security.Cryptography.X509Certificates;

public class Program
{
    private static SqlConnection connection;
    private static string connectionstring = "Data Source=LAPTOP-OE2ICFDP;Initial Catalog=db_hr_sibkm;Integrated Security=True;Connect Timeout=30;Encrypt=False;" 
        ;
    public static void Main()
    {
        //connection=new SqlConnection(connectionstring);
        //try
        //{
        //   connection.Open();
        // Console.WriteLine("Connection openned");
        //connection.Close();
        //}
        //catch (Exception ex)
        //{
        //Console.WriteLine(ex.ToString());
        //}
        GetAllCountry();
        // GetbyIdCount("SG");
        //Insertcount("WG","Warga Setan",3);
        // Updatecount("WG", "Warga Gundul", 4);
        //Deletecont("WG");
    }
    //getall
    public static void GetAllCountry()
    {
        connection=new SqlConnection(connectionstring);
        SqlCommand command = new SqlCommand();
        command.Connection = connection;
        command.CommandText = "Select * from country;";

        connection.Open();
        using SqlDataReader reader = command.ExecuteReader();
        if(reader.HasRows)
        {
            while(reader.Read()) {
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
    public static void Insertcount(string id,string name,int region)
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
