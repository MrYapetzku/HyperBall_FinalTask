using UnityEngine;

public class UIMainMenu : MonoBehaviour
{
    [SerializeField] private UIGameMenu _gameMenu;

    public void SwitchToGameMenu()
    {
        gameObject.SetActive(false);
        _gameMenu.gameObject.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
