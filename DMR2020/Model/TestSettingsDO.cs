using SqlSugar;

namespace DMR2020.Model
{
    [SugarTable("caidat_diemdactrung")]
    public class TestSettingsDO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public double TestTime { get; set; }
        public double TestTemperature { get; set; }
        public int TorqueUnit { get; set; }
        public int TimeUnit { get; set; }
        public double Arc { get; set; }
        public double CalTanDelta { get; set; }
        public double TorqueRange { get; set; }
    }
}
