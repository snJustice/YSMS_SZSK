using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections.ObjectModel;

namespace YSMS.DataManage
{
    [Serializable]
    public class LocationArea
    {
        public LocationArea() { }
        /// <summary>
        /// 定位区域列表
        /// </summary>
        public ObservableCollection<HRect> HRectList = new ObservableCollection<HRect>();

        public void Copy(LocationArea locationArea)
        {
            this.HRectList.Clear();
            foreach (var item in locationArea.HRectList)
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
