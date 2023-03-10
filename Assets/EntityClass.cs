using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class EntityClass : MonoBehaviour
{
    private Hull hullScript;
    private int health;
    protected virtual int GetHealth(Transform entity)
    {
        health = 0;
        foreach (Transform child in entity)
        {
            if (child.CompareTag("Hull"))
            {
                hullScript = child.GetComponent<Hull>();
                health += hullScript.partHealth;
            }
        }
            return health;
    }
}
