using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private GameSoundsSourse _gameSoundsSourse;

    public event UnityAction GameEnding;
    public event UnityAction<int> CoinCatched;
    public event UnityAction<int> BonusChargesChanged;

    private int _currentBonusCharges = 0;

    private void OnCollisionEnter(Collision collision)
    {
        var obstacle = collision.gameObject.GetComponentInParent<Obstacle>();
        if (obstacle)
        {
            if (_currentBonusCharges == 0)
            {
                _gameSoundsSourse.PlayGameOverSound();
                GameEnding?.Invoke();
            }
            else
            {
                _gameSoundsSourse.PlayObstacleSoundDestroy();
                obstacle.Disable();
                _currentBonusCharges--;
                BonusChargesChanged?.Invoke(_currentBonusCharges);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        var coin = other.GetComponentInParent<Coin>();
        var powerUp = other.GetComponentInParent<PowerUp>();

        if (coin)
        {
            _gameSoundsSourse.PlayCoinSound();
            CoinCatched?.Invoke(coin.ScoreValue);
            coin.Disable();
        }

        if (powerUp)
        {
            _gameSoundsSourse.PlayPowerUpSound();
            _currentBonusCharges += powerUp.BonusCharges;
            BonusChargesChanged?.Invoke(_currentBonusCharges);
            CoinCatched?.Invoke(powerUp.ScoreValue);
            powerUp.Disable();
        }
    }    
}
