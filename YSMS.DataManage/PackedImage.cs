using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;

namespace YSMS.DataManage
{
    public class PackedImage
    {
        /// <summary>
        /// 图片实体
        /// </summary>
        public HObject Image;

        /// <summary>
        /// 拍照时编码器值
        /// </summary>
        public double CodeValue;

        /// <summary>
        /// 编码器延时
        /// </summary>
        public double DelayCode;

        /// <summary>
        /// 时间延时
        /// </summary>
        public int DelayTime;

        /// <summary>
        /// 工位号
        /// </summary>
        public int StationNo;

        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelNo;

        /// <summary>
        /// 拍摄时刻
        /// </summary>
        public DateTime PhotoTime;

        /// <summary>
        /// 是否插入表格
        /// </summary>
        public bool Insert = false;

        /// <summary>
        /// 图像插入张数
        /// </summary>
        public string Info;

        /// <summary>
        /// 图像插入信息
        /// </summary>
        public string InfoMsg;

        public ResultType resultType;

        /// <summary>
        /// 保存路径
        /// </summary>
        public string SavePath;

        public void Copy(PackedImage originImage)
        {
            //this.Image = originImage.Image.CopyObj(1, 1);

            this.Image = new HObject(originImage.Image);


            this.CodeValue = originImage.CodeValue;
            this.DelayCode = originImage.DelayCode;
            this.DelayTime = originImage.DelayTime;
            this.StationNo = originImage.StationNo;
            this.ChannelNo = originImage.ChannelNo;
            this.PhotoTime = originImage.PhotoTime;
            this.Insert = originImage.Insert;
            this.Info = originImage.Info;
            this.SavePath = originImage.SavePath;
            this.InfoMsg = originImage.InfoMsg;
            this.resultType = originImage.resultType;
        }
    }
}
