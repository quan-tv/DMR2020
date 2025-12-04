using SqlSugar;

namespace DMR2020.Model
{
    [SugarTable("caidat_kieuthu")]
    public class TestSettingsDO: BaseDataTransferObject
    {
        [SugarColumn(ColumnName = "ten")]
        public string? Name { get; set; }
        [SugarColumn(ColumnName = "tgthu")]
        public double TestTime { get; set; }
        [SugarColumn(ColumnName = "nhietdothu")]
        public double TestTemperature { get; set; }
        [SugarColumn(ColumnName = "donvimomen")]
        public int TorqueUnit { get; set; }
        [SugarColumn(ColumnName = "donvitg")]
        public int TimeUnit { get; set; }
        [SugarColumn(ColumnName = "arc")]
        public double Arc { get; set; }
        [SugarColumn(ColumnName = "tinhtandelta")]
        public bool CalTanDelta { get; set; }
        [SugarColumn(ColumnName = "daimomen")]
        public double TorqueRange { get; set; }
    }
}
