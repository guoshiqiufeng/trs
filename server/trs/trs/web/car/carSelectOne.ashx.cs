using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing.web.car
{
    /// <summary>
    /// carSelectOne 的摘要说明
    /// </summary>
    public class carSelectOne : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var id = long.Parse(context.Request["id"].Trim());

            userBLL userService = new userBLL();
            user userModel = new user();

            carBLL carService = new carBLL();
            TakeRing.Model.car carModel = new TakeRing.Model.car();
            carModel= carService.QuerySingle(id);

            if(carModel!=null){
                print += "\"status\":\"1\"";
                print += ",\"car\":{";

                var newCar = carModel;
                var userId = newCar.user_id;
                var user = userService.QuerySingle(userId);
                print += "\"username\":\"" + user.nick_name + "\"";
                print += ",\"id\":\"" + newCar.id + "\"";
                print += ",\"phone\":\"" + newCar.phone + "\"";
                print += ",\"startPlace\":\"" + newCar.car_origin + "\"";
                print += ",\"endPlace\":\"" + newCar.car_destination + "\"";
                var d = newCar.startDate;
                var m = d.GetDateTimeFormats()[4];

                print += ",\"datetime\":\"" + m +"\"";
                print += ",\"time\":\"" +newCar.startTime.ToString().Substring(0,5) + "\"";
                print += ",\"carnumber\":\"" + newCar.car_number + "\"";
                print += ",\"carnum\":\"" + newCar.car_sum + "\"";

                print += "}";
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