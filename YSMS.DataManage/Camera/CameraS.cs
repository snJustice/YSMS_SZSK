using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using System.Windows;

namespace YSMS.DataManage
{
    /// <summary>
    /// 从文件中读取相机集合信息
    /// </summary>
    public class CameraS
    {
        /// <summary>
        /// 相机集合
        /// </summary>
        private Camera[,] dicCamera = new Camera[4, 2];

        /// <summary>
        /// 设置读取当前编码器值的方法（冲压电镀）
        /// </summary>
        /// <param name="GetChannelCode"></param>
        public void SetGetChannelCodeFunc(Func<int, double > GetChannelCode)
        {
            foreach (var cam in dicCamera)
            {
                cam.GetChannelCode = GetChannelCode;
            }
        }

        /// <summary>
        /// 设置读取当前工位编码器值的方法（片式）
        /// </summary>
        /// <param name="GetChannelCode"></param>
        public void SetGetStationCodeFunc(Func<int,int , int> GetStationCode)
        {
            foreach (var cam in dicCamera)
            {
                cam.GetStationCode = GetStationCode;
            }
        }

        /// <summary>
        /// 从配置文件中获取相机参数信息
        /// </summary>
        /// <param name="xmlPath"></param>
        /// <param name="exMessage"></param>
        /// <returns></returns>
        public int GetCameraS(string xmlPath, ref string exMessage)
        {
            if (!System.IO.File.Exists(xmlPath))
            {
                exMessage = "不存在文件=" + xmlPath;
                return -1;
            }
            int resultFLag = 0;
            try
            {
                XDocument xDoc = XDocument.Load(xmlPath);
                foreach (var camera in xDoc.Descendants("Camera"))
                {
                    Camera cam = new Camera();
                    if (camera.Attributes("StationNo").Count() > 0)
                    {
                        cam.StationNo = Convert.ToInt32(camera.Attribute("StationNo").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少StationNo属性\r\n";
                    }

                    if (camera.Attributes("ChannelNo").Count() > 0)
                    {
                        cam.ChannelNo = Convert.ToInt32(camera.Attribute("ChannelNo").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少ChannelNo属性\r\n";
                    }

                    if (camera.Attributes("Name").Count() > 0)
                    {
                        cam.Name = camera.Attribute("Name").Value;
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少Name属性\r\n";
                    }

                    if (camera.Attributes("IsEnabled").Count() > 0)
                    {
                        cam.IsEnabled = camera.Attribute("IsEnabled").Value == "1" ? true : false;
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少IsEnabled属性\r\n";
                    }

                    if (camera.Attributes("AOIHeight").Count() > 0)
                    {
                        cam.AOIHeight = Convert.ToInt32(camera.Attribute("AOIHeight").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少AOIHeight属性\r\n";
                    }

                    if (camera.Attributes("AOIWidth").Count() > 0)
                    {
                        cam.AOIWidth = Convert.ToInt32(camera.Attribute("AOIWidth").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少AOIWidth属性\r\n";
                    }

                    if (camera.Attributes("AlarmDelayTime").Count() > 0)
                    {
                        cam.AlarmDelayTime = Convert.ToInt32(camera.Attribute("AlarmDelayTime").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少AlarmDelayTime属性\r\n";
                    }

                    if (camera.Attributes("AlarmDelayCode").Count() > 0)
                    {
                        cam.AlarmDelayCode = Convert.ToInt32(camera.Attribute("AlarmDelayCode").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少AlarmDelayCode属性\r\n";
                    }

                    if (camera.Attributes("IsImageRotate").Count() > 0)
                    {
                        cam.IsImageRotate = Convert.ToInt32(camera.Attribute("IsImageRotate").Value);
                    }
                    else
                    {
                        resultFLag = -1;
                        exMessage += "相机缺少IsImageRotate属性\r\n";
                    }

                    //打开相机参数
                    cam.dicOpenFramegrabber_00_15 = (from para4 in camera.Element("OpenFramegrabber").Descendants("Para4HTuple")
                                                     select new Para4HTuple
                                                     {
                                                         ParaNo = para4.Attribute("ParaNo").Value,
                                                         ParaName = para4.Attribute("ParaName").Value,
                                                         ParaType = para4.Attribute("ParaType").Value,
                                                         ParaValue = para4.Value
                                                     }).ToDictionary(v4 => v4.ParaNo);

                    //设置参数
                    cam.dicSetFramegrabberParam = (from para7 in camera.Element("SetFramegrabberParam").Descendants("Para7HTuple")
                                                   select new Para7HTuple
                                                   {
                                                       ParaNo = para7.Attribute("ParaNo").Value,
                                                       ParaName = para7.Attribute("ParaName").Value,
                                                       ParaType = para7.Attribute("ParaType").Value,
                                                       ParaValue = para7.Value,
                                                       ShowName = para7.Attribute("ShowName").Value,
                                                       Des = para7.Attribute("Des").Value,
                                                       DefaultValue = para7.Attribute("DefaultValue").Value,
                                                       Level = Convert.ToInt32(para7.Attribute("Level").Value)

                                                   }).ToDictionary(v7 => v7.ParaNo);

                    cam.CameraParameters = (from paraString in camera.Element("CameraCalibration").Element("CameraParameters").Value.Split(',')
                                            select Convert.ToDouble(paraString)).ToList();
                    cam.CameraPose = (from PoseString in camera.Element("CameraCalibration").Element("CameraPose").Value.Split(',')
                                      select Convert.ToDouble(PoseString)).ToList();
                    cam.PixelToSizeRatio = Convert.ToDouble(camera.Element("CameraCalibration").Element("PixelToSizeRatio").Value);

                    int channelNo = Convert.ToInt32(camera.Attribute("ChannelNo").Value);
                    int stationNo = Convert.ToInt32(camera.Attribute("StationNo").Value);


                    dicCamera[channelNo, stationNo] = cam;
                }



            }
            catch (Exception ex)
            {
                SoftwareInfo.getInstance().WriteLog("GetCameraS:\n"+ex.ToString());
                resultFLag = -1;
                exMessage += ex.Message;
            }

            return resultFLag;
        }

        /// <summary>
        /// 打开相机
        /// </summary>
        /// <returns>OK</returns>
        public string OpenAllCamera()
        {

            if (dicCamera == null)
                return Application.Current.Resources.MergedDictionaries.First()["Camera configuration file exception"].ToString();
            //if (SoftwareInfo.getInstance().Language == "English")
            //{
            //    if (dicCamera == null)
            //        return "Camera configuration file exception ";
            //}
            //else
            //{
            //    if (dicCamera == null)
            //        return "相机配置文件异常";
            //}

            string resultFlag = "OK";
            foreach (var cam in dicCamera)
            {
                resultFlag = cam.OpenCamera();
                if ("OK" != resultFlag)
                {
                    break;
                }
            }
            return resultFlag;
        }

        /// <summary>
        /// 关闭相机
        /// </summary>
        /// <returns></returns>
        public void CloseAllCamera()
        {
            if (dicCamera != null)
            {
                
                foreach (var cam in dicCamera)
                {
                    if (cam != null)                       
                    {
                        cam.CloseCamera();
                    }
                    
                }
            }

        }

        //public void ImageOperType(Camera.ImageOper imageOper)
        //{
        //    if (dicCamera != null)
        //    {
        //        foreach (var cam in dicCamera.Values)
        //        {
        //            cam.ImageOperType = imageOper;
        //        }
        //    }
        //}

        ///// <summary>
        ///// 所有窗体置空
        ///// </summary>
        //public void SetHWindNull()
        //{
        //    if (dicCamera != null)
        //    {
        //        foreach (var cam in dicCamera.Values)
        //        {
        //            cam.HWindow = null;
        //        }
        //    }
        //}

        /// <summary>
        /// 获取相机引用
        /// </summary>
        /// <param name="channelNo">通道号</param>
        /// <param name="stationNo">工位号</param>
        /// <returns></returns>
        public Camera GetCamera(int channelNo, int stationNo)
        {
            if (dicCamera != null && dicCamera.GetLength(0) > channelNo && dicCamera.GetLength(1) > stationNo)
                return dicCamera[channelNo,stationNo];
            else
                return null;
        }

        ///// <summary>
        ///// 获取相机下实时显示窗体
        ///// </summary>
        ///// <param name="no">01,02,03,04,05,06</param>
        ///// <returns></returns>
        //public HalconDotNet.HWindowControl GetCameraHWindowControl(string no)
        //{
        //    if (dicCamera != null && dicCamera.ContainsKey(no))
        //        return dicCamera[no].HWindow;
        //    else
        //        return null;
        //}


        /// <summary>
        /// 相机是否 启用
        /// </summary>
        /// <param name="no"></param>
        /// <returns></returns>
        public bool IsEnabledCamera(int channelNo, int stationNo)
        {
            if (dicCamera == null || dicCamera.GetLength(0) <= channelNo || dicCamera.GetLength(1) <= stationNo)
                return false;
            return dicCamera[channelNo, stationNo].IsEnabled;
        }

        ///// <summary>
        ///// 设置相机 图像处理
        ///// </summary>
        ///// <param name="no"></param>
        ///// <param name="imageOper"></param>
        //public void SetCameraImageOper(string no, Camera.ImageOper imageOper)
        //{
        //    if (dicCamera != null && dicCamera.ContainsKey(no))
        //    {
        //        dicCamera[no].ImageOperType = imageOper;
        //    }
        //}

        /// <summary>
        /// 设置相机状态
        /// </summary>
        /// <param name="no"></param>
        /// <param name="state"></param>
        public void SetCameraState(int channelNo, int stationNo, Camera.CameraState state)
        {
            if (dicCamera != null && dicCamera.GetLength(0) > channelNo && dicCamera.GetLength(1) > stationNo)
            {
                dicCamera[channelNo, stationNo].SetCameraState(state);
            }
        }

        /// <summary>
        ///  设置所有相机状态
        /// </summary>
        /// <param name="state"></param>
        public void SetAllCamerasState(int channelNo, Camera.CameraState state)
        {
            for (int i = 0; i < 6; i++ )
            {
                dicCamera[channelNo,i].SetCameraState(state);
            }
        }

        /// <summary>
        /// 暂停所有相机
        /// </summary>
        /// <param name="channelNo"></param>
        public void PauseAllCamera(int channelNo)
        {
            for (int i = 0; i < 6; i++)
            {
                dicCamera[channelNo, i].Pause = true;
            }
        }

        /// <summary>
        /// 继续所有相机
        /// </summary>
        /// <param name="channelNo"></param>
        public void ContinousAllCamera(int channelNo)
        {
            for (int i = 0; i < 6; i++)
            {
                dicCamera[channelNo, i].Pause = false;
            }
        }
        /// <summary>
        /// 设置曝光时间和图像增益
        /// </summary>
        /// <param name="channelNo"></param>
        /// <param name="product"></param>
        public void SetAllCamerasParas(int channelNo, Product product)
        {
            foreach (var v in product.StationList)
            {
                dicCamera[channelNo, v.StationNo - 1].SetCameraPara(v.ExposureTimeRaw, v.GainRaw);          
            }
        }

        /// <summary>
        /// 设置相机起始拍照时间,清空拍照张数（计算每秒测量张数）
        /// </summary>
        /// <param name="channelNo"></param>
        /// <param name="stationNo"></param>
        public void SetCameraStartPhotoTime(int channelNo, int stationNo)
        {
            dicCamera[channelNo, stationNo].startTime = DateTime.Now;
            dicCamera[channelNo, stationNo].AllPhotoNum = 0;
            dicCamera[channelNo, stationNo].ThrowImageCount = 0;
            dicCamera[channelNo, stationNo].AllMeasureCount = 0;
            dicCamera[channelNo, stationNo].PerMeasureCount = 0;
            
        }

        /// <summary>
        /// 设置相机延时报警时间
        /// </summary>
        /// <param name="channelNo"></param>
        /// <param name="stationNo"></param>
        public void SetCameraDelayAlarmTime(int channelNo, int stationNo, int time)
        {
            dicCamera[channelNo, stationNo].AlarmDelayTime = time;
            
        }

        /// <summary>
        /// 设置所有相机的触发模式
        /// </summary>
        /// <param name="IsDeviceTrigger"></param>
        /// <returns></returns>
        public string SetCamerasTriggerMode(int channelNo, bool IsDeviceTrigger)
        {
           
                if (channelNo == 0 || channelNo == 1)
                {
                    for (int j = 0; j < 6; j++)
                    {
                        if (dicCamera[channelNo, j]!=null)
                        {
                            if (dicCamera[channelNo, j].IsEnabled)
                            {
                                dicCamera[channelNo, j].SetTriggerMode(IsDeviceTrigger);
                            }
                        }
                        
                    }
                }
           
           
            return "OK";
        }

        /// <summary>
        /// 设置相机采集终止与启动
        /// </summary>
        /// <param name="channelNo"></param>
        /// <param name="IsAction"></param>
        /// <returns></returns>
        public string SetCamerasGrabActionMode(int channelNo, bool IsAction)
        {
            if (channelNo == 0 || channelNo == 1)
            {
                for (int j = 0; j < 6; j++)
                {
                    if (dicCamera[channelNo, j] != null)
                    {
                        if (dicCamera[channelNo, j].IsEnabled)
                        {
                            dicCamera[channelNo, j].SetCameraGrabAction(IsAction);
                        }
                    }
                }
            }
            return "OK";
        }

        //读取相机参数信息
        public string ReadAndSetCameraParas(string xmlPath)
        {
            string xmlFileName = xmlPath + "\\CameraParas.xml";
            if (System.IO.File.Exists(xmlFileName))
            {
                System.Xml.Linq.XDocument xDoc = System.Xml.Linq.XDocument.Load(xmlFileName);

                try
                {
                    foreach (var camera in xDoc.Root.Descendants("CameraPara"))
                    {
                        int channelNo = Convert.ToInt32(camera.Attribute("ChannelNo").Value);
                        int stationNo = Convert.ToInt32(camera.Attribute("StationNo").Value);

                        Dictionary<string, Para4HTuple> dicParas = (from para in camera.Descendants("Para4HTuple")
                                                          select new Para4HTuple
                                                          {
                                                              ParaNo = para.Attribute("ParaNo").Value,
                                                              ParaName = para.Attribute("ParaName").Value,
                                                              ParaValue = para.Attribute("ParaValue").Value,
                                                              ParaType = para.Attribute("ParaType").Value
                                                          }).ToDictionary(v => v.ParaNo);

                        Camera nowCamera = dicCamera[channelNo, stationNo];

                        if (nowCamera != null)
                        {
                            //设置参数信息
                            foreach (var vPara in dicParas.Values)
                            {
                                nowCamera.SetCameraPara(vPara);
                            }
                        }

                    }

                  
                }
                catch(Exception ex)
                {
                    SoftwareInfo.getInstance().WriteLog("ReadAndSetCameraParas:\n"+ex.ToString ());
                }
            }           

            return "OK";
        }

        /// 清空所有相机缓存图片
        /// </summary>
        /// <param name="channelNo"></param>
        public void ClearAllCameraPhoto(int channelNo)
        {
            for (int i = 0; i < 6; i++)
            {
                dicCamera[channelNo, i].queueImage=new System.Collections.Concurrent.ConcurrentQueue<PackedImage>();
            }
        }

    }

}
