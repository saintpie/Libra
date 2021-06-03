using System;
using System.Data.SqlClient;

namespace ConsoleApp1
{
    class Program
    {
        private const string CONNECTIONSRING = "Data Source=N205-9;Initial Catalog=Library;Integrated Security=True";
        static void Main(string[] args)
        {
            using (var sqlConnection = new SqlConnection(CONNECTIONSRING))
            {
                try
                {
                    sqlConnection.Open();
                     var sqlCommand = "insert into Books values ('Faust Utopia', 'The beginning of the end of utopian wold')";

                    //var sqlCommand = "select * from Authors";

                    using (var command = new SqlCommand(sqlCommand, sqlConnection))
                    {
                            var affectedRows = command.ExecuteNonQuery();   
                            Console.WriteLine(affectedRows);
                        //var sqlDataReader =  command.ExecuteReader();
                        //int i = 0;
                        //while(sqlDataReader.Read())
                        //{
                        //    Console.WriteLine(string.Format("{0} | {1} |", sqlDataReader[0], sqlDataReader[1])); ;
                        //    i++;
                        //}                        
                    }
                }
                catch (SqlException exception)
                {
                    if (sqlConnection.State != System.Data.ConnectionState.Open)
                    {
                        Console.WriteLine("Соединение не установлено", exception);
                    }
                    Console.WriteLine("Другая ошибка", exception);
                }
                finally
                {
                    sqlConnection.Close();
                }
            }
        }
    }
}

