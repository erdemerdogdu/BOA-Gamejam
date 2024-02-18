using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;
    AudioManager audioManager;
    
    public GameObject player;
    
    public float health;
    public float maxHealth;
    public float damageTaken;

    private Rigidbody2D rb;
    private Animator anim;
    private BoxCollider2D bc;

    public HealthManager hm;

    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        bc = GetComponent<BoxCollider2D>();
        hm.SetMaxHealth((int)maxHealth);
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        Debug.Log(audioManager.mainMusicLoop);
    }

    public void DealDamage(float damage)
    {
        health -= damage;
        print("health");
        CheckDeath();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            DealDamage(damageTaken);
        }
    }
    
    public void HealCharacter(float heal)
    {
        health += heal;
        CheckOverheal();
    }
    
    private void CheckOverheal()
    {
        hm.SetHealth((int)health);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            rb.bodyType = RigidbodyType2D.Static;
            anim.SetTrigger("death");
            audioManager.PlaySFX(audioManager.characterDeathOut);
            Shooting.isDead = true;
            // DEATH ANIMATION WILL CALL THE RESTART
            //RestartLevel();
            hm.SetHealth((int)health);
        }
        else
        {
            hm.SetHealth((int)health);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CloseCol()
    {
        bc.enabled = false;
    }

}
