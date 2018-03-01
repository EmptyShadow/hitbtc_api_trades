using System;
using System.Collections.Generic;
using System.Text;

namespace Trades.src.Models
{
    /// <summary>
    /// Модель сделки
    /// </summary>
    [Serializable]
    public class Trades
    {
        /// <summary>
        /// Индитификатор
        /// </summary>
        public int id;
        /// <summary>
        /// Стоимость
        /// </summary>
        public int price;
        /// <summary>
        /// Количество
        /// </summary>
        public int quantity;
        /// <summary>
        /// Позиция
        /// </summary>
        public string side;
        /// <summary>
        /// Время сделки
        /// </summary>
        public DateTime dateTime;

        public Trades(int id, int price, int quantity, string side, DateTime dateTime)
        {
            this.id = id;
            this.price = price;
            this.quantity = quantity;
            this.side = side;
            this.dateTime = dateTime;
        }
    }
}
