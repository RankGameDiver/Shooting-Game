using UnityEngine;

public class Status
{
    private Life _life;
    public Status(int maxLife)
    {
        _life = new Life(0, maxLife, maxLife);
    }

    public Life GetLife()
    {
        return _life;
    }
}
