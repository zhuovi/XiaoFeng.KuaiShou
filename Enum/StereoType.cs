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
*  Create Time : 2024-02-06 02:09:28                            *
*  Version : v 1.0.0                                            *
*  CLR Version : 4.0.30319.42000                                *
*****************************************************************/
namespace XiaoFeng.KuaiShou.Enum
{
    /// <summary>
    /// 全景视频类型
    /// </summary>
    [Description("快手全景视频类型")]
    public enum StereoType
    {
        /// <summary>
        /// 无
        /// </summary>
        NOT_SPHERICAL_VIDEO = 0,
        /// <summary>
        /// 180
        /// </summary>
        SPHERICAL_VIDEO_180 = 1,
        /// <summary>
        /// 360
        /// </summary>
        SPHERICAL_VIDEO_360 = 2
    }
}