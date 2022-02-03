using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMobileApp.Classes
{
    public class Address
    {
        public Address(string street, string city, string zip, string country)
        {
            this.Street = street;
            this.City = city;
            this.ZIP = zip;
            this.Country = country;
        }

        [JsonProperty("Street")]
        public string Street
        {
            get;
            set;
        }

        [JsonProperty("City")]
        public string City
        {
            get;
            set;
        }

        [JsonProperty("State")]
        public string State
        {
            get;
            set;
        }

        [JsonProperty("ZIP")]
        public string ZIP
        {
            get;
            set;
        }

        [JsonProperty("Country")]
        public string Country
        {
            get;
            set;
        }
    }
}
