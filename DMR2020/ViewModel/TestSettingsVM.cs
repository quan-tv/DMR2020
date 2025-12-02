using CommunityToolkit.Mvvm.ComponentModel;

namespace DMR2020.ViewModel
{
    public partial class TestSettingsVM: ObservableObject
    {
        [ObservableProperty]
        private string? _name;
        [ObservableProperty]
        private double _testTime;
        [ObservableProperty]
        private double _testTemperature;
        [ObservableProperty]
        private int _torqueUnit;
        [ObservableProperty]
        private int _timeUnit;
        [ObservableProperty]
        private double _arc;
        [ObservableProperty]
        private bool _calTanDelta;
        [ObservableProperty]
        private int _torqueRange;

        public List<FeaturePointVM> FeaturePoints { get; set; } = [];

        public TestSettingsVM()
        {
            FeaturePoints.Add(new FeaturePointVM() { 
                Type = "ML"
            });
            FeaturePoints.Add(new FeaturePointVM()
            {
                Type = "MH"
            });
            FeaturePoints.Add(new FeaturePointVM()
            {
                Title = "Result 1",
                Type = "ts",
                TypeValue = 1,
            });
            FeaturePoints.Add(new FeaturePointVM()
            {
                Title = "Result 2",
                Type = "tc",
                TypeValue = 10,
            });
            FeaturePoints.Add(new FeaturePointVM()
            {
                Title = "Result 3",
                Type = "tc",
                TypeValue = 50,
            });
            FeaturePoints.Add(new FeaturePointVM()
            {
                Title = "Result 4",
                Type = "tc",
                TypeValue = 90
            });
        }
    }
}
