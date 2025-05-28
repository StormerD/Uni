public class Clock {
    private Counter hours;
    private Counter minutes;
    private Counter seconds;

    public Clock(int time_format) {
        if (time_format == 12) {
            hours = new Counter(1, 12);
        }
        else {
            hours = new Counter(0, 23);
        }
        minutes = new Counter(0, 59);
        seconds = new Counter(0, 59);
    }

    public void Tick(long count) {
        for (int i = 0; i < count; i++) {
            if (seconds.Increment()) {
                if (minutes.Increment()) {
                    hours.Increment();
                }
            }
        }
    }   

    public void Reset() {
        hours.Reset();
        minutes.Reset();
        seconds.Reset();
    }

    public string GetTime() {
        return $"{hours.GetPaddedValue()}:{minutes.GetPaddedValue()}:{seconds.GetPaddedValue()}";
    }
}