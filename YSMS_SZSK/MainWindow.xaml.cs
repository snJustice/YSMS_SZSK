using System.Windows;
using YSMS_SZSK.Lib.CustomerCamera;
using HalconDotNet;

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
            CameraParas paras = new CameraParas();
           
           

            Camera camera = new Camera(paras);
            camera.HWindowCont = HalconWindow;
            camera.OpenCamera();

        }
    }
}
