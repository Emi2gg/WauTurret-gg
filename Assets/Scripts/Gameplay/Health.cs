using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public HealthBar HealthBar;


    [SerializeField] public UnityEvent<float> _onHealthChanged = new();
    [SerializeField] public UnityEvent _onDeath = new();
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        HealthBar.SetMaxHealth(maxHealth);

    }

    public void ReceiveDamage(int damage)
    {
        //_currentHealth = _currentHealth - damage;
        currentHealth -= damage;


        if (currentHealth < 0)
        {
            currentHealth = 0;
        }

        HealthBar.SetHealth(currentHealth);

        _onHealthChanged?.Invoke((float)currentHealth / maxHealth);
        if (currentHealth == 0)
            _onDeath?.Invoke();

    }
}