using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackEffects : MonoBehaviour
{
    public GameObject spell1_Spawn, spell2_Spawn, staffAttack_Spawn, shield_Spawn, healFX_Spawn, thunderFX_Spawn;
    public GameObject spell1_Prefab, spell2_Prefab, staffAttack_Prefab, shield_Prefab,
        healFX_Prefab, thunderFX_Prefab;

    // Start is called before the first frame update

    void Spell1()
    {
        Instantiate(spell1_Prefab, spell1_Spawn.transform.position, Quaternion.identity);
    }

    void Spell2()
    {
        Instantiate(spell2_Prefab, spell2_Spawn.transform.position, Quaternion.identity);
	}
	void StaffAttack()
    {
        Instantiate(staffAttack_Prefab, staffAttack_Spawn.transform.position, Quaternion.identity);
    }
    void Punch()
    {   //punch is shield
        Instantiate(shield_Prefab, shield_Spawn.transform.position, Quaternion.identity);
    }
    void Heal()
    {
        Instantiate(healFX_Prefab, healFX_Spawn.transform.position, Quaternion.identity);
    }
    void GroundImpact()
    {
        Instantiate(thunderFX_Prefab, thunderFX_Spawn.transform.position, Quaternion.identity);
    }


}
