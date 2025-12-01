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

        /// <summary>
        ///  Tạo tên từ Type, TypeValue
        /// </summary>
        public void GenName()
        {
            switch (Type)
            {
                case FeaturePointTypes.MI: Name = "MI"; break;
                case FeaturePointTypes.ML: Name = "ML"; break;
                case FeaturePointTypes.MH: Name = "MH"; break;
                case FeaturePointTypes.ts: Name = $"ts{TypeValue}"; break;
                case FeaturePointTypes.tc: Name = $"tc{TypeValue}"; break;
                case FeaturePointTypes.Tc: Name = $"Tc{TypeValue}"; break;
                case FeaturePointTypes.T: Name = $"T{TypeValue}"; break;
                case FeaturePointTypes.t: Name = $"t{TypeValue}"; break;
            }
        }
    }
}
