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
        public int Id { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        public int Price { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        public int Quantity { get; set; }
        /// <summary>
        /// Позиция
        /// </summary>
        public string Side { get; set; }
        /// <summary>
        /// Время сделки
        /// </summary>
        public DateTime Timestamp { get; set; }

        public Trades(int id, int price, int quantity, string side, DateTime timestamp)
        {
            this.Id = id;
            this.Price = price;
            this.Quantity = quantity;
            this.Side = side;
            this.Timestamp = timestamp;
        }
    }
}
