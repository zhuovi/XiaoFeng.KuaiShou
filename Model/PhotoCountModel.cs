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
*  Create Time : 2024-02-06 02:35:47                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 视频数量模型
    /// </summary>
    public class PhotoCountModel:ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public PhotoCountModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public PhotoCountModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 公开视频数量
        /// </summary>
        [JsonElement("public_count")]
        public long PublicCount { get; set; }
        /// <summary>
        /// 仅好友可见视频数量
        /// </summary>
        [JsonElement("friend_count")]
        public long FriendCount { get; set; }
        /// <summary>
        /// 尽自己可见视频数量
        /// </summary>
        [JsonElement("private_count")]
        public long PrivateCount { get; set; }
        /// <summary>
        /// 视频总量
        /// </summary>
        [JsonElement("all_count")]
        public long AllCount { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}