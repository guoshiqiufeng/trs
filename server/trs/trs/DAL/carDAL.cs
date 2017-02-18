using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using TakeRing.Model;
using TakeRing.Utility;

namespace TakeRing.DAL
{
	public partial class carDAL
	{
        #region 向数据库中添加一条记录 +int Insert(car model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(car model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[car] (
	[user_id]
	,[startDate]
	,[startTime]
	,[phone]
	,[car_number]
	,[car_name]
	,[car_sum]
	,[car_destination]
	,[car_origin]
	,[type]
)
VALUES (
	@user_id
	,@startDate
	,@startTime
	,@phone
	,@car_number
	,@car_name
	,@car_sum
	,@car_destination
	,@car_origin
	,@type
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@user_id", model.user_id),					
					new SqlParameter("@startDate", model.startDate),					
					new SqlParameter("@startTime", model.startTime),					
					new SqlParameter("@phone", model.phone),					
					new SqlParameter("@car_number", model.car_number),					
					new SqlParameter("@car_name", model.car_name),					
					new SqlParameter("@car_sum", model.car_sum),					
					new SqlParameter("@car_destination", model.car_destination),					
					new SqlParameter("@car_origin", model.car_origin),					
					new SqlParameter("@type", model.type)					
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(long id)
        public int Delete(long id)
        {
            const string sql = "DELETE FROM [dbo].[car] WHERE [id] = @id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
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
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[car]
SET 
	[user_id] = @user_id
	,[startDate] = @startDate
	,[startTime] = @startTime
	,[phone] = @phone
	,[car_number] = @car_number
	,[car_name] = @car_name
	,[car_sum] = @car_sum
	,[car_destination] = @car_destination
	,[car_origin] = @car_origin
	,[type] = @type
WHERE [id] = @id";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id", model.id),					
					new SqlParameter("@user_id", model.user_id),					
					new SqlParameter("@startDate", model.startDate),					
					new SqlParameter("@startTime", model.startTime),					
					new SqlParameter("@phone", model.phone),					
					new SqlParameter("@car_number", model.car_number),					
					new SqlParameter("@car_name", model.car_name),					
					new SqlParameter("@car_sum", model.car_sum),					
					new SqlParameter("@car_destination", model.car_destination),					
					new SqlParameter("@car_origin", model.car_origin),					
					new SqlParameter("@type", model.type)					
                );
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
            var parameters = new List<SqlParameter>();
            var whereBuilder = new System.Text.StringBuilder();
            if (wheres != null)
            {
                var props = wheres.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name.Equals("__o", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 操作符
                        whereBuilder.AppendFormat(" {0} ", prop.GetValue(wheres, null).ToString());
                    }
                    else
                    {
                        var val = prop.GetValue(wheres, null).ToString();
                        whereBuilder.AppendFormat(" [{0}] = @{0} ", prop.Name);
                        parameters.Add(new SqlParameter("@" + prop.Name, val));
                    }
                }
            }
            var sql = SqlHelper.GenerateQuerySql("car", new[] { "id", "user_id", "startDate", "startTime", "phone", "car_number", "car_name", "car_sum", "car_destination", "car_origin", "type" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<car>(reader);
                    }
                }
            }
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
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
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
            const string sql = "SELECT TOP 1 [id], [user_id], [startDate], [startTime], [phone], [car_number], [car_name], [car_sum], [car_destination], [car_origin], [type] FROM [dbo].[car] WHERE [id] = @id";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id", id)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<car>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 查询条数 +int QueryCount(object wheres)
        /// <summary>
        /// 查询条数
        /// </summary>
        /// <param name="wheres">查询条件</param>
        /// <returns>条数</returns>
        public int QueryCount(object wheres)
        {
            var parameters = new List<SqlParameter>();
            var whereBuilder = new System.Text.StringBuilder();
            if (wheres != null)
            {
                var props = wheres.GetType().GetProperties();
                foreach (var prop in props)
                {
                    if (prop.Name.Equals("__o", StringComparison.InvariantCultureIgnoreCase))
                    {
                        // 操作符
                        whereBuilder.AppendFormat(" {0} ", prop.GetValue(wheres, null).ToString());
                    }
                    else
                    {
                        var val = prop.GetValue(wheres, null).ToString();
                        whereBuilder.AppendFormat(" [{0}] = @{0} ", prop.Name);
                        parameters.Add(new SqlParameter("@" + prop.Name, val));
                    }
                }
            }
            var sql = SqlHelper.GenerateQuerySql("car", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 查询所有实体 +List<car> QueryAllList(car model)
        /// <summary>
        /// 查询单个模型实体
        /// </summary>
        /// <param name="id">key</param>
        /// <returns>实体</returns>
        public DataSet QueryAllList(car model)
        {
            List<car> list=new List<car>();
            string sql = "SELECT [id], [user_id], [startDate], [startTime], [phone], [car_number], [car_name], [car_sum], [car_destination], [car_origin] FROM [dbo].[car] WHERE [type] = @type";
            List<SqlParameter> listparam= new List<SqlParameter>();
    
            listparam.Add(new SqlParameter("@type", model.type));
           
            if (model.user_id!= 0)
            {
                sql += " and [user_id]=@userId";
                listparam.Add(new SqlParameter("@userId", model.user_id));
            }
            SqlParameter[] Params = listparam.ToArray();
            sql += " order by id desc";
            using (var reader = SqlHelper.ExecuteDataSet(sql, Params))
            {
                return reader;
            }
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
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[car]
SET 
	[startDate] = @startDate
	,[startTime] = @startTime
	,[phone] = @phone
	,[car_sum] = @car_sum
	,[car_destination] = @car_destination
	,[car_origin] = @car_origin
	
WHERE [id] = @id";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id", model.id),
                    new SqlParameter("@startDate", model.startDate),
                    new SqlParameter("@startTime", model.startTime),
                    new SqlParameter("@phone", model.phone),
                    new SqlParameter("@car_sum", model.car_sum),
                    new SqlParameter("@car_destination", model.car_destination),
                    new SqlParameter("@car_origin", model.car_origin)
                );
        }
        #endregion
	}
}