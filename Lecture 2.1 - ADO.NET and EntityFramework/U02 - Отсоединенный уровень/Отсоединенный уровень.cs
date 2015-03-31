using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class DisconnectedLayer
{
    public static void Read()
    {
        var connection = new SqlConnection(Program.ConnectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from Shops";
        var adapter = new SqlDataAdapter(cmd);
        var set = new DataSet();
        adapter.Fill(set, "Shpos");
        connection.Close();

        var table = set.Tables[0];
        for (int i = 0; i < table.Rows.Count; i++)
        {
            for (int j = 0; j < table.Columns.Count; j++)
                Console.Write("{0,-15}",table.Rows[i][j].ToString());
            Console.WriteLine();
        }
        Console.WriteLine();
        Console.WriteLine();

    }

    public static void Update()
    {
        var connection = new SqlConnection(Program.ConnectionString);
        connection.Open();
        var cmd = connection.CreateCommand();
        cmd.CommandText = "Select * from Shops";
        var adapter = new SqlDataAdapter(cmd);
        var set = new DataSet();
        adapter.Fill(set, "Shops");
        new SqlCommandBuilder(adapter);
        connection.Close();

        var table = set.Tables[0];

        foreach (DataRow row in table.Rows)
            if ((int)row["Id"] == 1)
            {
                row.Delete();
                break;
            }

        table.Rows[1]["Name"] = "В Дирижабле";

        var newRow = table.NewRow();
        newRow["Name"] = "В Меге";
        newRow["Street"] = "Металлургов";
        newRow["HouseNumber"] = 87;
        newRow["OpeningDate"] = new DateTime(2013, 1, 1);
        table.Rows.Add(newRow);

        connection.Open();
        adapter.Update(set.Tables[0]);
        connection.Close();

        ConnectedLayer.Read();
    }
}
