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

namespace YSMS_SZSK.ImageDrawing
{
    /// <summary>
    /// SelectWindow.xaml 的交互逻辑
    /// </summary>
    public partial class SelectWindow : Window
    {
        private DrawingCanvas myDrawCanvas;

        public SelectWindow(DrawingCanvas drawCanvas, List<string> nameList)
        {
            InitializeComponent();
            myDrawCanvas = drawCanvas;
            NamelistBox.Items.Clear();
            foreach (var v in nameList)
            {
                NamelistBox.Items.Add(v);
            }
        }

        private void NamelistBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            myDrawCanvas.selectionIndex = NamelistBox.SelectedIndex;
            this.DialogResult = true;
            Close();
        }
    }
}
