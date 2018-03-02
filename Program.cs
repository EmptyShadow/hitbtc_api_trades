using System;
using System.Collections.Generic;
using Trades.src;
using Trades.src.Controllers;
using Trades.src.Models;

namespace Trades
{
    class Program
    {
        static void Main(string[] args)
        {
            Migrate();
            MainAsync(args);
            Console.Read();
        }

        static async void MainAsync(string[] args)
        {
            if (args.Length == 0) return;
            try
            {
                string tool = args[0]; // инструмент
                Dictionary<string, string> dictionary = GetMapParameters(ref args);

                List<Trade> t = await TradesController.GetTradesByAsync(tool, dictionary); // получаю список сделок

                // Сохраняю в базу данных
                using (TradesContext db = new TradesContext())
                {
                    Console.WriteLine("asdas");
                    db.Trades.AddRange(t);
                    db.SaveChanges();
                    Console.WriteLine("Объекты успешно сохранены");

                    foreach (Trade trade in db.Trades)
                    {
                        Console.WriteLine(trade.ToString());
                    }
                }

                FileTrades.SaveListTrades(tool, t); // сохраняю в файл
            } catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }
                     
            Console.Read();
        }

        /// <summary>
        /// Миграция базы и таблицы
        /// </summary>
        public static void Migrate()
        {
            TradesContext db = new TradesContext();
            db.Database.EnsureCreated(); // пытаюсь создать базу если ее нет

            TradeMigrate.Migrate(); // миграция таблицы сделок
        }

        /// <summary>
        /// Получить карту параметров запроса
        /// </summary>
        /// <param name="parameters"></param>
        /// <returns></returns>
        public static Dictionary<string, string> GetMapParameters(ref string[] parameters)
        {
            if (parameters.Length <= 1) return null;
            Dictionary<string, string> map = new Dictionary<string, string>();
            int index;
            foreach (string param in parameters)
            {
                index = param.IndexOf('=');
                if (index + 1 != param.Length)
                {
                    map.Add(param.Substring(0, index), param.Substring(index + 1));
                }
            }

            return map;
        }
    }
}
