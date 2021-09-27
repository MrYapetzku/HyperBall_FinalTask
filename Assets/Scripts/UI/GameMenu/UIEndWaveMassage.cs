using UnityEngine;

public class UIEndWaveMassage : MonoBehaviour
{
    [SerializeField] private UIPopup _popup;
    [SerializeField] private string[] _massages;

    public void Show()
    {
        int massageNumber = Random.Range(0, _massages.Length);
        _popup.ShowMassage(_massages[massageNumber]);
    }

}
