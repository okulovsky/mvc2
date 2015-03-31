using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


class ConnectedLayer
{


    public static void Read()
    {
        var connection = new SqlConnection(Program.ConnectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from Shops";
        var reader = cmd.ExecuteReader();
        var data = new List<List<string>>();
        while (reader.Read())
        {

            for (int i = 0; i < reader.FieldCount; i++)
                Console.Write("{0,-15}",reader[i].ToString());
            Console.WriteLine();
        }
        connection.Close();
        Console.WriteLine();
        Console.WriteLine();
    }
   
 

    public static void Update()
    {
        var connection = new SqlConnection(Program.ConnectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "delete from Shops where Id=1";
        cmd.ExecuteNonQuery();

        cmd = connection.CreateCommand();
        cmd.CommandText = "insert into Shops(Name,Street,HouseNumber,OpeningDate) values(@Name,@Street,@HouseNumber,@OpeningData)";
        cmd.Parameters.AddWithValue("@Name", "В Меге");
        cmd.Parameters.AddWithValue("@Street", "Металлургов");
        cmd.Parameters.AddWithValue("@HouseNumber", "87");
        cmd.Parameters.AddWithValue("@OpeningData", "2013-01-01"); 
        cmd.ExecuteNonQuery();


        cmd = connection.CreateCommand();
        cmd.CommandText = "update Shops set Name=@Name where Id=2";
        cmd.Parameters.AddWithValue("@Name", "В Дирижабле");
        cmd.ExecuteNonQuery();


        connection.Close();
        Read();

    }
}