using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace TimeCopyIconMaui.Extends
{
    public static class EntryExtend
    {

        private static void SafeInvokeInMainThread(Action action)
        {
            if (DeviceInfo.Platform == DevicePlatform.WinUI)
            {
                Application.Current.Dispatcher.Dispatch(action);
            }
            else
            {
                MainThread.BeginInvokeOnMainThread(action);
            }
        }

        public static void SetTextSafe(this Button entry, string text1)
        {
            if (!MainThread.IsMainThread)
            {
                SafeInvokeInMainThread(() => {
                    Debug.WriteLine($"setToText call  length={text1.Length}");
                    entry.Text = text1;
                    Debug.WriteLine($"setToText done  length={text1.Length}");
                });
            }
            else
            {
                Debug.WriteLine($"setToText call  length={text1.Length}");
                entry.Text = text1;
                Debug.WriteLine($"setToText done  length={text1.Length}");
            }
      
        }
        public static void SetTextSafe(this Entry entry, string text1)
        {
            if (!MainThread.IsMainThread)
            {
                SafeInvokeInMainThread(() => {
                    Debug.WriteLine($"setToText call  length={text1.Length}");
                    entry.Text = text1;
                    Debug.WriteLine($"setToText done  length={text1.Length}");
                });
            }
            else
            {
                Debug.WriteLine($"setToText call  length={text1.Length}");
                entry.Text = text1;
                Debug.WriteLine($"setToText done  length={text1.Length}");
            }

        }
        public static void SetTextSafe(this Label entry, string text1)
        {
            if (!MainThread.IsMainThread)
            {
                SafeInvokeInMainThread(() => {
                    Debug.WriteLine($"setToText call  length={text1.Length}");
                    entry.Text = text1;
                    Debug.WriteLine($"setToText done  length={text1.Length}");
                });
            }
            else
            {
                Debug.WriteLine($"setToText call  length={text1.Length}");
                entry.Text = text1;
                Debug.WriteLine($"setToText done  length={text1.Length}");
            }

        }
    }
}

