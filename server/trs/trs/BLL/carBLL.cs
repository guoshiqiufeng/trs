using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using TakeRing.DAL;
using TakeRing.Model;

namespace TakeRing.BLL 
{
	public partial class carBLL
	{
   		     
		/// <summary>
        /// 数据库操作对象
        /// </summary>
        private carDAL _dao = new carDAL();

        #region 向数据库中添加一条记录 +int Insert(car model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(car model)
        {
            return _dao.Insert(model);
        }
        #endregion

        #region 删除一条记录 +int Delete(long id)
        public int Delete(long id)
        {
            return _dao.Delete(id);
        }
        #endregion

        #region 根据主键ID更新一条记录 +int Update(car model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(car model)
        {
            return _dao.Update(model);
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<car> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<car> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
        }
        #endregion

        #region 查询单个模型实体 +car QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public car QuerySingle(object wheres)
        {
            return _dao.QuerySingle(wheres);
        }
        #endregion
        
        #region 查询单个模型实体 +car QuerySingle(long id)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public car QuerySingle(long id)
        {
            return _dao.QuerySingle(id);
        }
        #endregion

        #region 查询条数 +int QueryCount(object wheres)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>实体</returns>
        public int QueryCount(object wheres)
        {
            return _dao.QueryCount(wheres);
        }
        #endregion

        #region 查询实体集合 +List<car> QueryAllList(car model)
        /// <summary>
        /// 查询实体集合
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public List<car> QueryAllList(car model)
        {
            List<car> lc = new List<car>();
            DataSet dd= _dao.QueryAllList(model);

            if (dd.Tables.Count > 0)
            {
                foreach(DataRow row in dd.Tables[0].Rows)
                {
                    var a= row.ItemArray;
                    
                    car items = new car();
                    items.id = (long)a[0];
                    items.user_id = (long)a[1];
                    items.startDate = (DateTime)a[2];
                    items.startTime = (TimeSpan)a[3];
                    items.phone = (string)a[4];
                    items.car_number = (string)a[5];
                    items.car_name = (string)a[6];
                    items.car_sum = (int)a[7];
                    items.car_destination = (string)a[8];
                    items.car_origin = (string)a[9];

                    lc.Add(items);
                }
                
            }

            return lc;
        }
        #endregion

        #region 根据主键ID更新一条记录 +int UpdateCar(car model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int UpdateCar(car model)
        {
            return _dao.UpdateCar(model);
        }
        #endregion
	}
}