using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMobileApp.Classes
{
    public class WebContainer
    {
        [JsonProperty("d")]
        public string d { get; set; }
    }
}
