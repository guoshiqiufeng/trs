using System; 
namespace TakeRing.Model
{
	public class car
	{
   		     
      	/// <summary>
		/// car表主键
        /// </summary>
        public long id { get; set; }
		/// <summary>
		/// 用户id
        /// </summary>
        public long user_id { get; set; }
		/// <summary>
		/// 出发日期
        /// </summary>
        public DateTime startDate { get; set; }
		/// <summary>
		/// 出发时间
        /// </summary>
        public TimeSpan startTime { get; set; }
		/// <summary>
		/// 联系方式
        /// </summary>
        public string phone { get; set; }
		/// <summary>
		/// 车牌号
        /// </summary>
        public string car_number { get; set; }
		/// <summary>
		/// 车的名字
        /// </summary>
        public string car_name { get; set; }
		/// <summary>
		/// 空位数
        /// </summary>
        public int car_sum { get; set; }
		/// <summary>
		/// 目的地
        /// </summary>
        public string car_destination { get; set; }
		/// <summary>
		/// 出发地
        /// </summary>
        public string car_origin { get; set; }
		/// <summary>
		/// 类别：0为顺风车，1为空位
        /// </summary>
        public int type { get; set; }
		   
	}
}

