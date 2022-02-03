using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ROIMobileApp.Classes
{
    class RestService
    {
        HttpClient _client;

        /// <summary>
        /// Instantiates the HTTP client
        /// </summary>
        public RestService()
        {
            _client = new HttpClient();
        }

        private class RecordIdWrapper
        {
            public int recordId { get; set; }
        }

        public async Task<List<Department>> GetDepartmentsAsync(string uri)
        {
            List<Department> departments = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WebContainer newObj = JsonConvert.DeserializeObject<WebContainer>(content);
                    departments = JsonConvert.DeserializeObject<List<Department>>(newObj.d);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR {ex.Message}");
            }

            return departments;
        }

        public async Task<List<Record>> GetRecordsAsync(string uri)
        {
            List<Record> records = null;

            try
            {
                HttpResponseMessage response = await _client.GetAsync(uri);
                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WebContainer newObj = JsonConvert.DeserializeObject<WebContainer>(content);
                    records = JsonConvert.DeserializeObject<List<Record>>(newObj.d);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return records;
        }

        public async Task<string> AddRecordAsync(string uri, object newRecord)
        {
            string recordId = "Error adding record";

            try
            {
                var jsonData = new StringContent(JsonConvert.SerializeObject(newRecord), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, jsonData);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WebContainer newObj = JsonConvert.DeserializeObject<WebContainer>(content);
                    RecordIdWrapper recordIdWrapper = JsonConvert.DeserializeObject<RecordIdWrapper>(newObj.d);
                    recordId = recordIdWrapper.recordId.ToString();
                }
                else
                {
                    throw new Exception("Error response from AddRecord");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return recordId;
        }

        public async Task<string> UpdateRecordAsync(string uri, object updateRecord)
        {
            string recordId = "Error adding record";

            try
            {
                var jsonData = new StringContent(JsonConvert.SerializeObject(updateRecord), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, jsonData);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WebContainer newObj = JsonConvert.DeserializeObject<WebContainer>(content);
                    RecordIdWrapper recordIdWrapper = JsonConvert.DeserializeObject<RecordIdWrapper>(newObj.d);
                    recordId = recordIdWrapper.recordId.ToString();
                }
                else
                {
                    throw new Exception("Error response from UpdateRecord");
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return recordId;
        }

        public async Task<string> DeleteRecordAsync(string uri, int id)
        {
            object data = new { personId = id };
            string recordId = "Error adding record";

            try
            {
                var jsonData = new StringContent(JsonConvert.SerializeObject(data), Encoding.UTF8, "application/json");
                HttpResponseMessage response = await _client.PostAsync(uri, jsonData);

                if (response.IsSuccessStatusCode)
                {
                    string content = await response.Content.ReadAsStringAsync();
                    WebContainer newObj = JsonConvert.DeserializeObject<WebContainer>(content);
                    RecordIdWrapper recordIdWrapper = JsonConvert.DeserializeObject<RecordIdWrapper>(newObj.d);
                    recordId = recordIdWrapper.recordId.ToString();
                }
                else
                {
                    throw new Exception(response.Content.ReadAsStringAsync().Result + " ID: " + recordId);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"\tERROR: {ex.Message}");
            }

            return recordId;
        }
    }
}
