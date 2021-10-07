using UnityEngine;

public class BallPowerUpFXPlayer : MonoBehaviour
{
    [SerializeField] private CollisionHandler _collisionHandler;
    [SerializeField] private ParticleSystem _ballPowerUpFX;

    private void OnEnable()
    {
        _collisionHandler.BonusChargesChanged += OnBonusChargesChanged;
    }

    private void OnDisable()
    {
        _collisionHandler.BonusChargesChanged -= OnBonusChargesChanged;
    }

    private void OnBonusChargesChanged(int count)
    {
        if (count > 0)
            _ballPowerUpFX.Play();
        else
            _ballPowerUpFX.Stop();
    }
}
