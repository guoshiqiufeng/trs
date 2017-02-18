package cn.autumn.trs.web.basic;

import java.util.List;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import cn.autumn.trs.biz.basic.service.ICarService;
import cn.autumn.trs.biz.basic.service.IUserService;
import cn.autumn.trs.client.basic.car;
import cn.autumn.trs.client.basic.user;

@Controller
@RequestMapping("release")
public class ReleaseController {
	@Resource
	private ICarService carService;
	@Resource
	private IUserService userService;
	@RequestMapping(value="/releaseDelete")
	public String releaseDelete(HttpServletRequest request,Model model){
		String print="[{";
		Long id =Long.parseLong(request.getParameter("id").trim());
        int i= carService.Delete(id);
        if (i > 0)
        {
            print += "\"status\":\"1\"";
        }
        else {
            print += "\"status\":\"0\"";
        }
		print += "}]";
        model.addAttribute("json", print);
		return "login";
	}
	
	@RequestMapping(value="/releaseInsert")
	public String releaseInsert(HttpServletRequest request,Model model){
		String print="[{";
		
		 String token = request.getParameter("token").trim();
		 String startPlace = request.getParameter("startPlace").trim();
		 String endPlace = request.getParameter("endPlace").trim();
		 String date = request.getParameter("date").trim();
		 String time = request.getParameter("time").trim();
		 String carnumber = request.getParameter("carnumber").trim();
		 String carnum = request.getParameter("carnum").trim();
		 String phone = request.getParameter("phone").trim();
         
         user userModel = new user();
         userModel.setToken(token);
         user newUserModel = userService.token(userModel);

         car carModel = new car();
         carModel.setUserId(newUserModel.getId());
         carModel.setCarDestination(endPlace);
         carModel.setCarOrigin(startPlace);
         carModel.setStartdate(date);
         carModel.setStarttime(time);
         carModel.setCarNumber(carnumber);
         carModel.setCarSum(Integer.parseInt(carnum));
         carModel.setType(1);
         carModel.setCarName("");
         carModel.setPhone(phone);

         int m = carService.Insert(carModel);
         if (m != 0)
         {
             print += "\"status\":\"1\"";
         }
         else
         {
             print += "\"status\":\"0\"";
         }
		
		print += "}]";
        model.addAttribute("json", print);
		return "login";
	}
	
	@RequestMapping(value="/releaseSelect")
	public String releaseSelect(HttpServletRequest request,Model model){
		String print="[{";
		
		String token="";
        if (request.getParameter("token")!=null)
        {
            token = request.getParameter("token").trim();
        }
        
        user userModel = new user();
        car carModel = new car();

        carModel.setType(1);
        if(token!=""){
           userModel.setToken(token);
           user newUserModel = userService.token(userModel);
           carModel.setUserId(newUserModel.getId());
        }

        List<car> list = carService.FindAllList(carModel);

        if (list != null)
        {
            print += "\"status\":\"1\"";
            print += ",\"car\":[";
            for (int i = 0; i < list.size();i++ )
            {
                car newCar = list.get(i);
                Long userId = newCar.getUserId();
                user user = userService.SelectOneByID(userId);
                print += "{\"username\":\""+user.getNickName()+"\"";
                print += ",\"id\":\"" + newCar.getId() + "\"";
                print += ",\"phone\":\"" + newCar.getPhone() + "\"";
                print += ",\"startPlace\":\"" + newCar.getCarOrigin() + "\"";
                print += ",\"endPlace\":\"" + newCar.getCarDestination() + "\"";

                print += ",\"datetime\":\"" + newCar.getStartdate()+" " + newCar.getStarttime() + "\"";

                print += ",\"carnumber\":\"" + newCar.getCarNumber() + "\"";
                print += ",\"carnum\":\"" + newCar.getCarSum() + "\"";
               
                print += "}";
                if (i != list.size() - 1) {
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
        model.addAttribute("json", print);
		return "login";
	}
}
