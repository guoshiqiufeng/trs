using System; 
namespace TakeRing.Model
{
	public class user
	{
   		     
      	/// <summary>
		/// 用户id
        /// </summary>
        public long id { get; set; }
		/// <summary>
		/// 用户名
        /// </summary>
        public string username { get; set; }
		/// <summary>
		/// 用户昵称
        /// </summary>
        public string nick_name { get; set; }
		/// <summary>
		/// 用户密码
        /// </summary>
        public string password { get; set; }
		/// <summary>
		/// 手机号/联系方式
        /// </summary>
        public string phone { get; set; }
		/// <summary>
		/// email
        /// </summary>
        public string email { get; set; }
		/// <summary>
		/// 用户类别：1为管理员，2为普通用户
        /// </summary>
        public int user_type { get; set; }

        public string token { get; set; }

        public int usex { get; set; }

        public String uimg { get; set; }
	}
}

