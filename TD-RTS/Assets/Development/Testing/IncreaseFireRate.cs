using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IncreaseFireRate : MonoBehaviour {

    public float fireRateMultiplier = 1;
    public float range = 5f;
	
	// Update is called once per frame
	void Update () {
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(transform.position, range);

        for (int i = 0; i < hitColliders.Length; i++)
        {
            if (hitColliders[i].GetComponent<Tower>() != null)
            {
                hitColliders[i].GetComponent<Tower>().EnhancedFireRate(fireRateMultiplier);
                Debug.Log("Enhanced");
            }
        }

        /*foreach (Collider2D col in hitColliders)
        {
            if (col.GetComponent<Tower>() != null)
            {
                col.gameObject.GetComponent<Tower>().EnhancedFireRate(fireRateMultiplier);
                Debug.Log("Enhanced");
            }
            else
            {
                Debug.Log("Broke");
            }
        }*/
    }



    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
