using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// 플레이어 체력 이미지 관리
/// </summary>
public class Heart : MonoBehaviour
{
    [SerializeField] private Image _heartFill;

    public void Enable(bool isEnable)
    {
        _heartFill.fillAmount = isEnable ? 1 : 0;
    }
}
