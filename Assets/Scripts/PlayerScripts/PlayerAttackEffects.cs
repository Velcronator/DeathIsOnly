using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject groundImpact_Spawn, punchFX_Spawn, fireTornado_Spawn, fireShield_Spawn;
    public GameObject groundImpact_Prefab, punchFX_Prefab, fireTornado_Prefab, fireShield_Prefab,
        healFX_Prefab, thunderFX_Prefab;

    // Start is called before the first frame update

    void Spell1()
    {
        Instantiate(fireTornado_Prefab, fireTornado_Spawn.transform.position, Quaternion.identity);
    }

    void Spell2()
    {
        Instantiate(thunderFX_Prefab, punchFX_Spawn.transform.position, Quaternion.identity);
	}
	void StaffAttack()
    {
        GameObject fireObj = Instantiate(fireShield_Prefab, fireShield_Spawn.transform.position,
                                 Quaternion.identity);
        fireObj.transform.SetParent(transform);
    }
    void Punch()
    {
        Instantiate(punchFX_Prefab, punchFX_Spawn.transform.position, Quaternion.identity);
    }
    void Heal()
    {
        Vector3 temp = transform.position;
        temp.y += 2f;
        GameObject healObj = Instantiate(healFX_Prefab, temp, Quaternion.identity) as GameObject;
        healObj.transform.SetParent(transform);
    }
    void GroundImpact()
    {
        Instantiate(groundImpact_Prefab, groundImpact_Spawn.transform.position, Quaternion.identity);
    }


}
