using System.Globalization;
using System.Diagnostics;
using FileService;
using LogServices;




namespace Middleware;
public class WriteToLogMiddleware
{

    private Ilog _log;
    private readonly RequestDelegate _next;
    public WriteToLogMiddleware(RequestDelegate next)
    {
       _next=next;
    }
    public async Task InvokeAsync(HttpContext context,Ilog log)
    {
        _log=log;
        string str=(DateTime.Now).ToString();
        log.WriteMessage("date and time of request: "+ str+"\n");
        log.WriteMessage("method :"+context.Request.Method+"\n");
        string str1=(context.Request.Body).ToString();
        log.WriteMessage("action :"+str1+"\n");
        string str2=(context.Request.Headers).ToString();
        log.WriteMessage("body "+str2+"\n");
         await _next(context);
         string str3=(DateTime.Now).ToString();
        log.WriteMessage("date and time of response: "+str3+"\n");
        string str4=(context.Response.StatusCode).ToString();
        log.WriteMessage("status code of response :"+str4+"\n");
        string str5=(context.Response.Body).ToString();
        log.WriteMessage("body of response: "+str5+"\n");
    }
   
}

