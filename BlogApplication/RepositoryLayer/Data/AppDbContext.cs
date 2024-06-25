using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Data
{
    public static class AppDbContext<T>
    {
        public static List<T> datas;
        private static readonly string dataFilePath = $"{typeof(T).Name}.json";

        static AppDbContext()
        {
            if (File.Exists(dataFilePath))
            {
                LoadData();
            }
            else
            {
                datas = new List<T>();
            }
        }

        private static void SaveData()
        {
            string json = JsonConvert.SerializeObject(datas, Formatting.Indented);
            File.WriteAllText(dataFilePath, json);
        }

        private static void LoadData()
        {
            string json = File.ReadAllText(dataFilePath);
            datas = JsonConvert.DeserializeObject<List<T>>(json);
        }

        public static void Add(T entity)
        {
            datas.Add(entity);
            SaveData();
        }

        public static void Remove(T entity)
        {
            datas.Remove(entity);
            SaveData();
        }

        public static void Update()
        {
            SaveData();
        }
    }
}
