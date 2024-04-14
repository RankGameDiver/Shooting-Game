using UnityEngine;
using UnityEngine.UI;

public class Heart : MonoBehaviour
{
    [SerializeField] private Image _heartFill;

    public void Enable(bool isEnable)
    {
        _heartFill.fillAmount = isEnable ? 1 : 0;
    }
}
