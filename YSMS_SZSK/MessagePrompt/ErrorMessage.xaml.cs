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
    /// ErrorMessage.xaml 的交互逻辑
    /// </summary>
    public partial class ErrorMessage : UserControl
    {
        public MyMessageBox m_fatherInstance;

        public ErrorMessage()
        {
            InitializeComponent();
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            
            richTextBox_Discribe.Document.Blocks.Clear();
            richTextBox_Analysis.Document.Blocks.Clear();
            richTextBox_Solution.Document.Blocks.Clear();
            this.Visibility = System.Windows.Visibility.Hidden;
            m_fatherInstance.Hide();
            m_fatherInstance.MessageInfoInit();
        }

        public void ShowInfo(int errorNumber, string errorDescribe, string errorAnalysis, string errorSolution)
        {
            this.Visibility = System.Windows.Visibility.Visible;

            label_ErrorNumber.Content = errorNumber.ToString();

            FlowDocument doc1 = new FlowDocument();
            Paragraph p1 = new Paragraph();
            Run r1 = new Run(errorDescribe);
            p1.Inlines.Add(r1);
            doc1.Blocks.Add(p1);
            richTextBox_Discribe.Document = doc1;

            FlowDocument doc2 = new FlowDocument();
            Paragraph p2 = new Paragraph();
            Run r2 = new Run(errorAnalysis);
            p2.Inlines.Add(r2);
            doc2.Blocks.Add(p2);
            richTextBox_Analysis.Document = doc2;

            FlowDocument doc3 = new FlowDocument();
            Paragraph p3 = new Paragraph();
            Run r3 = new Run(errorSolution);
            p3.Inlines.Add(r3);
            doc3.Blocks.Add(p3);
            richTextBox_Solution.Document = doc3;

            m_fatherInstance.Title = "异 常";
            m_fatherInstance.ShowDialog();
        }
    }
}
