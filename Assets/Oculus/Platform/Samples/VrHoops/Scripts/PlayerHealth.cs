using UnityEngine.UI;
using UnityEngine;

public class PlayerHealth : Health
{
    private void Update()
    {
        healthBar.fillAmount = currHealth / maxHealth;
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "RedEnemy")
        {
            TakeDamage(1);
            ESpawner.eSpawner.streakCount = 0;
        }
    }

}
