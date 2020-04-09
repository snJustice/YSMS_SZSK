using System.Linq;
using System.Windows;

using HalconDotNet;
using YSMS.DataManage;
using YSMS_130Standard;
using YSMS_SZSK.Lib;
using YSMS_SZSK.Utils.Communication.TCP_Client.DSocket;
using YSMS_SZSK.参数设置;

namespace YSMS_SZSK
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {




        public MainWindow()
        {
            InitializeComponent();
        }

        private void Btn_Test_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("dasd");
        }


        public void UpdateImageGrayValue(Point point)
        {

        }

        public void ShowSlectedMeasureElementInfo()
        {

        }

        private void btn_Learning_Click(object sender, RoutedEventArgs e)
        {
            

        }






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



        }

        



        /// <summary>
        /// 对话框关闭
        /// 2020-4-06-zhouyin，释放相机资源
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }





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

        private void RunningInfoGrid_MouseDoubleClick(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {

        }

        private void RunningInfoGrid_IsChecked(object sender, RoutedEventArgs e)
        {

        }

        private void btSetParas_Click(object sender, RoutedEventArgs e)
        {
            SystemInfoWindow formss = new SystemInfoWindow();
            formss.ShowDialog();
        }

        private void bt_Flow_First_Start_Click(object sender, RoutedEventArgs e)
        {
            
        }






        private SoftwareInfo GetProgramSoftwareInfo()
        {
            return SoftwareInfo.getInstance();
        }
    }
}
