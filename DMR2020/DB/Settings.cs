using SqlSugar;

namespace DMR2020.Data
{
    [SugarTable("pm_settings")]
    public class Settings
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "ten")]
        public string ten { get; set; }

        [SugarColumn(ColumnName = "giatri")]
        public string giatri { get; set; }

        [SugarColumn(ColumnName = "kieu")]
        public int kieu { get; set; }
    }
}
