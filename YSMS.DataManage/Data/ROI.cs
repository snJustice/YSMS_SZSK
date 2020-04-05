using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    [Serializable]
    public class ROI : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion


        public ROI()
        {
           Height = ProductSet.getInstance().ROIHeight;
           Width = ProductSet.getInstance().ROIWidth;
        }
        /// <summary>
        /// X向中心偏移
        /// </summary>
        private int m_OffCenters_X;
        public int OffCenters_X
        {
            get { return m_OffCenters_X; }
            set
            {
                m_OffCenters_X = value;
                OnPropertyChanged("OffCenters_X");
            }
        }

        /// <summary>
        /// Y向中心偏移
        /// </summary>
        private int m_OffCenters_Y;
        public int OffCenters_Y
        {
            get { return m_OffCenters_Y; }
            set
            {
                m_OffCenters_Y = value;
                OnPropertyChanged("OffCenters_Y");
            }
        }

        /// <summary>
        /// 高度
        /// </summary>
        private int m_Height;
        public int Height
        {

            get { return m_Height; }
            set
            {
                m_Height = value;
                OnPropertyChanged("Height");
            }
        }
        /// <summary>
        /// 宽度
        /// </summary>
        private int m_Width;
        public int Width
        {

            get { return m_Width; }
            set
            {
                m_Width = value;
                OnPropertyChanged("Width");
            }
        }

        /// <summary>
        /// 灰度边界  Qiyi Li 20200320
        /// </summary>
        private int m_Bondary;
        public int Bondary
        {

            get { return m_Bondary; }
            set
            {
                m_Bondary = value;
                OnPropertyChanged("Bondary");
            }
        }

        /// <summary>
        /// 检测区域列表
        /// </summary>
        public ObservableCollection<HRect> HRectList = new ObservableCollection<HRect>();

        public void Copy(ROI detectionArea)
        {
            this.Height = detectionArea.Height;
            this.Width = detectionArea.Width;
            this.OffCenters_X = detectionArea.OffCenters_X;
            this.OffCenters_Y = detectionArea.OffCenters_Y;
            this.HRectList.Clear();
            foreach (HRect item in detectionArea.HRectList)
            {
                this.HRectList.Add(new HRect()
                {
                    Column = item.Column,
                    Id = item.Id,
                    IsSelected = item.IsSelected,
                    IsVisable = item.IsVisable,
                    Length1 = item.Length1,
                    Length2 = item.Length2,
                    Phi = item.Phi,
                    RectName = item.RectName,
                    Row = item.Row,
                    Type =item .Type 
                });
            }
         
        }
    }
}
