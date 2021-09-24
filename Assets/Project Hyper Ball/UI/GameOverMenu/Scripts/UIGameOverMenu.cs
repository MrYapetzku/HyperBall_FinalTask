using UnityEngine;

public class UIGameOverMenu : MonoBehaviour
{
    [SerializeField] private UIMainMenu _mainMenu;
    [SerializeField] private UIGameMenu _gameMenu;
    public void SwitchToMainMenu()
    {
        gameObject.SetActive(false);
        _mainMenu.gameObject.SetActive(true);
    }

    public void SwithcToGameMenu()
    {
        gameObject.SetActive(false);
        _gameMenu.gameObject.SetActive(true);
    }
}
