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
        public static List<TradesModel> GetTradesByJSON(string json)
        {
            DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(List<TradesModel>));
            MemoryStream stream = new MemoryStream(Encoding.UTF8.GetBytes(json));
            List<TradesModel> objs = JsonConvert.DeserializeObject <List<TradesModel>>(json);
            return objs; 
        }
    }
}
