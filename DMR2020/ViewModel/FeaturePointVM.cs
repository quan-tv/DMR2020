using System;
using CommunityToolkit.Mvvm.ComponentModel;
using DMR2020.Model;

namespace DMR2020.ViewModel
{
    public partial class FeaturePointVM: ObservableObject
    {
        #region Tên điểm
        [ObservableProperty]
        private string? _name;
        [ObservableProperty]
        private FeaturePointTypes _type;
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

        partial void OnTypeChanged(FeaturePointTypes oldValue, FeaturePointTypes newValue)
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
