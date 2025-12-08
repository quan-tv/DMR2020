using System;
using CommunityToolkit.Mvvm.ComponentModel;
using DMR2020.Model;

namespace DMR2020.ViewModel
{
    public partial class FeaturePointVM: ObservableObject
    {
        public int Id { get; set; }
        public string? Title { get; set; }

        #region Tên điểm
        [ObservableProperty]
        private string? _name;
        [ObservableProperty]
        private string? _type;
        [ObservableProperty]
        private double _typeValue;
        #endregion

        #region Kiểm tra đạt
        [ObservableProperty]
        private double _specMin;
        [ObservableProperty]
        private double _specMax;
        [ObservableProperty]
        private bool _isSpecChecked;
        #endregion

        #region Giá trị thực trên đồ thị: X - thời gian, Y - Theo phân loại
        public double CurveY { get; set; }
        public double CurveX { get; set; }
        #endregion

        partial void OnTypeChanged(string? oldValue, string? newValue)
        {
            GenName();
        }

        partial void OnTypeValueChanged(double oldValue, double newValue)
        {
            GenName();
        }

        /// <summary>
        ///  Tạo tên từ Type, TypeValue
        /// </summary>
        private void GenName()
        {
            switch (Type)
            {
                case "MI": Name = "MI"; break;
                case "ML": Name = "ML"; break;
                case "MH": Name = "MH"; break;
                default: Name = $"{Type}{TypeValue}"; break;
            }
        }

        public void FromDO(FeaturePointDO o)
        {
            Id = o.Id;
            Type = o.Type.ToString();
            TypeValue = o.TypeValue;
            SpecMin = o.SpecMin;
            SpecMax = o.SpecMax;
            IsSpecChecked = o.IsSpecChecked;            
        }

        public void ToDO(FeaturePointDO o)
        {
            o.Id = Id;
            o.Type = Type switch
            {
                "MI" => FeaturePointTypes.MI,
                "ML" => FeaturePointTypes.ML,
                "MH" => FeaturePointTypes.MH,
                "ts" => FeaturePointTypes.ts,
                "tc" => FeaturePointTypes.tc,
                "Tc" => FeaturePointTypes.Tc,
                "T" => FeaturePointTypes.T,
                _ => FeaturePointTypes.t,
            };
            o.TypeValue = TypeValue;
            o.SpecMin = SpecMin;
            o.SpecMax = SpecMax;
            o.IsSpecChecked = IsSpecChecked;
        }
    }
}
