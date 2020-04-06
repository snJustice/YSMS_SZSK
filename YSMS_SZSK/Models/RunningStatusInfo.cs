
//model,用于保存展示的数据，这里可以用automapper，看情况


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace YSMS_SZSK.Models
{
    public class RunningStatusInfo : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged Members

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (null != PropertyChanged)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        /// <summary>
        /// 时间
        /// </summary>
        public string Time { get; set; }

        /// <summary>
        /// 状态
        /// </summary>
        public string State { get; set; }

        /// <summary>
        /// 通道号
        /// </summary>
        public string Channel { get; set; }

        /// <summary>
        /// 工位号
        /// </summary>
        public string Station { get; set; }

        /// <summary>
        /// 说明
        /// </summary>
        public string Explain { get; set; }

        /// <summary>
        /// 异常信息存档确认
        /// </summary>
        private bool isConfirm;
        public bool IsConfirm
        {
            get { return isConfirm; }
            set
            {
                isConfirm = value;
                OnPropertyChanged("IsConfirm");
            }
        }

        /// <summary>
        /// 是否显示checkbox  20200320 Qiyi Li
        /// </summary>
        public string CheckboxVisible { get; set; }


        /// <summary>
        /// 图片路径
        /// </summary>
        public string ImagePath { get; set; }

        public double CodeValue { get; set; }

        public string DefectNames { get; set; }

        public string Postion { get; set; }

        public bool IsInfoWritten { get; set; }

        public void Copy(RunningStatusInfo item)
        {
            this.Time = item.Time;
            this.State = item.State;
            this.Channel = item.Channel;
            this.Station = item.Station;
            this.Explain = item.Explain;
            this.IsConfirm = item.IsConfirm;
            this.ImagePath = item.ImagePath;
            this.CodeValue = item.CodeValue;
            this.DefectNames = item.DefectNames;
            this.Postion = item.Postion;
            this.IsInfoWritten = item.IsInfoWritten;
        }

        public RunningStatusInfo()
        {
            IsConfirm = false;
            IsInfoWritten = false;
        }
    }
}
