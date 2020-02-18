using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numofHearts;
    public Image[] hearts;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public GameObject player;
    Coroutine storeRoutine;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numofHearts)
        {
            health = numofHearts;
        }
        for (int i = 0; i < hearts.Length; i++)
        {
            if(i < health)
            {
                hearts[i].sprite = fullHeart;

            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }
            if (i < numofHearts)
            {
                hearts[i].enabled = true;
            }
            /*else
            {
                hearts[i].enabled = false;
            }*/
        }
    }

    public void TakeDamage()
    {

        health -= 1;

        if (health <= 0)
        {
            print("dead");
            StartCoroutine(Die());
        }
    }

    IEnumerator Die()
    {
        yield return new WaitForSeconds(0.5f);
        player.active = false;
    }




    IEnumerator ChangeColour()
    {
        yield return new WaitForSeconds(1f);
        print("Test");
    }
    void ExampleTakeDamage()
    {
        if(storeRoutine != null)
        {
            StopCoroutine(storeRoutine);
        }
        storeRoutine = StartCoroutine(ChangeColour());
    }
}
