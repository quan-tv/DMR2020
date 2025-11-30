using SqlSugar;
using System;

namespace DMR2020.Data
{
    /// <summary>
    /// Singleton quản lý SqlSugar cho MariaDB
    /// </summary>
    public sealed class Db
    {
        // Singleton instance
        private static readonly Lazy<Db> _instance =
            new Lazy<Db>(() => new Db());

        public static Db Instance => _instance.Value;

        // SqlSugarScope: thread-safe, dùng làm singleton
        public SqlSugarScope Client { get; }

        private Db()
        {
            Client = new SqlSugarScope(
                new ConnectionConfig
                {
                    ConnectionString = "Server=localhost;Port=3306;Database=dmr2020;User Id=root;Password=123456aA@;",
                    DbType = DbType.MySql,          // MariaDB dùng MySql
                    IsAutoCloseConnection = true,   // tự đóng connection
                    InitKeyType = InitKeyType.Attribute // dùng [SugarColumn] nếu có
                },
                db =>
                {
                    // Log SQL cho dễ debug (nếu không thích thì bỏ)
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        System.Diagnostics.Debug.WriteLine(sql);
                    };
                });
        }
    }
}