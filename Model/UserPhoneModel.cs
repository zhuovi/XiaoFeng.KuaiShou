using System;
using System.Collections.Generic;
using System.Text;
using XiaoFeng.Json;
using XiaoFeng.KuaiShou.Enum;
using XiaoFeng.Redis;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-03 18:22:43                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 用户手机
    /// </summary>
    public class UserPhoneModel:ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public UserPhoneModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public UserPhoneModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 手机号的加密信息
        /// </summary>
        [JsonElement("encrypted_phone")]
        public string Phone { get; set; }
        #endregion

        #region 方法
        /// <summary>
        /// 获取手机号
        /// </summary>
        /// <param name="appSecret">密钥</param>
        /// <returns></returns>
        public string GetPhone(string appSecret)
        {
            if (this.Phone.IsNullOrEmpty()) return string.Empty;
            if (!this.Phone.Contains(":")) return string.Empty;
            var phones = this.Phone.Split(':', StringSplitOptions.RemoveEmptyEntries);
            if (phones.Length != 2) return string.Empty;

            var iv = phones[0].FromBase64StringToBytes();
            var phone = phones[1].FromBase64StringToBytes().GetString();
            return phone.AESDecrypt(appSecret.FromBase64StringToBytes().GetString(), iv.GetString());
        }
        #endregion
    }
}