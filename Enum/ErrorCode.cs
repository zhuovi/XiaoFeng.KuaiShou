using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-03 14:00:17                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Enum
{
    /// <summary>
    /// 快手状态码
    /// </summary>
    [Description("快手状态码")]
    public enum ErrorCode
    {
        /// <summary>
        /// 成功
        /// </summary>
        [Description("成功")]
        SUCCESS = 1,
        /// <summary>
        /// 视频不存在
        /// </summary>
        [Description("视频不存在")]
        VIDEO_NO_EXISTS = 100120001,
        /// <summary>
        /// 视频未上传
        /// </summary>
        [Description("视频未上传")]
        VIDEO_NO_UPLOAD = 100120002,
        /// <summary>
        /// 视频发布失败
        /// </summary>
        [Description("视频发布失败")]
        VIDEO_PUBLISH_FAILEDS = 100120003,
        /// <summary>
        /// 异常参数
        /// </summary>
        [Description("异常参数")]
        PARAMETER_INVAILD = 100100400,
        /// <summary>
        /// 一般有3种情况：1. 用户被封禁；2. 用户一天请求该接口超过1k次；3. app一天请求该接口超过10w次
        /// </summary>
        [Description("请求超限")]
        REQUEST_LIMIT = 100100402,
        /// <summary>
        /// 请求缺少参数或参数类型错误
        /// </summary>
        [Description("请求缺少参数或参数类型错误")]
        PARAM_INVALID = 100200100,
        /// <summary>
        /// 无效的client，无效的 app 或 developer,可能是验证参数不正确(回调地址,安卓包名签名等信息)
        /// </summary>
        [Description("无效的client，无效的 app 或 developer,可能是验证参数不正确(回调地址,安卓包名签名等信息)")]
        CLIENT_INVALID = 100200101,
        /// <summary>
        /// 请求被拒绝，可能是无效的 token 等
        /// </summary>
        [Description("请求被拒绝，可能是无效的 token 等")]
        REQUEST_REJECTED = 100200102,
        /// <summary>
        /// 请求的 responseType 错误
        /// </summary>
        [Description("请求的 responseType 错误")]
        RESPONSE_TYPE_ERROR = 100200103,
        /// <summary>
        /// 请求的 grantType 不支持
        /// </summary>
        [Description("请求的 grantType 不支持")]
        RRANT_TYPE_NO_SUPPORTED = 100200104,
        /// <summary>
        /// 请求的 code 错误
        /// </summary>
        [Description("请求的 code 错误")]
        REQUEST_CODE_ERROR = 100200105,
        /// <summary>
        /// 请求的 scope 错误
        /// </summary>
        [Description("请求的 scope 错误")]
        REQUEST_SCOPE_ERROR = 100200106,
        /// <summary>
        /// 无效的 openid
        /// </summary>
        [Description("无效的 openid")]
        OPEN_ID_INVALID = 100200107,
        /// <summary>
        /// access_token过期
        /// </summary>
        [Description("access_token过期")]
        ACCESS_TOKEN_EXPIRED = 100200108,
        /// <summary>
        /// 用户取消该 app 授权
        /// </summary>
        [Description("用户取消该 app 授权")]
        CANCEL_AUTHORIZATION = 100200109,
        /// <summary>
        /// 用户授权过期
        /// </summary>
        [Description("用户授权过期")]
        AUTHORIZATION_EXPIRED = 100200110,
        /// <summary>
        /// 用户未授权过
        /// </summary>
        [Description("用户未授权过")]
        UNAUTHORIZED = 100200111,
        /// <summary>
        /// bundleToken不合法
        /// </summary>
        [Description("bundleToken不合法")]
        BUNDLE_TOKEN_INVALID = 100200112,
        /// <summary>
        /// refresh_token过期
        /// </summary>
        [Description("refresh_token过期")]
        REFRESH_TOKEN_EXPIRED = 100200113,
        /// <summary>
        /// 服务内部错误
        /// </summary>
        [Description("服务内部错误")]
        SERVER_ERROR = 100200500,
        /// <summary>
        /// 视频不存在
        /// </summary>
        [Description("视频不存在")]
        VIDEO_NOT_EXIST = 120001,
        /// <summary>
        /// 视频未上传成功
        /// </summary>
        [Description("视频未上传成功")]
        VIDEO_NOT_UPLOADED_SUCCESSFULLY = 120002,
        /// <summary>
        /// 视频发布失败
        /// </summary>
        [Description("视频发布失败")]
        VIDEO_PUBLISH_FAILED = 120003,
        /// <summary>
        /// 参数错误
        /// </summary>
        [Description("参数错误")]
        PARAMETER_ERROR = 100400
    }
}