using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using TimeCopyIconMaui.Extends;
using TimeCopyIconMaui.Utility;

namespace TimeCopyIconMaui
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();

            //var now = DateTimeOffset.Now;
            //textBoxISO8601Example.SetTextSafe(now.ToString("yyyy-MM-ddTHH:mm:ss") + now.ToString("zzz").Replace(":", ""));

        }

        private async void GetUnixTimeBtn_Clicked(object sender, EventArgs e)
        {

            var text = await TimeUtility.CopyUnixtime_Click(sender, e);
            SemanticScreenReader.Announce(text);
            Debug.WriteLine("GetUnixTimeBtn_Clicked");
        }

        private async void GetDateTime2Btn_Clicked(object sender, EventArgs e)
        {
            var text = await TimeUtility.CopyYmd2_Click(sender, e);
            SemanticScreenReader.Announce(text);
            Debug.WriteLine("GetDateTime2Btn_Clicked");

        }

        private async void GetDateTimeBtn_Clicked(object sender, EventArgs e)
        {
            var text = await TimeUtility.CopyYmd1_Click(sender, e);
            SemanticScreenReader.Announce(text);

            Debug.WriteLine("GetDateTimeBtn_Clicked");
        }


        private async void FromUnixtime_Unfocused(object sender, FocusEventArgs e)
        {
            long unixT;
            string unixTimeText = await MainThread.InvokeOnMainThreadAsync<string>(() =>
            {
                return ((Entry)sender).Text.Trim();
            });
            //Tonixtime.CursorPosition = 0;
            //Tonixtime.SelectionLength = 0;

            if (!Regex.IsMatch(unixTimeText, @"^[0-9]+$"))
            {
                Tonixtime.SetTextSafe("");
                return;
            }

            if (long.TryParse(unixTimeText, out unixT))
            {
                Debug.WriteLine("TryParse ok");
                // ローカルタイム
                var result = UnixTimeToLocalDateString(unixT);

                Dispatcher.Dispatch(() =>
                {
                    Debug.WriteLine("Dispatch");
                    Tonixtime.SetTextSafe(result);
                    selectAllText();
                    Debug.WriteLine("DispatchDone");

                });
                Debug.WriteLine("TryParse done");

            }
            else
            {
                Tonixtime.SetTextSafe("");
            }

            SemanticScreenReader.Announce(Tonixtime.Text);
            Debug.WriteLine("FromUnixtime_Unfocused done");
        }
        private void FromUnixtime_Completed(object sender, EventArgs e)
        {
            FromUnixtime_Unfocused(sender, null);
            Debug.WriteLine("FromUnixtime_Completed");
        }

        private string UnixTimeToLocalDateString(long unixTime)
        {
            return DateTimeOffset.FromUnixTimeSeconds(unixTime).LocalDateTime.ToString("yyyy/MM/dd HH:mm:ss");

        }

        private void Tonixtime_Focused(object sender, FocusEventArgs e)
        {
            Debug.WriteLine("Tonixtime_Focused call");
            Entry entry = ((Entry)sender);
            if (entry.Text.Length == 0)
            {
                Debug.WriteLine("Tonixtime_Focused no length");
                return;
            }

            selectAllText();

            Debug.WriteLine($"Tonixtime_Focused length={entry.Text.Length}");
        }

        private void Tonixtime_TextChanged(object sender, TextChangedEventArgs e)
        {
            Debug.WriteLine("Tonixtime_TextChanged call");
            Entry entry = ((Entry)sender);
            if (entry.Text.Length == 0)
            {
                Debug.WriteLine("Tonixtime_TextChanged no length");
                return;
            }

            selectAllText();

            Debug.WriteLine($"Tonixtime_TextChanged done  length={entry.Text.Length}");
        }

        void textBoxFromISO8601_Unfocused(object sender, FocusEventArgs e)
        {
            Entry entry = ((Entry)sender);
            if (entry.Text.Length == 0)
            {
                Debug.WriteLine("Tonixtime_TextChanged no length");
                return;
            }

            string isoTest = entry.Text.Trim();

            DateTimeOffset dto;
            if (DateTimeOffset.TryParse(isoTest, out dto))
            {

                textBoxToUnixMessage.SetTextSafe("");
                textBoxISO8601ToUnixtime.SetTextSafe("");

                var unixTimeSeconds = dto.ToUnixTimeSeconds();
                textBoxISO8601ToUnixtime.SetTextSafe(unixTimeSeconds.ToString());
                //textBoxFromUnixtime.Text = unixTimeSeconds.ToString();
                //textBoxFromUnixtime_Leave(textBoxFromUnixtime, null);
                var dateStr = UnixTimeToLocalDateString(unixTimeSeconds);
                // ReSharper disable once LocalizableElement
                textBoxToUnixMessage.SetTextSafe(@"変換しました。日付けは" + "\r\n" + dateStr);

            }
            else
            {
                textBoxToUnixMessage.SetTextSafe(@"変換出来ませんでした");

                textBoxISO8601ToUnixtime.SetTextSafe("");
            }

        }




        private void selectAllText()
        {

            MainThread.BeginInvokeOnMainThread(() =>
            {
                var entry = Tonixtime;
                Debug.WriteLine($"selectAllText call  length={entry.Text?.Length}");
                entry.CursorPosition = 0;
                entry.SelectionLength = 0;
                entry.SelectionLength = entry.Text.Length;
                Debug.WriteLine($"selectAllText done  length={entry.Text?.Length}");
            });
        }

        void textBoxISO8601Example_Focused(System.Object sender, Microsoft.Maui.Controls.FocusEventArgs e)
        {
            //            Clipboard.SetText(chk.Text);

        }

    }
}