using System;

namespace Web2App
{
    public class WebAppData
    {
        public WebAppData()
        {

        }
        public WebAppData(string uri)
        {
            Url = new Uri(uri);
        }
        public Uri Url { get; set; }
    }
}
