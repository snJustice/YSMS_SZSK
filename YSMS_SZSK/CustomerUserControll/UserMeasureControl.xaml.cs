using System.Windows.Controls;

namespace YSMS_SZSK.CustomerUserControll
{
    /// <summary>
    /// UserMeasureControl.xaml 的交互逻辑
    /// </summary>
    public partial class UserMeasureControl : UserControl
    {
        public UserMeasureControl()
        {
            InitializeComponent();
            
            

        }

        public string StationMessage { set { lbl_Number.Content = value; } get { return lbl_Number.Content.ToString(); } }

        public string Product_Type { set { txtbox_Product_Type.Text = value; } get { return txtbox_Product_Type.Text.ToString(); } }
        public string Product_Serial_Number { set { txtbox_Product_SerialNumber.Text = value; } get { return txtbox_Product_SerialNumber.Text.ToString(); } }
        


        public CameraViews WorkStation2 { get { return Work_Station2; } }

        public CameraViews WorkStation1 { get { return Work_Station1; } }
    }
}
