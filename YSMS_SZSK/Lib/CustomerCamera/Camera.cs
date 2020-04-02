



using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HalconDotNet;
using System.Threading;
using System.Windows;
using YSMS_SZSK.MessagePrompt;
using YSMS_SZSK.CustomerGlobal;
using YSMS_SZSK.Basic.PublicClass;

namespace YSMS_SZSK.Lib.CustomerCamera
{
    public partial class Camera
    {
        private CameraParas m_controlParas = null;
        public HTuple hv_AcqHandle;

        public Thread m_GrabImageThread = null;
        public bool m_grabRun = false;

        public List<FoucsImage> FoucsImageList = new List<FoucsImage>();

        public FoucsImage tempImge = new FoucsImage();

        #region 图像获取完成-触发事件   2017-03-27 ludc
        public delegate void ImageReadyEventHandler(HObject hoImage);
        public event ImageReadyEventHandler ImageReadyEvent;
        /// <summary>
        /// 图像获取完成-触发事件
        /// </summary>
        protected void OnImageReadyEvent(HObject hoImage)
        {
            if (ImageReadyEvent != null)
            {
                ImageReadyEvent(hoImage);
            }
        }
        #endregion

        #region 实时图像与静态图像

        /// <summary>
        /// 同步基元
        /// </summary>
        public Mutex mutex = new Mutex();

        /// <summary>
        /// 连续图像
        /// </summary>
        HObject hoAllWaysImage = null;

        HObject copyImage = null;
        /// <summary>
        /// 获取单张图像
        /// </summary>
        HObject hoOneImage = null;
        private HalconDotNet.HWindowControlWPF hWindowCont;
        public HalconDotNet.HWindowControlWPF HWindowCont
        {
            set
            {
                mutex.WaitOne();
                hWindowCont = value;
                mutex.ReleaseMutex();
            }
        }
        /// <summary>
        /// 获取采集图片信号
        /// </summary>
        private bool m_grabOneImageSignalAndSave = false;
        private bool m_grabOneImageSignalNotsave = false;
        #endregion

        private string tempImageName = "Temp";

        public Camera(CameraParas paras)
        {
            this.m_controlParas = paras;
            //halcon 窗体
            hWindowCont = null;

        }
        HObject ho_Cross = new HObject();
        HObject ContCircle = new HObject();

        private void GrabImage()
        {
            while (true)
            {
                try
                {

                    if (hoAllWaysImage != null)
                    {
                        hoAllWaysImage.Dispose();
                    }

                    //int postion = (int)Dmc2210.d2210_get_encoder(Dmc2210.Asix_Z);
                    HOperatorSet.GrabImageAsync(out hoAllWaysImage, hv_AcqHandle, -1);
                    //int postion = (int)Dmc2210.d2210_get_encoder(Dmc2210.Asix_Z);
                    HOperatorSet.CopyImage(hoAllWaysImage, out copyImage);

                    //if (Global.IsFoucsing)
                    //{
                    //    tempImge = new FoucsImage() { Image = copyImage, GetPosition = postion };
                    //    FoucsImageList.Add(tempImge);
                    //}


                    //halcon 窗体
                    if (hWindowCont != null)
                    {
                        HalconDotNet.HOperatorSet.SetLineWidth(hWindowCont.HalconWindow, 1);
                        HalconDotNet.HOperatorSet.SetColor(hWindowCont.HalconWindow, "red");
                        HOperatorSet.GenCrossContourXld(out ho_Cross, 1028, 1232, 2464, 0);
                        HOperatorSet.GenCircleContourXld(out ContCircle, 1028, 1232, 900, 0, 6.28318, "positive", 1);

                        HOperatorSet.DispObj(hoAllWaysImage, hWindowCont.HalconWindow);

                        HOperatorSet.DispObj(ho_Cross, hWindowCont.HalconWindow);
                        HOperatorSet.DispObj(ContCircle, hWindowCont.HalconWindow);
                    }
                    OnImageReadyEvent(hoAllWaysImage);

                    #region 获取图片并保存到 硬盘中
                    if (m_grabOneImageSignalAndSave)
                    {
                        //  mutex.WaitOne();
                        if (hoAllWaysImage != null)
                        {
                            HOperatorSet.WriteImage(hoAllWaysImage, "bmp", 0, "D:\\TempImage\\" + tempImageName);
                        }
                        m_grabOneImageSignalAndSave = false;
                        tempImageName = "Temp";
                        //  mutex.ReleaseMutex();
                    }

                    if (m_grabOneImageSignalNotsave)
                    {
                        mutex.WaitOne();

                        if (hoOneImage != null)
                        {
                            hoOneImage.Dispose();
                            hoOneImage = null;
                        }
                        if (hoAllWaysImage != null)
                        {
                            HOperatorSet.CopyImage(hoAllWaysImage, out hoOneImage);
                        }
                        m_grabOneImageSignalNotsave = false;
                        m_grabOneImageSignalAndSave = false;
                        mutex.ReleaseMutex();
                    }

                    #endregion

                    Thread.Sleep(50);
                }
                catch (HalconException HDevExpDefaultException)
                {
                    HTuple hv_Exception;
                    HDevExpDefaultException.ToHTuple(out hv_Exception);
                }

            }
        }



        /// <summary>
        /// 获取一张图片
        /// </summary>
        public void GetOneImage()
        {
            ///防止死锁
            mutex.WaitOne();
            m_grabOneImageSignalAndSave = true;
            mutex.ReleaseMutex();

            while (m_grabOneImageSignalAndSave)
            {
                DispatcherHelper.DoEvents();
                Thread.Sleep(10);
            }

        }



        /// <summary>
        /// 获取一张图片
        /// </summary>
        public HObject GetOneImageNotSave()
        {
            ///防止死锁
            mutex.WaitOne();
            m_grabOneImageSignalAndSave = false;
            m_grabOneImageSignalNotsave = true;
            mutex.ReleaseMutex();
            while (m_grabOneImageSignalNotsave)
            {
                DispatcherHelper.DoEvents();
                Thread.Sleep(10);
            }
            return hoOneImage;
        }


        /// <summary>
        /// 获取一张图片
        /// </summary>
        public void GetOneImage(string imageName)
        {
            ///防止死锁
            mutex.WaitOne();
            m_grabOneImageSignalAndSave = true;

            tempImageName = imageName;
            mutex.ReleaseMutex();

            while (m_grabOneImageSignalAndSave)
            {
                DispatcherHelper.DoEvents();
                Thread.Sleep(10);
            }
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns></returns>
        public int OpenCamera()
        {

            try
            {

                HOperatorSet.CloseAllFramegrabbers();
                if (m_controlParas.OpenFramegrabber.Count == 16)
                {/*
                    HOperatorSet.OpenFramegrabber
                        (
                           m_controlParas.OpenFramegrabber[0].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[1].GetHTupleValue(),

                           m_controlParas.OpenFramegrabber[2].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[3].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[4].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[5].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[6].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[7].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[8].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[9].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[10].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[11].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[12].GetHTupleValue(),

                           m_controlParas.OpenFramegrabber[13].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[14].GetHTupleValue(),
                           m_controlParas.OpenFramegrabber[15].GetHTupleValue(),
                           out hv_AcqHandle
                        );*/
                    try
                    {
                        HOperatorSet.OpenFramegrabber("File", 1, 1, 0, 0, 0, 0, "default",
                        -1, "default", -1, "false", "fabrik", "default", 1, -1, out hv_AcqHandle);
                    }
                    catch(Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                    
                }

                //初始化参数
                foreach (var v in m_controlParas.SetFramegrabberParam)
                {
                   // HOperatorSet.SetFramegrabberParam(hv_AcqHandle, v.ParaKey, v.GetHTupleValue());
                }

                HOperatorSet.GrabImageStart(hv_AcqHandle, -1);
            }
            catch (System.Exception ex)
            {
                MyMessageBox.GetInstance().errorNumber = 501;
                MyMessageBox.GetInstance().errorDescribe = "相机启动异常" + ex.Message;
                MyMessageBox.GetInstance().errorAnalysis = "相机连接不良，或相机已经被其他程序打开。";
                MyMessageBox.GetInstance().errorSolution = "请关闭所有相机相关软件并重新连接相机。";
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Error);

                return 1;

            }

            return StartGrabImageThread();
        }
        /// <summary>
        /// 单个设置相机参数
        /// </summary>
        /// <param name="grabberParaHTuple"></param>
        public void SetFramegrabberParam(GrabberParaHTuple grabberParaHTuple)
        {
            HOperatorSet.SetFramegrabberParam(hv_AcqHandle, grabberParaHTuple.ParaKey, grabberParaHTuple.GetHTupleValue());
        }
        public int StartGrabImageThread()
        {
            if (hv_AcqHandle == null || hv_AcqHandle.Length == 0)
            {
                MyMessageBox.GetInstance().tipsInfo = "相机句柄为空。";
                MyMessageBox.GetInstance().ShowWindow(PublicEnum.MessageType.Tips);
                return 1;
            }

            if (m_GrabImageThread == null || !m_GrabImageThread.IsAlive)
            {
                m_grabRun = false;
                m_GrabImageThread = new Thread(GrabImage);
                m_GrabImageThread.IsBackground = true;
                m_GrabImageThread.Start();
            }

            return 0;
        }

        public void CloseGrabImageThread()
        {
            try
            {
                if (m_GrabImageThread != null && m_GrabImageThread.IsAlive)
                {
                    m_GrabImageThread.Abort();
                    m_GrabImageThread.Join(50);
                }
            }
            catch (System.Exception ex)
            {

            }
        }

        public int CloseCamera()
        {
            CloseGrabImageThread();

            Console.WriteLine("等待拍照线程关闭......");
            while (m_GrabImageThread != null && m_GrabImageThread.IsAlive)
            {
                DispatcherHelper.DoEvents();
            }
            Console.WriteLine("等待拍照线程已关闭");

            Console.WriteLine("相机关闭......");
            try
            {
                if (hv_AcqHandle != null && hv_AcqHandle.Length != 0)
                {
                    HOperatorSet.CloseFramegrabber(hv_AcqHandle);
                }

            }
            catch (System.Exception ex)
            {
                return 1;
            }
            finally
            {
                hv_AcqHandle = new HTuple();
            }
            Console.WriteLine("相机关闭结束");
            return 0;
        }


    }

    public partial class Camera
    {

        /// <summary>
        /// 获取最佳图像的Z轴位置
        /// </summary>
        /// <returns></returns>
        public int CalBestPostion()
        {
            int Postion = 99999;
            if (FoucsImageList.Count > 0 && Global.RectValue != null)
            {
                foreach (var item in FoucsImageList)
                {
                    item.Cal(Global.RectValue);
                }
                var BestImage = FoucsImageList.OrderBy(n => n.Score).Last();

                if (Global.IsFoucsingSaveimage)
                {
                    int i = 0;
                    foreach (var item in FoucsImageList)
                    {
                        HOperatorSet.WriteImage(item.Image, "bmp", 0, @"E:\TempImage\" + i);
                        i++;
                    }
                }

                Postion = BestImage.GetPosition;
                FoucsImageList.Clear();
            }
            return Postion;
        }


       
    }
}



