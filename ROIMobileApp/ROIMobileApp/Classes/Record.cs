using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMobileApp.Classes
{
    public class Record
    {
        public Record(int id, string name, string phone, Department department, Address address)
        {
            this.Id = id;
            this.Name = name;
            this.Phone = phone;
            this.Department = department;
            this.Address = address;
        }

        [JsonProperty("Id")]
        public int Id
        {
            get;
            set;
        }

        [JsonProperty("Name")]
        public string Name
        {
            get;
            set;
        }

        [JsonProperty("Phone")]
        public string Phone
        {
            get;
            set;
        }

        [JsonProperty("Department")]
        public Department Department
        {
            get;
            set;
        }

        [JsonProperty("Address")]
        public Address Address
        {
            get;
            set;
        }
    }
}
