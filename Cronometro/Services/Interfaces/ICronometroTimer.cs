namespace Services.Interfaces
{
    public interface ICronometroTimer
    {
        string Value { get; }

        void Start();

        void Pause();

        void Stop();

        void AddSecond();

        void InitializeCurrentSecond(int seconds);
    }
}