using MarketForce.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MarketForce.Data
{
   public class HttpReq
    {
        private string BaseAddres = "https://dev-kfgfly.marketforce.com/api/api/report";


        public async Task MakeString()
        {
            try
            {


                var getData = JsonConvert.DeserializeObject<RequestData>(await TestGet());
            }
            catch (Exception ex)
            {
                var a = ex.Message.ToString();
            }
        }

        public async Task<string>  TestGet()
        {
           
            string testRequest = "";
            try
            {

                var request = HttpWebRequest.CreateHttp(BaseAddres + "");
                request.Method = WebRequestMethods.Http.Get;
                request.Headers.Add("Authorization: bc4b0be2fdd660c46df39aa418423b6d");
                request.Accept = "application/json; charset=utf-8";

                await Task.Factory.FromAsync<WebResponse>(request.BeginGetResponse, request.EndGetResponse, null)
                    .ContinueWith(task =>
                    {
                        var respons = (HttpWebResponse)task.Result;
                        if(respons.StatusCode == HttpStatusCode.OK)
                        {
                            StreamReader responseReader = new StreamReader(respons.GetResponseStream(), Encoding.UTF8);
                            string responseData = responseReader.ReadToEnd();

                            testRequest = responseData.ToString();
                            responseReader.Close();

                        }

                        respons.Close();

                    });
            }
            catch(Exception)
            {
                //just pass
            }


            return testRequest;
        }
    }
}
