using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CommunityToolkit.Maui.Alerts;
using CommunityToolkit.Maui.Core;

namespace TimeCopyIconMaui.Utility
{
    public static class NotifyHelper
    {
        public async static Task Notify(string title, string text)
        {
            // https://learn.microsoft.com/ja-jp/dotnet/communitytoolkit/maui/alerts/toast

            CancellationTokenSource cancellationTokenSource = new CancellationTokenSource();

            ToastDuration duration = ToastDuration.Short;
            double fontSize = 14;

            var message = $"{title}\n{text}";

            var toast = Toast.Make(message, duration, fontSize);

            await toast.Show(cancellationTokenSource.Token);

        }
    }
}
