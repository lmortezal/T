using System;
using System.Data;
using System.Data.SqlClient;
using ConsoleApp1.Models;
using Dapper;

namespace ConsoleApp1{

    class Program
    {
        static void Main(string[] args)
        {
            string connectionString = "Server=localhost;Database=DotNetCourseDatabase;TrustServerCertificate=True;Trusted_Connection=True;";
            IDbConnection dbConnection = new SqlConnection(connectionString); 

            string sqlcommand = "SELECT GETDATE()";

            DateTime time = dbConnection.QuerySingle<DateTime>(sqlcommand);
            Console.WriteLine(time);





            Computer computer = new Computer()
            {
                Motherboard = "ASUS",
                CPUCores = 4,
                HasWifi = true,
                HasLTE = false,
                ReleaseDate = new DateTime(2020, 1, 1),
                Price = 1000,
                VideoCard = "NVIDIA"
            };
            Console.WriteLine(computer.Motherboard);
            Console.WriteLine(computer.CPUCores);
            Console.WriteLine(computer.HasWifi);
            Console.WriteLine(computer.HasLTE);
            Console.WriteLine(computer.ReleaseDate);
            Console.WriteLine(computer.Price);
            Console.WriteLine(computer.VideoCard);

            string sql = @"INSERT INTO  TutorialAppSchema.Computer (
                Motherboard,
                CPUCores,
                HasWifi,
                HasLTE,
                ReleaseDate, 
                Price,
                VideoCard
            ) VALUES ('" + computer.Motherboard
                + "','" + computer.CPUCores
                + "','" + computer.HasWifi
                + "','" + computer.HasLTE
                + "','" + computer.ReleaseDate
                + "','" + computer.Price
                + "','" + computer.VideoCard
            + "') ";

            Console.WriteLine(sql);

            string sqlselect = @"
            SELECT
                computer.Motherboard,
                computer.CPUCores,
                computer.HasWifi,
                computer.HasLTE,
                computer.ReleaseDate,
                computer.Price,
                computer.VideoCard
            FROM TutorialAppSchema.Computer computer";

            List<Computer> computers = dbConnection.Query<Computer>(sqlselect).ToList();

            foreach (Computer item in sql)
            {
                Console.WriteLine(computer.Motherboard);
                Console.WriteLine(computer.CPUCores);
                Console.WriteLine(computer.HasWifi);
                Console.WriteLine(computer.HasLTE);
                Console.WriteLine(computer.ReleaseDate);
                Console.WriteLine(computer.Price);
                Console.WriteLine(computer.VideoCard);
            }
        }
    }

}