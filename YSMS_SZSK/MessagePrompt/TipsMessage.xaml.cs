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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace YSMS_SZSK.MessagePrompt
{
    /// <summary>
    /// TipsMessage.xaml 的交互逻辑
    /// </summary>
    public partial class TipsMessage : UserControl
    {
        public MyMessageBox m_fatherInstance;

        public TipsMessage()
        {
            InitializeComponent();
        }

        public void ShowInfo(string info)
        {
            FlowDocument doc1 = new FlowDocument();
            Paragraph p1 = new Paragraph();
            Run r1 = new Run(info);
            p1.Inlines.Add(r1);
            doc1.Blocks.Add(p1);
            richTextBox_Info.Document = doc1;

            m_fatherInstance.Title = "提 示";
            m_fatherInstance.ShowDialog();
        }

        private void btn_Confrim_Click(object sender, RoutedEventArgs e)
        {
            richTextBox_Info.Document.Blocks.Clear();
            this.Visibility = System.Windows.Visibility.Hidden;
            m_fatherInstance.Hide();
            m_fatherInstance.MessageInfoInit();
        }

    }
}
