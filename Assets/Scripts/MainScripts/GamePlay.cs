using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GamePlay : MonoBehaviour
{
   // private EnemyHealth enemyHealth;

    public GameObject wonMenuUI;
    public Text blueCount, yellowCount, redCount, purpleCount, totalCount;
    public int amountOfHenchmenForALoseConditions = 10;

    private bool isBlueBossDead = false;
    private bool isYellowBossDead = false;
    private bool isRedBossDead = false;
    private bool isPurpleBossDead = false;
    private int bossCount, countBlue, countYellow, countRed, countPurple = 0;
    private int countBlueBoss, countYellowBoss, countRedBoss, countPurpleBoss = 0;

    private void Awake()
    {
        
    }

    void LateUpdate()
    {
        countEnemies();
        areBossesShielded();
    }

    private void areBossesShielded()
    {
        if (!isBlueBossDead && countBlue > 0)
        {
            
        }
        if (!isYellowBossDead && countYellow > 0)
        {
            //blue boss is shielded
        }
        if (!isRedBossDead && countRed > 0)
        {
            //blue boss is shielded
        }
        if (!isPurpleBossDead && countPurple > 0)
        {
            //blue boss is shielded
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
