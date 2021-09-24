using UnityEngine;

public class UIGameMenu : MonoBehaviour
{
    [SerializeField] private GameObject _gameOverMenu;
    [SerializeField] private CollisionHandler _collisionHandler;

    private void OnEnable()
    {
        _collisionHandler.GameEnding += OnGameOver;
    }

    private void OnDisable()
    {
        _collisionHandler.GameEnding -= OnGameOver;
    }

    private void OnGameOver()
    {
        SwitchToGameOverMenu();
    }

    private void SwitchToGameOverMenu()
    {
        _gameOverMenu.SetActive(true);
        gameObject.SetActive(false);
    }
}
