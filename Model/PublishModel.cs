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
*  Create Time : 2024-02-06 02:14:44                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Model
{
    /// <summary>
    /// 发部视频结果模型
    /// </summary>
    public class PublishModel:ResultModel
    {
        #region 构造器
        /// <summary>
        /// 无参构造器
        /// </summary>
        public PublishModel()
        {

        }
        /// <summary>
        /// 初始化一个新实例
        /// </summary>
        /// <param name="errorCode">错误码</param>
        /// <param name="errorMsg">错误消息</param>
        public PublishModel(ErrorCode errorCode, string errorMsg) : base(errorCode, errorMsg) { }
        #endregion

        #region 属性
        /// <summary>
        /// 视频详情
        /// </summary>
        [JsonElement("video_info")]
        public VideoInfoModel VideoInfo { get; set; }
        #endregion

        #region 方法

        #endregion
    }
    /// <summary>
    /// 视频详情模型
    /// </summary>
    public class VideoInfoModel
    {
        /// <summary>
        /// 作品id
        /// </summary>
        [JsonElement("photo_id")]
        public string PhotoId { get; set; }
        /// <summary>
        /// 作品标题
        /// </summary>
        [JsonElement("caption")]
        public string Caption { get; set; }
        /// <summary>
        /// 作品封面
        /// </summary>
        [JsonElement("cover")]
        public string Cover { get; set; }
        /// <summary>
        /// 作品播放链接
        /// </summary>
        [JsonElement("play_url")]
        public string PlayUrl { get; set; }
        /// <summary>
        /// 作品创建时间
        /// </summary>
        [JsonElement("create_time")]
        public long CreateTime { get; set; }
        /// <summary>
        /// 作品点赞数
        /// </summary>
        [JsonElement("like_count")]
        public string LikeCount { get; set; }
        /// <summary>
        /// 作品评论数
        /// </summary>
        [JsonElement("comment_count")]
        public string CommentCount { get; set; }
        /// <summary>
        /// 作品观看数
        /// </summary>
        [JsonElement("view_count")]
        public string ViewCount { get; set; }
        /// <summary>
        /// 作品状态(是否还在处理中，不能观看)
        /// </summary>
        [JsonElement("pending")]
        public Boolean Pending { get; set; }
    }
}