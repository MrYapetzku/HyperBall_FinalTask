using System.Collections;
using UnityEngine;

public class UICouwndown : MonoBehaviour
{
    [SerializeField] private UIPopup _popup;
    [SerializeField] private float _countMassageTime;
    [SerializeField] private string _startMassage;

    private void OnEnable()
    {
        StartCoroutine(ShowStartCountdouwn());
    }

    private IEnumerator ShowStartCountdouwn()
    {
        yield return new WaitForSeconds(_countMassageTime);
        for (int i = 3; i > 0; i--)        {
            _popup.ShowMassage(i.ToString());
            yield return new WaitForSeconds(_countMassageTime);
        }
        _popup.ShowMassage(_startMassage);
    }
}
