using System;
using System.Data;
using System.Data.SqlClient;

class Program
{
    static string connStr = "Server=DESKTOP-EGKD5AF;Database=offlinetest;Trusted_Connection=True;TrustServerCertificate=True";

    static void Main()
    {
        using (SqlConnection conn = new SqlConnection(connStr))
        {
            conn.Open();
            while (true)
            {
                Console.WriteLine("\nChoose the option:");
                Console.WriteLine("1. Insert bank");
                Console.WriteLine("2. Delete bank");
                Console.WriteLine("3. Count banks");
                Console.WriteLine("4. Average feedback");
                Console.WriteLine("5. Update bank");
                Console.WriteLine("6. search");
                Console.WriteLine("7. Exit");


                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.WriteLine("Enter name:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter date (yyyy-mm-dd):");
                        DateTime date = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter feedback (number):");
                        int feedback = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter balance:");
                        decimal balance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter location:");
                        string location = Console.ReadLine();
                        Console.WriteLine("Enter phone number:");
                        string phoneno = Console.ReadLine();

                        int newId = InsertBank(conn, name, date, feedback, balance, location, phoneno);
                        Console.WriteLine("Inserted ID is: " + newId);
                        break;

                    case 2:
                        Console.WriteLine("Enter ID to delete:");
                        int delId = Convert.ToInt32(Console.ReadLine());
                        DeleteBank(conn, delId);
                        Console.WriteLine("Deleted ID is: " + delId);
                        break;

                    case 3:
                        int total = CountBanks(conn);
                        Console.WriteLine("Total records: " + total);
                        break;

                    case 4:
                        decimal avg = AverageFeedback(conn);
                        Console.WriteLine("Average feedback: " + avg);
                        break;

                    case 5:
                        Console.WriteLine("Enter ID to update:");
                        int upId = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new name:");
                        string upName = Console.ReadLine();
                        Console.WriteLine("Enter new date (yyyy-mm-dd):");
                        DateTime upDate = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new feedback (number):");
                        int upFeedback = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Enter new balance:");
                        decimal upBalance = Convert.ToDecimal(Console.ReadLine());
                        Console.WriteLine("Enter new location:");
                        string upLocation = Console.ReadLine();
                        Console.WriteLine("Enter new phone number:");
                        string upPhone = Console.ReadLine();

                        int updatedId = UpdateBank(conn, upId, upName, upDate, upFeedback, upBalance, upLocation, upPhone);
                        Console.WriteLine("Updated ID is: " + updatedId);
                        break;
                    case 6:
                        Console.WriteLine("Enter date to search (yyyy-mm-dd):");
                        DateTime searchDate = DateTime.Parse(Console.ReadLine());
                        SearchBankByDate(conn, searchDate);
                        break;

                    case 7:
                        Console.WriteLine("Exiting...");
                        return;

                    default:
                        Console.WriteLine("Invalid option");
                        break;
                }
            }
        }
    }

    static int InsertBank(SqlConnection conn, string name, DateTime date, int feedback, decimal balance, string location, string phoneno)
    {
        SqlCommand cmd = new SqlCommand("insert_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@feedback", feedback);
        cmd.Parameters.AddWithValue("@balance", balance);
        cmd.Parameters.AddWithValue("@location", location);
        cmd.Parameters.AddWithValue("@phoneno", phoneno);
        SqlParameter outputId = new SqlParameter("@new_id", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(outputId);
        cmd.ExecuteNonQuery();
        return Convert.ToInt32(outputId.Value);
    }

    static void DeleteBank(SqlConnection conn, int id)
    {
        SqlCommand cmd = new SqlCommand("delete_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        SqlParameter outputId = new SqlParameter("@new_id", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(outputId);
        cmd.ExecuteNonQuery();
        Console.WriteLine("Deleted ID is: " + outputId.Value);
    }

    static int CountBanks(SqlConnection conn)
    {
        SqlCommand cmd = new SqlCommand("count_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter output = new SqlParameter("@new_id", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(output);
        cmd.ExecuteNonQuery();
        return Convert.ToInt32(output.Value);
    }

    static decimal AverageFeedback(SqlConnection conn)
    {
        SqlCommand cmd = new SqlCommand("avg_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        SqlParameter avgOut = new SqlParameter("@avg_rating", SqlDbType.Decimal)
        {
            Precision = 10,
            Scale = 2,
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(avgOut);
        cmd.ExecuteNonQuery();
        return Convert.ToDecimal(avgOut.Value);
    }

    static int UpdateBank(SqlConnection conn, int id, string name, DateTime date, int feedback, decimal balance, string location, string phoneno)
    {
        SqlCommand cmd = new SqlCommand("update_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@id", id);
        cmd.Parameters.AddWithValue("@name", name);
        cmd.Parameters.AddWithValue("@date", date);
        cmd.Parameters.AddWithValue("@feedback", feedback);
        cmd.Parameters.AddWithValue("@balance", balance);
        cmd.Parameters.AddWithValue("@location", location);
        cmd.Parameters.AddWithValue("@phoneno", phoneno);
        SqlParameter outputId = new SqlParameter("@new_id", SqlDbType.Int)
        {
            Direction = ParameterDirection.Output
        };
        cmd.Parameters.Add(outputId);
        cmd.ExecuteNonQuery();
        return Convert.ToInt32(outputId.Value);
    }
    static void SearchBankByDate(SqlConnection conn, DateTime date)
    {
        SqlCommand cmd = new SqlCommand("search_bank", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.AddWithValue("@date", date);
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            Console.WriteLine("Search Results (by date):");
            while (reader.Read())
            {
                Console.WriteLine($"ID: {reader["id"]}, Name: {reader["name"]}, Date: {reader["date"]}, Feedback: {reader["feedback"]}, Balance: {reader["balance"]}, Location: {reader["location"]}, Phone: {reader["phoneno"]}");
            }
        }
    }

}
