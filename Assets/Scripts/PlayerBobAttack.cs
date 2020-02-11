using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBobAttack : MonoBehaviour
{
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRangeX;
    public float attackRangeY;
    public int damage;

    //State
    bool isAlive = true;


    //Cache ref.
    public Animator playerAnimator;


    // Start is called before the first frame update
    void Start()
    {
        playerAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (timeBtwAttack <= 0)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {

                playerAnimator.SetBool("SlapRight", true);
                Collider2D[] enemiesToDamage = Physics2D.OverlapBoxAll(attackPos.position, new Vector2(attackRangeX, attackRangeY), 0, whatIsEnemies);

             
              
                    for (int i = 0; i < enemiesToDamage.Length; i++)
                    {

                        enemiesToDamage[i].GetComponent<Mosquito>().TakeDamage(damage);
                        enemiesToDamage[i].GetComponent<Mosquito>().TakeDamage(damage);
                       }
         
            }
            else if (Input.GetKeyUp(KeyCode.Space))
            {
                playerAnimator.SetBool("SlapRight", false);
            }
            timeBtwAttack = startTimeBtwAttack;
        }
        else
        {

            timeBtwAttack -= Time.deltaTime;
        }


        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.red;
            Gizmos.DrawWireCube(attackPos.position, new Vector3(attackRangeX, attackRangeY, 1));
        }
    }
}
