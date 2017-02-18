using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using TakeRing.Model;
using TakeRing.Utility;

namespace TakeRing.DAL
{
	public partial class userDAL
	{
        #region 向数据库中添加一条记录 +int Insert(user model)
        /// <summary>
        /// 向数据库中添加一条记录
        /// </summary>
        /// <param name="model">要添加的实体</param>
        /// <returns>插入数据的ID</returns>
        public int Insert(user model)
        {
            #region SQL语句
            const string sql = @"
INSERT INTO [dbo].[user] (
	[username]
	,[nick_name]
	,[password]
	,[phone]
	,[email]
	,[user_type]
    ,[token]
    ,[usex]
    ,[uimg]
)
VALUES (
	@username
	,@nick_name
	,@password
	,@phone
	,@email
	,@user_type
    ,@token
    ,@usex
    ,@uimg
);select @@IDENTITY";
            #endregion
            var res = SqlHelper.ExecuteScalar(sql,
					new SqlParameter("@username", model.username),					
					new SqlParameter("@nick_name", model.nick_name),					
					new SqlParameter("@password", model.password),					
					new SqlParameter("@phone", model.phone),					
					new SqlParameter("@email", model.email),					
					new SqlParameter("@user_type", model.user_type),
                    new SqlParameter("@token",model.token),
                    new SqlParameter("@usex", model.usex),
                    new SqlParameter("@uimg", model.uimg)
                );
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 删除一条记录 +int Delete(long id)
        public int Delete(long id)
        {
            const string sql = "DELETE FROM [dbo].[user] WHERE [id] = @id";
            return SqlHelper.ExecuteNonQuery(sql, new SqlParameter("@id", id));
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
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[user]
SET 
	[username] = @username
	,[nick_name] = @nick_name
	,[password] = @password
	,[phone] = @phone
	,[email] = @email
	,[user_type] = @user_type
    ,[token]=@token
    ,[uimg]=@uimg
WHERE [id] = @id";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
					new SqlParameter("@id", model.id),					
					new SqlParameter("@username", model.username),					
					new SqlParameter("@nick_name", model.nick_name),					
					new SqlParameter("@password", model.password),					
					new SqlParameter("@phone", model.phone),					
					new SqlParameter("@email", model.email),					
					new SqlParameter("@user_type", model.user_type),
					new SqlParameter("@token",model.token),
                    new SqlParameter("@usex", model.usex),
                    new SqlParameter("@uimg", model.uimg)
                );
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
            var sql = SqlHelper.GenerateQuerySql("user", new[] { "id", "username", "nick_name", "password", "phone", "email", "user_type", "token", "usex", "uimg" }, index, size, whereBuilder.ToString(), orderField, isDesc);
            using (var reader = SqlHelper.ExecuteReader(sql, parameters.ToArray()))
            {
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        yield return SqlHelper.MapEntity<user>(reader);
                    }
                }
            }
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
            var list = QueryList(1, 1, wheres, null);
            return list != null && list.Any() ? list.FirstOrDefault() : null;
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
            const string sql = "SELECT TOP 1 [id], [username], [nick_name], [password], [phone], [email], [user_type],[token],[usex],[uimg] FROM [dbo].[user] WHERE [id] = @id";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@id", id)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<user>(reader);
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
            var sql = SqlHelper.GenerateQuerySql("user", new[] { "COUNT(1)" }, whereBuilder.ToString(), string.Empty);
            var res = SqlHelper.ExecuteScalar(sql, parameters.ToArray());
            return res == null ? 0 : Convert.ToInt32(res);
        }
        #endregion

        #region 登录查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="username">用户名</param>
        /// <param name="password">密码</param>
        /// <returns>实体</returns>
        public user SelectOne(String username,string password) 
        {
            const string sql = "SELECT TOP 1 [id], [username], [nick_name], [password], [phone], [email], [user_type],[token],[uimg] FROM [dbo].[user] WHERE [username] = @username and [password] = @password";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@username", username), new SqlParameter("@password", password)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<user>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 根据主键ID更新token记录 +int UpdateForToken(user model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int UpdateForToken(user model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[user]
SET 
	[token]=@token
WHERE [id] = @id";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@id", model.id),
                    new SqlParameter("@token", model.token)
                );
        }
        #endregion

        #region token查询
        /// <summary>
        /// 
        /// </summary>
        /// <param name="token">token</param>
        /// <returns>实体</returns>
        public user SelectOneFortoken(String token)
        {
            const string sql = "SELECT TOP 1 [id], [username], [nick_name], [password], [phone], [email], [user_type],[token],[usex],[uimg] FROM [dbo].[user] WHERE [token] = @token ";
            using (var reader = SqlHelper.ExecuteReader(sql, new SqlParameter("@token", token)))
            {
                if (reader.HasRows)
                {
                    reader.Read();
                    return SqlHelper.MapEntity<user>(reader);
                }
                else
                {
                    return null;
                }
            }
        }
        #endregion

        #region 根据token更新记录 +int tokenUpdate(user model)
        /// <summary>
        /// 根据主键ID更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int tokenUpdate(user model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[user]
SET 
	[usex]=@usex
    ,[nick_name]=@nick_name
    ,[phone] = @phone
	,[email] = @email
WHERE [token]=@token";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@token", model.token),
                    new SqlParameter("@nick_name", model.nick_name),
                    new SqlParameter("@usex", model.usex),
                    new SqlParameter("@phone", model.phone),
                    new SqlParameter("@email", model.email)
                );
        }
        #endregion

        #region 根据token更新记录 +int imgUpdate(user model)
        /// <summary>
        /// 根据token更新一条记录
        /// </summary>
        /// <param name="model">更新后的实体</param>
        /// <returns>执行结果受影响行数</returns>
        public int imgUpdate(user model)
        {
            #region SQL语句
            const string sql = @"
UPDATE [dbo].[user]
SET 
	[uimg]=@uimg
    
WHERE [token]=@token";
            #endregion
            return SqlHelper.ExecuteNonQuery(sql,
                    new SqlParameter("@token", model.token),

                    new SqlParameter("@uimg", model.uimg)
                );
        }
        #endregion
    }
}