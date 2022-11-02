using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TimeCopyIconMaui.Utility
{
    public static class TimeUtility
    {

        public static string getUnixTimeStr(DateTimeOffset dto)
        {
            return dto.ToUnixTimeSeconds().ToString();
        }

        public static string getYmd1Str(DateTimeOffset dto)
        {
            return dto.LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");
        }

        public static string getYmd2Str(DateTimeOffset dto)
        {
            return dto.LocalDateTime.ToString("yyyyMMddHHmmss");
        }

        public static async Task<string> CopyUnixtime_Click(object sender, EventArgs e)
        {
            var data = getUnixTimeStr(DateTimeOffset.Now);
            await Clipboard.SetTextAsync(data);
            await NotifyHelper.Notify("現在時刻 unixtime", $"{data} をコピーしました");
            return $"{data} をコピーしました";
        }

        public static async Task<string> CopyYmd1_Click(object sender, EventArgs e)
        {
            var data = getYmd1Str(DateTimeOffset.Now);
            await Clipboard.SetTextAsync(data);
            await NotifyHelper.Notify("現在時刻 Y/m/d H:i:s", $"{data} をコピーしました");
            return $"{data} をコピーしました";
        }

        public static async Task<string> CopyYmd2_Click(object sender, EventArgs e)
        {
            var data = getYmd2Str(DateTimeOffset.Now);
            await Clipboard.SetTextAsync(data);
            await NotifyHelper.Notify("現在時刻 YmdHis", $"{data} をコピーしました");
            return $"{data} をコピーしました";
        }

        

    }
}
