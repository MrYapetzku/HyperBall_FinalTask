using UnityEngine;
using UnityEngine.Events;

public class EndWave : MonoBehaviour
{
    public event UnityAction<EndWave> WaveEnded;

    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponentInParent<BallMover>())
        {
            WaveEnded?.Invoke(this);
        }
    }
}
