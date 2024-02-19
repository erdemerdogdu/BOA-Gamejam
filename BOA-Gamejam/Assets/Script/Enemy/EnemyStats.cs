using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyStats : MonoBehaviour
{
    public static EnemyStats enemyStats;
    private PlayerStats playerStats;

    AudioManager audioManager;
    private CircleCollider2D bc;

    public float health;
    public float maxHealth;
    public float damageTaken;

    public bool isAlive = true;

    private Rigidbody2D rb;
    private Animator anim;
    
    void Start()
    {
        health = maxHealth;
        playerStats = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerStats>();
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        bc = GetComponent<CircleCollider2D>();
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        anim.Play("HitTree");
        rb.bodyType = RigidbodyType2D.Static;
        CheckDeath();
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            DealDamage(damageTaken);
        }
        // for further usage: if the enemy sends a projectile, take this block of code to enemy and destroy projectile on hit
        //Destroy(gameObject);
    }

    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }

    private void CheckOverheal()
    {
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            //Destroy(player);
            rb.bodyType = RigidbodyType2D.Static;
            if (isAlive)
            {
                audioManager.PlaySFX(audioManager.enemyDeath);
            }
            isAlive = false;
            playerStats.killCnt++;
            anim.SetTrigger("death");
            // DEATH ANIMATION WILL CALL THE RESTART
            //RestartLevel();
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void DestroyPlayer()
    {
        Destroy(gameObject);
    }


    private void resetBody()
    {
        if (health > 0)
            rb.bodyType = RigidbodyType2D.Dynamic;
    }

    private void CloseCol()
    {
        bc.enabled = false;
    }

}
