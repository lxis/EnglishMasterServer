<%@ WebHandler Language="C#" Class="ArticleHandler" %>

using System;
using System.Web;

public class ArticleHandler : IHttpHandler {
    
    public void ProcessRequest (HttpContext context) {
        string url = context.Request.Url.ToString();        
        System.Collections.Specialized.NameValueCollection requestParams = context.Request.QueryString;
        System.Collections.Generic.IDictionary<string,string> paramDic = new System.Collections.Generic.Dictionary<string,string>();
        for(int i = 0;i<requestParams.Keys.Count;i++)
        {
            string key = requestParams.Keys.Get(i);
            string value = requestParams.Get(i);
            paramDic.Add(new System.Collections.Generic.KeyValuePair<string, string>(key, value));
        }
        Domain.ResponseMessage<Domain.ArticleCollection> response = new Domain.ResponseMessage<Domain.ArticleCollection>();
        if (!paramDic.ContainsKey("in") || !paramDic.ContainsKey("rn"))
        {
            response.Error = new Domain.ExceptionMessage();
            response.Error.Code = 1;
            response.Error.Message = "参数不对";
        }
        else
        {
            response.Data = new Domain.ArticleServices().GetArticle(paramDic["in"], paramDic["rn"]);
        }
        context.Response.ContentType = "text/plain";
        string responseText = Newtonsoft.Json.JsonConvert.SerializeObject(response);
        context.Response.Write(responseText);
    }
 
    public bool IsReusable {
        get {
            return false;
        }
    }

}

