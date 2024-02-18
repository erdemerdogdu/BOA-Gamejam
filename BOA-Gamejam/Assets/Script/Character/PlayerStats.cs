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
    
    /* [SerializeField]
    private GameObject pFab;
    [SerializeField]
    public Vector3 spawnPoint; */
    
    /* void Awake()
    {
        if (playerStats != null)
        {
            Destroy(playerStats);
        }
        else
        {
            playerStats = this;
        }
        DontDestroyOnLoad(this);
    } */

    void Start()
    {
        health = maxHealth;
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        //spawnPoint = transform.position;
        bc = GetComponent<BoxCollider2D>();
        audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();

        Debug.Log(audioManager.mainMusicLoop);
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
            anim.SetTrigger("death");
            audioManager.PlaySFX(audioManager.characterDeathOut);
            Shooting.isDead = true;
            // DEATH ANIMATION WILL CALL THE RESTART
            //RestartLevel();
        }
    }

    private void RestartLevel()
    {
        //GameObject newPlayer = Instantiate(gameObject, spawnPoint, Quaternion.identity);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    /* private void DestroyPlayer()
    {
        Destroy(player);
    } */

    private void CloseCol()
    {
        bc.enabled = false;
    }
}
