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
*  Create Time : 2024-02-06 01:41:13                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 上传分片模型
    /// </summary>
    public class FragmentModel:ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public FragmentModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public FragmentModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 检验码
        /// </summary>
        [JsonElement("checksum")]
        public string CheckSum { get; set; }
        /// <summary>
        /// 分片大小
        /// </summary>
        [JsonElement("Size")]
        public long Size { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}