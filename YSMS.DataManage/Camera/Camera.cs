using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using System.Text;
using HalconDotNet;
using System.Threading;
//using HalconDotNet;
using System.IO;
using System.Windows;

using System.Diagnostics;       // baicx 20200305 监视时间

namespace YSMS.DataManage
{
    public class Camera
    {
        ///// <summary>
        ///// 采集图像后操作
        ///// </summary>
        //public enum ImageOper
        //{
        //    /// <summary>
        //    /// 无显示
        //    /// </summary>
        //    None,
        //    /// <summary>
        //    /// 显示
        //    /// </summary>
        //    Show,
        //    /// <summary>
        //    /// 压栈
        //    /// </summary>
        //    Enqueue,
        //}

        // baicx 20200305 监视时间
        public static bool bRunStart = false;
        public static Int16 ncount = 0;

        /// <summary>
        /// 像素转尺寸比例
        /// </summary>
        public double PixelToSizeRatio { get; set; }

        /// <summary>
        /// 相机参数
        /// </summary>
        public List<double> CameraParameters = new List<double>();

        /// <summary>
        /// 相机姿态
        /// </summary>
        public List<double> CameraPose = new List<double>();

        /// <summary>
        /// 相机工作状态
        /// </summary>
        public enum CameraState
        {
            /// <summary>
            /// 待机
            /// </summary>
            Standby,
            /// <summary>
            /// 拍照
            /// </summary>
            Photo,

        }

        public static Stopwatch stopwatch = new Stopwatch();  //baicx 20200305 增加监视时间

        /// <summary>
        /// 是否暂停拍照
        /// </summary>
        public bool Pause = false;

        /// <summary>
        /// 编号
        /// </summary>
        public int StationNo { get; set; }

        /// <summary>
        /// 名称
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 启用1  停用0
        /// </summary>
        public bool IsEnabled { get; set; }

        /// <summary>
        /// 图像宽
        /// </summary>
        public int AOIWidth { get; set; }

        /// <summary>
        /// 图像高
        /// </summary>
        public int AOIHeight { get; set; }

        /// <summary>
        /// 报警延时时间（ms）
        /// </summary>
        public int AlarmDelayTime = 0;

        /// <summary>
        /// 报警延时编码器值
        /// </summary>
        public int AlarmDelayCode = 0;

        /// <summary>
        /// 图像是否旋转 0:不旋转 1：90° 2：180° 3：270°
        /// </summary>
        public int IsImageRotate = 0;

        /// <summary>
        /// 获取通道编码值的方法(电镀冲压停机用)
        /// </summary>
        public Func<int, double > GetChannelCode;

        /// <summary>
        /// 获取工位编码值的方法(片式判断图像用)
        /// </summary>
        public Func<int, int,int> GetStationCode;

        /// <summary>
        /// 通道号
        /// </summary>
        public int ChannelNo = 0;

        /// <summary>
        /// 打开相机参数 16参数
        ///  Name, HorizontalResolution, VerticalResolution, ImageWidth, ImageHeight, StartRow, StartColumn, Field, BitsPerChannel, ColorSpace, Generic, ExternalTrigger, CameraType, Device, Port, LineIn : AcqHandle
        /// </summary>
        public Dictionary<string, Para4HTuple> dicOpenFramegrabber_00_15 = new Dictionary<string, Para4HTuple>();

        /// <summary>
        /// 设置初始化参数
        /// </summary>
        public Dictionary<string, Para7HTuple> dicSetFramegrabberParam = new Dictionary<string, Para7HTuple>();


        #region 相机参数信息
        /// <summary>
        /// 相机句柄
        /// </summary>
        private HTuple hv_AcqHandle = null;

        /// <summary>
        /// 采图线程
        /// </summary>
        private System.Threading.Thread grabImageThread = null;

        int paiZhaoJianGe = 150;
        /// <summary>
        /// 拍照间隔 毫秒
        /// </summary>
        public int PaiZhaoJianGe
        {
            set
            {
                //mutex.WaitOne();
                paiZhaoJianGe = value;
                //mutex.ReleaseMutex();
            }
            get
            {
                return paiZhaoJianGe;
            }
        }

        //ImageOper imageOperType;
        ///// <summary>
        ///// 图像操作
        ///// </summary>
        //public ImageOper ImageOperType
        //{
        //    get
        //    {
        //        return imageOperType;
        //    }
        //    set
        //    {
        //        //mutex.WaitOne();
        //        imageOperType = value;
        //        //mutex.ReleaseMutex();
        //    }
        //}

        private CameraState cameraState = CameraState.Standby;

        public void SetCameraState(CameraState state)
        {
            try
            {
                switch (state)
                {
                    case CameraState.Standby:
                        cameraState = state;
                        //清空图像
                        while (queueImage.Count > 0)
                        {
                            //PackedImage packedImage = queueImage.Dequeue();

                            if (queueImage[0].Image != null && queueImage[0].Image.IsInitialized())
                            {
                                PackedImage packedImage = queueImage[0];
                                if (packedImage != null)
                                {
                                    if (packedImage.Image != null)
                                    {
                                        packedImage.Image.Dispose();
                                    }
                                }
                            }

                            if (queueImage.Count > 0)
                            {
                                queueImage.RemoveAt(0);
                            }

                            Thread.Sleep(20);
                        }

                        break;
                    case CameraState.Photo:
                        cameraState = state;
                        break;
                }
            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog ("SetCameraState:\n"+ex.ToString ());
                Console.WriteLine("SetCameraState出错：" + ex.Message);
            }
        }

        ///// <summary>
        ///// 图像队列
        ///// </summary>
        //public Queue<HObject> queueImage = new Queue<HObject>();

        ///// <summary>
        ///// 新的图像队列
        ///// </summary>
        //public Queue<PackedImage> queueImage = new Queue<PackedImage>();


        /// <summary>
        /// 新的图像队列
        /// </summary>
        public List<PackedImage> queueImage = new List<PackedImage>();

        /// <summary>
        /// 运行起始时间
        /// </summary>
        public DateTime startTime;

        /// <summary>
        /// 总拍照张数
        /// </summary>
        public int AllPhotoNum = 0;

        /// <summary>
        /// 抛弃图像张数
        /// </summary>
        public int ThrowImageCount = 0;

        /// <summary>
        /// 测量图像张数
        /// </summary>
        public int AllMeasureCount = 0;


        /// <summary>
        /// 平均测量图像张数
        /// </summary>
        public double PerMeasureCount = 0;

        /// <summary>
        /// 同步基元
        /// </summary>
        System.Threading.Mutex mutex = new System.Threading.Mutex();


        //private HalconDotNet.HWindowControl hWindow;
        ///// <summary>
        ///// 显示窗体
        ///// </summary>
        //public HalconDotNet.HWindowControl HWindow
        //{
        //    get
        //    {
        //        return hWindow;
        //    }
        //    set
        //    {
        //        //mutex.WaitOne();
        //        hWindow = value;
        //        //mutex.ReleaseMutex();
        //    }
        //}


        /// <summary>
        /// HalconId 异常计数
        /// </summary>
        //int halconIdErrorCounter = 0;

        /// <summary>
        /// 临时图片
        /// </summary>
        HObject temp_HoImage = null;

        /// <summary>
        /// 采集图像失败次数
        /// </summary>
        public int grabErrorCnt = 0;

        /// <summary>
        /// 是否停止采集出错
        /// </summary>
        public bool  IsGrabError = false ;

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <param name="hv_AcqHandle"></param>
        /// <returns></returns>
        private string OpenCamera(out HTuple hv_AcqHandle)
        {
            hv_AcqHandle = new HTuple();
            string resultOK = "OK";
            try
            {
                //打开相机
                /*///////////////////////////////////////////////////--2020-04-07,zhouyin,要复原
                HOperatorSet.OpenFramegrabber(

                    dicOpenFramegrabber_00_15["00"].GetHTuple,
                    dicOpenFramegrabber_00_15["01"].GetHTuple,
                    dicOpenFramegrabber_00_15["02"].GetHTuple,
                    dicOpenFramegrabber_00_15["03"].GetHTuple,

                    dicOpenFramegrabber_00_15["04"].GetHTuple,
                    dicOpenFramegrabber_00_15["05"].GetHTuple,
                    dicOpenFramegrabber_00_15["06"].GetHTuple,
                    dicOpenFramegrabber_00_15["07"].GetHTuple,

                    dicOpenFramegrabber_00_15["08"].GetHTuple,
                    dicOpenFramegrabber_00_15["09"].GetHTuple,
                    dicOpenFramegrabber_00_15["10"].GetHTuple,
                    dicOpenFramegrabber_00_15["11"].GetHTuple,

                    dicOpenFramegrabber_00_15["12"].GetHTuple,
                    dicOpenFramegrabber_00_15["13"].GetHTuple,
                    dicOpenFramegrabber_00_15["14"].GetHTuple,
                    dicOpenFramegrabber_00_15["15"].GetHTuple,
                    out hv_AcqHandle);


                //设置初始化参数
                foreach (var para in dicSetFramegrabberParam.Values)
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, para.ParaName, para.GetHTuple);
                }

                // wuqh 2016-9-12 更改图像采集方式
                HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "GtlBufferHandlingMode", "2");
                */
                HOperatorSet.OpenFramegrabber("File", 1, 1, 0, 0, 0, 0, "default", -1, "default", -1, "false", @"C:\Users\ZY\Desktop\图片", "default", 1, -1, out hv_AcqHandle); 
                HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            }
            catch (Exception ex)
            {
                resultOK = ex.Message + " 相机" + Name + ":打开异常,请检查 CameraS.xml 配置文件是否正确!";
                SoftwareInfo.getInstance().WriteLog("OpenCamera:\n"+ex .ToString ());
            }

            return resultOK;

        }

        private void reOpenCamera( )
        {
            grabErrorCnt++;
            if (grabErrorCnt >= SoftwareInfo.getInstance ().GrabErrorNumRestart)
            {
                IsGrabError = true;
                grabErrorCnt = 0;
                if (IsEnabled)
                {
                    if (hv_AcqHandle != null && hv_AcqHandle.Length == 1)
                    {
                        //2.停止相机
                        if (hv_AcqHandle != null && hv_AcqHandle.Length != 0)
                        {
                            HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                            hv_AcqHandle = null;
                        }
                    }
                
                    string resultFlag = "OK";                
                    try
                    {
                        //1.打开相机  
                        resultFlag = OpenCamera(out hv_AcqHandle);
                        //2.相机打开成功，开启采图线程
                        if ("OK" == resultFlag)
                        {

                            Console.WriteLine("重启相机"+(StationNo +1)+"成功！");
                        }
                    }
                    catch (Exception ex)
                    {
                        resultFlag = " 相机[" + Name + "]打开异常!";
                        SoftwareInfo.getInstance().WriteLog("OpenCamera:\n" + ex.ToString());
                    }
                }
            }
        }


        #region 监控记录数据 wuqh

        private string saveDataDirectory = "D:\\TestData";
        private StreamWriter swSaveInfo;
        private StringBuilder sbDataInfo = new StringBuilder();

        private int saveCounterNo = 0;
        private int pageDataNum = 1000;
        private double lastCode = -1;
        private int grabNo = 0;

        private void CreatDataFile(int channelNo, int stationNo)
        {
            saveCounterNo = 0;

            if (!Directory.Exists(saveDataDirectory))
            {
                Directory.CreateDirectory(saveDataDirectory);
            }

            string saveDataFile = saveDataDirectory + "\\工位" +  stationNo.ToString()  + "_" + channelNo.ToString() + " " + DateTime.Now.ToString("yyyyMMdd HHmmss") + ".sd";

            if (swSaveInfo != null)
            {
                swSaveInfo.Close();
            }
            swSaveInfo = new StreamWriter(saveDataFile, true);
            sbDataInfo.Clear();

        }

        private void SavaDataFile(int channelNo, int stationNo, int grabNo, double code, string dtNow)
        {

            int saveCounterTmp = 0;

            sbDataInfo.Clear();

            saveCounterNo++;
            saveCounterTmp = saveCounterNo;

            sbDataInfo.Append(stationNo);
            sbDataInfo.Append("\t");
            sbDataInfo.Append(grabNo);
            sbDataInfo.Append("\t");
            sbDataInfo.Append(code);
            sbDataInfo.Append("\t");
            sbDataInfo.Append(dtNow);
            sbDataInfo.Append("\t");

            sbDataInfo.Append("\t");
            sbDataInfo.Append("\r\n");

            swSaveInfo.Write(sbDataInfo);
            swSaveInfo.Flush();


            if (saveCounterTmp >= pageDataNum)
            {
                swSaveInfo.Close();
                saveCounterNo = 0;

                CreatDataFile(channelNo, stationNo);
            }
        }

       

        #endregion


        /// <summary>
        /// 图像采集 函数
        /// </summary>
        /// <param name="stationNumber"></param>
        private void GrabImageFunc()
        {
            //if (MessageBox.Show("是否需要清除D:\\TestData相关数据？", "系统提示", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            //{
            //    if (Directory.Exists(dataPath))
            //    {
            //        DeleteFileDir(dataPath);
            //    }
            //}

            if (SoftwareInfo.getInstance().IsSaveRunInfoData)
            {
                CreatDataFile(ChannelNo, (StationNo + 1));
            }

            while (true)
            {
                //是否暂停拍照  0419 zyh
                if (!Pause || !(SoftwareInfo.getInstance().IsStopCheck && SoftwareInfo.getInstance().IsBatchCheck))
                {
                    if (cameraState == CameraState.Photo)
                    {

                        try
                        {
                            if (SoftwareInfo.getInstance().IsSaveRunInfoData)
                            {                               
                                string dtNow = DateTime.Now.ToString("yyyy MM dd HH mm ss fff");
                                SavaDataFile(ChannelNo, (StationNo + 1), 0, 0,"start:"+ dtNow);
                                
                            }
                            temp_HoImage = null;
                            mutex.WaitOne();

                            // Qiyi Li 20200219 调试卡死
                            try
                            {
                                HOperatorSet.GrabImageAsync(out temp_HoImage, hv_AcqHandle, -1);
                                // baicx 20200305 监视时间计数 
                                ncount++;
                                if (bRunStart && ncount == 1)
                                {
                                    bRunStart = false;
                                    stopwatch.Restart();  //启动Stopwatch
                                    Console.WriteLine(DateTime.Now.ToString("HH:mm:ss fff") + " " + "Stopwatch is running-=========================================:{0}", stopwatch.IsRunning);//获取当前Stopwatch的状态
                                }
                                // baicx 202003054 监视时间计数 
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine(this.Name + "--->" + ex.Message);
                            }

                            //HObject ho_ImageFliter = null;
                            //HTuple hv_CorrectGray;

                            //string impPath = "D:\\YSMS_130StandardV4_Info\\Products\\C线\\" +
                            //    SoftwareInfo.getInstance().FirstChannelLastProductName + "\\" + (StationNo + 1) + "\\light.bmp";

                            //if (File.Exists(impPath))
                            //{
                            //    HObject ho_ImageBackGround = null;
                            //    HOperatorSet.ReadImage(out ho_ImageBackGround, impPath);
                            //    if (ho_ImageBackGround != null)
                            //    {
                            //        Mean_Image_By_Gray(ho_ImageBackGround, temp_HoImage, out ho_ImageFliter, out hv_CorrectGray);
                            //        HOperatorSet.AddImage(temp_HoImage, ho_ImageFliter, out ho_ImageFliter, 1, -hv_CorrectGray);

                            //        temp_HoImage = ho_ImageFliter;
                            //    }
                            //}
                                                          

                            IsGrabError = false;                    
                            mutex.ReleaseMutex();

                            //if (SoftwareInfo .getInstance (). IsRotate)
                            //{
                            //    HOperatorSet.RotateImage(temp_HoImage, out temp_HoImage, 90, "constant");
                            //}

                            if (1 == IsImageRotate)
                            {
                                HOperatorSet.RotateImage(temp_HoImage, out temp_HoImage, 90, "constant");
                            }
                            else if (2 == IsImageRotate)
                            {
                                HOperatorSet.RotateImage(temp_HoImage, out temp_HoImage, 180, "constant");
                            }
                            else if (3 == IsImageRotate)
                            {
                                HOperatorSet.RotateImage(temp_HoImage, out temp_HoImage, 270, "constant");
                            }

                            AllPhotoNum++;
                        }
                        catch(Exception ex)
                        {
                            SoftwareInfo.getInstance().WriteLog("GrabImageFunc:\n"+ex .ToString ());
                            Console.WriteLine("GrabImageFunc:\n" + ex.Message .ToString());
                            temp_HoImage = null;
                            reOpenCamera();
                            
                        }

                        #region 获取一张图片
                        if (m_grabOneImageSignal)
                        {
                            if (m_oneHoImage != null)
                            {
                                m_oneHoImage.Dispose();
                                m_oneHoImage = null;
                            }
                            if (temp_HoImage != null)
                            {
                                m_oneHoImage = temp_HoImage.CopyObj(1, 1);
                                m_grabOneImageSignal = false;
                            }
                        }
                        #endregion

                        //防止内存 过大 丢弃一些图像
                        if (temp_HoImage != null && temp_HoImage.IsInitialized())
                        {
                            if (queueImage.Count < 20)
                            {
                                PackedImage packedImage = new PackedImage();
                                packedImage.PhotoTime = DateTime.Now;
                                packedImage.Image = temp_HoImage;
                                if (SoftwareInfo.getInstance().SoftwareType == SoftwareTypeEnum.Normal)
                                {
                                    if (GetChannelCode != null)
                                    {
                                        packedImage.CodeValue = GetChannelCode(ChannelNo) ;                                        
                                    }
                                    
                                }
                                else if (SoftwareInfo.getInstance().SoftwareType == SoftwareTypeEnum.ContinueUDP)
                                {
                                    if (GetStationCode != null)
                                    {
                                        packedImage.CodeValue = GetStationCode(ChannelNo, StationNo);
                                    }

                                }
                                //片式读取工位编码值
                                else
                                {
                                    if (GetStationCode != null)
                                    {
                                        packedImage.CodeValue = GetStationCode(ChannelNo ,StationNo);
                                    }
                                }
                                packedImage.DelayCode = AlarmDelayCode * SoftwareInfo.getInstance().DistanceToAlarmCode;
                                packedImage.DelayTime = AlarmDelayTime;
                                packedImage.StationNo = StationNo;
                                packedImage.ChannelNo = ChannelNo;
                                //queueImage.Enqueue(packedImage);
                                queueImage.Add(packedImage);


                                if (SoftwareInfo.getInstance().IsSaveRunInfoData)
                                {
                                    //用于记录监控数据wuqh
                                    if (lastCode != packedImage.CodeValue)
                                    {
                                        grabNo = 0;
                                    }

                                    grabNo++;
                                    string dtNow = DateTime.Now.ToString("yyyy MM dd HH mm ss fff");
                                    SavaDataFile(ChannelNo, (StationNo + 1), grabNo, packedImage.CodeValue,"addPhoto"+ dtNow);
                                    lastCode = packedImage.CodeValue;
                                }
                            }
                            else
                            {
                                temp_HoImage.Dispose();
                                ThrowImageCount++;
                            }
                        }

                    }
                    else
                    {
                        //由于相机模式设置更改 无需再一直清空相机里的图片？？？
                        //try
                        //{
                        //    HOperatorSet.GrabImageAsync(out temp_HoImage, hv_AcqHandle, -1);
                        //}
                        //catch
                        //{
                        //    temp_HoImage = null;
                        //}
                        //if (temp_HoImage != null)
                        //{
                        //    temp_HoImage.Dispose();
                        //}
                    }
                }
                DispatcherHelper.DoEvents();
                if (SoftwareInfo.getInstance().CameraPhotoType == 1 &&!SoftwareInfo .getInstance ().IsStrobe )
                {
                    Thread.Sleep(20);
                }
                else
                {
                    Thread.Sleep(PaiZhaoJianGe);
                }



                }

            }



        public void Mean_Image_By_Gray(HObject ho_ImageBackground, HObject ho_ImageModel,
       out HObject ho_ImageFliter, out HTuple hv_CorrectGray)
        {


            // Stack for temporary objects 
            HObject[] OTemp = new HObject[20];
            long SP_O = 0;

            // Local iconic variables 

            HObject ho_Domain, ho_Rectangle1, ho_Region;
            HObject ho_RegionIntersection, ho_Rectangle, ho_RegionDifference;
            HObject ho_ConnectedRegions, ho_DupImage, ho_ObjectSelected = null;
            HObject ho_RegionIntersection1 = null, ho_RegionErosion = null;
            HObject ho_RegionDilation = null, ho_ImageMean, ho_ImageCleared;


            // Local control variables 

            HTuple hv_Width, hv_Height, hv_Mean, hv_Deviation;
            HTuple hv_Mean1, hv_ExpDefaultCtrlDummyVar, hv_Min, hv_Max;
            HTuple hv_Range, hv_Mean2, hv_Number, hv_Index, hv_Area = new HTuple();
            HTuple hv_Mean1_1 = new HTuple(), hv_Deviation1 = new HTuple();

            // Initialize local and output iconic variables 
            HOperatorSet.GenEmptyObj(out ho_ImageFliter);
            HOperatorSet.GenEmptyObj(out ho_Domain);
            HOperatorSet.GenEmptyObj(out ho_Rectangle1);
            HOperatorSet.GenEmptyObj(out ho_Region);
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection);
            HOperatorSet.GenEmptyObj(out ho_Rectangle);
            HOperatorSet.GenEmptyObj(out ho_RegionDifference);
            HOperatorSet.GenEmptyObj(out ho_ConnectedRegions);
            HOperatorSet.GenEmptyObj(out ho_DupImage);
            HOperatorSet.GenEmptyObj(out ho_ObjectSelected);
            HOperatorSet.GenEmptyObj(out ho_RegionIntersection1);
            HOperatorSet.GenEmptyObj(out ho_RegionErosion);
            HOperatorSet.GenEmptyObj(out ho_RegionDilation);
            HOperatorSet.GenEmptyObj(out ho_ImageMean);
            HOperatorSet.GenEmptyObj(out ho_ImageCleared);

            if (HDevWindowStack.IsOpen())
            {
                HOperatorSet.SetDraw(HDevWindowStack.GetActive(), "margin");
            }
            ho_Domain.Dispose();
            HOperatorSet.GetDomain(ho_ImageBackground, out ho_Domain);
            HOperatorSet.GetImageSize(ho_ImageBackground, out hv_Width, out hv_Height);

            HOperatorSet.Intensity(ho_Domain, ho_ImageBackground, out hv_Mean, out hv_Deviation);
            //产品灰度zhu20190409
            ho_Rectangle1.Dispose();
            HOperatorSet.GenRectangle1(out ho_Rectangle1, hv_Height / 4, hv_Width / 4, (hv_Height * 3) / 4,
                (hv_Width * 3) / 4);
            ho_Region.Dispose();
            HOperatorSet.Threshold(ho_ImageModel, out ho_Region, 50, 255);
            ho_RegionIntersection.Dispose();
            HOperatorSet.Intersection(ho_Rectangle1, ho_Region, out ho_RegionIntersection
                );
            HOperatorSet.Intensity(ho_RegionIntersection, ho_ImageModel, out hv_Mean1, out hv_ExpDefaultCtrlDummyVar);
            //
            //intensity (Domain, ImageModel, Mean1, _)
            //zhu20190409产品定位

            HOperatorSet.MinMaxGray(ho_Domain, ho_ImageBackground, 0, out hv_Min, out hv_Max,
                out hv_Range);
            ho_Rectangle.Dispose();
            HOperatorSet.GenGridRegion(out ho_Rectangle, hv_Height / 3, hv_Width / 3, "lines",
                hv_Width, hv_Height);
            ho_RegionDifference.Dispose();
            HOperatorSet.Difference(ho_Domain, ho_Rectangle, out ho_RegionDifference);
            ho_ConnectedRegions.Dispose();
            HOperatorSet.Connection(ho_RegionDifference, out ho_ConnectedRegions);
            ho_Rectangle.Dispose();
            HOperatorSet.SelectShape(ho_ConnectedRegions, out ho_Rectangle, "inner_radius",
                "and", 50, 99999);

            //gen_rectangle1 (Rectangle, [0,Height-Height/5,0,Height-Height/5,Height/2-Height/5], [0,0,Width-Height/5,Width-Height/5,Width/2-Height/5], [Height/5,Height,Height/5,Height,Height/2+Height/5], [Height/5,Height/5,Width,Width,Width/2+Height/5])
            ho_DupImage.Dispose();
            HOperatorSet.CopyImage(ho_ImageModel, out ho_DupImage);
            hv_Mean2 = new HTuple();
            HOperatorSet.CountObj(ho_Rectangle, out hv_Number);
            for (hv_Index = 0; hv_Index.Continue(hv_Number - 1, 1); hv_Index = hv_Index.TupleAdd(1))
            {
                ho_ObjectSelected.Dispose();
                HOperatorSet.SelectObj(ho_Rectangle, out ho_ObjectSelected, hv_Index + 1);
                ho_RegionIntersection1.Dispose();
                HOperatorSet.Intersection(ho_Region, ho_ObjectSelected, out ho_RegionIntersection1
                    );
                HOperatorSet.AreaCenter(ho_RegionIntersection1, out hv_Area, out hv_ExpDefaultCtrlDummyVar,
                    out hv_ExpDefaultCtrlDummyVar);
                if ((int)(new HTuple(hv_Area.TupleGreater(5000))) != 0)
                {
                    ho_RegionErosion.Dispose();
                    HOperatorSet.ErosionCircle(ho_RegionIntersection1, out ho_RegionErosion,
                        3);
                    HOperatorSet.Intensity(ho_RegionErosion, ho_ImageModel, out hv_Mean1_1, out hv_Deviation1);
                }
                else
                {
                    hv_Mean1_1 = hv_Mean1.Clone();
                }
                ho_RegionDilation.Dispose();
                HOperatorSet.DilationRectangle1(ho_ObjectSelected, out ho_RegionDilation, 2,
                    2);

                hv_Mean2 = hv_Mean2.TupleConcat(hv_Mean1_1);
                OTemp[SP_O] = ho_DupImage.CopyObj(1, -1);
                SP_O++;
                ho_DupImage.Dispose();
                HOperatorSet.PaintRegion(ho_RegionDilation, OTemp[SP_O - 1], out ho_DupImage,
                    hv_Mean1_1, "fill");
                OTemp[SP_O - 1].Dispose();
                SP_O = 0;
            }
            ho_ImageMean.Dispose();
            HOperatorSet.MeanImage(ho_DupImage, out ho_ImageMean, hv_Width / 4, hv_Height / 4);
            //scale_image (DupImage, ImageScaled, 1, -(max(Mean2)-min(Mean2)))
            ho_ImageCleared.Dispose();
            HOperatorSet.GenImageProto(ho_ImageMean, out ho_ImageCleared, hv_Mean2.TupleMax()
                );
            //sub_image (ImageCleared, ImageScaled, ImageFliter, 1, 0)
            ho_ImageFliter.Dispose();
            HOperatorSet.SubImage(ho_ImageCleared, ho_ImageMean, out ho_ImageFliter, 1, 0);
            hv_CorrectGray = 0;
            //zhu20190409产品定位



            //scale_image (ImageBackground, ImageScaled, 1, -(Mean-Min))
            //gen_image_proto (ImageScaled, ImageCleared, (Mean-Min))
            //sub_image (ImageCleared, ImageScaled, ImageFliter, 1, 0)
            //CorrectGray := Mean-Mean1

            ho_Domain.Dispose();
            ho_Rectangle1.Dispose();
            ho_Region.Dispose();
            ho_RegionIntersection.Dispose();
            ho_Rectangle.Dispose();
            ho_RegionDifference.Dispose();
            ho_ConnectedRegions.Dispose();
            ho_DupImage.Dispose();
            ho_ObjectSelected.Dispose();
            ho_RegionIntersection1.Dispose();
            ho_RegionErosion.Dispose();
            ho_RegionDilation.Dispose();
            ho_ImageMean.Dispose();
            ho_ImageCleared.Dispose();

            return;
        }

        #region 获取一张图片
        private HObject m_oneHoImage = null;
        /// <summary>
        /// 获取一张图片信号
        /// </summary>
        private bool m_grabOneImageSignal = false;

        /// <summary>
        /// 等待采集图片循环计数
        /// </summary>
        private int m_waitGrabImageWheelCount = 0;
        #endregion
        /// <summary>
        /// 获取一张图片
        /// </summary>
        public HObject GetOneHoImage()
        {
            if (IsEnabled)
            {
                ///防止死锁
                //mutex.WaitOne();
                m_grabOneImageSignal = true;
                m_waitGrabImageWheelCount = 0;
                if (m_oneHoImage != null)
                {
                    m_oneHoImage.Dispose();
                    m_oneHoImage = null;
                }
                //mutex.ReleaseMutex();

                //System.Console.WriteLine("获取图片开始！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                while (m_grabOneImageSignal && m_waitGrabImageWheelCount < 3)
                {
                    m_waitGrabImageWheelCount++;
                    //2016-02-19 暂时注释
                    DispatcherHelper.DoEvents();
                    Thread.Sleep(300);
                    //System.Console.WriteLine("获取图片完成！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                }

                if (m_grabOneImageSignal)
                {
                    //采集图片失败
                    System.Console.WriteLine("获取图片失败！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));
                    if (m_oneHoImage != null)
                    {
                        m_oneHoImage.Dispose();
                        m_oneHoImage = null;
                    }
                    m_grabOneImageSignal = false;
                }
                return m_oneHoImage;
            }
            else
            {
                return null;
            }
            //System.Console.WriteLine("获取图片完成！" + DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss fff"));

        }


        /// <summary>
        /// 
        /// </summary>
        /// <returns>OK</returns>
        public string OpenCamera()
        {
            string resultFlag = "OK";
            if (IsEnabled)
            {
                try
                {
                    //1.打开相机  
                    resultFlag = OpenCamera(out hv_AcqHandle);
                    //2.相机打开成功，开启采图线程
                    if ("OK" == resultFlag)
                    {

                        grabImageThread = new System.Threading.Thread(GrabImageFunc);
                        grabImageThread.IsBackground = true;
                        grabImageThread.Priority = System.Threading.ThreadPriority.Normal;
                        grabImageThread.Start();
                    }
                }
                catch(Exception ex)
                {                    
                    resultFlag = " 相机[" + Name + "]打开异常!";
                    SoftwareInfo.getInstance().WriteLog("OpenCamera:\n"+ ex.ToString());
                }
            }

            return resultFlag;
        }

        /// <summary>
        /// 关闭相机 
        /// </summary>
        public void CloseCamera()
        {
            if (IsEnabled)
            {
                if (grabImageThread != null && grabImageThread.IsAlive)
                {
                    grabImageThread.Abort();
                    grabImageThread.Join();
                }

                if (hv_AcqHandle != null && hv_AcqHandle.Length == 1)
                {
                    //2.停止相机
                    if (hv_AcqHandle != null && hv_AcqHandle.Length != 0)
                    {
                        HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                        hv_AcqHandle = null;
                    }
                }
            }

        }

        //设置拍照模式
        public string SetTriggerMode(bool IsDeviceTrigger)
        {
            string result = "OK";
            try
            {
                if (IsDeviceTrigger)
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "do_abort_grab", 1);
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "TriggerMode", "On");
                    Console.WriteLine(this.Name + " Set TriggerMode On");
                }
                else
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "do_abort_grab", 1);
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "TriggerMode", "Off");
                    Console.WriteLine(this.Name + " Set TriggerMode Off");
                }

            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("SetTriggerMode:\n"+ex.ToString ());
                result = ex.Message;               
            }
            return result;
        }

        /// <summary>
        /// 设置相机曝光时间和图像增益
        /// </summary>
        /// <param name="exposureTimeRaw"></param>
        /// <param name="GainRaw"></param>
        /// <returns></returns>
        public string SetCameraPara(int ExposureTimeRaw, int GainRaw)
        {
            string result = "OK";
            if (IsEnabled && SoftwareInfo.getInstance().SystemRunMode == 1)
            {
                try
                {
                    //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, SoftwareInfo.getInstance().ExposureTimeRaw, ExposureTimeRaw);
                    //HOperatorSet.SetFramegrabberParam(hv_AcqHandle, SoftwareInfo.getInstance().GainRaw, GainRaw);

                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, dicSetFramegrabberParam["02"].ParaName, ExposureTimeRaw);
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, dicSetFramegrabberParam["03"].ParaName, GainRaw);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("SetCameraPara:\n" + ex.ToString());
                    SoftwareInfo.getInstance().WriteLog("SetCameraPara:\n"+ex.ToString ());
                    result = ex.Message;
                }

            }
            return result;
        }

        /// <summary>
        /// 设置相机参数
        /// </summary>
        /// <param name="para7"></param>
        /// <returns></returns>
        public string SetCameraPara(YSMS.DataManage.Para4HTuple para4)
        {
            string result = "OK";
            if (IsEnabled)
            {
                if (para4 != null)
                {
                    try
                    {

                        HOperatorSet.SetFramegrabberParam(hv_AcqHandle, para4.ParaName, para4.GetHTuple);

                        //记录设置的值
                        dicSetFramegrabberParam[para4.ParaNo].ParaValue = para4.ParaValue;
                    }
                    catch (Exception ex)
                    {
                        SoftwareInfo.getInstance().WriteLog("SetCameraPara:\n"+ex.ToString ()); 
                        result = ex.Message;
                    }
                }
            }
            else
            {
                //记录设置的值
                dicSetFramegrabberParam[para4.ParaNo].ParaValue = para4.ParaValue;
            }
            return result;
        }

        /// <summary>
        /// 设置相机参数
        /// </summary>
        /// <param name="para7"></param>
        /// <returns></returns>
        public string SetCameraPara(YSMS.DataManage.Para7HTuple para7)
        {
            string result = "OK";
            if (IsEnabled)
            {
                if (para7 != null)
                {
                    try
                    {
                        HOperatorSet.SetFramegrabberParam(hv_AcqHandle, para7.ParaName, para7.GetHTuple);

                        //记录设置的值
                        dicSetFramegrabberParam[para7.ParaNo].ParaValue = para7.ParaValue;
                    }
                    catch (Exception ex)
                    {
                        SoftwareInfo.getInstance().WriteLog("SetCameraPara:\n" +ex.ToString ());
                        result = ex.Message;
                    }
                }
            }
            else
            {
                //记录设置的值
                dicSetFramegrabberParam[para7.ParaNo].ParaValue = para7.ParaValue;
            }
            return result;
        }


        public string SetCameraGrabAction(bool isAction)
        {
            string result = "OK";

            try
            {
                if (isAction)
                {
                    HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
                }
                else
                {
                    HOperatorSet.SetFramegrabberParam(hv_AcqHandle, "do_abort_grab", 1);
                }
                
            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("SetCameraGrabAction:\n" + ex.ToString());
                result = ex.Message;
            }

            return result;
        }


        #endregion

    }
}
