using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;

namespace Web2App
{
    public class WebAppDataService
    {
        private readonly string _path = Application.UserAppDataPath + @"\settings.json";

        public IEnumerable<WebAppData> Get()
        {
            if (!File.Exists(_path))
            {
                var file = File.Create(_path);
                file.Close();
            }
            var text = File.ReadAllText(_path);
            return JsonConvert.DeserializeObject<IEnumerable<WebAppData>>(text) ?? new List<WebAppData>();
        }

        public void Add(WebAppData entry)
        {
            var data = Get().ToList();
            data.Add(entry);

            File.WriteAllText(_path, JsonConvert.SerializeObject(data));
        }

        public void Remove(Uri url)
        {
            var data = Get().ToList();
            File.WriteAllText(_path, JsonConvert.SerializeObject(data.Where(x => x.Url != url)));
        }
    }
}
