using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Linq;

namespace LambdaExample.DataAccess
{
    public class Repository
    {
        private const string ConnectionString = @"Data Source=C:\Users\Andrew\Projects\LambdaExample\LambdaExample.DataAccess\LambdaExample.sqlite";

        public IEnumerable<TagItem> List()
        {
            string spName = "SELECT * FROM Tracking";
            var dataSet = runSql(spName);

            var tagItems = dataSet.Tables[0].AsEnumerable()
                .Select(row => new TagItem
                                   {
                                       Id = int.Parse(row["TrackingId"].ToString()),
                                       Tag = row["TrackingTag"].ToString()
                                   }).ToList();

            return tagItems;
        }

        private DataSet runSql(string commandText)
        {
            var dataSet = new DataSet();

            using (var connection = new SQLiteConnection(ConnectionString))
            {
                connection.Open();

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

                connection.Close();
            }

            return dataSet;
        }
    }

    public class TagItem
    {
        public int Id { get; set; }
        public string Tag { get; set; }
        public DateTime TrackingTime { get; set; }
    }
}
