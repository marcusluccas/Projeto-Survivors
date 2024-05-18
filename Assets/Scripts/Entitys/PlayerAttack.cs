using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject myProjectile;
    float attackRange;
    float attackSpeed;
    float timer = 0;
    bool canAttack = false;
    GameObject targetEnemy;

    // Start is called before the first frame update
    void Start()
    {
        attackRange = this.gameObject.GetComponent<EntityStats>().attackRange;
        attackSpeed = this.gameObject.GetComponent<EntityStats>().attackSpeed;
    }

    // Update is called once per frame
    void Update()
    {
        Shot();
    }

    void Shot()
    {
        if (Input.GetMouseButton(0) && canAttack && targetEnemy != null)
        {
            GameObject newProjectile = Instantiate(myProjectile, this.gameObject.transform.position, Quaternion.identity);
            Vector3 directionProjectile = targetEnemy.transform.position - transform.position;
            directionProjectile.Normalize();

            newProjectile.GetComponent<Rigidbody2D>().velocity = directionProjectile * attackRange;
            timer = 0;
            canAttack = false;
            Destroy(newProjectile, 6);
        }

        if (targetEnemy == null)
        {
            targetEnemy = FindNearestEnemy();
        }

        Cooldown();
    }

    void Cooldown()
    {
        timer += Time.deltaTime;

        if (timer >= attackSpeed)
        {
            canAttack = true;
        }
    }

    GameObject FindNearestEnemy()
    {
        GameObject[] enemys = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject nearestEnemy = enemys[0];

        for (int i = 0; i < enemys.Length; i++)
        {
            float distanceNearestEnemy = Vector2.Distance(this.gameObject.transform.position, nearestEnemy.transform.position);
            float distanceEnemy = Vector2.Distance(this.gameObject.transform.position, enemys[i].transform.position);
            if (distanceEnemy < distanceNearestEnemy)
            {
                nearestEnemy = enemys[i];
            }
        }

        return nearestEnemy;
    }
}
