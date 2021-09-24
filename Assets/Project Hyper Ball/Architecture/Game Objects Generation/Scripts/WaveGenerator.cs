using UnityEngine;

public class WaveGenerator : MonoBehaviour
{
    [SerializeField] private float _spawnDelay;
    [SerializeField] private float _obstaclesDistanceZ;
    [SerializeField] private int _obstaclesCount;
    [SerializeField] private float _gameAcceleration;
    [SerializeField] private int _coinsBetweenObstaclesCount;
    [SerializeField] private Transform _container;
    [SerializeField] private ObstaclesGenerator _obstaclesGenerator;
    [SerializeField] private BonusesGenerator _coinsGenerator;

    [SerializeField] private UIEndWaveMassage _endWaveMassage;

    private EndWave _endWaveTrigger;

    private void Awake()
    {
        _endWaveTrigger = CreateEndWaveTrigger();
    }

    private void OnEnable()
    {
        _endWaveTrigger.WaveEnded += OnWaveEnded;
        CreateWave();
    }

    private void OnDisable()
    {
        if (_endWaveTrigger != null)
            _endWaveTrigger.WaveEnded -= OnWaveEnded;
    }

    private void CreateWave()
    {
        Vector3 endWavePoint = _obstaclesGenerator.CreateObstaclesWave(_spawnDelay, _obstaclesDistanceZ, _obstaclesCount);
        _coinsGenerator.CreateCoinsWave(_spawnDelay, _obstaclesDistanceZ, _coinsBetweenObstaclesCount, _obstaclesCount);
        SetEndWavePosition(endWavePoint);
    }

    private EndWave CreateEndWaveTrigger()
    {
        GameObject endWaveTrigger = new GameObject();
        endWaveTrigger.name = "EndWave";
        endWaveTrigger.transform.parent = _container;
        endWaveTrigger.AddComponent<BoxCollider>().isTrigger = true;
        return endWaveTrigger.AddComponent<EndWave>();
    }

    private void SetEndWavePosition(Vector3 position)
    {
        _endWaveTrigger.gameObject.SetActive(true);
        _endWaveTrigger.transform.position = position;
    }

    private void OnWaveEnded(EndWave endWave)
    {
        _endWaveMassage.Show();
        DisableObjectsInContainer();
        CreateWave();
        Time.timeScale += _gameAcceleration;
    }

    private void DisableObjectsInContainer()
    {
        foreach (Transform item in _container)
            item.gameObject.SetActive(false);
    }
}
