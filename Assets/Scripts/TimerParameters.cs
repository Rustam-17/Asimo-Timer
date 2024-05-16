using System;

public struct TimerParameters
{
    public string Title { get; set; }
    public bool IsPlay { get; set; }
    public TimeSpan ElapsedTime { get; set; }

    public TimerParameters(string title, bool isPlay, TimeSpan elapsedTime)
    {
        Title = title;
        IsPlay = isPlay;
        ElapsedTime = elapsedTime;
    }
}
