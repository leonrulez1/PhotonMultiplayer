using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numofHearts;
    public Image[] hearts;
    public Image hearts1, hearts2, hearts3;
    public Sprite emptyHeart;
    public Sprite fullHeart;
    public GameObject player;
    Coroutine storeRoutine;

    [Header("forHealth")]
    HeartManager theHeartManager;
    // Start is called before the first frame update
    void Start()
    {
        theHeartManager = HeartManager.instance;
        health = 3;
        hearts1.enabled = true;
        hearts2.enabled = true;
        hearts3.enabled = true;
        // for setting of the heart variables
        hearts1 = theHeartManager.hearts1;
        hearts2 = theHeartManager.hearts2;
        hearts3 = theHeartManager.hearts3;
    }

    // Update is called once per frame
    void Update()
    {
        if (health > numofHearts)
        {
            health = numofHearts;
        }
        //for (int i = 0; i < hearts.Length; i++)
        //{
        //    if(i < health)
        //    {
        //        hearts[i].sprite = fullHeart;

        //    }
        //    else
        //    {
        //        hearts[i].sprite = emptyHeart;
        //    }
        //    if (i < numofHearts)
        //    {
        //        hearts[i].enabled = true;
        //    }
        //    /*else
        //    {
        //        hearts[i].enabled = false;
        //    }*/
        //}
        
        HealthUI();
    }
    void HealthUI()
    {
        switch(health)
        {
            case 3:
                hearts1.gameObject.SetActive(true);
                hearts2.gameObject.SetActive(true);
                hearts3.gameObject.SetActive(true);
                print("2");
                break;
            case 2:
                hearts1.gameObject.SetActive(true);
                hearts2.gameObject.SetActive(false);
                hearts3.gameObject.SetActive(true);
                break;
            case 1:
                hearts1.gameObject.SetActive(false);
                hearts2.gameObject.SetActive(false);
                hearts3.gameObject.SetActive(true);
                break;
            default:
                hearts1.gameObject.SetActive(false);
                hearts2.gameObject.SetActive(false);
                hearts3.gameObject.SetActive(false);
                break;
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
