using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPotion : MonoBehaviour
{
    private float hp;
    private float maxhp;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        hp = player.GetComponent<PlayerHealthManager>().hp;
        maxhp = player.GetComponent<PlayerHealthManager>().hp;
    }

    public void Use()
    {
        player.GetComponent<PlayerHealthManager>().hp = maxhp;
        Destroy(gameObject);
    }
}
