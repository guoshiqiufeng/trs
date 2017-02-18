package cn.autumn.trs.web.basic;

import java.io.File;

import javax.annotation.Resource;
import javax.servlet.http.HttpServletRequest;

import org.springframework.stereotype.Controller;
import org.springframework.ui.Model;
import org.springframework.ui.ModelMap;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RequestParam;
import org.springframework.web.multipart.MultipartFile;

import cn.autumn.trs.biz.basic.service.IUserService;
import cn.autumn.trs.client.basic.user;

@Controller
@RequestMapping("img")
public class ImgController {
	@Resource
	private IUserService userService;
	
	@RequestMapping(value="/imgUpdate")
	public String imgUpdate(HttpServletRequest request,Model model){
		String print = "[{";
        String token = request.getParameter("token").trim();
        String uimg = request.getParameter("uimg").trim();
        
        user userModel = new user();
        userModel.setToken(token);

        userModel.setUimg(uimg);
        int m = userService.imgUpdate(userModel);
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
	
	@RequestMapping(value="/imgUpload")
	public String imgUpload(@RequestParam(value = "uimg", required = false) MultipartFile file, HttpServletRequest request, ModelMap model) { 
		String token = request.getParameter("token").trim();
		String path = request.getSession().getServletContext().getRealPath("images/user/");  
        //String fileName = file.getOriginalFilename();  
        String fileName = token + ".jpg";  
        System.out.println(path);  
        System.out.println(fileName);  
        System.out.println(file);
        File targetFile = new File(path, fileName);  
        if (!targetFile.exists()) {
			targetFile.mkdirs();
		}
  
        //保存  
        try {  
            file.transferTo(targetFile);  
        } catch (Exception e) {  
            e.printStackTrace();  
        }  
		return "login";
	} 
}
