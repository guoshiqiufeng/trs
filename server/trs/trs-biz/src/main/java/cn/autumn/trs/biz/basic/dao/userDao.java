package cn.autumn.trs.biz.basic.dao;

import cn.autumn.trs.client.basic.user;

public interface userDao {
    int deleteByPrimaryKey(Long id);

    int insert(user record);

    int insertSelective(user record);

    user selectByPrimaryKey(Long id);

    int updateByPrimaryKeySelective(user record);

    int updateByPrimaryKey(user record);
    
    user selectOne(user record);

	int tokenUpdate(user userModel);
}