using UnityEngine;

[RequireComponent(typeof(CollisionHandler),typeof(Animator))]
public class GameStatesSwitcher : MonoBehaviour
{
    [SerializeField] private WaveGenerator _spawner;
    [SerializeField] private GameObject _notInteractiveObjectsContainer;
    [SerializeField] private GameObject _interactiveObjectsContainer;
    [SerializeField] private UIGameMenu _gameMenu;

    private CollisionHandler _collisionHandler;
    private Animator _animator;
    private Vector3 _ballStartPosition;
    private Vector3 _cameraStartPosition;

    private void Awake()
    {
        _ballStartPosition = transform.position;
        _cameraStartPosition = Camera.main.transform.position;
        _collisionHandler = GetComponent<CollisionHandler>();
        _animator = GetComponent<Animator>();
        transform.gameObject.SetActive(false);
    }

    private void OnEnable()
    {
        _collisionHandler.GameEnding += OnGameEnding;
    }

    private void OnDisable()
    {
        _collisionHandler.GameEnding -= OnGameEnding;
    }


    public void OnStartingState()
    {
        Time.timeScale = 1;        
        _animator.SetTrigger(BallAnimator.StartGame);
        SetStartPositions();
        _spawner.gameObject.SetActive(true);
        gameObject.SetActive(true);
    }

    private void OnGameOver()
    {
        _spawner.gameObject.SetActive(false);
        gameObject.SetActive(false);
        DisableObjectsInContainer(_notInteractiveObjectsContainer);
        DisableObjectsInContainer(_interactiveObjectsContainer);
        _gameMenu.SwitchToGameOverMenu();
    }

    private void OnGameEnding()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
        _animator.SetTrigger(BallAnimator.GameOver);
    }

    private void SetStartPositions()
    {
        transform.position = _ballStartPosition;
        transform.rotation = Quaternion.Euler(Vector3.zero);
        Camera.main.transform.position = _cameraStartPosition;
    }

    private void DisableObjectsInContainer(GameObject conteiner)
    {
        foreach (Transform item in conteiner.transform)
            item.gameObject.SetActive(false);
    }
}
