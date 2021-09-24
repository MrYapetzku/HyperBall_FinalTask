using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CollisionHandler))]
public class GameStatesSwitcher : MonoBehaviour
{
    [SerializeField] private WaveGenerator _spawner;
    [SerializeField] private GameObject _notInteractiveObjectsContainer;
    [SerializeField] private GameObject _interactiveObjectsContainer;

    private CollisionHandler _collisionHandler;
    private Vector3 _ballStartPosition;
    private Vector3 _cameraStartPosition;

    private void Awake()
    {
        _ballStartPosition = transform.position;
        _cameraStartPosition = Camera.main.transform.position;
        _collisionHandler = GetComponent<CollisionHandler>();
        transform.gameObject.SetActive(false);
    }

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
        OnGameOverState();
    }

    public void OnStartState()
    {
        Time.timeScale = 1;
        SetStartPositions();
        _spawner.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    private void OnGameOverState()
    {
        _spawner.gameObject.SetActive(false);
        DisableObjectsInContainer(_notInteractiveObjectsContainer);
        DisableObjectsInContainer(_interactiveObjectsContainer);
        _collisionHandler.gameObject.SetActive(false);
    }

    private void SetStartPositions()
    {
        transform.position = _ballStartPosition;
        Camera.main.transform.position = _cameraStartPosition;
    }

    private void DisableObjectsInContainer(GameObject conteiner)
    {
        foreach (Transform item in conteiner.transform)
            item.gameObject.SetActive(false);
    }

}
