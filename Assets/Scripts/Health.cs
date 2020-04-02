using UnityEngine;

public class Health : MonoBehaviour
{
    public float maxHealth = 5;
    public float currHealth = 0;
    bool invulnerable = false;
    public float damageTaken = 0;
    public float healingRecieved = 0;

    public HealthDelegate onHurt = new HealthDelegate();
    public HealthDelegate onDeath = new HealthDelegate();
    public HealthDelegate onHeal = new HealthDelegate();

    public ESpawner eSpawnerRef;
    public bool streakBreaker = false;

    public bool immune { get => invulnerable; set => invulnerable = value; }

    private void Awake()
    {
        ResetHealth();
    }

    public virtual void TakeDamage(float damageAmount)
    {
        streakBreaker = true;

        if (streakBreaker == true && eSpawnerRef != null)
        {
            streakBreaker = false;
            eSpawnerRef.streakCount = 0;
        }

        if (immune == true) return;
        if (currHealth == 0) return;
        currHealth = Mathf.Clamp(currHealth - damageAmount, 0, maxHealth);
        Debug.Log(damageAmount);
        if (currHealth == 0)
        {
            onDeath.CallEvent(0);
        }
        else
        {
            damageTaken = damageAmount;
            onHurt.CallEvent(currHealth / maxHealth);
        }
    }
    public void ResetHealth()
    {
        currHealth = maxHealth;
    }

    public void Healing(float healingAmount)
    {
        healingRecieved = healingAmount;
        onHeal.CallEvent(0);
        currHealth += healingAmount;
        currHealth = Mathf.Clamp(currHealth, 0, maxHealth);
        if (currHealth >= maxHealth)
        {
            currHealth = maxHealth;
        }
    }
}
