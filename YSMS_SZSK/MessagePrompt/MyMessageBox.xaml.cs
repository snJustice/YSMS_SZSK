using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using YSMS_SZSK.CustomerGlobal;

namespace YSMS_SZSK.MessagePrompt
{
    /// <summary>
    /// MyMessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MyMessageBox : Window
    {
        private static readonly MyMessageBox instance = new MyMessageBox();

        private const int GWL_STYLE = -16;
        private const int WS_SYSMENU = 0x80000;
        [DllImport("user32.dll", SetLastError = true)]
        private static extern int GetWindowLong(IntPtr hWnd, int nIndex);
        [DllImport("user32.dll")]
        private static extern int SetWindowLong(IntPtr hWnd, int nIndex, int dwNewLong);


        public ErrorMessage m_UC_ErrorMessage = new ErrorMessage();
        public QuestionMessage m_UC_QuestionMessage = new QuestionMessage();
        public TipsMessage m_UC_TipsMessage = new TipsMessage();

        /// <summary>
        /// 异常代号
        /// </summary>
        public int errorNumber = 0;

        /// <summary>
        /// 异常描述
        /// </summary>
        public string errorDescribe = "";

        /// <summary>
        /// 异常分析
        /// </summary>
        public string errorAnalysis = "";

        /// <summary>
        /// 异常解决方案
        /// </summary>
        public string errorSolution = "";

        /// <summary>
        /// 询问内容
        /// </summary>
        public string questionInfo = "";

        /// <summary>
        /// 提示内容
        /// </summary>
        public string tipsInfo = "";

        /// <summary>
        /// 0：默认 1：Yes -1：No
        /// </summary>
        public int chooseState = 0;


        private MyMessageBox()
        {
            InitializeComponent();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            var hwnd = new WindowInteropHelper(this).Handle;
            SetWindowLong(hwnd, GWL_STYLE, GetWindowLong(hwnd, GWL_STYLE) & ~WS_SYSMENU);

            SubWindowBody.Children.Add(m_UC_ErrorMessage);
            m_UC_ErrorMessage.Margin = new Thickness(0, 0, 0, 0);

            SubWindowBody.Children.Add(m_UC_QuestionMessage);
            m_UC_QuestionMessage.Margin = new Thickness(0, 0, 0, 0);

            SubWindowBody.Children.Add(m_UC_TipsMessage);
            m_UC_TipsMessage.Margin = new Thickness(0, 0, 0, 0);

        }

        public void ShowWindow(PublicEnum.MessageType messageType)
        {
            //MyProgressBar.close();
            switch (messageType)
            {
                case PublicEnum.MessageType.Error:
                    {
                        this.Height = 309;
                        this.Width = 460;
                        chooseState = 0;
                        m_UC_ErrorMessage.Visibility = Visibility.Visible;
                        m_UC_QuestionMessage.Visibility = Visibility.Hidden;
                        m_UC_TipsMessage.Visibility = Visibility.Hidden;

                        //是否显示错误提示
                        if (Global.m_isShowError)
                        {
                            m_UC_ErrorMessage.m_fatherInstance = this;
                            m_UC_ErrorMessage.ShowInfo(errorNumber, errorDescribe, errorAnalysis, errorSolution);
                        }

                        //拼接错误信息
                        string errorInfo = "\r\n错误号：" + errorNumber.ToString() + "\r\n";

                        if (errorDescribe != "")
                        {
                            errorInfo += "错误描述：" + errorDescribe + "\r\n";
                        }

                        if (errorAnalysis != "")
                        {
                            errorInfo += "错误分析：" + errorAnalysis + "\r\n";
                        }

                        if (errorSolution != "")
                        {
                            errorInfo += "解决方案：" + errorSolution + "\r\n";
                        }

                        Global.m_errorInfos.Add(errorInfo);

                        break;
                    }
                case PublicEnum.MessageType.Question:
                    {
                        this.Height = 130;
                        this.Width = this.Width / 1.43;
                        chooseState = 0;
                        m_UC_ErrorMessage.Visibility = Visibility.Hidden;
                        m_UC_QuestionMessage.Visibility = Visibility.Visible;
                        m_UC_TipsMessage.Visibility = Visibility.Hidden;

                        if (Global.m_isShowError)
                        {
                            m_UC_QuestionMessage.m_fatherInstance = this;
                            m_UC_QuestionMessage.ShowInfo(questionInfo);
                        }

                        this.Width = 460;

                        break;
                    }
                case PublicEnum.MessageType.Tips:
                    {
                        this.Height = 130;
                        this.Width = this.Width / 1.43;
                        chooseState = 0;
                        m_UC_ErrorMessage.Visibility = Visibility.Hidden;
                        m_UC_QuestionMessage.Visibility = Visibility.Hidden;
                        m_UC_TipsMessage.Visibility = Visibility.Visible;

                        if (Global.m_isShowError)
                        {
                            m_UC_TipsMessage.m_fatherInstance = this;
                            m_UC_TipsMessage.ShowInfo(tipsInfo);
                        }
                        this.Width = 460;


                        //拼接错误信息
                        Global.m_errorInfos.Add(tipsInfo + "\r\n");

                        break;
                    }
                default:
                    break;
            }
        }

        protected override void OnClosing(System.ComponentModel.CancelEventArgs e)
        {
            e.Cancel = true;
        }

        public static MyMessageBox GetInstance()
        {
            return instance;
        }

        public void MessageInfoInit()
        {
            errorNumber = 0;
            errorDescribe = "";
            errorAnalysis = "";
            errorSolution = "";
            questionInfo = "";
            tipsInfo = "";
        }





    }
}
