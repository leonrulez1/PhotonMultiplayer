using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public int health = 1000;
    public GameObject deathEffect;
    public GameObject projectile;
    public GameObject[] firePoints;
    public GameObject[] spikes;
    public List<string> possibleAttacks = new List<string>() { "Horizontal" };

    public enum BossType { one, two, three }
    public BossType bossType;


     void Start()
    {
        StartCoroutine(Attack());
        print("Attack");
    }

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        } else if (health <= 500)
        {
            possibleAttacks.Add("Up");
            print("Up");
        }
        else if (health <= 200)
        {
            possibleAttacks.Add("Down");
        }
    }
    
    void Die ()
    {
        Instantiate(deathEffect, transform.position, Quaternion.identity);
        Destroy(gameObject);
    }
    
    void Executable(string currentAttack)
    {
        //print(currentAttack);
        switch (currentAttack)
        {
            case "Horizontal":
               // Instantiate(projectile, firePoints[0].transform.position, firePoints[0].transform.rotation);
                StartCoroutine(HorizontalAttack());
                print("horizontal");
                break;

            case "Up":
                StartCoroutine(Up());
                print("Up");
                break;

            case "Down":
               // Instantiate(projectile, firePoints.transform.position, firePoint1.transform.rotation);
                print("Down");
                break;
        }
    }

    IEnumerator Attack()
    {
        switch (bossType) {

            // AI for Boss 1
            case BossType.one:

                while (true)
                {
                    yield return new WaitForSeconds(2f);
                    Executable(possibleAttacks[Random.Range(0, possibleAttacks.Count)]);
                    yield return new WaitForSeconds(2f);
                }
                break;
                
        }
    }
    IEnumerator HorizontalAttack()
    {
        for(int i = 0; i < firePoints.Length; i++)
        {
            yield return new WaitForSeconds(0.4f);
            Instantiate(projectile, firePoints[i].transform.position, firePoints[i].transform.rotation);
        }
    }
    IEnumerator Up()
    {
        for (int i = 0; i < spikes.Length; i++)
        {
            yield return new WaitForSeconds(0.4f);
            Collider2D c = GetComponent<Collider2D>();
            c.enabled = true;
            yield return new WaitForSeconds(0.2f);
            c.enabled = false;


        }
    }
}
