using UnityEngine;

public abstract class InteractiveObject : MonoBehaviour
{
    [SerializeField] private ParticleSystem _disableEffect;
    [SerializeField] private GameObject _visual;

    private void OnDisable()
    {
        _visual.SetActive(true);
    }

    public virtual void Disable()
    {
        _visual.SetActive(false);
        _disableEffect.Play();
    }
}
