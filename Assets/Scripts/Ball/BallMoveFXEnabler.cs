using UnityEngine;

public class BallMoveFXEnabler : MonoBehaviour
{
    [SerializeField] private ParticleSystem _ballMoveFX;

    private void OnEnable()
    {
        _ballMoveFX.Play();
    }

    private void OnDisable()
    {
        if(_ballMoveFX != null)
            _ballMoveFX.Stop();
    }
}
