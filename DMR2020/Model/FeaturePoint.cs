namespace DMR2020.Model
{
    // TODO: xác định ý nghĩa của Tc, T, t
    public enum FeaturePointTypes { MI = 0, ML = 1, MH = 2, ts = 3, tc = 4, Tc = 5, T = 6, t = 7 }

    /// <summary>
    /// Các điểm đặc trưng của đồ thị
    /// </summary>
    public class FeaturePoint
    {
        #region Tên điểm
        public string? Name { get; set; }        
        public FeaturePointTypes Type { get; set; }
        public double TypeValue { get; set; }
        #endregion

        #region Kiểm tra đạt
        public double SpecMin { get; set; }
        public double SpecMax { get; set; }
        public bool IsSpecHasMin { get; set; }
        public bool IsSpecHasMax { get; set; }
        #endregion

        #region Giá trị thực trên đồ thị: X - thời gian, Y - Theo phân loại
        public double CurveY { get; set; }
        public double CurveX { get; set; }
        #endregion
    }
}
