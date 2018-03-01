using System;
using System.Collections.Generic;
using System.Text;
using Trades.src.Models;
using System.IO;

namespace Trades.src
{
    class FileTrades
    {
        public static void SaveListTrades(string tool, List<TradesModel> trades)
        {
            string path = ".\\" + tool + ".txt";
            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach(TradesModel trade in trades)
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(trade.ToString() + "\r\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
    }
}
