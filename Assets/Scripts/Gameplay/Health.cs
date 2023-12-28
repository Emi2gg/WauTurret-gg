using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Health : MonoBehaviour
{
    [SerializeField]public int maxHealth = 100
    public int currentHealth = 100;
    public HealthBar healthBar;


    [SerializeField]private UnityEvent<float> _onHealthChanged = new ();
    [SerializeField]private UnityEvent _onDeath = new ();
    // Start is called before the first frame update
    void OnEnable()
    {
       currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
    }

    public void ReceiveDamage(int damage)
    {
        //_currentHealth = _currentHealth - damage;
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);

        if (currentHealth < 0)
        {
            currentHealth = 0;
        }
        _onHealthChanged?.Invoke((float)currentHealth / maxHealth);
        if(currentHealth == 0)
            _onDeath?.Invoke();
        
    }
}
