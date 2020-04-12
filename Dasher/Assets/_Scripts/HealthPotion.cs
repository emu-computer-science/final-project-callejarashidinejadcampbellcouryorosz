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
        hp = player.GetComponent<TestDummyContorller>().hp;
        maxhp = player.GetComponent<TestDummyContorller>().maxhp;
    }

    public void Use()
    {
        player.GetComponent<TestDummyContorller>().hp = maxhp;
        Destroy(gameObject);
    }
}
