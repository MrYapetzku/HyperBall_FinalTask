using UnityEngine;
using TMPro;

public class UIYourScoresViewer : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private UIScoreViewer _viewer;

    private void OnEnable()
    {
        _text.SetText("Your Scores\n" + _viewer.Scores);
    }
}
