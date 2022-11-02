using System;
using System.Diagnostics;
using Microsoft.Maui.Controls;

namespace TimeCopyIconMaui.Extends
{
    public static class EntryExtend
    {
        public static void SetTextSafe(this Entry entry, string text1)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                Debug.WriteLine($"setToText call  length={text1.Length}");
                entry.Text = text1;
                Debug.WriteLine($"setToText done  length={text1.Length}");
            });
        }
        public static void SetTextSafe(this Label entry, string text1)
        {
            MainThread.BeginInvokeOnMainThread(() => {
                Debug.WriteLine($"setToText call  length={text1.Length}");
                entry.Text = text1;
                Debug.WriteLine($"setToText done  length={text1.Length}");
            });
        }
    }
}

