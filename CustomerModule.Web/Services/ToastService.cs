using System;
using System.Timers;

namespace CustomerModule.Web.Services
{
    public enum ToastLevel
    {
        Info,
        Success,
        Warning,
        Error
    }

    public class ToastService : IDisposable
    {
        public event Action<string, ToastLevel>? OnShow;
        public event Action? OnHide;
        private Timer? Countdown;

        public void ShowToast(string message, ToastLevel level)
        {
            OnShow?.Invoke(message, level);
            StartCountdown();
        }

        private void StartCountdown()
        {
            SetCountdown();

            if (Countdown!.Enabled)
            {
                Countdown.Stop();
                Countdown.Start();
            }
            else
            {
                Countdown!.Start();
            }
        }

        private void SetCountdown()
        {
            if (Countdown != null) return;

            Countdown = new Timer(5000);
            Countdown.Elapsed += HideToast;
            Countdown.AutoReset = false;
        }

        private void HideToast(object? source, ElapsedEventArgs args)
            => OnHide?.Invoke();

        public void Dispose()
        {
            if (Countdown != null)
            {
                Countdown.Elapsed -= HideToast;
                Countdown.Dispose();
            }
        }

        public void ShowInfo(string message)
            => ShowToast(message, ToastLevel.Info);

        public void ShowSuccess(string message)
            => ShowToast(message, ToastLevel.Success);

        public void ShowWarning(string message)
            => ShowToast(message, ToastLevel.Warning);

        public void ShowError(string message)
            => ShowToast(message, ToastLevel.Error);
    }
}
