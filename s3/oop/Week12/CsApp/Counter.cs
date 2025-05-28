public class Counter
{
    private int value;
    private int minValue;
    private int maxValue;

    public Counter(int minValue, int maxValue) {
        this.minValue = minValue;
        this.maxValue = maxValue;
        this.value = minValue;
    }

    public bool Increment() {
        this.value += 1;
        if (this.value > maxValue) {
            this.value = minValue;
            return true; // Counter rolled over
        }
        return false; // No rollover
    }

    public void Reset() {
        this.value = this.minValue;
    }

    public int Value {
        get { return value; }
    }

    public string GetPaddedValue() {
        return Value.ToString("D2");
    }
}

