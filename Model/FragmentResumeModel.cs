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
*  Create Time : 2024-02-06 01:46:00                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 断点续传模型
    /// </summary>
    public class FragmentResumeModel : ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public FragmentResumeModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public FragmentResumeModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 该文件是否已上传过
        /// </summary>
        [JsonElement("existed")]
        public Boolean Existed { get; set; }
        /// <summary>
        /// 从0开始的已上传的连续分片id (-1 表示没有分片)
        /// </summary>
        [JsonElement("fragment_index")]
        public int FragmentIndex { get; set; }
        /// <summary>
        /// 已上传的分片id
        /// </summary>
        [JsonElement("fragment_list")]
        public string[] FragmentList { get; set; }
        /// <summary>
        /// 上传网关的域名  api方式上传不用关心
        /// </summary>
        [JsonElement("endpoint")]
        public List<FragmentEndpointModel> Endpoint { get; set; }
        /// <summary>
        /// 从0开始的已上传的连续分片size
        /// </summary>
        [JsonElement("fragment_index_bytes")]
        public int FragmentIndexBytes { get; set; }
        /// <summary>
        /// 上传id 用于业务打点  关联本次 
        /// </summary>
        [JsonElement("token_id")]
        public string TokenId { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 分片终节点
    /// </summary>
    public class FragmentEndpointModel
    {
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        public FragmentEndpointModel() { }
        /// <summary>
        /// 协议
        /// </summary>
        [JsonElement("protocol")]
        public string Protocol { get; set; }
        /// <summary>
        /// 主机
        /// </summary>
        [JsonElement("host")]
        public string Host { get; set; }
        /// <summary>
        /// 端口
        /// </summary>
        [JsonElement("port")]
        public int Port { get; set; }
    }
}