using System.Collections;
using UnityEngine;

public class GameAnimations : MonoBehaviour
{
    [SerializeField] private UIPopup _popup;
    [SerializeField] private BallMover _ballMover;
    [SerializeField] private float _countMassageTime;
    [SerializeField] private string _startMassage;

    private void OnEnable()
    {
        _ballMover.enabled = false;
        StartCoroutine(ShowStartAnimation());
    }

    private IEnumerator ShowStartAnimation()
    {
        yield return new WaitForSeconds(_countMassageTime);
        for (int i = 3; i > 0; i--)        {
            _popup.ShowMassage(i.ToString());
            yield return new WaitForSeconds(_countMassageTime);
        }
        _popup.ShowMassage(_startMassage);
        _ballMover.enabled = true;
    }

}
