using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    
    public int maxHealth = 100;
    public int currentHealth;
    public Transform foot;
    public float footRadius;
    public LayerMask floor;
    public LayerMask enemy;
    public bool isOnFloor;
    public bool isOnEnemy;
    public bool isDead = false;

    public Animator animator;
    public HealthBar healthBar;
    public GameObject LevelCompleteMenuUI;
    public GameObject playerObject;
    public GameObject grid;
    public GameObject scenery;
    public GameObject enemies;
    public GameObject coins;
    public GameObject waterdrops;    

    
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        isOnFloor = Physics2D.OverlapCircle(foot.position, footRadius, floor);

        if (!isOnFloor) {
            isOnEnemy = Physics2D.OverlapCircle(foot.position, footRadius, enemy);
        }

        if (currentHealth == 0)
        {
            isDead = true;
        }
    }

    void TakeDamage(int damage) {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }

    void IncreaseHealth(int health) 
    {
        currentHealth += health;

        healthBar.SetHealth(currentHealth);
    }

    void OnCollisionEnter2D (Collision2D collision) {
        if (collision.gameObject.tag == "Enemy" && isOnEnemy == false)
        {
            TakeDamage(10);
        }
    }

    private void OnTriggerEnter2D (Collider2D other) {
        if (other.gameObject.CompareTag("Coin")) {
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("WaterDrop")) {
            IncreaseHealth(20);
            Destroy(other.gameObject);
        }

        if (other.gameObject.CompareTag("Endpoint")) {
            LevelCompleteMenuUI.SetActive(true);
            playerObject.SetActive(false);
            grid.SetActive(false);
            scenery.SetActive(false);
            coins.SetActive(false);
            waterdrops.SetActive(false);
            if (enemies != null) {
                enemies.SetActive(false);
            }
            Time.timeScale = 0f;
        }
    }
}
