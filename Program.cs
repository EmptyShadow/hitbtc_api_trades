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
            string tool = "ETHBTC"; // инструмент

            List<Trade> t = await TradesController.GetTradesByAsync(tool); // получаю список сделок

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
    }
}
