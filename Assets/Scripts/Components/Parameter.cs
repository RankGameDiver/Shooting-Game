
public class Parameter
{
    public float Min { get; private set; }
    public float Max { get; private set; }
    public float Value { get; private set; }

    public Parameter(float min, float max, float current)
    {
        Min = min;
        Max = max;
        Value = current;
    }

    public void Increase(float value = 1)
    {
        Value = Validation(Value + value);
    }

    public void Decrease(float value = 1)
    {
        Value = Validation(Value - value);
    }

    private float Validation(float value)
    {
        if(value > Max) {
            value = Max;
        }
        else if(value < Min) {
            value = Min;
        }

        return value;
    }
}