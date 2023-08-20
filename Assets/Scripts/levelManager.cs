using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class levelManager : MonoBehaviour
{
    [SerializeField] GameObject notEnuf,gameOver;
    [SerializeField] TextMeshProUGUI cashText,healthText;
    static public bool canPlace;
    static public int cash,health=100;
    public int cashMoney,Health;
    // Start is called before the first frame update

    private void Awake()
    {
        cash = 0;
        health = 100;

    }
    void Start()
    {
        InvokeRepeating("CashGain", 1f, 2f);
    }

    // Update is called once per frame
    void Update()
    {
        cashMoney = cash;
        Health = health;
        cashText.text = "" + cash + " $";
        healthText.text = "HP: " + health + "%";
        if (cash > 200) {
            spawnerScript.rate = 7f;
        }else if (cash > 450)
        {
            spawnerScript.rate = 9f;

        }

        if (health <= 0)
        {
            gameOver.SetActive(true);
            health = 0;
        }
        else
        {
            gameOver.SetActive(false);
        }
    }



    public void PauseGame()
    {
        Time.timeScale = 0;
    }
    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    void CashGain()
    {
        cash += 10;
    }

    static public void HealthDecrease()
    {
        health -= 20;
    }

    public void CanonSelect(int val)
    {
        if (cash >= 20)
        {
            canPlace = true;
            Waypoint.SelectCanon(val);
        }else 
        {
            StartCoroutine(NotEnuf());
            canPlace = false;
        }
    }

    IEnumerator NotEnuf()
    {
        notEnuf.SetActive(true);
        yield return new WaitForSeconds(2f);
        notEnuf.SetActive(false);
    }

    
}
