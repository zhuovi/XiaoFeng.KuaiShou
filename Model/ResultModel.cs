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
*  Create Time : 2024-02-03 15:48:12                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 基础模型
    /// </summary>
    public class ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public ResultModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public ResultModel(ErrorCode errorCode, string errorMsg)
        {
            ErrorCode = errorCode;
            ErrorMsg = errorMsg;
        }

        #endregion

        #region 属性
        /// <summary>
        /// 状态码
        /// </summary>
        [JsonElement("result")]
        public ErrorCode ErrorCode { get; set; }
        /// <summary>
        /// 错误消息
        /// </summary>
        [JsonElement("error_msg")]
        public string ErrorMsg { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 基本模型
    /// </summary>
    /// <typeparam name="T">对象类型</typeparam>
    public class ResultModel<T>:ResultModel where T :new()
    {
        #region 构造器
        public ResultModel() { }
        public ResultModel(ErrorCode errorCode,string errorMsg) :base(errorCode,errorMsg){ }
        public ResultModel(T result)
        {

        }
        #endregion

        #region 属性
        /// <summary>
        /// 数据
        /// </summary>
        public T Data { get; set; }
        #endregion
    }
}