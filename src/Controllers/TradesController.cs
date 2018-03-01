using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using Trades.src.Models;

namespace Trades.src.Controllers
{
    class TradesController
    {
        public const string API_TRADES = "https://api.hitbtc.com/api/2/public/trades/";

        /// <summary>
        /// Метод подключается к HITBTC через API GET /api/2/public/trades/{symbol}
        /// и асинхронно получает ответ от сервера 
        /// symbol является строковое представление параметров
        /// </summary>
        /// <param name="tool">Инструмент</param>
        /// <param name="parametrics">Параметры отбора</param>
        /// <returns></returns>
        static public async System.Threading.Tasks.Task<List<TradesModel>> GetTradesByAsync(string tool, Dictionary<string, string> parametrics = null)
        {
            /// путь запроса к API
            string urlAPI = API_TRADES + tool + DictionatyToParamsURLReq(parametrics);
            /// строка ответа в JSON формате
            string tradesJSON = "";

            /// Создаем веб соединение с сервером
            WebRequest request = WebRequest.Create(urlAPI);
            /// в асинхронном режиме получам ответ от сервера
            WebResponse response = await request.GetResponseAsync();
            /// Получение потока данных от сервера
            using (Stream stream = response.GetResponseStream())
            {
                /// Получаем данные из потока
                using (StreamReader reader = new StreamReader(stream))
                {
                    tradesJSON = reader.ReadToEnd();
                }
            }
            /// Закрывает соединение с сервером
            response.Close();

            List<TradesModel> trades = BuilderTrades.GetTradesByJSON(tradesJSON);

            return trades;
        }

        /// <summary>
        /// Перевод карты параметров в строковое представление параметров url
        /// </summary>
        /// <param name="parametrics"></param>
        /// <returns></returns>
        static public string DictionatyToParamsURLReq(Dictionary<string, string> parametrics)
        {
            if (parametrics == null) return "";
            if (parametrics.Count == 0) return "";

            string paramsURLReq = "?";
            foreach(KeyValuePair<string, string> param in parametrics)
            {
                paramsURLReq += param.Key + "=" + param.Value + "&";
            }

            paramsURLReq = paramsURLReq.Substring(0, paramsURLReq.Length - 1);

            return paramsURLReq;
        }
    }
}
