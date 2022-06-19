using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnemyHealth : MonoBehaviour
{
	// stuff to assign
	public float health = 100f;
	public Image health_Img;

    [HideInInspector]
    public bool isShield = false;
    public GameObject Shield;

    private void Awake()
    {
        if(tag == "BlueBoss" || tag == "YellowBoss" || tag == "RedBoss" || tag == "PurpleBoss")
        {
			health_Img = GameObject.Find("Health FG Boss").GetComponent<Image>();
        }
        else
        {
			health_Img = GameObject.Find("Health FG").GetComponent<Image>();
		}
	}



    public void TakeDamage(float amount)
	{
        if (isShield)
        {
            return;
        }
        else
        {
            health -= amount;
		    health_Img.fillAmount = health / 100f;
        }
	}


} // class