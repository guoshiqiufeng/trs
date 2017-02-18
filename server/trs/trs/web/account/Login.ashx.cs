using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// Login 的摘要说明
    /// </summary>
    public class Login : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var username = context.Request["username"].Trim();
            var password = context.Request["password"].Trim();
            userBLL service = new userBLL();
            user model = new Model.user();
            model.username = username;
            model.password = password.Md5();
            Random ran=new Random();
            int RandKey=ran.Next(100,999);
            string token=username+password+RandKey;
            model.token = token.Md5();
            var a = service.Login(model);
            string url = "http://" + HttpContext.Current.Request.Url.Host + ":" + HttpContext.Current.Request.Url.Port; 
            if (a !=null)
            {
                print += "\"status\":\"1\"";
                print += ",\"token\":\"" + a.token + "\"";
                print += ",\"user\":{";
                print += "\"nname\":\"" + a.nick_name + "\"";
                if (a.uimg == null)
                {
                    print += ",\"uimg\":\"" + url + "/images/user/user.jpg" + "\"";
                }
                else
                {
                    print += ",\"uimg\":\"" + url + a.uimg + "\"";
                }
                print += ",\"phone\":\"" + a.phone + "\"";
                print += "}";
            }
            else
            {
                print += "\"status\":\"0\"";
                print += ",\"token\":\"\"";
            }
            
            print += "}]";
            context.Response.Write(print);
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}