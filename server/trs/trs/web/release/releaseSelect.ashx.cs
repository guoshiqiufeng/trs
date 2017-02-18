using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;
using TakeRing.Model;

namespace TakeRing
{
    /// <summary>
    /// releaseSelect 的摘要说明
    /// </summary>
    public class releaseSelect : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var token="";
            if (context.Request["token"]!=null)
            {
                token = context.Request["token"].Trim();
            }
            
            
            userBLL userService = new userBLL();
            user userModel = new user();

            carBLL carService = new carBLL();
            car carModel = new car();

            carModel.type =1;
            if(token!=""){
               userModel.token = token;
               var newUserModel = userService.token(userModel);
               carModel.user_id = newUserModel.id;
            }

            var list = carService.QueryAllList(carModel);

            if (list != null)
            {
                print += "\"status\":\"1\"";
                print += ",\"car\":[";
                for (int i = 0; i < list.Count;i++ )
                {
                    var newCar = list[i];
                    var userId = newCar.user_id;
                    var user = userService.QuerySingle(userId);
                    print += "{\"username\":\""+user.nick_name+"\"";
                    print += ",\"id\":\"" + newCar.id + "\"";
                    print += ",\"phone\":\"" + newCar.phone + "\"";
                    print += ",\"startPlace\":\"" + newCar.car_origin + "\"";
                    print += ",\"endPlace\":\"" + newCar.car_destination + "\"";
                    var d = newCar.startDate;
                    var m = d.GetDateTimeFormats()[4];

                    print += ",\"datetime\":\"" + m+" " + newCar.startTime + "\"";

                    print += ",\"carnumber\":\"" + newCar.car_number + "\"";
                    print += ",\"carnum\":\"" + newCar.car_sum + "\"";
                   
                    print += "}";
                    if (i != list.Count - 1) {
                        print += ",";
                    }
            
                }
                print += "]";
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