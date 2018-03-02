using System;
using System.Collections.Generic;
using System.Text;
using Trades.src.Models;
using System.IO;

namespace Trades.src
{
    /// <summary>
    /// Класс работы с файлами сделок
    /// </summary>
    class FileTrades
    {
        /// <summary>
        /// Сохранить сделки в файл с названием инструмента
        /// </summary>
        /// <param name="tool"></param>
        /// <param name="trades"></param>
        public static void SaveListTrades(string tool, List<Trade> trades)
        {
            string path = ".\\" + tool + ".txt";
            // запись в файл
            using (FileStream fstream = new FileStream(path, FileMode.OpenOrCreate))
            {
                foreach(Trade trade in trades)
                {
                    // преобразуем строку в байты
                    byte[] array = System.Text.Encoding.Default.GetBytes(trade.ToString() + "\r\n");
                    fstream.Write(array, 0, array.Length);
                }
            }
        }
    }
}
