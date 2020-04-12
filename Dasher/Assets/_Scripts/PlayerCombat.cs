using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    //Set to display sword by default
    public static int currentWeapon = 1;
    public GameObject sword, gun;
    public LineRenderer burst;

    //For animations
    public Animator animator;

    //Start point for all attacks
    public Transform attackPoint;

    public static float swordAttackRange = 0.5f;


    public static float attackRate = 2f;
    public static float nextAttackTime = 0f;


    public LayerMask enemiesLayer;
    public static int attackDamage = 5;

    public GameObject bulletPrefab;


    void Start()
    {
        //Controls what weapons are displayed by defualt
        sword.SetActive(true);
        gun.SetActive(false);
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetMouseButton(0))
            {
                attack();
                //Resets attack timer
                nextAttackTime = Time.time + 1f / attackRate;
            }
        }

        //Weapon switches If press 1 then sword, 2 then gun, 3 then burst
        if (Input.GetKeyDown(KeyCode.Alpha1) && currentWeapon != 1)
        {
            switchWeapon(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2) && currentWeapon != 2)
        {
            switchWeapon(2);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3) && currentWeapon != 3)
        {
            switchWeapon(3);
        }
    }

    void attack()
    {
        //Checks what attack to do based on what weapon is equipped
        if (currentWeapon == 1)
        {
            swordAttack();
        }
        if (currentWeapon == 2)
        {
            gunAttack();
        }
        if (currentWeapon == 3)
        {
            //Enabled line renderer so it can be seen
            burst.enabled = true;
            StartCoroutine(burstAttack());
        }
    }

    void switchWeapon(int weaponSelection)
    {
        //Put current weapon away
        switch (currentWeapon)
        {
            case 1: //Animation here
                sword.SetActive(false);
                break;
            case 2: //Animation here
                gun.SetActive(false);
                break;
            case 3: //Animation here
                //burst.SetActive(false);
                break;
            default: break;
        }

        //Get weapon selection out
        switch (weaponSelection)
        {
            case 1: //Animation here
                sword.SetActive(true);
                attackDamage = 5;
                attackRate = 2f;
                nextAttackTime = 0f;
                break;
            case 2: //Animaton here
                gun.SetActive(true);
                attackDamage = 3;
                attackRate = 4f;
                nextAttackTime = 0f;
                break;
            case 3: //Animation here
                //burst.SetActive(true);
                attackDamage = 10;
                attackRate = 0.25f;
                nextAttackTime = 0f;
                break;
        }

        //Update current wepon
        currentWeapon = weaponSelection;
    }

    void swordAttack()
    {

        //animator.SetTrigger("Sword Attack");
        //Damages all enemies within Circle
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, swordAttackRange, enemiesLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<EnemyClass>().takeDamage(attackDamage);
        }
    }

    void gunAttack()
    {
        //Fires a bullet
        //Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
    }

    //Uses raycasting to trace a path either to hit object or out into distance
    //IEnumerator is only so I can make the burst effect last temporarily before being gone
    IEnumerator burstAttack()
    {
        //What you hit. (Enemies, Obstacles, and the like)
        RaycastHit2D hitInfo;
        if (TestDummyContorller.facingRight)
        {
            hitInfo = Physics2D.Raycast(attackPoint.position, attackPoint.right);
        }

        else
        {
            hitInfo = Physics2D.Raycast(attackPoint.position, attackPoint.right * -1);
        }

        //If you hit an enemy do damage and draw the ray to hit enemy
        if (hitInfo)
        {
            EnemyClass enemy = hitInfo.transform.GetComponent<EnemyClass>();
            //If enemy was hit they take damage
            if (enemy != null)
            {
                enemy.takeDamage(attackDamage);
            }
            //Creates line from attackPoint to enemy
            burst.SetPosition(0, attackPoint.position);
            burst.SetPosition(1, hitInfo.point);
            //Makes line last temporarily
            yield return new WaitForSeconds(.2f);

        }

        else
        {
            //If no enemy is hit it travels onwards till it is disabled after wait for seconds
            burst.SetPosition(0, attackPoint.position);
            if (TestDummyContorller.facingRight)
            {
                Debug.Log(TestDummyContorller.facingRight);
                burst.SetPosition(1, attackPoint.position + attackPoint.right * 100);
            }
            else
            {
                Debug.Log(TestDummyContorller.facingRight);
                burst.SetPosition(1, attackPoint.position + attackPoint.right * -100);
            }
            yield return new WaitForSeconds(.2f);
        }

        //Line renderer is disabled
        burst.enabled = false;
    }

    void OnDrawGizmosSelected()
    {
        //Just so we can see how big the size needs to be
        Gizmos.DrawWireSphere(attackPoint.position, swordAttackRange);
    }
}