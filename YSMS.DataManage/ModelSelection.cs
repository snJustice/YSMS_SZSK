using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel;

namespace YSMS.DataManage
{
    /// <summary>
    /// 模板选择信息
    /// </summary>
    public class ModelSelection : INotifyPropertyChanged
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

        private ModelSelection()
        {
            PhotoIndex = 0;
            HasModel1 = true;
            HasModel2 = false;
            HasModel3 = false;
            HasModel4 = false;
        }
        public ModelSelection(int photoIndex)
        {
            PhotoIndex = photoIndex;
            HasModel1 = true;
            HasModel2 = false;
            HasModel3 = false;
            HasModel4 = false;
        }

        private int m_PhotoIndex;
        /// <summary>
        /// 编号
        /// </summary>
        public int PhotoIndex
        {
            get
            {
                return m_PhotoIndex;
            }
            set
            {
                m_PhotoIndex = value;
                OnPropertyChanged("PhotoIndex");
            }
        }



        private bool m_HasModel1;
        /// <summary>
        /// 是否有模板1
        /// </summary>
        public bool HasModel1
        {
            get
            {
                return m_HasModel1;
            }
            set
            {
                m_HasModel1 = value;
                OnPropertyChanged("HasModel1");
            }
        }

        private bool m_HasModel2;
        /// <summary>
        /// 是否有模板2
        /// </summary>
        public bool HasModel2
        {
            get
            {
                return m_HasModel2;
            }
            set
            {
                m_HasModel2 = value;
                OnPropertyChanged("HasModel2");
            }
        }


        private bool m_HasModel3;
        /// <summary>
        /// 是否有模板3
        /// </summary>
        public bool HasModel3
        {
            get
            {
                return m_HasModel3;
            }
            set
            {
                m_HasModel3 = value;
                OnPropertyChanged("HasModel3");
            }
        }

        private bool m_HasModel4;
        /// <summary>
        /// 是否有模板3
        /// </summary>
        public bool HasModel4
        {
            get
            {
                return m_HasModel4;
            }
            set
            {
                m_HasModel4 = value;
                OnPropertyChanged("HasModel4");
            }
        }

        public void copy(ModelSelection ms)
        {
            this.PhotoIndex = ms.PhotoIndex;
            this.HasModel1 = ms.HasModel1;
            this.HasModel2 = ms.HasModel2;
            this.HasModel3 = ms.HasModel3;
            this.HasModel4 = ms.HasModel4;
        }
    }
}
