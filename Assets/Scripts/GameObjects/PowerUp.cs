using UnityEngine;

public class PowerUp : InteractiveObject
{
    [SerializeField] private int _scoreValue;
    [SerializeField] private int _bonusCharges;

    public int ScoreValue => _scoreValue;
    public int BonusCharges => _bonusCharges;
}
