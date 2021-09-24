using UnityEngine;

public class GameSoundsSourse : MonoBehaviour
{
    [SerializeField] private ClipPlayer _obstacleSoundsSource;
    [SerializeField] private ClipPlayer _coinSoundsSource;
    [SerializeField] private ClipPlayer _powerUpSoundsSource;
    [SerializeField] private AudioSource _gameOverSoundSource;

    public void PlayObstacleSoundDestroy()
    {
        _obstacleSoundsSource.Play();
    }

    public void PlayCoinSound()
    {
        _coinSoundsSource.Play();
    }

    public void PlayPowerUpSound()
    {
        _powerUpSoundsSource.Play();
    }

    public void PlayGameOverSound()
    {
        _gameOverSoundSource.Play();
    }
}
