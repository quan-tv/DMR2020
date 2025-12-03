using SqlSugar;

namespace DMR2020.Db
{
    /// <summary>
    /// Singleton quản lý SqlSugar cho MariaDB
    /// </summary>
    public sealed class DbBridge
    {
        private const string _testPw = "ncmanh191";

        private static readonly Lazy<DbBridge> _instance =
            new Lazy<DbBridge>(() => new DbBridge());

        public static DbBridge Instance => _instance.Value;

        public SqlSugarScope Client { get; }

        private DbBridge()
        {
            Client = new SqlSugarScope(
                new ConnectionConfig
                {
                    ConnectionString = $"Server=localhost;Port=3306;Database=dmr2020;User Id=root;Password={_testPw};",
                    DbType = DbType.MySql,
                    IsAutoCloseConnection = true,
                    InitKeyType = InitKeyType.Attribute
                },
                db =>
                {
                    db.Aop.OnLogExecuting = (sql, pars) =>
                    {
                        System.Diagnostics.Debug.WriteLine(sql);
                    };
                });
        }

        /// <summary>
        /// Kiểm tra kết nối DB
        /// </summary>
        public bool TestConnection()
        {
            try
            {
                // Lệnh đơn giản để test
                Client.Ado.GetInt("SELECT 1");
                return true;
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("TestConnection Error: " + ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Tạo database nếu chưa có
        /// </summary>
        public void CreateDatabaseIfNotExists()
        {
            try
            {
                // SqlSugar tự kiểm tra, nếu chưa có thì tạo DB + cấu trúc
                Client.DbMaintenance.CreateDatabase();
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine("CreateDatabase Error: " + ex.Message);
                throw;
            }
        }
    }
}
