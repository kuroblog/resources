
namespace WebApiSite.WebLoadTests
{
    using Microsoft.VisualStudio.TestTools.WebTesting;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.ComponentModel;

    [DisplayName(nameof(JsonExtRule))]
    [Description("从返回的json对象拉取特定的值保存到上下文参数中去")]
    public class JsonExtRule : ExtractionRule
    {
        public string Token { get; set; }

        public override void Extract(object sender, ExtractionEventArgs e)
        {
            var jString = e.Response.BodyString;
            var jObject = JsonConvert.DeserializeObject<JObject>(jString);
            if (jObject == null)
            {
                e.Success = false;
                e.Message = "Response received not in JSON format";
            }
            else
            {
                var jToken = jObject.SelectToken(Token);
                if (jToken == null)
                {
                    e.Success = false;
                    e.Message = String.Format("{0} : Not found", Token);
                }
                else
                {
                    e.Success = true;
                    e.WebTest.Context.Add(ContextParameterName, jToken);
                }
            }
        }
    }
}
