using Services.Interfaces;
using System;
using System.Windows.Threading;

namespace Cronometro.Services
{
    public class CronometroTimer : DispatcherTimer, ICronometroTimer
    {
        public int CurrentSecond { private get; set; }

        private CronometroTimer()
        {
            InitializeCurrentSecond();
        }
       
        private void InitializeCurrentSecond()
        {
            InitializeCurrentSecond(0);
        }

        public void InitializeCurrentSecond(int seconds)
        {
            CurrentSecond = seconds;
        }

        public string Value
        {
            get
            {
                CurrentSecond = RemoveIncrementDay(CurrentSecond);
                return TimeSpan.FromSeconds(CurrentSecond).ToString();
            }
        }

        public static CronometroTimer Create(EventHandler eventHandler)
        {
            const int secondsInterval = 1;
            var cronometro = new CronometroTimer();

            cronometro.Interval = TimeSpan.FromSeconds(secondsInterval);
            cronometro.Tick += eventHandler;

            return cronometro;
        }

        public void AddSecond()
        {
            CurrentSecond++;
        }
        
        public new void Start()
        {
            base.Start();
        }

        public void Pause()
        {
            base.Stop();
        }

        public new void Stop()
        {
            base.Stop();
            InitializeCurrentSecond(0);
        }

        private static int RemoveIncrementDay(int seconds)
        {
            const int secondsDay = 86400; // 60s*60m*24h
            return seconds >= secondsDay ? seconds - secondsDay : seconds;
        }

       
    }
}