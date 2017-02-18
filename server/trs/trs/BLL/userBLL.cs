using System.Collections.Generic;
using System.Linq;
using TakeRing.DAL;
using TakeRing.Model;
using TakeRing.Utility;

namespace TakeRing.BLL 
{
	public partial class userBLL
	{
   		     
		/// <summary>
        /// 数据库操作对象
        /// </summary>
        private userDAL _dao = new userDAL();

        #region 向数据库中添加一条记录 +int Insert(user model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(user model)
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

        #region 根据主键ID更新一条记录 +int Update(user model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int Update(user model)
        {
            return _dao.Update(model);
        }
        #endregion

        #region 分页查询一个集合 +IEnumerable<user> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        /// <summary>
        /// 分页查询一个集合
        /// </summary>
        /// <param name="index">页码</param>
        /// <param name="size">页大小</param>
        /// <param name="wheres">条件匿名类</param>
        /// <param name="orderField">排序字段</param>
        /// <param name="isDesc">是否降序排序</param>
        /// <returns>实体集合</returns>
        public IEnumerable<user> QueryList(int index, int size, object wheres, string orderField, bool isDesc = true)
        {
            return _dao.QueryList(index, size, wheres, orderField, isDesc);
        }
        #endregion

        #region 查询单个模型实体 +user QuerySingle(object wheres)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="wheres">条件匿名类</param>
        /// <returns>实体</returns>
        public user QuerySingle(object wheres)
        {
            return _dao.QuerySingle(wheres);
        }
        #endregion
        
        #region 查询单个模型实体 +user QuerySingle(long id)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public user QuerySingle(long id)
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

        #region 登录
		/// <summary>
        /// 登录
		/// </summary>
		/// <param name="model">实体</param>
		/// <returns>实体</returns>
 
        public user Login(user model) 
        {
            
            var userModel= _dao.SelectOne(model.username, model.password);
            return userModel;
        }
        #endregion
        
        #region 注册
        /// <summary>
        /// 
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>-1:用户名已存在;0:注册失败；1：注册成功</returns>
        public int Register(user model)
        {
            var count = this.QueryCount(new { username = model.username });
            if (count > 0)
            {
                // 数据库已存在
                return -1;// 用户名已存在;
            }
            var userModel = _dao.Insert(model);
            if (userModel > 0)
            {
                return 1;//注册成功
            }
            else
            {
                return 0;//注册失败
            }
        }
        #endregion

        #region 查询token
        /// <summary>
        /// 查询token
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>实体</returns>

        public user token(user model)
        {

            var userModel = _dao.SelectOneFortoken(model.token);
            return userModel;
        }
        #endregion

        #region 更新token
        /// <summary>
        /// 根据token更新
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>实体</returns>

        public int tokenUpdate(user model)
        {

            var userint = _dao.tokenUpdate(model);
            return userint;
        }
        #endregion

        #region 更新img
        /// <summary>
        /// 更新img
        /// </summary>
        /// <param name="model">实体</param>
        /// <returns>实体</returns>

        public int imgUpdate(user model)
        {

            var userint = _dao.imgUpdate(model);
            return userint;
        }
        #endregion
    }
}