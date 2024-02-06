using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using XiaoFeng.Http;
using XiaoFeng.KuaiShou.Enum;
using XiaoFeng.KuaiShou.Internal;
using XiaoFeng.KuaiShou.Model;

/****************************************************************
*  Copyright © (2024) www.eelf.cn All Rights Reserved.          *
*  Author : jacky                                               *
*  QQ : 7092734                                                 *
*  Email : jacky@eelf.cn                                        *
*  Site : www.eelf.cn                                           *
*  Create Time : 2024-02-03 15:37:05                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou
{
    /// <summary>
    /// OpenAPI
    /// <para>
    /// 授权地址:
    /// </para>
    /// <para>网页登陆后授权模式 : https://open.kuaishou.com/oauth2/authorize?app_id=your_app_id&#38;scope=user_info&#38;response_type=code&#38;ua=pc&#38;redirect_uri=your_callback_url&#38;state=your_state
    /// </para>
    /// <para>
    /// 手机扫码授权模式 : https://open.kuaishou.com/oauth2/connect?app_id=your_app_id&#38;scope=user_info&#38;response_type=code&#38;redirect_uri=your_callback_url&#38;state=your_state
    /// </para>
    /// </summary>
    public class OpenAPI
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public OpenAPI()
        {
            this.Options = OpenApiOptions.Current;
        }
        #endregion

        #region 属性
        /// <summary>
        /// 配置
        /// </summary>
        public OpenApiOptions Options { get; set; }
        /// <summary>
        /// AccessToken
        /// </summary>
        public AccessTokenModel AccessToken { get; set; }
        #endregion

        #region 方法

        #region 快手登录

        #region 获取AccessToken
        /// <summary>
        /// 获取AccessToken
        /// </summary>
        /// <param name="code">授权code</param>
        /// <returns></returns>
        public async Task<AccessTokenModel> GetAccessTokenAsync(string code)
        {
            var path = $"/oauth2/access_token?app_id={this.Options.AppId}&app_secret={this.Options.AppSecret}&code={code}&grant_type=authorization_code";
            var result = await new HttpRequest
            {
                Method= HttpMethod.Get,
                Address=Helper.API_DOMAIN + path,
            }.GetResponseAsync().ConfigureAwait(false);
            if(result.StatusCode== System.Net.HttpStatusCode.OK)
            {
                var data = result.Html.JsonToObject<AccessTokenModel>();
                if (data.ErrorCode == ErrorCode.SUCCESS)
                    this.AccessToken = data;
                return data;
            }else
                return await Task.FromResult(new AccessTokenModel(ErrorCode.SERVER_ERROR, "请求不通"));
        }
        #endregion

        #region 刷新Token
        /// <summary>
        /// 刷新Token
        /// </summary>
        /// <param name="refreshToken">刷新Token</param>
        /// <returns></returns>
        public async Task<AccessTokenModel> GetRefreshAccessTokenAsync(string refreshToken)
        {
            var path = $"/oauth2/refresh_token?app_id={this.Options.AppId}&app_secret={this.Options.AppSecret}&refresh_token={refreshToken}&grant_type=refresh_token";
            var result = await new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = Helper.API_DOMAIN + path,
            }.GetResponseAsync().ConfigureAwait(false);
            if (result.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = result.Html.JsonToObject<AccessTokenModel>();
                if (data.ErrorCode == ErrorCode.SUCCESS)
                    this.AccessToken = data;
                return data;
            }
            else
                return await Task.FromResult(new AccessTokenModel(ErrorCode.SERVER_ERROR, "请求不通"));
        }
        #endregion

        #endregion

        #region 用户信息

        #region 公开信息
        /// <summary>
        /// 公开信息
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public async Task<UserModel> GetUserInfoAsync(string accessToken)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/openapi/user_info?app_id={this.Options.AppId}&access_token={accessToken}",
            }, async token =>
            {
                return await GetUserInfoAsync(token.AccessToken);
            });
        }
        #endregion

        #region 手机号
        /// <summary>
        /// 手机号
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public async Task<UserPhoneModel> GetUserPhoneAsync(string accessToken)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/openapi/user_phone?app_id={this.Options.AppId}&access_token={accessToken}",
            },async token =>
            {
                return await this.GetUserPhoneAsync(token.AccessToken);
            });
        }
        #endregion

        #endregion

        #region 内容管理

        #region 创建视频

        #region 发起上传
        /// <summary>
        /// 发起上传
        /// </summary>
        /// <param name="accessToken">accessToken</param>
        /// <returns></returns>
        public async Task<StartUploadModel> StartUploadAsync(string accessToken)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/openapi/photo/start_upload?app_id={this.Options.AppId}&access_token={accessToken}",
            }, async token =>
            {
                return await this.StartUploadAsync(token.AccessToken);
            });
        }
        #endregion

        #region 上传视频

        #region A.直接上传

        #region A1.直接上传 Body上传
        /// <summary>
        /// 直接上传视频[Body]
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="videoData">视频字节数组</param>
        /// <returns></returns>
        public async Task<ResultModel> UploadBodyAsync(string accessToken, byte[] videoData)
        {
            var startUpload = await this.StartUploadAsync(accessToken);
            if (startUpload.ErrorCode != ErrorCode.SUCCESS) return startUpload;
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                ContentType = "video/mp4",
                Address = $"http://{startUpload.Endpoint}/api/upload?upload_token ={startUpload.UploadToken}",
                BodyBytes = videoData
            }, async token =>
            {
                return await this.UploadBodyAsync(token.AccessToken, videoData);
            });
        }
        #endregion

        #region A2.直接上传 FormData上传
        /// <summary>
        /// 直接上传视频[FormData]
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="videoData">视频字节数组</param>
        /// <returns></returns>
        public async Task<ResultModel> UploadFormDataAsync(string accessToken, byte[] videoData)
        {
            var startUpload = await this.StartUploadAsync(accessToken);
            if (startUpload.ErrorCode != ErrorCode.SUCCESS) return startUpload;
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                ContentType = "multipart/form-data",
                Address = $"http://{startUpload.Endpoint}/api/upload?upload_token ={startUpload.UploadToken}",
                FormData = new List<FormData> { new FormData("file", videoData) }
            }, async token =>
            {
                return await this.UploadBodyAsync(token.AccessToken, videoData);
            });
        }
        #endregion

        #endregion

        #region B.分片上传

        #region B1.上传分片
        /// <summary>
        /// 上传分片
        /// </summary>
        /// <param name="endpoint">上传网关的域名</param>
        /// <param name="uploadToken">上传令牌</param>
        ///<param name="fragmentId">分片ID 从0开始</param>
        /// <param name="videoData">视频字节数组</param>
        /// <returns></returns>
        public async Task<FragmentModel> UploadFragmentAsync(string endpoint,string uploadToken,int fragmentId,  byte[] videoData)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                ContentType = "video/mp4",
                Address = $"http://{endpoint}/api/upload/fragment?upload_token ={uploadToken}&fragment_id={fragmentId}",
                BodyBytes = videoData
            }, async token =>
            {
                return await this.UploadFragmentAsync(endpoint, uploadToken, fragmentId, videoData);
            });
        }
        #endregion

        #region B2.断点续传
        /// <summary>
        /// 断点续传
        /// </summary>
        /// <param name="endpoint">上传网关的域名</param>
        /// <param name="uploadToken">上传令牌</param>
        /// <returns></returns>
        public async Task<FragmentResumeModel> GetFragmentResumeAsync(string endpoint, string uploadToken)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"http://{endpoint}/api/upload/resume?upload_token ={uploadToken}"
            }, async token =>
            {
                return await this.GetFragmentResumeAsync(endpoint, uploadToken);
            });
        }
        #endregion

        #region B3.完成分片上传
        /// <summary>
        /// 完成分片上传
        /// </summary>
        /// <param name="endpoint">上传网关的域名</param>
        /// <param name="uploadToken">上传令牌</param>
        /// <param name="fragmentCount">分片总数</param>
        /// <returns></returns>
        public async Task<ResultModel> GetFragmentCompleteAsync(string endpoint, string uploadToken,int fragmentCount)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"http://{endpoint}/api/upload/complete?upload_token ={uploadToken}&fragment_count={fragmentCount}"
            }, async token =>
            {
                return await this.GetFragmentCompleteAsync(endpoint, uploadToken, fragmentCount);
            });
        }
        #endregion

        #endregion

        #endregion

        #region 发布视频
        /// <summary>
        /// 发布视频
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="uploadToken">上传令牌</param>
        /// <param name="cover">封面</param>
        /// <param name="caption">标题</param>
        /// <param name="stereoType">视频全景类型</param>
        /// <param name="merchantProductId">需要挂载小黄车的商品ID</param>
        /// <returns></returns>
        public async Task<PublishModel> PublishAsync(string accessToken, string uploadToken, string cover, string caption, StereoType stereoType = StereoType.NOT_SPHERICAL_VIDEO, string merchantProductId = "")
        {
            var formData = new List<FormData>
            {
                new FormData("cover",cover,FormType.Text),
                new FormData("caption",caption,FormType.Text),
                new FormData("stereo_type",stereoType.ToString(),FormType.Text)
            };
            if (merchantProductId.IsNotNullOrEmpty())
                formData.Add(new FormData("merchant_product_id", merchantProductId, FormType.Text));
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                ContentType = "multipart/form-data",
                Address = $"{Helper.API_DOMAIN}/openapi/photo/publish?access_token ={accessToken}&app_id={this.Options.AppId}&upload_token={uploadToken}",
                FormData = formData
            }, async token =>
            {
                return await this.PublishAsync(token.AccessToken, uploadToken, cover, caption, stereoType, merchantProductId);
            });
        }
        #endregion

        #endregion

        #region 删除视频
        /// <summary>
        /// 删除视频
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="photoId">作品id</param>
        /// <returns></returns>
        public async Task<ResultModel> DeletePhotoAsync(string accessToken, string photoId)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Post,
                Address = $"{Helper.API_DOMAIN}/openapi/photo/delete?app_id={this.Options.AppId}&access_token={accessToken}&photo_id={photoId}",
            }, async token =>
            {
                return await DeletePhotoAsync(token.AccessToken, photoId);
            });
        }
        #endregion

        #region 查询视频

        #region 查询用户视频列表
        /// <summary>
        /// 查询用户视频列表
        /// </summary>
        /// <param name="accessToken">AccessToken</param>
        /// <param name="cursor">游标，用于分页，值为作品id。分页查询时，传上一页create_time最小的photo_id。第一页不传此参数。</param>
        /// <param name="count">数量，默认为20,最大不超过200</param>
        /// <returns></returns>
        public async Task<VideoListModel> GetVideoListAsync(string accessToken, string cursor, int count = 20)
        {
            if (count <= 0) count = 20;
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/openapi/photo/list?app_id={this.Options.AppId}&access_token={accessToken}&cursor={cursor}&count={count}",
            }, async token =>
            {
                return await GetVideoListAsync(token.AccessToken, cursor, count);
            });
        }
        #endregion

        #region 查询单一视频详情
        /// <summary>
        /// 查询单一视频详情
        /// </summary>
        /// <param name="accessToken">Oath令牌</param>
        /// <param name="photoId">作品id</param>
        /// <returns></returns>
        public async Task<PublishModel> GetPhotoAsync(string accessToken, string photoId)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/openapi/photo/list?app_id={this.Options.AppId}&access_token={accessToken}&photo_id={photoId}",
            }, async token =>
            {
                return await GetPhotoAsync(token.AccessToken, photoId);
            });
        }
        #endregion

        #region 查询视频数量
        /// <summary>
        /// 查询视频数量
        /// </summary>
        /// <param name="accessToken">Oath令牌</param>
        /// <returns></returns>
        public async Task<PhotoCountModel> GetPhotoCountAsync(string accessToken)
        {
            return await ExecuteAsync(new HttpRequest
            {
                Method = HttpMethod.Get,
                Address = $"{Helper.API_DOMAIN}/openapi/photo/count?app_id={this.Options.AppId}&access_token={accessToken}",
            }, async token =>
            {
                return await GetPhotoCountAsync(token.AccessToken);
            });
        }
        #endregion

        #endregion

        #endregion

        #region WebHook

        #endregion

        #region 运行结果
        /// <summary>
        /// 运行结果
        /// </summary>
        /// <typeparam name="T">返回类型</typeparam>
        /// <param name="request">请求对象</param>
        /// <param name="func">回调方法</param>
        /// <returns></returns>
        public async Task<T> ExecuteAsync<T>(IHttpRequest request, Func<AccessTokenModel, Task<T>> func) where T : ResultModel
        {
            var response = await request.GetResponseAsync();
            if (response.StatusCode == System.Net.HttpStatusCode.OK)
            {
                var data = response.Html.JsonToObject<T>();
                if (data.ErrorCode == ErrorCode.ACCESS_TOKEN_EXPIRED)
                {
                    var client = await this.GetRefreshAccessTokenAsync(this.AccessToken.RefreshToken).ConfigureAwait(false);
                    if (client.ErrorCode == ErrorCode.SUCCESS)
                        return await func.Invoke(client);
                    else return (T)(client as ResultModel);
                }
                return data;
            }
            else
                return await Task.FromResult((T)new ResultModel(ErrorCode.SERVER_ERROR, "请求不通"));
        }
        #endregion

        #endregion
    }
}