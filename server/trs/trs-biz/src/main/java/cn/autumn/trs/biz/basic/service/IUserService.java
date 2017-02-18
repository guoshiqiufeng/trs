package cn.autumn.trs.biz.basic.service;

import org.springframework.ui.Model;

import cn.autumn.trs.client.basic.user;

public interface IUserService {

	user Login(user userModel);

	int Register(user userModel);

	user token(user userModel);
	
	user SelectOneByID(Long id);

	int imgUpdate(user model);

	int tokenUpdate(user userModel);
}
