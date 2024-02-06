using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Json;
using XiaoFeng.KuaiShou.Enum;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-03 18:14:52                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 用户信息模型
    /// </summary>
    public class UserModel : ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public UserModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 用户数据
        /// </summary>
        [JsonElement("user_info")]
        public UserInfoModel UserInfo { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 用户详情
    /// </summary>
    public class UserInfoModel
    {
        /// <summary>
        /// 用户昵称。
        /// </summary>
        [JsonElement("name")]
        public string Name { get; set; }
        /// <summary>
        /// 性别。"M：男性，“F”:女性，其他：未知。
        /// </summary>
        [JsonElement("sex")] 
        public string Sex { get; set; }
        /// <summary>
        /// 粉丝数。
        /// </summary>
        [JsonElement("fan")] 
        public long Fans { get; set; }
        /// <summary>
        /// 关注数。
        /// </summary>
        [JsonElement("follow")] 
        public long Follow { get; set; }
        /// <summary>
        /// 头像地址。
        /// </summary>
        [JsonElement("head")] 
        public string Head { get; set; }
        /// <summary>
        /// 大头像地址(可能为空)。
        /// </summary>
        [JsonElement("bigHead")] 
        public string BigHead { get; set; }
        /// <summary>
        /// 用户地区名称。
        /// </summary>
        [JsonElement("city")] 
        public string City { get; set; }
    }
}