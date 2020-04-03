using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCombat : MonoBehaviour
{
    public static int currentWeapon = 1;
    public GameObject sword, gun;
    public LineRenderer burst;
    public Animator animator;
    public Transform attackPoint;

    public static float swordAttackRange = 0.5f;

    public static float attackRate = 2f;
    public static float nextAttackTime = 0f;

    public LayerMask enemiesLayer;
    public static int attackDamage = 5;

    public GameObject bulletPrefab;



    void Start()
    {
        sword.SetActive(true);
        gun.SetActive(false);
        //burst.SetActive(false);
    }

    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                attack();
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
            burst.enabled = true;
            StartCoroutine(burstAttack());
        }
    }

    void switchWeapon(int weaponSelection)
    {
        //Add animations for switching weapons here
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

        currentWeapon = weaponSelection;
    }

    void swordAttack()
    {

        //animator.SetTrigger("Sword Attack");
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, swordAttackRange, enemiesLayer);
        for (int i = 0; i < hitEnemies.Length; i++)
        {
            hitEnemies[i].GetComponent<EnemyClass>().takeDamage(attackDamage);
        }
    }

    void gunAttack()
    {
        Instantiate(bulletPrefab, attackPoint.position, attackPoint.rotation);
    }

    IEnumerator burstAttack()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(attackPoint.position, attackPoint.right * -1);
        if (hitInfo)
        {
            EnemyClass enemy = hitInfo.transform.GetComponent<EnemyClass>();
            if (enemy != null)
            {
                enemy.takeDamage(attackDamage);
            }
            burst.SetPosition(0, attackPoint.position);
            burst.SetPosition(1, hitInfo.point);
            yield return new WaitForSeconds(.2f);

        }

        else
        {
            burst.SetPosition(0, attackPoint.position);
            burst.SetPosition(1, attackPoint.position + attackPoint.right * -100);
            yield return new WaitForSeconds(.2f);
        }

        burst.enabled = false;

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(attackPoint.position, swordAttackRange);
    }
}