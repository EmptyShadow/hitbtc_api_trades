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
            MainAsync(args);
            Console.Read();
        }

        static async void MainAsync(string[] args)
        {
            List<TradesModel> t = await TradesController.GetTradesByAsync("ETHBTC");

            FileTrades.SaveListTrades("ETHBTC", t);
            Console.Read();
        }
    }
}
