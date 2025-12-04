using Google.Protobuf.WellKnownTypes;
using SqlSugar;

namespace DMR2020.Data
{
    [SugarTable("settings")]
    public class Settings
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "password")]
        public string password { get; set; }
    }
}
