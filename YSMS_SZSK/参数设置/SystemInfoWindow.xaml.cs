using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YSMS.DataManage;
using YSMS_SZSK.Lib;

namespace YSMS_SZSK.参数设置
{
    /// <summary>
    /// SystemInfoWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SystemInfoWindow : Window
    {
        public SystemInfoWindow()
        {
            InitializeComponent();
            Load();
        }

        private void button_OK_Click(object sender, RoutedEventArgs e)
        {
            Save();
        }

        private void button_Cancel_Click(object sender, RoutedEventArgs e)
        {

        }

        private void checkbox_IsStartMark_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Save()
        {
            GetGlobalSoftwareInfo().Folw1IsSaveOkImage =(bool) checkBox_OK_Flow1.IsChecked;
            GetGlobalSoftwareInfo().Folw1IsSaveNGImage = (bool)checkBox_NG_Flow1.IsChecked;

            GetGlobalSoftwareInfo().Folw2IsSaveOkImage = (bool)checkBox_OK_Flow2.IsChecked;
            GetGlobalSoftwareInfo().Folw2IsSaveNGImage = (bool)checkBox_NG_Flow2.IsChecked;

            GetGlobalSoftwareInfo().Folw3IsSaveOkImage = (bool)checkBox_OK_Flow3.IsChecked;
            GetGlobalSoftwareInfo().Folw3IsSaveNGImage = (bool)checkBox_NG_Flow3.IsChecked;

            string exMessage = string.Empty;
            if(! (0==(GetGlobalSoftwareInfo().save(InfoPath.getInstance().SoftwareInfo, ref exMessage))))
            {
                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["Failed to save software parameters:"].ToString());
                return;
            }
            else
            {
                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["SoftwareInfo Save Successfully"].ToString());
            }
             
        }

        private void Load()
        {
            checkBox_OK_Flow1.IsChecked = GetGlobalSoftwareInfo().Folw1IsSaveOkImage;
            checkBox_NG_Flow1.IsChecked = GetGlobalSoftwareInfo().Folw1IsSaveNGImage;

            checkBox_OK_Flow2.IsChecked = GetGlobalSoftwareInfo().Folw2IsSaveOkImage;
            checkBox_NG_Flow2.IsChecked = GetGlobalSoftwareInfo().Folw2IsSaveNGImage;

            checkBox_OK_Flow3.IsChecked = GetGlobalSoftwareInfo().Folw3IsSaveOkImage;
            checkBox_NG_Flow3.IsChecked = GetGlobalSoftwareInfo().Folw3IsSaveNGImage;
        }

        private SoftwareInfo GetGlobalSoftwareInfo()
        {
            return SoftwareInfo.getInstance();
        }
    }
}
