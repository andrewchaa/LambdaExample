using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace LambdaExample.DataAccess
{
    public class Repository
    {
        private readonly string _connectionString = "Data Source=" + Environment.CurrentDirectory + "\\LambdaExample.sqlite";

        public IEnumerable<TagItem> List()
        {
            string spName = "SELECT * FROM Tracking";
            var dataSet = RunSql(spName);

            var tagItems = dataSet.Tables[0].AsEnumerable()
                .Select(row => new TagItem
                                   {
                                       Id = int.Parse(row["TrackingId"].ToString()),
                                       Tag = row["TrackingTag"].ToString()
                                   }).ToList();

            return tagItems;
        }

        private DataSet RunSql(string commandText)
        {
            var dataSet = new DataSet();

            ConnectionHelper(
                connection =>
                    {
                        var command = new SQLiteCommand
                                          {
                                              Connection = connection,
                                              CommandType = CommandType.Text,
                                              CommandText = commandText
                                          };

                        using (var dataAdapter = new SQLiteDataAdapter(command))
                        {
                            dataAdapter.Fill(dataSet);
                        }

                    });



            return dataSet;
        }

        private void ConnectionHelper(Action<SQLiteConnection> action)
        {
            using (var connection = new SQLiteConnection(_connectionString))
            {
                connection.Open();

                action(connection);

                connection.Close();
            }

        }
    }

    public class TagItem
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public DateTime TrackingTime { get; set; }
    }
}
