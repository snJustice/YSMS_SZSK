using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 工位类
    /// </summary>
    public class Station
    {
        /// <summary>
        /// 通道编号（0-1 用于程序 比真实值小1）
        /// </summary>
        public int ChannelNo { get; set; }

        /// <summary>
        /// 工位编号（1-6）
        /// </summary>
        public int StationNo { get; set; }   

        
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool IsEnable { get; set; }

        /// <summary>
        /// 图像通道 用于生成 检测
        /// </summary>
        public int ImageChannel = 0;

        /// <summary>
        /// 模板未匹配报警次数
        /// </summary>
        public int ModelUnMatchAlarmNum { get; set; }

        /// <summary>
        /// 曝光时间
        /// </summary>
        public int ExposureTimeRaw { get; set; }

        /// <summary>
        /// 图像增益
        /// </summary>
        public int GainRaw { get; set; }

        /// <summary>
        /// 相机拍照间隔
        /// </summary>
        public int CameraPhotoInterval { get; set; }

        /// <summary>
        /// 每次尺寸测量间隔拍照次数(尺寸测量)
        /// </summary>
        public int PhotoNumForOneSize { get; set; }


        /// <summary>
        /// 工位相机拍照次数
        /// </summary>
        public int CameraPhotoCount { get; set; }

        /// <summary>
        /// 是否启用频场校正
        /// </summary>
        public bool isEnablePCRevise { get; set; }
        /// <summary>
        /// 频场校正参数
        /// </summary>
        public int hv_CorrectGray { get; set; }

        ///// <summary>
        ///// 优先匹配工位几 0,不指定 1,工位1...
        ///// </summary>
        //public int PriorityStationModel { get; set; }

        //设置拍照张数，并设置模板选择列表
        public void SetCameraPhotoCount(int PhotoCount)
        {
            if (CameraPhotoCount != PhotoCount &&
                PhotoCount >= 0)
            {
                CameraPhotoCount = PhotoCount;
                PhotoModelSelectionList.Clear();
                for (int i = 1; i < PhotoCount + 1; i++)
                {
                    ModelSelection ms = new ModelSelection(i);
                    PhotoModelSelectionList.Add(ms);
                }
            }
        }


        public ObservableCollection<ModelSelection> PhotoModelSelectionList = new ObservableCollection<ModelSelection>();

        //相机起始拍照位置
        public int CameraStartPhotoPosition { get; set; }

        //相机间隔拍照位置
        public int CameraIntervalPhotoPosition { get; set; }

        ////相机起始拍照位置
        //public int CameraStartMarkPosition { get; set; }

        ////相机间隔拍照位置
        //public int CameraIntervalMarkPosition { get; set; }

        /// <summary>
        /// 模板列表
        /// </summary>
        public ObservableCollection<Model> ModeList;

        public Station(int ChannelNo, int StationNo, bool isEnable)
        {
            IsEnable = isEnable;
            ModeList = new ObservableCollection<Model>();
            this.ChannelNo = ChannelNo;
            this.StationNo = StationNo;
            for (int i = 0; i < 4; i++)
            {
                ModeList.Add(new Model(i + 1));
            }
            ModelUnMatchAlarmNum = SoftwareInfo.getInstance().ModelUnMatchAlarmNum;
            CameraPhotoInterval = SoftwareInfo.getInstance().CameraPhotoInterval;
            PhotoNumForOneSize = SoftwareInfo.getInstance().PhotoNumForOneSize;

            SetCameraPhotoCount(SoftwareInfo.getInstance().CameraPhotoCount);
            CameraStartPhotoPosition = SoftwareInfo.getInstance().CameraStartPhotoPosition;
            CameraIntervalPhotoPosition = SoftwareInfo.getInstance().CameraIntervalPhotoPosition;    

            //todo
            ExposureTimeRaw = 80;
            GainRaw = 390;
            //PriorityStationModel =SoftwareInfo.getInstance().PriorityStationModel;
        }

        //序列化用
        public Station()
        {
            ModelUnMatchAlarmNum = SoftwareInfo.getInstance().ModelUnMatchAlarmNum;
            CameraPhotoInterval = SoftwareInfo.getInstance().CameraPhotoInterval;
            PhotoNumForOneSize = SoftwareInfo.getInstance().PhotoNumForOneSize;

            CameraPhotoCount = SoftwareInfo.getInstance().CameraPhotoCount;
            CameraStartPhotoPosition = SoftwareInfo.getInstance().CameraStartPhotoPosition;
            CameraIntervalPhotoPosition = SoftwareInfo.getInstance().CameraIntervalPhotoPosition;
            //todo
            ExposureTimeRaw = 80;
            GainRaw = 390;
            //PriorityStationModel = SoftwareInfo.getInstance().PriorityStationModel;
            isEnablePCRevise = false;
            hv_CorrectGray = 0;

        }

    }
}
