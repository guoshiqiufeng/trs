package cn.autumn.trs.web.basic;

import java.util.Random;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import cn.autumn.trs.biz.basic.service.IUserService;
import cn.autumn.trs.biz.util.PasswordUtil;
import cn.autumn.trs.client.basic.user;

@Controller
@RequestMapping("account")
public class UserController {
	@Resource
	private IUserService userService;
	
	@RequestMapping(value="/login")
	public String Login(HttpServletRequest request,Model model){
		String username=request.getParameter("username").trim();
		String password=request.getParameter("password").trim();
		user userModel=new user();
		userModel.setUsername(username);
		userModel.setPassword(PasswordUtil.encrypt(password));
		
        //Random ran=new Random();
        //int RandKey=ran.nextInt(999)%(900)+100;
       // String token=username+password+RandKey;
        //userModel.setToken(PasswordUtil.encrypt(token));
        user a = userService.Login(userModel);
		
		String url = request.getScheme() +"://" + request.getServerName()  
	                        + ":" +request.getServerPort()+ "/trs";
		String print="[{";
        if (a !=null)
        {
            print += "\"status\":\"1\"";
            print += ",\"token\":\"" + a.getToken() + "\"";
            print += ",\"user\":{";
            print += "\"nname\":\"" + a.getNickName() + "\"";
            if (a.getUimg() == null)
            {
                print += ",\"uimg\":\"" + url + "/images/user/user.jpg" + "\"";
            }
            else
            {
                print += ",\"uimg\":\"" + url + a.getUimg() + "\"";
            }
            print += ",\"phone\":\"" + a.getPhone() + "\"";
            print += "}";
        }
        else
        {
            print += "\"status\":\"0\"";
            print += ",\"token\":\"\"";
        }
        
        print += "}]";
        model.addAttribute("json", print);
		return "login";
	}
	
	@RequestMapping(value="/register")
	public String Register(HttpServletRequest request,Model model){
		String print="[{";
		String username=request.getParameter("username").trim();
		String password=request.getParameter("password").trim();
		 
		user userModel = new user();
		userModel.setUsername(username);
		userModel.setPassword(PasswordUtil.encrypt(password));
		userModel.setNickName(username);
		userModel.setPhone("");
		userModel.setEmail("");
		userModel.setUserType(0);
		userModel.setUimg(null);
		userModel.setUsex(1);
        Random ran = new Random();
        int RandKey=ran.nextInt(999)%(900)+100;
        String token = username + password + RandKey;
        userModel.setToken(PasswordUtil.encrypt(token));
        
        int a = userService.Register(userModel);
        print += "\"status\":\"" + a + "\"";
         if (a == 1)
         {
             print += ",\"token\":\"" + userModel.getToken() + "\"";
         }
         else
         {
             print += ",\"token\":\"\"";
         }
         print += "}]"; 
		model.addAttribute("json", print);
		return "login";
	}
}
