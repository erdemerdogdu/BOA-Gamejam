using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour
{
    public GameObject player;

    public int killCnt;
    public int eggCnt;
    public float health;
    public float maxHealth;
    public float damageTaken;

    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    private BoxCollider2D _boxCollider2D;
    private PlayerMovement _playerMovement;
    private AudioManager _audioManager;
    private HealthManager _healthManager;

    private void Start()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _boxCollider2D = GetComponent<BoxCollider2D>();
        _playerMovement = GetComponent<PlayerMovement>();
        _healthManager.SetMaxHealth((int)maxHealth);
        _audioManager = GameObject.FindGameObjectWithTag("Audio").GetComponent<AudioManager>();
        health = maxHealth;
    }

    private void DealDamage(float damage)
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
        _healthManager.SetHealth((int)health);
        if (health > maxHealth)
        {
            health = maxHealth;
        }
    }

    private void CheckDeath()
    {
        if (health <= 0)
        {
            _playerMovement.moveSpeed = 0;
            _playerMovement.canBlink = false;
            _playerMovement.blinkTime = 10;
            _animator.SetTrigger("death");
            _audioManager.PlaySFX(_audioManager.characterDeathOut);
            Shooting.isDead = true;
            // DEATH ANIMATION WILL CALL THE RESTART
            // RestartLevel();
            _healthManager.SetHealth((int)health);
        }
        else
        {
            _healthManager.SetHealth((int)health);
        }
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void CloseCol()
    {
        _boxCollider2D.enabled = false;
    }

}