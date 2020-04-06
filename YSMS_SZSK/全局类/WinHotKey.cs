using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Interop;
using System.Collections;
using System.Runtime.InteropServices;

namespace YSMS_130Standard
{
    class HotKey
    {
        int KeyId;
        IntPtr Handle;
        Window window;
        uint Controlkey;
        uint Key;

        public delegate void  OnHotkeyEventHandeler(int  o);
        //public event OnHotkeyEventHandeler myevent;

        public event OnHotkeyEventHandeler OnHotKey = null;
        public  static Hashtable KeyPair = new Hashtable();
        private const int WM_HOTKEY = 0x0312;
        public enum KeyFlags
        {
            MOD_NONE = 0x0,
            MOD_ALT = 0x1,
            MOD_CONTROL = 0x2,
            MOD_SHIFT = 0x4,
            MOD_WIN = 0x8,

        }

        public HotKey(Window win, HotKey.KeyFlags control, Keys key)
        {
           
            Handle = new WindowInteropHelper(win).Handle;
            window = win;

            Controlkey = (uint)control;
            Key = (uint)key;
            KeyId = (int)Controlkey + (int)Key * 10;

                
            if (HotKey.KeyPair.ContainsKey(KeyId))
            {
                        
                throw new Exception("AlreadyRegisterd");

            }

                   
            if (false == HotKey.RegisterHotKey(Handle, KeyId, Controlkey, Key))
            {
                        
                throw new Exception("RegisterFailed!");
            }


            if (HotKey.KeyPair.Count == 0)
            {
                if (false == InstallHotKeyHook(this))
                {
                            
                    throw new Exception("HookFailed!");
                }
            }

            HotKey.KeyPair.Add(KeyId, this);
                
            
        }

        public static void Unregister(IntPtr Handle, HotKey.KeyFlags control, Keys key)
        {
            // IntPtr handle = new WindowInteropHelper(this).Handle;

            uint Controlkey1 = (uint)control;
            uint Key = (uint)key;
            int KeyId = (int)Controlkey1 + (int)Key * 10;
            HotKey.UnregisterHotKey(Handle, KeyId);
        }

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool RegisterHotKey(IntPtr hWnd, int id, uint controlKey, uint virtualKey);

        [DllImport("user32", CharSet = CharSet.Ansi, SetLastError = true, ExactSpelling = true)]
        private static extern bool UnregisterHotKey(IntPtr hWnd, int id);

        [DllImport("kernel32", SetLastError = true)]
        public static extern short GlobalAddAtom(string lpString);

        static private bool InstallHotKeyHook(HotKey hk)
        {
            if (hk.window == null || hk.Handle == IntPtr.Zero)
                return false;

            HwndSource source = HwndSource.FromHwnd(hk.Handle) as HwndSource;

            if (source == null)
                return false;

            source.AddHook(HotKey.HotKeyHook);

            return true;
        }

        static private IntPtr HotKeyHook(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {
            if (msg == WM_HOTKEY)
            {
                HotKey hk = (HotKey)HotKey.KeyPair[(int)wParam];
                if (hk.OnHotKey != null)
                    hk.OnHotKey(wParam.ToInt32 ());
            }

            return IntPtr.Zero;
        }

        ~HotKey()
        {
            HotKey.UnregisterHotKey(Handle, KeyId);
        }
    }
}
