using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace ROIMobileApp.Classes
{
    public class Department
    {
        public Department(int id, string name)
        {
            this.Id = id;
            this.Name = name;
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

        /// <summary>
        /// Obtains the name of a department given the Id
        /// </summary>
        private string NameLookup
        {
            get { string value; DepartmentsList depList = new DepartmentsList(); depList.DepartmentList.TryGetValue(Id, out value); return value; }
        }
    }
}
