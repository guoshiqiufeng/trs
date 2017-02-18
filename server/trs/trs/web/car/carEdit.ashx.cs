using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TakeRing.BLL;

namespace TakeRing.web.car
{
    /// <summary>
    /// carEdit 的摘要说明
    /// </summary>
    public class carEdit : IHttpHandler
    {

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            String print = "[{";
            var id = long.Parse(context.Request["id"].Trim());
            var phone=context.Request["phone"].Trim();
            var startPlace=context.Request["startPlace"].Trim();
            var endPlace=context.Request["endPlace"].Trim();
            var date=context.Request["date"].Trim();
            var time=context.Request["time"].Trim();
            var carnum=Convert.ToInt32(context.Request["carnum"].Trim());
            
            carBLL carService = new carBLL();
            TakeRing.Model.car carModel = new TakeRing.Model.car();

            carModel.id = id;
            carModel.phone=phone;
            carModel.car_origin = startPlace;
            carModel.car_destination = endPlace;
            carModel.startDate = Convert.ToDateTime(date);
            carModel.startTime = TimeSpan.Parse(time);
            carModel.car_sum = carnum;

            var i = carService.UpdateCar(carModel);

            if (i >0)
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