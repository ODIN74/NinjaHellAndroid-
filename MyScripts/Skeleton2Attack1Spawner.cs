using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton2Attack1Spawner : MonoBehaviour {

    public GameObject WeaponForFarAttack;

    private bool weaponStart = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (GetComponentInParent<Skeleton2>().farAttack)
        {
            if (!weaponStart)
            {
                weaponStart = true;
                StartCoroutine(FarAttack());
            }
        }
        else
        {
            StopCoroutine(FarAttack());
            weaponStart = false;
        }
	}

    IEnumerator FarAttack()
    {
        while (weaponStart)
        {
            yield return new WaitForSeconds(1f);
            Instantiate(WeaponForFarAttack, transform);
        }
    }
}
