using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using YSMS_SZSK.Basic.PublicClass;
using YSMS_SZSK.MessagePrompt;

namespace YSMS_SZSK.CustomerGlobal
{
    public static class StaticPublicFunction
    {
       
        /// <summary>
        /// Kill 当前进程  
        /// </summary>
        /// ludc  2015-07-21 
        public static void KillCurrentProcess()
        {

            try
            {
                //获取当前进程
                System.Diagnostics.Process currentProcess = System.Diagnostics.Process.GetCurrentProcess();

                //kill 当前进程
                currentProcess.Kill();
            }
            catch
            {

            }
        }

      


    }
}
