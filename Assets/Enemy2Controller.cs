using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy2Controller : MonoBehaviour {

    private PlayerController thePlayer;
    public float moveSpeed;
    public float playerRange;
    public LayerMask playerLayer;

    public bool playerInRange;
    public bool facingAway;

    public bool followOnLookAway;

    void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    void Update()
    {

        playerInRange = Physics2D.OverlapCircle(transform.position, playerRange, playerLayer);

        if (!followOnLookAway)
        {
            if (playerInRange)
            {
                transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
                return;
            }
        }

        if((thePlayer.transform.position.x < transform.position.x && thePlayer.transform.localScale.x < 0) || (thePlayer.transform.position.x > transform.position.x && thePlayer.transform.localScale.x > 0))
        {
            facingAway = false;
        }else
        {
            facingAway = true;
        }

        //if(playerInRange && facingAway)
        if (playerInRange)
        {
            transform.position = Vector3.MoveTowards(transform.position, thePlayer.transform.position, moveSpeed * Time.deltaTime);
        }

    }

    void OnDrawGizmosSelected(){

        Gizmos.DrawSphere(transform.position, playerRange);

    }

}
