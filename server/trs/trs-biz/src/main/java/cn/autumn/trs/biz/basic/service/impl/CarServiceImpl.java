package cn.autumn.trs.biz.basic.service.impl;

import java.util.List;

import javax.annotation.Resource;

import org.springframework.stereotype.Service;

import cn.autumn.trs.biz.basic.dao.carDao;
import cn.autumn.trs.biz.basic.service.ICarService;
import cn.autumn.trs.client.basic.car;
@Service("carService")
public class CarServiceImpl implements ICarService{
	@Resource
	private carDao carDao;

	@Override
	public int Insert(car carModel) {
		return carDao.insert(carModel);
	}

	@Override
	public int UpdateCar(car carModel) {
		return carDao.updateByPrimaryKeySelective(carModel);
	}

	@Override
	public List<car> FindAllList(car carModel) {
		
		return carDao.listAll(carModel);
	}

	@Override
	public car SelectByID(Long id) {
		return carDao.selectByPrimaryKey(id);
	}

	@Override
	public int Delete(Long id) {
		return carDao.deleteByPrimaryKey(id);
	}

	
}
