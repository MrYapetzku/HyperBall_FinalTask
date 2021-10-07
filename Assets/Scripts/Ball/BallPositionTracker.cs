using UnityEngine;

public class BallPositionTracker : MonoBehaviour
{
    [SerializeField] private Transform _ball;

    private void Update()
    {
        transform.position = _ball.transform.position;
    }
}
