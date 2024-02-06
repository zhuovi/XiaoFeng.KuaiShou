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
*  Create Time : 2024-02-03 15:55:50                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// AccessToken模型
    /// </summary>
    public class AccessTokenModel:ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public AccessTokenModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public AccessTokenModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 授权凭证。
        /// </summary>
        [JsonElement("access_token")]
        public string AccessToken { get; set; }
        /// <summary>
        /// access_token 的过期时间，单位为秒，有效期为48小时。
        /// </summary>
        [JsonElement("expires_in")]
        public int ExpiresIn { get; set; }
        /// <summary>
        /// 可以用来刷新 access_token，获取一个新的。
        /// </summary>
        [JsonElement("refresh_token")]
        public string RefreshToken { get; set; }
        /// <summary>
        /// refresh_token 的过期时间，单位为秒，有效期为180天。
        /// </summary>
        [JsonElement("refresh_token_expires_in")]
        public int RefreshTokenExpiresIn { get; set; }
        /// <summary>
        /// 用户在快手的唯一标识 (同一开发主体下唯一)。
        /// </summary>
        [JsonElement("open_id")]
        public string OpenId { get; set; }
        /// <summary>
        /// 本次授权的token包含的scope,如果返回的scope没有包含开发者需要的scope,说明用户没有点击同意授权,开发者在调用相应的openAPI接口的时候,需要让用户授权。
        /// </summary>
        [JsonElement("scopes")]
        public List<string> Scopes { get; set; }
        #endregion

        #region 方法

        #endregion
    }
}