using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerAttack : MonoBehaviour
{
    public GameObject weaponPrefab;
    public Vector3 offset; 

    bool canAttack = true;
    bool isAttacking = false;

    public float cooldown; 
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && canAttack && !isAttacking)
        {
            StartCoroutine(Attack());
        }
    }

    IEnumerator Attack()
    {
        isAttacking = true; 

        canAttack = false; 
        GetComponent<playermovement>().canMove = false; 

        bool isLeft = GetComponent<playermovement>().isFacingLeft;
        Vector3 spawnPosition = transform.position + (isLeft ? -offset : offset);

        GameObject newWeapon = Instantiate(weaponPrefab, spawnPosition, Quaternion.identity);
        SpriteRenderer weaponRenderer = newWeapon.GetComponent<SpriteRenderer>();
        weaponRenderer.flipX = isLeft;
       
        yield return new WaitForSeconds(cooldown); 

        Destroy(newWeapon);

        canAttack = true; 
        isAttacking = false; 
        GetComponent<playermovement>().canMove = true; 
    }
}
