using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// tokenUpdate 的摘要说明
    /// </summary>
    public class tokenUpdate : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var token = context.Request["token"].Trim();
            var name = context.Request["name"].Trim();
            var usex=context.Request["usex"].Trim();
			var phone=context.Request["phone"].Trim();
			var email=context.Request["email"].Trim();

            userBLL service = new userBLL();
            user model = new user();
            model.token = token;
            model.nick_name = name;
            model.usex = Convert.ToInt32(usex);
            model.phone = phone;
            model.email = email;
            var m = service.tokenUpdate(model);
            if (m >= 0)
            {
                print += "\"status\":\"1\"";
            }
            else
            {
                print += "\"status\":\"0\"";
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