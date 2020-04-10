using System.Linq;
using System.Windows;

using HalconDotNet;
using YSMS.DataManage;
using YSMS_130Standard;
using YSMS_SZSK.Lib;
using YSMS_SZSK.Utils.Communication.TCP_Client.DSocket;
using YSMS_SZSK.参数设置;
using YSMS_SZSK.Utils;
using System.ComponentModel;
using YSMS_SZSK.Models;
using System;
using System.Windows.Media;
using YSMS_SZSK.CustomerUserControll;

namespace YSMS_SZSK
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        //数据展示的list
        public BindingList<RunningStatusInfo> RunningStatusInfoList = null;



        public MainWindow()
        {
            InitializeComponent();
            RunningStatusInfoList = new BindingList<RunningStatusInfo>();
            RunningInfoGrid.DataContext = RunningStatusInfoList;
        }

    


        public void UpdateImageGrayValue(Point point)
        {

        }

        public void ShowSlectedMeasureElementInfo()
        {

        }

        #region 对话框事件
        /// <summary>
        /// 对话框初始化，
        /// 2020-04-06，zhouyin，加载相机
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {


            string exMessage = "";
            if (0 != SoftwareInfo.getInstance().load(InfoPath.getInstance().SoftwareInfo, ref exMessage))
            {
                MessageBox.Show(messageBoxText: exMessage);
                this.Closing -= Window_Closing;
                //  MyProgressBar.close();
                this.Close();
            }


            //判断程序是否已启动，如果已启动则不再打开 进程优先级提高
            RaiseCurrentProgramPority();


            //打开相机
            GetCamerasInfo();

            SetCameraViewWithCamera();


        }





        /// <summary>
        /// 对话框关闭
        /// 2020-4-06-zhouyin，释放相机资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

            BatchMeasure_Flow1.WorkStation1.StopProcessImage();
            BatchMeasure_Flow1.WorkStation2.StopProcessImage();
            BatchMeasure_Flow2.WorkStation1.StopProcessImage();
            BatchMeasure_Flow2.WorkStation2.StopProcessImage();
            BatchMeasure_Flow3.WorkStation1.StopProcessImage();
            BatchMeasure_Flow3.WorkStation2.StopProcessImage();

            Global.m_dicCameraS.CloseAllCamera();
        }
        #endregion









        //提升本程序的优先级
        private static void RaiseCurrentProgramPority()
        {
            System.Diagnostics.Process[] customerProcess = System.Diagnostics.Process.GetProcessesByName("YSMS_SZSK");
            if (customerProcess.Length > 1)
            {

              //  MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["The program has started!"].ToString());
                Application.Current.Shutdown();  //关闭系统
            }
            if (customerProcess.Length == 1)
            {
                customerProcess[0].PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
            }
            customerProcess = System.Diagnostics.Process.GetProcessesByName("YSMS_SZSK.vshost");
            if (customerProcess.Length == 1)
            {
                customerProcess[0].PriorityClass = System.Diagnostics.ProcessPriorityClass.High;
            }
        }

        //加载相机信息
        private void GetCamerasInfo()
        {
            Global.IsGrab(true);
            string CameraPath = "";
            string exMessage = "";
            //#region 获取相机参数集合

            if (SoftwareInfo.getInstance().HasTwoChannels && SoftwareInfo.getInstance().SoftwareType == SoftwareTypeEnum.Pieces)
            {
                CameraPath = InfoPath.getInstance().CameraS2Ch;
            }
            else
            {
                CameraPath = InfoPath.getInstance().CameraS;

            }
            if (SoftwareInfo.getInstance().SystemRunMode == 1)
            {
                Global.m_dicCameraS.CloseAllCamera();
            }

            if (0 != Global.m_dicCameraS.GetCameraS(CameraPath, ref exMessage))
            {

                exMessage = Application.Current.Resources.MergedDictionaries.First()["Camera configuration loaded error:"].ToString() + exMessage;
                //if (SoftwareInfo.getInstance().Language == "English")
                //{
                //    exMessage = "Camera configuration loaded error : " + exMessage;
                //}
                //else
                //{
                //    exMessage = "相机配置加载出错: " + exMessage;
                //}
                MessageBox.Show(messageBoxText: exMessage);
                this.Closing -= Window_Closing;
                this.Close();
            }

            //设置读取编码器值的方法
            if (SoftwareInfo.getInstance().SoftwareType == SoftwareTypeEnum.Normal)
            {
                Global.m_dicCameraS.SetGetChannelCodeFunc(Global.GetChannelCode);
            }
            else if (SoftwareInfo.getInstance().SoftwareType == SoftwareTypeEnum.ContinueUDP)
            {
                Global.m_dicCameraS.SetGetStationCodeFunc(Global.GetStationImageCode);
            }
            //片式
            else
            {
                Global.m_dicCameraS.SetGetStationCodeFunc(Global.GetStationImageCode);
            }
            if (GetProgramSoftwareInfo().SystemRunMode == 1)
            {
                string openCamera = Global.m_dicCameraS.OpenAllCamera();
                

                if ("OK" != openCamera)
                {
                    Global.m_dicCameraS.CloseAllCamera();
                    MessageBox.Show(messageBoxText: openCamera);
                    this.Closing -= Window_Closing;
                    this.Close();
                }
            }
            Global.IsGrab(false);


        }

        //双击datagrid的事件
        private void RunningInfoGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            if (RunningInfoGrid.SelectedItem == null || RunningInfoGrid.SelectedItem.GetType() != typeof(RunningStatusInfo))
                return;
            //显示图片

            try
            {
                RunningStatusInfo item = RunningInfoGrid.SelectedItem as RunningStatusInfo;
                RunningStatusInfo itemTemp = new RunningStatusInfo();
                if (!string.IsNullOrEmpty(item.ImagePath))
                {
                    Tools.ShowImage_shimgvw(item.ImagePath);
                    
                }
            }
            catch (System.Exception ex)
            {

                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["Error opening picture"].ToString() + ex.Message);
                //if (SoftwareInfo.getInstance().Language == "English")
                //{
                //    MessageBox.Show("Error opening picture " + ex.Message);
                //}
                //else
                //{
                //    MessageBox.Show("打开图片出错" + ex.Message);
                //}

                SoftwareInfo.getInstance().WriteLog("RunningInfoGrid_MouseDoubleClick:打开图片出错\n" + ex.ToString());
            }
        }

        //grid上checkbox的事件，目前没发现用处
        private void RunningInfoGrid_IsChecked(object sender, RoutedEventArgs e)
        {

        }



        #region 开始停止按钮

        //1号通道，开始
        private void bt_Flow_First_Start_Click(object sender, RoutedEventArgs e)
        {
            string path = GetProgramSoftwareInfo().SaveAllImagePath;


            NeededSetProductMessageAndSeralNumber(BatchMeasure_Flow1);


            BatchMeasure_Flow1.WorkStation1.SetImageSavePath(path);

            BatchMeasure_Flow1.WorkStation1.StationState = PublicEnum.StationState.Show;


            
            BatchMeasure_Flow1.WorkStation2.SetImageSavePath(path);

            BatchMeasure_Flow1.WorkStation2.StationState = PublicEnum.StationState.Show;

            BatchMeasure_Flow1.WorkStation2.SetCamera(Global.m_dicCameraS.GetCamera(0, 1));


            //设置相机开始取图，改变状态
            Global.m_dicCameraS.SetCameraState(0, 0, Camera.CameraState.Photo);
            Global.m_dicCameraS.SetCameraState(0, 1, Camera.CameraState.Photo);


            
            //------------------------------------------------------------------------------------

            
           
            


        }
        //1号通道，停止
        private void bt_Flow_First_Stop_Click(object sender, RoutedEventArgs e)
        {
          

            SwitchCameraState(0, 0, Camera.CameraState.Standby);
            SwitchCameraState(0, 1, Camera.CameraState.Standby);



        }




        //2号通道，开始
        private void bt_Flow_Second_Start_Click(object sender, RoutedEventArgs e)
        {
            string path = GetProgramSoftwareInfo().SaveAllImagePath;
            BatchMeasure_Flow2.WorkStation1.SetImageSavePath(path);

            NeededSetProductMessageAndSeralNumber(BatchMeasure_Flow2);

            BatchMeasure_Flow2.WorkStation1.StationState = PublicEnum.StationState.Show;


            BatchMeasure_Flow2.WorkStation2.SetImageSavePath(path);

            BatchMeasure_Flow2.WorkStation2.StationState = PublicEnum.StationState.Show;




            //设置相机开始取图，改变状态
            SwitchCameraState(1, 0, Camera.CameraState.Photo);
            SwitchCameraState(1, 1, Camera.CameraState.Photo);
 
        }
        //2号通道，停止
        private void bt_Flow_Second_Stop_Click(object sender, RoutedEventArgs e)
        {
            SwitchCameraState(1, 0, Camera.CameraState.Standby);
            SwitchCameraState(1, 1, Camera.CameraState.Standby);

        }



        //3号通道，开始
        private void bt_Flow_Third_Start_Click(object sender, RoutedEventArgs e)
        {

            string path = GetProgramSoftwareInfo().SaveAllImagePath;
            BatchMeasure_Flow3.WorkStation1.SetImageSavePath(path);

            BatchMeasure_Flow3.WorkStation1.StationState = PublicEnum.StationState.Show;


            BatchMeasure_Flow3.WorkStation2.SetImageSavePath(path);

            BatchMeasure_Flow3.WorkStation2.StationState = PublicEnum.StationState.Show;




            //设置相机开始取图，改变状态
            SwitchCameraState(2, 0, Camera.CameraState.Photo);
            SwitchCameraState(2, 1, Camera.CameraState.Photo);

        }
        //3号通道，停止
        private void bt_Flow_Third_Stop_Click(object sender, RoutedEventArgs e)
        {
            SwitchCameraState(2, 0, Camera.CameraState.Standby);
            SwitchCameraState(2, 1, Camera.CameraState.Standby);
   
        }


        #endregion



        //设置参数
        private void btSetParas_Click(object sender, RoutedEventArgs e)
        {
            SystemInfoWindow formss = new SystemInfoWindow();
            formss.ShowDialog();
        }

       





        //获得系统参数的单例
        private SoftwareInfo GetProgramSoftwareInfo()
        {
            return SoftwareInfo.getInstance();
        }

        





        //插入一条数据
        public void InsertRunningInfo(RunningStatusInfo info)
        {
            RunningStatusInfoList.Insert(0, info);
        }


        //改变相机的状态
        private void SwitchCameraState(int chanlNo,int station,Camera.CameraState cameraState)
        {
            Global.m_dicCameraS.SetCameraState(chanlNo, station, cameraState);
        }


        private void SetCameraViewWithCamera()
        {
            BatchMeasure_Flow1.WorkStation1.SetCamera(Global.m_dicCameraS.GetCamera(0, 0));
            BatchMeasure_Flow1.WorkStation2.SetCamera(Global.m_dicCameraS.GetCamera(0, 1));
            BatchMeasure_Flow1.WorkStation1.InsertInfo = InsertRunningInfo;
            BatchMeasure_Flow1.WorkStation2.InsertInfo = InsertRunningInfo;

            BatchMeasure_Flow2.WorkStation1.SetCamera(Global.m_dicCameraS.GetCamera(1, 0));
            BatchMeasure_Flow2.WorkStation2.SetCamera(Global.m_dicCameraS.GetCamera(1, 1));
            BatchMeasure_Flow2.WorkStation1.InsertInfo = InsertRunningInfo;
            BatchMeasure_Flow2.WorkStation2.InsertInfo = InsertRunningInfo;

            BatchMeasure_Flow3.WorkStation1.SetCamera(Global.m_dicCameraS.GetCamera(2, 0));
            BatchMeasure_Flow3.WorkStation2.SetCamera(Global.m_dicCameraS.GetCamera(2, 1));
            BatchMeasure_Flow3.WorkStation1.InsertInfo = InsertRunningInfo;
            BatchMeasure_Flow3.WorkStation2.InsertInfo = InsertRunningInfo;
        }

        

        private void tabControl_Main_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            tabControl_Child.SelectedIndex = tabControl_Main.SelectedIndex;
        }

        private void tabControl_Child_SelectionChanged(object sender, System.Windows.Controls.SelectionChangedEventArgs e)
        {
            tabControl_Main.SelectedIndex = tabControl_Child.SelectedIndex; 
        }


        //添加对应的产品型号
        private void NeededSetProductMessageAndSeralNumber(UserMeasureControl customerUserControll)
        {
            if (string.IsNullOrWhiteSpace(customerUserControll.Product_Type))
            {
                MessageBox.Show("请添加产品型号");
            }

            if (string.IsNullOrWhiteSpace(customerUserControll.Product_Serial_Number))
            {
                MessageBox.Show("请添加流水号");
            }
        }
    }
}
