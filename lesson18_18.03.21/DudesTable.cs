using System.Linq;
using Dapper;
using Microsoft.Data.SqlClient;

namespace lesson18_18._03._21
{
    class DudesTable
    {
        private const string ConString = @"Server=NUSHKOPC\SQLSERVER; Initial Catalog=AlifBase; Integrated Security=True";

        public class Dude
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public int Age { get; set; }
            public string Surname { get; set; }
        }

        public class Commands
        {
            public static void Create(Dude input)
            {
                try
                {
                    using (var conn = new SqlConnection(ConString))
                    {
                        var sql =
                            @"insert into Dudes (Name, Age, Surname) 
                        values (@Name, @Age, @Surname)";
                        conn.Execute(sql, input);
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Create error - " + ex);
                }
            }
            public static Dude Read(int id)
            {
                try
                {
                    using (var conn = new SqlConnection(ConString))
                    {
                        return conn.Query<Dude>(@"select * from Dudes where Id = @id").First();
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Read error - " + ex);
                }
                return default;
            }

            public static void Update(Dude input)
            {
                try
                {
                    using (var conn = new SqlConnection(ConString))
                    {
                        var sql =
                            "update Dudes set " +
                            "Name = @Name, " +
                            "Age = @Age, " +
                            "Surname = @Surname, " +
                            "WHERE Id = @Id";
                        conn.Execute(sql, input);
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Update error - " + ex);
                }
            }

            public static void Delete(int id)
            {
                try
                {
                    using (var conn = new SqlConnection(ConString))
                    {
                        var sql =
                            $"delete from Dudes where Id = @id";
                        conn.Execute(sql, id);
                    }
                }
                catch (System.Exception ex)
                {
                    System.Console.WriteLine("Delete error - " + ex);
                }
            }
        }
    }
}
