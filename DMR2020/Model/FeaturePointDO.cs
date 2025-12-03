using SqlSugar;

namespace DMR2020.Model
{
    // TODO: xác định ý nghĩa của Tc, T, t
    public enum FeaturePointTypes { MI = 0, ML = 1, MH = 2, ts = 3, tc = 4, Tc = 5, T = 6, t = 7 }

    [SugarTable("caidat_diemdactrung")]
    /// <summary>
    /// Các điểm đặc trưng của đồ thị
    /// </summary>
    public class FeaturePointDO
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        #region Tên điểm
        [SugarColumn(ColumnName="kieu")]
        public FeaturePointTypes Type { get; set; }
        [SugarColumn(ColumnName="kieu_giatri")]
        public double TypeValue { get; set; }
        #endregion

        #region Kiểm tra đạt
        [SugarColumn(ColumnName="spec_min")]
        public double SpecMin { get; set; }
        [SugarColumn(ColumnName="spec_max")]
        public double SpecMax { get; set; }
        [SugarColumn(ColumnName="spec_check")]
        public bool IsSpecChecked { get; set; }

        public bool EqualContent(FeaturePointDO? other)
        {
            if (other == null) return false;
            return Type == other.Type && TypeValue == other.TypeValue && SpecMin == other.SpecMin && SpecMax == other.SpecMax && IsSpecChecked == other.IsSpecChecked;
        }
        #endregion
    }
}
