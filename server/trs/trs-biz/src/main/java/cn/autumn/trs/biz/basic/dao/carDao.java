package cn.autumn.trs.biz.basic.dao;

import java.util.List;

import cn.autumn.trs.client.basic.car;

public interface carDao {
    int deleteByPrimaryKey(Long id);

    int insert(car record);

    int insertSelective(car record);

    car selectByPrimaryKey(Long id);

    int updateByPrimaryKeySelective(car record);

    int updateByPrimaryKey(car record);
    
    List<car> listAll(car record);
}