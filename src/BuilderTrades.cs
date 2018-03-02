using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Trades.src.Models;

namespace Trades.src
{
    /// <summary>
    /// Класс, который создает список сделок по строке в формате json
    /// </summary>
    class BuilderTrades
    {
        /// <summary>
        /// Получить сделки из строки в формате JSON
        /// </summary>
        /// <param name="json"></param>
        /// <returns></returns>
        public static List<Trade> GetTradesByJSON(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<Trade>));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            List<Trade> objs = JsonConvert.DeserializeObject <List<Trade>>(json);
            return objs; 
        }
    }
}
