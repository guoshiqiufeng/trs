using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing.web.car
{
    /// <summary>
    /// carInsert 的摘要说明
    /// </summary>
    public class carInsert : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var token = context.Request["token"].Trim();
            var startPlace = context.Request["startPlace"].Trim();
            var endPlace = context.Request["endPlace"].Trim();
            var date = context.Request["date"].Trim();
            var time = context.Request["time"].Trim();
            
            var carnum = context.Request["carnum"].Trim();
            var phone = context.Request["phone"].Trim();

            userBLL userService = new userBLL();
            user userModel = new user();
            userModel.token = token;
            var newUserModel = userService.token(userModel);

            carBLL carService = new carBLL();
            TakeRing.Model.car carModel = new TakeRing.Model.car();
            carModel.user_id = newUserModel.id;
            carModel.car_destination = endPlace;
            carModel.car_origin = startPlace;
            carModel.startDate = Convert.ToDateTime(date);
            carModel.startTime = TimeSpan.Parse(time);
            carModel.car_number = "";
            carModel.car_sum = Convert.ToInt32(carnum);
            carModel.type = 0;
            carModel.car_name = "";
            carModel.phone = phone;

            var m = carService.Insert(carModel);
            if (m != 0)
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