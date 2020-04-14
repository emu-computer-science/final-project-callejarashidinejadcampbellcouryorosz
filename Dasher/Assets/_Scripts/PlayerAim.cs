using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAim : MonoBehaviour
{
    public float offset;
    public GameObject bulletPrefab;
    public Transform shotPoint;

    private float timeBtwnShots;
    public float startTimeBtwnShots;

    void Update()
    {
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + offset);

        if (timeBtwnShots <= 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                Instantiate(bulletPrefab, shotPoint.position, shotPoint.rotation);
                timeBtwnShots = startTimeBtwnShots;
            }
        }
        else
        {
            timeBtwnShots -= Time.deltaTime;
        }

    }

}
