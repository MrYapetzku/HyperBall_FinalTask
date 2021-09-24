using System.Collections;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BallMover),typeof(AudioSource),typeof(Animator))]
[RequireComponent(typeof(Rigidbody))]
public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _gemeOverDelay;
    [SerializeField] private Vector3 _reboundVector;

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
                StartCoroutine(SetGameOver(_gemeOverDelay));
            }
            else
            {
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
            CoinCatched?.Invoke(coin.ScoreValue);
            coin.Disable();
        }

        if (powerUp)
        {
            _currentBonusCharges += powerUp.BonusCharges;
            BonusChargesChanged?.Invoke(_currentBonusCharges);
            CoinCatched?.Invoke(powerUp.ScoreValue);
            powerUp.Disable();
        }
    }

    private IEnumerator SetGameOver(float gameOverDelay)
    {
        BallMover mover = GetComponent<BallMover>();
        mover.enabled = false;
        AudioSource _gameOverSound = GetComponent<AudioSource>();
        _gameOverSound.Play();
        Animator animator = GetComponent<Animator>();
        animator.SetTrigger(BallAnimator.GameOver);
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        rigidbody.velocity = Vector3.zero;
        rigidbody.AddForce(_reboundVector, ForceMode.Impulse);
        yield return new WaitForSeconds(gameOverDelay);
        mover.enabled = true;
        GameEnding?.Invoke();
    }
}
