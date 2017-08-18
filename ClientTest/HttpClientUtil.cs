using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DuoMall.IISClientTest
{
    public class HttpClientUtil
    {

        // REST @GET 方法，根据泛型自动转换成实体，支持List<T>
        public static T Get<T>(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(metodUrl);
            request.Method = "get";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = null;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (WebException e)
            {
                response = (HttpWebResponse)e.Response;
                //HandleError(e.Message + " - " + getRestErrorMessage(response));

                return default(T);
            }
            string json = GetResponseString(response);
            return JsonConvert.ParseJson<T>(json);
        }


        // REST @POST 方法
        public static T Post<T>(string metodUrl, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(metodUrl);
            request.Method = "post";
            request.ContentType = "application/json;charset=UTF-8";
            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = GetResponseString(response);
            return JsonConvert.ParseJson<T>(json);
        }

        // REST @PUT 方法
        public static string Put(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(metodUrl);
            request.Method = "put";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            {
                return reader.ReadToEnd();
            }
        }

        // REST @PUT 方法，带发送内容主体
        public static T Put<T>(string metodUrl, string jsonBody)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(metodUrl);
            request.Method = "put";
            request.ContentType = "application/json;charset=UTF-8";
            var stream = request.GetRequestStream();
            using (var writer = new StreamWriter(stream))
            {
                writer.Write(jsonBody);
                writer.Flush();
            }
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            string json = GetResponseString(response);
            return JsonConvert.ParseJson<T>(json);
        }

        // REST @DELETE 方法
        public static bool Delete(string metodUrl)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(metodUrl);
            request.Method = "delete";
            request.ContentType = "application/json;charset=UTF-8";
            HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            {
                string responseString = reader.ReadToEnd();
                if (responseString.Equals("1"))
                {
                    return true;
                }
                return false;
            }
        }

        #region s

        // 获取异常信息
        private static string HandleError(HttpWebResponse errorResponse)
        {
            string errorhtml = GetResponseString(errorResponse);
            string errorkey = "spi.UnhandledException:";
            errorhtml = errorhtml.Substring(errorhtml.IndexOf(errorkey) + errorkey.Length);
            errorhtml = errorhtml.Substring(0, errorhtml.IndexOf("\n"));
            return errorhtml;
        }

        // 将 HttpWebResponse 返回结果转换成 string
        private static string GetResponseString(HttpWebResponse response)
        {
            string json = null;
            using (StreamReader reader = new StreamReader(response.GetResponseStream(), System.Text.Encoding.GetEncoding("UTF-8")))
            {
                json = reader.ReadToEnd();
            }
            return json;
        }
        #endregion
    }
}