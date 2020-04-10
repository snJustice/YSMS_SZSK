using HalconDotNet;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using YSMS;
using YSMS.DataManage;
using YSMS_130Standard;
using YSMS_SZSK.Models;

namespace YSMS_SZSK.CustomerUserControll
{
    /// <summary>
    /// CameraViews.xaml 的交互逻辑
    /// </summary>
    public partial class CameraViews : UserControl
    {

        public int ChannelNo = 0;

        //工位号（用于程序 比真实值小1）
        public int StationNo = 0;

        //工位状态
        public PublicEnum.StationState StationState = PublicEnum.StationState.Close;

        //是否暂停
        public bool Pause = false;
        //停止所有线程
        public bool Stop = false;

        //是否是待机状态
        public bool IsReady = true;

        //抽样计数
        public int SampleCount = 0;

        public YSMS.DataManage.Camera m_camera = null;

        System.Threading.Mutex mutex = new System.Threading.Mutex();
        Thread processImageThread = null;

        //直接报警功能(通道号，延时时间, 报警类型)（无编码器使用）
        public Action<int, int, int, AlarmType> alarmFunction = null;
        //报警加入等待队列功能(有编码器使用)
        public Action<PackedImage> AddAlarmFunction = null;
        //插入运行信息功能
        public Action<RunningStatusInfo> InsertInfo = null;

        int nullCnt = 0;


        int ImageCount = 0;

        private string SetImgeSaveFilePath;

        public CameraViews()
        {
            InitializeComponent();

            hWindControl1 = new HWindowControl();
            windowsFormsHost1.Child = hWindControl1;
            

        }


        public void SetCamera(YSMS.DataManage.Camera instanceCamera)
        {
            if (instanceCamera == null || !instanceCamera.IsEnabled)
                return;

            if (m_camera == null)
            {
                //切换窗体暂时不使能
                this.tabControl1.IsEnabled = false;
                m_camera = instanceCamera;


                //设置显示图像
                HOperatorSet.SetPart(hWindControl1.HalconWindow, 0, 0, m_camera.AOIHeight - 1, m_camera.AOIWidth - 1);
                /*
                HOperatorSet.SetPart(hWindControl2.HalconWindow, 0, 0, m_camera.AOIHeight - 1, m_camera.AOIWidth - 1);
                HOperatorSet.SetPart(hWindControl3.HalconWindow, 0, 0, m_camera.AOIHeight - 1, m_camera.AOIWidth - 1);
                HOperatorSet.SetPart(hWindControl4.HalconWindow, 0, 0, m_camera.AOIHeight - 1, m_camera.AOIWidth - 1);
                HOperatorSet.SetPart(hWindControl5.HalconWindow, 0, 0, m_camera.AOIHeight - 1, m_camera.AOIWidth - 1);*/


                processImageThread = new System.Threading.Thread(ProcessImage);

                processImageThread.Start();

                //切换窗体使能
                System.Threading.Thread.Sleep(30);
                this.tabControl1.IsEnabled = true;

            }
            else
            {
                //m_camera.HWindow = this.hWindControl1;
            }
        }

        private void ProcessImage()
        {
            while (!Stop)
            {
                try
                {
                    if (!Pause)
                    {
                        IsReady = false;
                        switch (StationState)
                        {
                            case PublicEnum.StationState.Close:
                            case PublicEnum.StationState.Black:
                                //todo
                                //显示黑屏
                                break;
                            case PublicEnum.StationState.Stay:
                                //todo
                                //不动
                                //Thread.Sleep(200);
                                //if (SoftwareInfo.getInstance().IsShowAlarmImage)
                                //{
                                //    if (m_camera != null &&
                                //        !Pause)
                                //    {
                                //        if (m_camera.queueImage.Count > 0)
                                //        {
                                //            //取出图像                                       
                                //            PackedImage tempPackedImage = m_camera.queueImage[0];

                                //            //处理图像
                                //            ProcessImageFunction(tempPackedImage);

                                //            //图像需要销毁
                                //            if (tempPackedImage != null)
                                //            {
                                //                if (tempPackedImage.Image != null)
                                //                    tempPackedImage.Image.Dispose();
                                //            }

                                //            if (m_camera.queueImage.Count > 0)
                                //            {
                                //                m_camera.queueImage.RemoveAt(0);
                                //            }
                                //        }
                                //    }
                                //}
                                break;
                            case PublicEnum.StationState.Show:

                                if (m_camera != null &&
                                    !Pause)
                                {
                                    Action action = () =>
                                    {
                                        PackedImage tempPackedImage = null;

                                        try
                                        {
                                            if (m_camera.queueImage.TryDequeue(out tempPackedImage))
                                            {

                                               
                                                
                                                if (tempPackedImage != null && tempPackedImage.Image.IsInitialized())
                                                {
                                                    HTuple objNum = 0;
                                                    HOperatorSet.CountObj(tempPackedImage.Image, out objNum);
                                                    if (objNum.I != 1)
                                                    {
                                                        
                                                       
                                                        SoftwareInfo.getInstance().WriteLog("ProcessImage出错：tempPackedImage 中图像I的值不等于1");
                                                        throw new Exception("ProcessImage出错：tempPackedImage 中图像I的值不等于1");              
                                                    }

                                                    showHoImage(tempPackedImage.Image);
                                                    ImageCount++;
                                                    if (false && ImageCount % 10 == 0)
                                                    {
                                                        string path = SaveImage(tempPackedImage.Image, "");
                                                        RunningStatusInfo info = new RunningStatusInfo
                                                        {
                                                            Channel = tempPackedImage.ChannelNo.ToString(),
                                                            CodeValue = tempPackedImage.CodeValue,
                                                            ImagePath = path,
                                                            State = "ng",
                                                            Time = DateTime.Now.ToString(),
                                                            Explain = "ng测试"
                                                        };

                                                        Dispatcher.Invoke(InsertInfo, info);
                                                    }
                                                }
                                                else
                                                {
                                                    nullCnt++;
                                                    SoftwareInfo.getInstance().WriteLog("ProcessImage出错：\n tempPackedImage == null");
                                                    if (SoftwareInfo.getInstance().IsStrobe && nullCnt > 20)
                                                    {
                                                        nullCnt = 0;
                                                      //  Global.m_alarmIO.Stop(0);
                                                        MessageBox.Show("ProcessImage出错：\n取图为空，tempPackedImage");
                                                    }
                                                }


                                                
                                            }
                                        }
                                        catch (Exception)
                                        {

                                            throw;
                                        }
                                    };

                                    action.Invoke();


                                }
                                break;
                            case PublicEnum.StationState.Measure:

                                if (m_camera != null &&
                                    !Pause)
                                {
                                    if (m_camera.IsGrabError && SoftwareInfo.getInstance().IsStrobe)
                                    {
                                      //  Global.m_alarmIO.Stop(0);/////////////////////////////////////////////zy
                                        MessageBox.Show("ProcessImage出错：\n采图出错，tempPackedImage");
                                    }
                                    if (m_camera.queueImage.Count > 0)
                                    {
                                        //取出图像
                                        mutex.WaitOne();
                                        PackedImage tempPackedImage = null;
                                        m_camera.queueImage.TryDequeue(out tempPackedImage) ;



                                        if (tempPackedImage != null && tempPackedImage.Image.IsInitialized())
                                        {
                                            HTuple objNum = 0;
                                            HOperatorSet.CountObj(tempPackedImage.Image, out objNum);
                                            if (objNum.I != 1)
                                            {
                                                //销毁本次图像
                                                if (tempPackedImage != null)
                                                {
                                                    if (tempPackedImage.Image != null)
                                                        tempPackedImage.Image.Dispose();
                                                }

                                               
                                                SoftwareInfo.getInstance().WriteLog("ProcessImage出错：tempPackedImage 中图像I的值不等于1");
                                                break;
                                            }
                                            //是否启用频场校正
                                           

                                            //处理图像
                                           
                                        }
                                        else
                                        {
                                            nullCnt++;
                                            SoftwareInfo.getInstance().WriteLog("ProcessImage出错：\n tempPackedImage == null");
                                            if (SoftwareInfo.getInstance().IsStrobe && nullCnt > 20)
                                            {
                                                nullCnt = 0;
                                             //   Global.m_alarmIO.Stop(0);////////////////////////////////////////////////////zy
                                                MessageBox.Show("ProcessImage出错：\n取图为空，tempPackedImage");
                                            }
                                        }


                                        //图像需要销毁
                                        if (tempPackedImage != null)
                                        {
                                            if (tempPackedImage.Image != null)
                                                tempPackedImage.Image.Dispose();
                                        }

                                       
                                    //    mutex.ReleaseMutex();

                                        //触发缓存图像报警
                                        if (SoftwareInfo.getInstance().IsCacheImageAlarm && m_camera.queueImage.Count > SoftwareInfo.getInstance().CacheAlarmNumer)
                                        {
                                            if (InsertInfo != null)
                                            {
                                                RunningStatusInfo info = new RunningStatusInfo();
                                                info.Time = DateTime.Now.ToString("HH:mm:ss");
                                                info.Channel = Global.ProductChannelArray[ChannelNo].ChannelName;
                                                info.Station = (StationNo + 1).ToString();

                                                info.State = "产品运行速度与检测速度不匹配！";
                                                info.Explain = "请检查产品运行速度是否过快！";
                                                Dispatcher.Invoke(InsertInfo, info);
                                            }

                                            if (alarmFunction != null)
                                            {
                                                Object[] arg = new Object[] { ChannelNo, StationNo, m_camera.AlarmDelayTime, AlarmType.Measure };
                                                Dispatcher.Invoke(alarmFunction, arg);
                                               // Global.m_alarmIO.Stop(ChannelNo);/////////////////////////////////////////////////////////////zy

                                                if (SoftwareInfo.getInstance().IsAlarmDeviceStop)
                                                {
                                                   // Global.m_alarmIO.CacheImageAlarmStop(ChannelNo);////////////////////////////////////////////zy
                                                }

                                            }
                                        }
                                    }
                                }
                                break;
                            case PublicEnum.StationState.Ajust:
                                //Thread.Sleep(200);
                                //todo
                                break;
                        }


                        IsReady = true;

                    }
                    //刷新数字
                   // Dispatcher.Invoke(new Action(RefreshInformation));///////////////////////////////////////zy

                }
                catch (Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("ProcessImage出错：\n" + ex.ToString());
                    Console.WriteLine("ProcessImage出错：" + ex.Message);
                }
                finally
                {

                }
                DispatcherHelper.DoEvents();
                Thread.Sleep(50);
            }
        }


        #region HALCON窗体
        public HalconDotNet.HWindowControl hWindControl1 = null;
        public HalconDotNet.HWindowControl hWindControl2 = null;
        public HalconDotNet.HWindowControl hWindControl3 = null;
        public HalconDotNet.HWindowControl hWindControl4 = null;
        public HalconDotNet.HWindowControl hWindControl5 = null;
        //HalconDotNet.HWindowControl hWindControl4 = null;
        #endregion

        public void showHoImage(HObject hoImage)
        {
            try
            {
                if (hoImage != null && hoImage.IsInitialized())
                {
                    HOperatorSet.DispObj(hoImage, hWindControl1.HalconWindow);
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["Error displaying real-time images"].ToString() + e.Message);

                //if (SoftwareInfo.getInstance().Language == "English")
                //{
                //    MessageBox.Show("Error displaying real-time images" + e.Message);
                //}
                //else
                //{
                //    //MessageBox.Show("显示实时图像出错" + e.Message);
                //    Console.WriteLine("显示实时图像出错" + e.Message);
                //}

                SoftwareInfo.getInstance().WriteLog("showHoImage:显示实时图像出错\n" + e.ToString());
            }
        }


        public void StopProcessImage()
        {
            if(processImageThread!=null && processImageThread.IsAlive)
            {
                processImageThread.Abort();
                
                
            }
        }

        public void SetImageSavePath(string filepath)
        {
            if(!Directory.Exists(filepath))
            {
                Directory.CreateDirectory(filepath);
            }

            SetImgeSaveFilePath = filepath;

        }


        private string  SaveImage(HObject iamge, string iamgePaths)
        {

            string datetime = DateTime.Now.ToString("yyyy-MM-dd");
            string product = "111";
            string serialnumber = "555";

            
            string iamgepath = string.Format("{0}//{1}//{2}", SetImgeSaveFilePath, product,serialnumber);
            string filepath = string.Format("{0}//{1}.jpg", iamgepath, ImageCount);
            if (!Directory.Exists(iamgepath))
            {
                Directory.CreateDirectory(iamgepath);
            }
           

            HOperatorSet.WriteImage(iamge,"jpg",0, filepath);
          
            return filepath;
        }



    }
}
