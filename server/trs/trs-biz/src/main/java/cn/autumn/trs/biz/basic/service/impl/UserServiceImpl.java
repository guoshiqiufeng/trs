package cn.autumn.trs.biz.basic.service.impl;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import cn.autumn.trs.biz.basic.dao.userDao;
import cn.autumn.trs.biz.basic.service.IUserService;
import cn.autumn.trs.client.basic.user;
@Service("userService")
public class UserServiceImpl implements IUserService{
	@Resource
	private userDao userDao;

	@Override
	public user Login(user userModel) {
		// TODO Auto-generated method stub
		return userDao.selectOne(userModel);
	}

	@Override
	public int Register(user userModel) {
		// TODO Auto-generated method stub
		if(userModel.getUsername()!=null){
			user user=new user();
			user.setUsername(userModel.getUsername());
			user=userDao.selectOne(user);
			if(user!=null){
				return -1;
			}else{
				return userDao.insert(userModel);
			}
		}
		return 0;
	}

	@Override
	public user token(user userModel) {
		if(userModel.getToken()!=null){
			user user=new user();
			user.setToken(userModel.getToken());
			user=userDao.selectOne(user);
			return user;
		}
		return null;
	}

	@Override
	public user SelectOneByID(Long id) {
		
		return userDao.selectByPrimaryKey(id);
	}

	@Override
	public int imgUpdate(user userModel) {
		Long id= this.token(userModel).getId();
		userModel.setId(id);
		return userDao.updateByPrimaryKeySelective(userModel);
	}

	@Override
	public int tokenUpdate(user userModel) {
		Long id= this.token(userModel).getId();
		userModel.setId(id);
		return userDao.updateByPrimaryKeySelective(userModel);
	}
}
