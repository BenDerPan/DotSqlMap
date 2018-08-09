using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace SqlmapApi
{
    public class RequestResponse
    {
        public string Content { get; private set; }

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public JToken ContentJToken => JToken.Parse(Content);

        public RequestResponse(string content, string msg = "")
        {
            Content = content;
            Message = msg;
            IsSuccess = (bool)ContentJToken.SelectToken("success");
            if (!IsSuccess && string.IsNullOrEmpty(Message))
            {
                Message = ContentJToken.SelectToken("message").ToString();
            }
        }
    }


    public class SqlmapRawApi
    {
        /// <summary>
        /// Sqlmap server address
        /// </summary>
        public string Host { get; private set; }
        public uint Port { get; private set; }

        public string ApiUrl => $"http://{Host}:{Port}";

        private RestClient restClient;

        public SqlmapRawApi(string host, uint port)
        {
            Host = host;
            Port = port;
            restClient = new RestClient(ApiUrl);
        }

        public RequestResponse Get(string subUrl)
        {
            try
            {
                RestRequest request = new RestRequest(subUrl, Method.GET);
                var res = restClient.Execute(request);
                return new RequestResponse(res.Content);
            }
            catch (Exception e)
            {
                return  new RequestResponse(null,e.Message);
            }
        }

        public RequestResponse Post(string subUrl,object jsonData)
        {
            try
            {
                RestRequest request = new RestRequest(subUrl, Method.POST);
                request.AddJsonBody(jsonData);
                var res = restClient.Execute(request);
                return new RequestResponse(res.Content);
            }
            catch (Exception e)
            {
                return new RequestResponse(null, e.Message);
            }
        }

        public RequestResponse NewTask()
        {
            var res = Get("/task/new");
            return res;

        }

        public RequestResponse DeleteTask(string taskID)
        {
            var res = Get($"/task/{taskID}/delete");
            return res;
        }

        

        public RequestResponse AdminTaskList(string taskID)
        {
            var res = Get($"/admin/{taskID}/list");
            return res;
        } 

        public RequestResponse AdminTaskFlush(string taskID)
        {
            var res = Get($"/admin/{taskID}/flush");
            return res;
        }

        public RequestResponse GetTaskOptionList(string taskID)
        {
            var res = Get($"/option/{taskID}/list");
            return res;
        }

        public RequestResponse GetTaskOption(string taskID, string optionKey)
        {
            var op = new { option=optionKey};
            var res = Post($"/option/{taskID}/get", op);
            return res;
        }

        public RequestResponse SetTaskOption(string taskID,object option)
        {
            var res = Post($"/option/{taskID}/set", option);
            return res;
        }

        public RequestResponse StartScan(string taskID, object option = null)
        {
            if (option == null)
            {
                option = new { };
            }
            var res = Post($"/scan/{taskID}/start", option);
            return res;
        }

        public RequestResponse StopScan(string taskID)
        {
            var res = Get($"/scan/{taskID}/stop");
            return res;
        }


        public RequestResponse KillScan(string taskID)
        {
            var res = Get($"/scan/{taskID}/kill");
            return res;
        }


        public RequestResponse GetScanStatus(string taskID)
        {
            var res = Get($"/scan/{taskID}/status");
            return res;
        }

        public RequestResponse GetScanData(string taskID)
        {
            var res = Get($"/scan/{taskID}/data");
            return res;
        }


        public RequestResponse GetLog(string taskID)
        {
            var res = Get($"/scan/{taskID}/log");
            return res;
        }

        public RequestResponse GetLogRange(string taskID,int start,int end)
        {
            var res = Get($"/scan/{taskID}/log/{start}/{end}");
            return res;
        }

        public RequestResponse DownloadFileToLocal(string taskID,string target,string filename,string path)
        {
            var res = Get($"/download/{taskID}/{target}/{filename}:{path}");
            return res;
        }

    }
}
