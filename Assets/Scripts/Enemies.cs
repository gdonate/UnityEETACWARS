using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float visionRadius;
    public float speed;
    public float attackRadius;
    
    public float attackSpeed;
    public GameObject rockPrefab;
        
    bool attacking;

    GameObject player;

    Animator anim;

    Vector3 initialPosition;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        initialPosition = transform.position;
       
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 target = initialPosition;

        float dist = Vector3.Distance(player.transform.position, transform.position);
        Vector3 dir = (target - transform.position).normalized;
        
        // Si el Raycast encuentra al jugador lo ponemos de target
       
        if (dist < visionRadius)
        {
            target = player.transform.position;

            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);
            
        } 
        
             
        float fixedSpeed = speed*Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, target, fixedSpeed);
 
        Debug.DrawLine(transform.position, target, Color.green);
    }

    void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, visionRadius);
        Gizmos.DrawWireSphere(transform.position, attackRadius);
        
    }

    void Attack(float seconds)
    {
        attacking = true;

        if (target != initialPosition && rockPrefab != null)
        {
            Instantiate (rockPrefab, transform.position, transform.rotation);
            yield return new WaitForSeconds(seconds);

        }
        attacking = false;
    }
}
