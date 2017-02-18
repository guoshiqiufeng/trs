package cn.autumn.trs.biz.basic.service;

import java.util.List;

import cn.autumn.trs.client.basic.car;


public interface ICarService {

	int Insert(car carModel);

	int UpdateCar(car carModel);

	List<car> FindAllList(car carModel);

	car SelectByID(Long id);

	int Delete(Long id);
}
