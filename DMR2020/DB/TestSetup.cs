using Google.Protobuf.WellKnownTypes;
using SqlSugar;

namespace DMR2020.Data
{
    [SugarTable("test_setup")]
    public class TestSetup
    {
        [SugarColumn(ColumnName = "id", IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        [SugarColumn(ColumnName = "test_name")]
        public string TestName { get; set; }

        [SugarColumn(ColumnName = "test_time")]
        public int? TestTime { get; set; }

        [SugarColumn(ColumnName = "torque_unit")]
        public string TorqueUnit { get; set; }

        [SugarColumn(ColumnName = "time_unit")]
        public string TimeUnit { get; set; }

        [SugarColumn(ColumnName = "test_temp")]
        public double? TestTemp { get; set; }

        [SugarColumn(ColumnName = "arc")]
        public double? Arc { get; set; }

        [SugarColumn(ColumnName = "tan_delta_checked")]
        public bool TanDeltaChecked { get; set; }

        [SugarColumn(ColumnName = "result_1_unit")]
        public string Result1Unit { get; set; }

        [SugarColumn(ColumnName = "result_1_value")]
        public string Result1Value { get; set; }

        [SugarColumn(ColumnName = "result_2_unit")]
        public string Result2Unit { get; set; }

        [SugarColumn(ColumnName = "result_2_value")]
        public string Result2Value { get; set; }

        [SugarColumn(ColumnName = "result_3_unit")]
        public string Result3Unit { get; set; }

        [SugarColumn(ColumnName = "result_3_value")]
        public string Result3Value { get; set; }

        [SugarColumn(ColumnName = "result_4_unit")]
        public string Result4Unit { get; set; }

        [SugarColumn(ColumnName = "result_4_value")]
        public string Result4Value { get; set; }
        [SugarColumn(ColumnName = "ml_min_value")]
        public int? MlMinValue { get; set; }

        [SugarColumn(ColumnName = "ml_max_value")]
        public int? MlMaxValue { get; set; }

        [SugarColumn(ColumnName = "ml_checked")]
        public bool MlChecked { get; set; }

        [SugarColumn(ColumnName = "mh_min_value")]
        public int? MhMinValue { get; set; }

        [SugarColumn(ColumnName = "mh_max_value")]
        public int? MhMaxValue { get; set; }

        [SugarColumn(ColumnName = "mh_checked")]
        public bool MhChecked { get; set; }

        [SugarColumn(ColumnName = "ts1_min_value")]
        public int? Ts1MinValue { get; set; }

        [SugarColumn(ColumnName = "ts1_max_value")]
        public int? Ts1MaxValue { get; set; }

        [SugarColumn(ColumnName = "ts1_checked")]
        public bool Ts1Checked { get; set; }

        [SugarColumn(ColumnName = "tc10_min_value")]
        public int? Tc10MinValue { get; set; }

        [SugarColumn(ColumnName = "tc10_max_value")]
        public int? Tc10MaxValue { get; set; }

        [SugarColumn(ColumnName = "tc10_checked")]
        public bool Tc10Checked { get; set; }

        [SugarColumn(ColumnName = "tc50_min_value")]
        public int? Tc50MinValue { get; set; }

        [SugarColumn(ColumnName = "tc50_max_value")]
        public int? Tc50MaxValue { get; set; }

        [SugarColumn(ColumnName = "tc50_checked")]
        public bool Tc50Checked { get; set; }

        [SugarColumn(ColumnName = "tc90_min_value")]
        public int? Tc90MinValue { get; set; }

        [SugarColumn(ColumnName = "tc90_max_value")]
        public int? Tc90MaxValue { get; set; }

        [SugarColumn(ColumnName = "tc90_checked")]
        public bool Tc90Checked { get; set; }

        [SugarColumn(ColumnName = "torque_range")]
        public int TorqueRange { get; set; }

        [SugarColumn(ColumnName = "created_time", IsNullable = true)]
        public DateTime? CreatedTime { get; set; }

    }
}
