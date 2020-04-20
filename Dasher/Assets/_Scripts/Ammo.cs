using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    private static GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Destroy(gameObject);
            player.GetComponent<OverhaulCombat>().currentAmmo += 10;
            Debug.Log(player.GetComponent<OverhaulCombat>().currentAmmo);
        }
    }
}
