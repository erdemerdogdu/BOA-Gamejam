using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public static PlayerStats playerStats;

    AudioManager audioManager;
    GameObject audioManagerObj;
    HealthManager healthManager;

    public int killCnt;
    public int eggCnt;
    private float health;
    public float maxHealth;
    public float damageTaken;
    public bool isAlive;

    private Rigidbody2D rigidBody;
    private Animator animator;
    private BoxCollider2D boxCollider;
    

    void Start()
    {
        isAlive = true;
        health = maxHealth;

        rigidBody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        boxCollider = GetComponent<BoxCollider2D>();
        healthManager.SetMaxHealth((int)maxHealth);
        audioManagerObj = GameObject.FindGameObjectWithTag("Audio");
        if(audioManagerObj != null)
        {
            audioManager = audioManagerObj.GetComponent<AudioManager>();
        }
        
    }

    public void DealDamage(float damage)
    {
        health -= damage;
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
        healthManager.SetHealth((int)health);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        healthManager.SetHealth((int)health);
        if (health <= 0)
        {
            //rigidBody.bodyType = RigidbodyType2D.Static;
            PlayerMovement.moveSpeed = 0;
            isAlive = false;
            animator.SetTrigger("death");
            audioManager.PlaySFX(audioManager.characterDeathOut);
            Shooting.isDead = true;
        }
    }

    // Used by animator
    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    // Used by animator
    private void CloseCol()
    {
        boxCollider.enabled = false;
    }

}
