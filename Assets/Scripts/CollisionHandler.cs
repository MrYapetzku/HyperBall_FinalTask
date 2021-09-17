using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] private float _gemeOverDelay;
    [SerializeField] private Vector3 _reboundVector;

    public UnityAction GameOver;
    public UnityAction<int> CoinCatched;
    public UnityAction<int> BonusChargesChanged;

    private int _currentBonusCharges = 0;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent(out Obstacle obstacle))
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
        if (other.TryGetComponent(out Coin coin))
        {
            CoinCatched?.Invoke(coin.ScoreValue);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            coin.Disable();
        }

        if (other.TryGetComponent(out Bonus bonus))
        {
            _currentBonusCharges += bonus.BonusCharges;
            BonusChargesChanged?.Invoke(_currentBonusCharges);
            CoinCatched?.Invoke(bonus.ScoreValue);
            other.gameObject.transform.rotation = Quaternion.Euler(0, 0, 0);
            bonus.Disable();
        }
    }

    private IEnumerator SetGameOver(float gameOverDelay)
    {
        BallMover mover = gameObject.GetComponent<BallMover>();
        mover.enabled = false;
        AudioSource _gameOverSound = gameObject.GetComponent<AudioSource>();
        _gameOverSound.Play();
        Animator animator = gameObject.GetComponent<Animator>();
        animator.SetTrigger("GameOver");
        Rigidbody rigidBody = gameObject.GetComponent<Rigidbody>();
        rigidBody.velocity = Vector3.zero;
        rigidBody.AddForce(_reboundVector, ForceMode.Impulse);
        yield return new WaitForSeconds(gameOverDelay);
        mover.enabled = true;
        GameOver?.Invoke();
    }
}
