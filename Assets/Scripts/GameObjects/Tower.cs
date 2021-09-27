using UnityEngine;

[RequireComponent(typeof(Animator))]
public class Tower : MonoBehaviour
{
    [SerializeField] private int _animationsCount;
    private Animator _animator;
    private void Start()
    {
        _animator = GetComponent<Animator>();
        SelectAnimation();
    }

    private void SelectAnimation()
    {
        int animationNuber = Random.Range(0, _animationsCount);

        switch (animationNuber)
        {
            case 1:
                _animator.SetTrigger(TowerAnimator.Animation1);
                break;
            case 2:
                _animator.SetTrigger(TowerAnimator.Animation2);
                break;
            case 3:
                _animator.SetTrigger(TowerAnimator.Animation3);
                break;

            default:
                break;
        }
    }
}
