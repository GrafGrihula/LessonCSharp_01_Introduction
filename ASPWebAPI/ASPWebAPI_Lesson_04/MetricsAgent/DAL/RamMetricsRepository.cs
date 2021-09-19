using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace MetricsAgent.DAL
{
    public class RamMetricsRepository : IRamMetricsRepository
    {
        private const string ConnectionString = "DataSource=metrics.db;Version=3;Pooling=true;Max Pool Size=100;";


        public void Create(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "INSERT INTO rammetrics(value, time) VALUES(@value, @time)";
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.Second);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public void Delete(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // прописываем в команду SQL запрос на удаление данных
            cmd.CommandText = "DELETE FROM Rammetrics WHERE id=@id";
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }

        public IList<RamMetric> GetAll()
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            // прописываем в команду SQL запрос на получение всех данных из таблицы
            cmd.CommandText = "SELECT * FROM rammetrics";
            var returnList = new List<RamMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // пока есть что читать -- читаем
                while (reader.Read())
                {
                    // добавляем объект в список возврата
                    returnList.Add(new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        // налету преобразуем прочитанные секунды в метку времени
                        Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(2))
                    });
                }
            }
            return returnList;
        }

        public RamMetric GetById(int id)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT * FROM rammetrics WHERE id=@id";
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                // если удалось что то прочитать
                if (reader.Read())
                {
                    // возвращаем прочитанное
                    return new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(1))
                    };
                }
                else
                {
                    // не нашлось запись по идентификатору, не делаем ничего
                    return null;
                }
            }
        }

        public IList<RamMetric> GetByTimePeriod(DateTimeOffset startTime, DateTimeOffset stopTime)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            connection.Open();
            using var cmd = new SQLiteCommand(connection);
            cmd.CommandText = "SELECT time FROM rammetrics WHERE time>@startTime AND time<@stopTime";
            cmd.Parameters.AddWithValue("@startTime", startTime);
            cmd.Parameters.AddWithValue("@stopTime", stopTime);
            var returnList = new List<RamMetric>();
            using (SQLiteDataReader reader = cmd.ExecuteReader())
            {
                while (reader.Read())
                {
                    returnList.Add(new RamMetric
                    {
                        Id = reader.GetInt32(0),
                        Value = reader.GetInt32(1),
                        Time = DateTimeOffset.FromUnixTimeSeconds(reader.GetInt32(2))
                    });
                }
            }
            return returnList;
        }

        public void Update(RamMetric item)
        {
            using var connection = new SQLiteConnection(ConnectionString);
            using var cmd = new SQLiteCommand(connection);
            // прописываем в команду SQL запрос на обновление данных
            cmd.CommandText = "UPDATE rammetrics SET value = @value, time = @time WHERE id = @id; ";
            cmd.Parameters.AddWithValue("@id", item.Id);
            cmd.Parameters.AddWithValue("@value", item.Value);
            cmd.Parameters.AddWithValue("@time", item.Time.ToUnixTimeSeconds());
            cmd.Prepare();
            cmd.ExecuteNonQuery();
        }
    }
}
