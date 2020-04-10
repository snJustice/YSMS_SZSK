using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using YSMS.DataManage;

namespace YSMS_SZSK.Utils
{
    public static class Tools
    {
        public static string GetNewName(string prefix, List<string> OldNameList)
        {
            string newName = string.Empty;
            int newNum = OldNameList.Count;
            for (int i = 0; i < OldNameList.Count; i++)
            {
                if (!OldNameList.Contains(prefix + newNum))
                {
                    newName = prefix + newNum;
                    break;
                }
                else
                {
                    newNum++;
                }
            }
            return newName;
        }

        #region 使用 windows自带程序 浏览图片
        public static void ShowImage_shimgvw(string imageName)
        {
            //判断图片是否存在
            if (!System.IO.File.Exists(imageName))
            {
                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["Picture does not exist!"].ToString());

                //if (SoftwareInfo.getInstance().Language == "English")
                //{
                //    MessageBox.Show("Picture does not exist! ");
                //}
                //else
                //{
                //    MessageBox.Show("图片不存在！");
                //}

                return;
            }

            try
            {
                //路径 window 下是   \
                imageName = imageName.Replace("//", "\\").Replace("/", "\\");
                System.Diagnostics.Process.Start
                    (
                        "rundll32.exe",
                        string.Format("{0} {1}", "shimgvw.dll,ImageView_Fullscreen", imageName)
                    );
            }
            catch (Exception ex)
            {

                MessageBox.Show(Application.Current.Resources.MergedDictionaries.First()["access denied :"].ToString());

                //if (SoftwareInfo.getInstance().Language == "English")
                //{
                //    MessageBox.Show("Access denied: " + imageName + "");
                //}
                //else
                //{
                //    MessageBox.Show("拒绝访问: " + imageName + "");
                //}                
                SoftwareInfo.getInstance().WriteLog("ShowImage_shimgvw拒绝访问:\n " + imageName + "\n" + ex.ToString());
            }

        }


        #endregion

        #region 拷贝目录和文件
        public static void copyDirectory(string sourceDirectory, string destDirectory)
        {
            //判断源目录和目标目录是否存在，如果不存在，则创建一个目录
            if (!Directory.Exists(sourceDirectory))
            {
                Directory.CreateDirectory(sourceDirectory);
            }
            if (!Directory.Exists(destDirectory))
            {
                Directory.CreateDirectory(destDirectory);
            }
            //拷贝文件
            copyFile(sourceDirectory, destDirectory);

            //拷贝子目录       
            //获取所有子目录名称
            string[] directionName = Directory.GetDirectories(sourceDirectory);

            foreach (string directionPath in directionName)
            {
                //根据每个子目录名称生成对应的目标子目录名称
                string directionPathTemp = destDirectory + "\\" + directionPath.Substring(sourceDirectory.Length + 1);

                //递归下去
                copyDirectory(directionPath, directionPathTemp);
            }
        }
        public static void copyFile(string sourceDirectory, string destDirectory)
        {
            //获取所有文件名称
            string[] fileName = Directory.GetFiles(sourceDirectory);

            foreach (string filePath in fileName)
            {
                //根据每个文件名称生成对应的目标文件名称
                string filePathTemp = destDirectory + "\\" + filePath.Substring(sourceDirectory.Length + 1);

                //若不存在，直接复制文件；若存在，覆盖复制
                if (File.Exists(filePathTemp))
                {
                    File.Copy(filePath, filePathTemp, true);
                }
                else
                {
                    try
                    {
                        File.Copy(filePath, filePathTemp);
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message.ToString(), Application.Current.Resources.MergedDictionaries.First()["System prompt"].ToString());
                        //if (SoftwareInfo.getInstance().Language == "English")
                        //{
                        //    MessageBox.Show(ex.Message.ToString(), "System prompt");
                        //}
                        //else
                        //{
                        //    MessageBox.Show(ex.Message.ToString(), "系统提示");
                        //}

                        SoftwareInfo.getInstance().WriteLog("copyFile:\n" + ex.ToString());
                    }
                }
            }
        }
        #endregion

        #region 获取磁盘空间大小
        public static long GetHardDiskSpace(string str_HardDiskName)
        {
            long totalSize = new long();
            str_HardDiskName = str_HardDiskName + ":\\";
            System.IO.DriveInfo[] drives = System.IO.DriveInfo.GetDrives();
            foreach (System.IO.DriveInfo drive in drives)
            {
                if (drive.Name == str_HardDiskName)
                {
                    totalSize = drive.TotalSize / (1024 * 1024 * 1024);
                }
            }
            return totalSize;
        }
        #endregion

        #region string byte 转换

        /// <summary>
        /// Byte转String
        /// </summary>
        /// <param name="InBytes"></param>
        /// <returns></returns>
        public static string ByteToString(byte[] InBytes)
        {
            string StringOut = "";
            foreach (byte InByte in InBytes)
            {
                StringOut = StringOut + String.Format("{0:X2} ", InByte);
            }
            return StringOut;
        }

        /// <summary>
        /// String转Byte
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static byte[] StringToByte(string InString)
        {
            //string[] ByteStrings;
            //ByteStrings = InString.Split(" ".ToCharArray());
            byte[] ByteOut;
            int count = InString.Length / 2;
            ByteOut = new byte[count];
            for (int i = 0; i < count; i++)
            {
                ByteOut[i] = Convert.ToByte(InString.Substring(2 * i, 2), 16);
            }
            return ByteOut;
        }
        #endregion

        /// 指定字符串的固定长度，如果字符串小于固定长度，
        /// 则在字符串的前面补足零，可设置的固定长度最大为9位
        /// </summary>
        /// <param name="text">原始字符串</param>
        /// <param name="limitedLength">字符串的固定长度</param>
        public static string RepairZero(string text, int limitedLength)
        {
            //补足0的字符串
            string temp = "";

            //补足0
            for (int i = 0; i < limitedLength - text.Length; i++)
            {
                temp += "0";
            }

            //连接text
            temp += text;

            //返回补足0的字符串
            return temp;
        }

        /// <summary>
        /// 高地位转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HighLowChange8(string text)
        {
            string temp1 = text.Substring(0, 4);
            string temp2 = text.Substring(4, 4);
            return temp2 + temp1;
        }
        // baicx 20200330
        /// <summary>
        /// 高地位转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HighLowChange8_4_8(string text)
        {
            string temp1 = text.Substring(0, 2);
            string temp2 = text.Substring(2, 2);
            string temp3 = text.Substring(4, 2);
            string temp4 = text.Substring(6, 2);

            return temp4 + temp3 + temp2 + temp1;
        }
        /// <summary>
        /// 高地位转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HighLowChange8_4(string text)
        {
            string temp1 = text.Substring(0, 2);
            string temp2 = text.Substring(2, 2);
            string temp3 = text.Substring(4, 2);
            string temp4 = text.Substring(6, 2);

            return temp2 + temp1 + temp4 + temp3;
        }
        /// <summary>
        /// 高地位转换
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public static string HighLowChange4(string text)
        {
            string temp1 = text.Substring(0, 2);
            string temp2 = text.Substring(2, 2);
            return temp2 + temp1;
        }

        /// <summary>
        /// 获取多语言配置文件的值
        /// </summary>
        /// <param name="key"></param>
        /// <returns></returns>
        public static string GetMessageText(string key)
        {
            try
            {
                return Application.Current.Resources.MergedDictionaries[0][key].ToString();
            }
            catch (Exception ex)
            {
                string erStr = key + ":" + Application.Current.Resources.MergedDictionaries[0]["StringKeyNotExist"].ToString();

                throw new FormatException(ex.Message + erStr);
            }

        }
    }
}
