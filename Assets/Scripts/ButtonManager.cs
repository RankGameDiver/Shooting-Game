using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    [SerializeField] private Text _text;

    public void OnButtonA()
    {
        _text.text = "A Button Clicked!!";
    }

    public void OnButtonB()
    {
        _text.text = "B Button Clicked!!";
    }

    public void OnButton()
    {
        _text.text = "Button Clicked!!";
    }
}
