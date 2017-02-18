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
@RequestMapping("car")
public class CarController {
	@Resource 
	private ICarService carService;
	@Resource
	private IUserService userService;
	@RequestMapping(value="/carInsert")
	public String carInsert(HttpServletRequest request,Model model){
		String print="[{";
		String token = request.getParameter("token").trim();
		String startPlace =request.getParameter("startPlace").trim();
		String endPlace = request.getParameter("endPlace").trim();
		String date = request.getParameter("date").trim();
		String time = request.getParameter("time").trim();
         
		String carnum =request.getParameter("carnum").trim();
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
        carModel.setCarNumber("");
        carModel.setCarSum(Integer.parseInt(carnum));
        carModel.setType(0);
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
	
	@RequestMapping(value="/carEdit")
	public String carEdit(HttpServletRequest request,Model model){
		String print="[{";
		Long id = Long.parseLong(request.getParameter("id").trim());
        String phone=request.getParameter("phone").trim();
        String startPlace=request.getParameter("startPlace").trim();
        String endPlace=request.getParameter("endPlace").trim();
        String date=request.getParameter("date").trim();
        String time=request.getParameter("time").trim();
        Integer carnum=Integer.parseInt(request.getParameter("carnum").trim());
        
        car carModel = new car();

        carModel.setId(id);
        carModel.setPhone(phone);
        carModel.setCarOrigin(startPlace);
        carModel.setCarDestination(endPlace);
        carModel.setStartdate(date);
        carModel.setStarttime(time);
        carModel.setCarSum(carnum);

        int i = carService.UpdateCar(carModel);

        if (i >0)
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
	
	@RequestMapping(value="/carSelect")
	public String carSelect(HttpServletRequest request,Model model){
		String print="[{";
		String token="";
		if(request.getParameter("token")!=null){
			token =request.getParameter("token");
		}

        user userModel = new user();

        car carModel = new car();

        carModel.setType(0);
        
        if (token != "")
        {
            userModel.setToken(token);
            user newUserModel = userService.token(userModel);
            carModel.setUserId(newUserModel.getId());
        }

        List<car> list = carService.FindAllList(carModel);

        if (list != null)
        {
            print += "\"status\":\"1\"";
            print += ",\"car\":[";
            for (int i = 0; i < list.size(); i++)
            {
                car newCar = list.get(i);
                Long userId = newCar.getUserId();
                user user = userService.SelectOneByID(userId);
                print += "{\"username\":\"" + user.getNickName() + "\"";
                print += ",\"id\":\"" + newCar.getId() + "\"";
                print += ",\"phone\":\"" + newCar.getPhone() + "\"";
                print += ",\"startPlace\":\"" + newCar.getCarOrigin() + "\"";
                print += ",\"endPlace\":\"" + newCar.getCarDestination() + "\"";

                print += ",\"datetime\":\"" + newCar.getStartdate() +" "+ newCar.getStarttime() + "\"";

                print += ",\"carnumber\":\"" + newCar.getCarNumber() + "\"";
                print += ",\"carnum\":\"" + newCar.getCarSum() + "\"";

                print += "}";
                if (i != list.size() - 1)
                {
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
	
	@RequestMapping(value="/carSelectOne")
	public String carSelectOne(HttpServletRequest request,Model model){
		String print="[{";
		Long id = Long.parseLong(request.getParameter("id").trim());

        car carModel = new car();
        carModel= carService.SelectByID(id);

        if(carModel!=null){
            print += "\"status\":\"1\"";
            print += ",\"car\":{";

            car newCar = carModel;
            Long userId = newCar.getUserId();
            user user = userService.SelectOneByID(userId);
            print += "\"username\":\"" + user.getNickName() + "\"";
            print += ",\"id\":\"" + newCar.getId() + "\"";
            print += ",\"phone\":\"" + newCar.getPhone() + "\"";
            print += ",\"startPlace\":\"" + newCar.getCarOrigin() + "\"";
            print += ",\"endPlace\":\"" + newCar.getCarDestination() + "\"";

            print += ",\"datetime\":\"" + newCar.getStartdate() +"\"";
            print += ",\"time\":\"" +newCar.getStarttime() + "\"";
            print += ",\"carnumber\":\"" + newCar.getCarNumber() + "\"";
            print += ",\"carnum\":\"" + newCar.getCarSum()+ "\"";

            print += "}";
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
