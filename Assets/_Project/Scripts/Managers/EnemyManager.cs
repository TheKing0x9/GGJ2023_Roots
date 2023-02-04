using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;

public class EnemyManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI powerText;
    public ScriptableObjectNumbersGenerator enemyPowerData;
    public int power;
    public int health { get; private set; } = 64;
    public int damage { get; private set; }

    public void setPower(int power)
    {
        this.power = power;
        powerText.text = power.ToString();
        health = this.power;
        damage = this.power;
    }
    
    public bool IsSqrt()
    {
        return enemyPowerData.IsNumberAPerfectSquare(power);
    }

    public void TakeDamage(int dmg)
    {
        health -= dmg;
        health = Mathf.Max(0, health);
    }
}
