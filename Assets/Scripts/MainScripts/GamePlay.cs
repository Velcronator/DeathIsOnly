using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
    private EnemyHealth enemyHealth;
    public GameObject blue;
    public GameObject yellow;
    public GameObject red;
    public GameObject purple;
    public GameObject player;

    public GameObject wonMenuUI, lostMenuUI;
    public Text blueCount, yellowCount, redCount, purpleCount, totalCount;

    private bool isBlueBossDead = false;
    private bool isYellowBossDead = false;
    private bool isRedBossDead = false;
    private bool isPurpleBossDead = false;
    private int bossCount, countBlue, countYellow, countRed, countPurple = 0;
    private int countBlueBoss, countYellowBoss, countRedBoss, countPurpleBoss = 0;

    void LateUpdate()
    {
        countEnemies();
        areBossesShielded();
    }

    private void areBossesShielded()
    {
        if (!isBlueBossDead)
        {
            if(countBlue == 0)
            {
                blue.GetComponent<EnemyHealth>().isShield = false;
                blue.GetComponent<EnemyHealth>().Shield.SetActive(false);
                blue.GetComponent<CapsuleCollider>().enabled = false;
            }
            else
            {
                blue.GetComponent<EnemyHealth>().isShield = true;
                blue.GetComponent<EnemyHealth>().Shield.SetActive(true);
                blue.GetComponent<CapsuleCollider>().enabled = true;
            }
        }

        if (!isYellowBossDead)
        {
            if (countYellow == 0)
            {
                yellow.GetComponent<EnemyHealth>().isShield = false;
                yellow.GetComponent<EnemyHealth>().Shield.SetActive(false);
                yellow.GetComponent<CapsuleCollider>().enabled = false;

            }
            else
            {
                yellow.GetComponent<EnemyHealth>().isShield = true;
                yellow.GetComponent<EnemyHealth>().Shield.SetActive(true); 
                yellow.GetComponent<CapsuleCollider>().enabled = true;

            }
        }

        if (!isRedBossDead)
        {
            if (countRed == 0)
            {
                red.GetComponent<EnemyHealth>().isShield = false;
                red.GetComponent<EnemyHealth>().Shield.SetActive(false);
                red.GetComponent<CapsuleCollider>().enabled = false;

            }
            else
            {
                red.GetComponent<EnemyHealth>().isShield = true;
                red.GetComponent<EnemyHealth>().Shield.SetActive(true);
                red.GetComponent<CapsuleCollider>().enabled = true;

            }
        }
        if (!isPurpleBossDead)
        {
            if (countPurple == 0)
            {
                purple.GetComponent<EnemyHealth>().isShield = false;
                purple.GetComponent<EnemyHealth>().Shield.SetActive(false);
                purple.GetComponent<CapsuleCollider>().enabled = false;

            }
            else
            {
                purple.GetComponent<EnemyHealth>().isShield = true;
                purple.GetComponent<EnemyHealth>().Shield.SetActive(true);
                purple.GetComponent<CapsuleCollider>().enabled = true;

            }
        }
    }

    void countEnemies()
    {
        bossCount = 0;
        countBlue = GameObject.FindGameObjectsWithTag("BlueEnemy").Length;
        countYellow = GameObject.FindGameObjectsWithTag("YellowEnemy").Length;
        countRed = GameObject.FindGameObjectsWithTag("RedEnemy").Length;
        countPurple = GameObject.FindGameObjectsWithTag("PurpleEnemy").Length;
        countBlueBoss = GameObject.FindGameObjectsWithTag("BlueBoss").Length;
        countYellowBoss = GameObject.FindGameObjectsWithTag("YellowBoss").Length;
        countRedBoss = GameObject.FindGameObjectsWithTag("RedBoss").Length;
        countPurpleBoss = GameObject.FindGameObjectsWithTag("PurpleBoss").Length;

        if (countBlueBoss == 1)
        {
            bossCount += 1;
        }
        else
        {
            isBlueBossDead = true;
        }

        if (countYellowBoss == 1)
        {
            bossCount += 1;
        }
        else
        {
            isYellowBossDead = true;
        }

        if (countRedBoss == 1)
        {
            bossCount += 1;
        }
        else
        {
            isRedBossDead = true;
        }

        if (countPurpleBoss == 1)
        {
            bossCount += 1;
        }
        else
        {
            isPurpleBossDead = true;
        }

        blueCount.text = countBlue.ToString();
        yellowCount.text = countYellow.ToString();
        redCount.text = countRed.ToString();
        purpleCount.text = countPurple.ToString();
        totalCount.text = bossCount.ToString();

        if(bossCount == 0)
        {
            wonMenuUI.SetActive(true);
        }
    }
}
