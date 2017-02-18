package cn.autumn.trs.web.basic;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;
import javax.xml.ws.spi.http.HttpContext;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.web.bind.annotation.RequestMapping;

import cn.autumn.trs.biz.basic.service.IUserService;
import cn.autumn.trs.client.basic.user;

@Controller
@RequestMapping("token")
public class TokenController {
	@Resource 
	private IUserService userService;
	
	@RequestMapping(value="/token")
	public String token(HttpServletRequest request,Model model){
		String print="[{";
		
		String token = request.getParameter("token").trim();
        user userModel = new user();
        userModel.setToken(token);
        user m= userService.token(userModel);
        String url = request.getScheme() +"://" + request.getServerName()  
                + ":" +request.getServerPort()+ "/trs";
        if (m != null)
        {
            print += "\"status\":\"1\"";
            print += ",\"user\":{";
            print += "\"username\":\"" + m.getUsername() + "\"";
            if (m.getUimg() == null)
            {
                print += ",\"uimg\":\"" + url + "/images/user/user.jpg" + "\"";
            }
            else 
            {
                print += ",\"uimg\":\"" + url + m.getUimg() + "\"";
            }
            print += ",\"usex\":\"" + m.getUsex() + "\"";
            print += ",\"nname\":\"" + m.getNickName()+ "\"";
            print += ",\"phone\":\"" + m.getPhone() + "\"";
            print += ",\"email\":\"" + m.getEmail() + "\"";
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
	
	@RequestMapping(value="/tokenUpdate")
	public String tokenUpdate(HttpServletRequest request,Model model){
		String print="[{";
		
		 String token = request.getParameter("token").trim()==null?"":request.getParameter("token").trim();
		 String name = request.getParameter("name").trim()==null?"":request.getParameter("name").trim();
		 String usex=request.getParameter("usex").trim()==null?"":request.getParameter("usex").trim();
		 String phone=request.getParameter("phone").trim()==null?"":request.getParameter("phone").trim();
		 String email=request.getParameter("email").trim()==null?"":request.getParameter("email").trim();

         user userModel = new user();
         userModel.setToken(token);
         userModel.setNickName(name);
         userModel.setUsex(Integer.parseInt(usex));
         userModel.setPhone(phone);
         userModel.setEmail(email);
         int m = userService.tokenUpdate(userModel);
         if (m >= 0)
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
	
}
