using DMR2020.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Documents;

namespace DMR2020.DB
{
    public class PMSettings
    {
        private static readonly Lazy<PMSettings> _instance =
            new Lazy<PMSettings>(() => new PMSettings());

        public static PMSettings Instance => _instance.Value;

        public Dictionary<string, Settings> SettingsDict { get; private set; }

        private PMSettings()
        {
            Load();
        }

        private void Load()
        {
            var list = Db.Instance.Client.Queryable<Settings>().ToList();

            SettingsDict = new Dictionary<string, Settings>();

            foreach (var item in list)
            {
                // key = item.ten, value = object Settings
                SettingsDict[item.ten] = item;
            }
        }

        // Đề phòng khi cần đọc lại dữ liệu
        public void Reload()
        {
            Load();        
        }

        public void Save()
        {
            foreach (var item in SettingsDict.Values)
            {
                Db.Instance.Client.Updateable(item).ExecuteCommand();
            }
        }
    }

}


