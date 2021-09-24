using UnityEngine;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;

    public void SwitchToGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
