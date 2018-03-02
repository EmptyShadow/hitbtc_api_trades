using System;
using System.Collections.Generic;
using System.Text;
using Trades.src.Models;
using Microsoft.EntityFrameworkCore;

namespace Trades.src
{
    /// <summary>
    /// База данных
    /// </summary>
    class TradesContext : DbContext
    {
        public const string SERVER_DB = "server=127.0.0.1;";
        public const string PORT_DB = "port=3306;";
        public const string USER = "UserId=root;";
        public const string DB = "database=trades;";
        public const string PWD = "Password=1234;";
        
        public DbSet<Trade> Trades { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySQL(GetMYSQLStringLink());
        }

        /// <summary>
        /// Получение строки подключения к MYSQL
        /// </summary>
        /// <returns></returns>
        public static string GetMYSQLStringLink()
        {
            return SERVER_DB + PORT_DB + USER + DB + PWD;
        }
    }
}
