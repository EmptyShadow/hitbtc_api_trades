﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Serialization;

namespace Trades.src.Models
{
    /// <summary>
    /// Модель сделки
    /// </summary>
    [DataContract]
    public class TradesModel
    {
        /// <summary>
        /// Индитификатор
        /// </summary>
        [DataMember]
        public long id { get; set; }
        /// <summary>
        /// Стоимость
        /// </summary>
        [DataMember]
        public double price { get; set; }
        /// <summary>
        /// Количество
        /// </summary>
        [DataMember]
        public double quantity { get; set; }
        /// <summary>
        /// Позиция
        /// </summary>
        [DataMember]
        public string side { get; set; }
        /// <summary>
        /// Время сделки
        /// </summary>
        [DataMember]
        public DateTime timestamp { get; set; }

        public TradesModel(int id, int price, int quantity, string side, DateTime timestamp)
        {
            this.id = id;
            this.price = price;
            this.quantity = quantity;
            this.side = side;
            this.timestamp = timestamp;
        }

        public TradesModel() { }

        public override string ToString()
        {
            string end = ";\r\n";
            string s = "id: " + id.ToString() + end;
            s += "price: " + price.ToString() + end;
            s += "quantity: " + quantity.ToString() + end;
            s += "side: " + side.ToString() + end;
            s += "timestamp: " + timestamp.ToString() + end;
            return s;
        }
    }
}
