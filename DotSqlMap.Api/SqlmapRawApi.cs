using System;
using Newtonsoft.Json.Linq;
using RestSharp;

namespace DotSqlMap.Api
{
    public class RawResponse
    {
        public string Content { get; private set; }

        public bool IsSuccess { get; private set; }

        public string Message { get; private set; }

        public JToken ContentJToken => JToken.Parse(Content);

        public RawResponse(string content, string msg = "")
        {
            Content = content;
            Message = msg;
            if (Content==null)
            {
                IsSuccess = false;
            }
            else
            {
                IsSuccess = (bool)ContentJToken.SelectToken("success");
            }
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

        public RawResponse Get(string subUrl)
        {
            try
            {
                RestRequest request = new RestRequest(subUrl, Method.GET);
                var res = restClient.Execute(request);
                return new RawResponse(res.Content);
            }
            catch (Exception e)
            {
                return  new RawResponse(null,e.Message);
            }
        }

        public RawResponse Post(string subUrl,object jsonData)
        {
            try
            {
                RestRequest request = new RestRequest(subUrl, Method.POST);
                request.AddJsonBody(jsonData);
                var res = restClient.Execute(request);
                return new RawResponse(res.Content);
            }
            catch (Exception e)
            {
                return new RawResponse(null, e.Message);
            }
        }

        public RawResponse NewTask()
        {
            var res = Get("/task/new");
            return res;

        }

        public RawResponse DeleteTask(string taskID)
        {
            var res = Get($"/task/{taskID}/delete");
            return res;
        }

        

        public RawResponse AdminTaskList(string taskID)
        {
            var res = Get($"/admin/{taskID}/list");
            return res;
        } 

        public RawResponse AdminTaskFlush(string taskID)
        {
            var res = Get($"/admin/{taskID}/flush");
            return res;
        }

        public RawResponse GetTaskOptionList(string taskID)
        {
            var res = Get($"/option/{taskID}/list");
            return res;
        }

        public RawResponse GetTaskOption(string taskID, string optionKey)
        {
            var op = new { option=optionKey};
            var res = Post($"/option/{taskID}/get", op);
            return res;
        }

        public RawResponse SetTaskOption(string taskID,object option)
        {
            var res = Post($"/option/{taskID}/set", option);
            return res;
        }

        public RawResponse StartScan(string taskID, object option = null)
        {
            if (option == null)
            {
                option = new { };
            }
            var res = Post($"/scan/{taskID}/start", option);
            return res;
        }

        public RawResponse StopScan(string taskID)
        {
            var res = Get($"/scan/{taskID}/stop");
            return res;
        }


        public RawResponse KillScan(string taskID)
        {
            var res = Get($"/scan/{taskID}/kill");
            return res;
        }


        public RawResponse GetScanStatus(string taskID)
        {
            var res = Get($"/scan/{taskID}/status");
            return res;
        }

        public RawResponse GetScanData(string taskID)
        {
            var res = Get($"/scan/{taskID}/data");
            return res;
        }


        public RawResponse GetLog(string taskID)
        {
            var res = Get($"/scan/{taskID}/log");
            return res;
        }

        public RawResponse GetLogRange(string taskID,int start,int end)
        {
            var res = Get($"/scan/{taskID}/log/{start}/{end}");
            return res;
        }

        public RawResponse DownloadFileToLocal(string taskID,string target,string filename,string path)
        {
            var res = Get($"/download/{taskID}/{target}/{filename}:{path}");
            return res;
        }

    }
}
