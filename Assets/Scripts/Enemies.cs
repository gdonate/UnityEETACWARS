using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemies : MonoBehaviour
{

    public float visionRadius;
    public float speed;
    public float attackRadius;
    

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
        if (dist < visionRadius)
        {
            target = player.transform.position;

            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.SetBool("walking", true);
        } 
        if (target != initialPosition && dist < attackRadius){
            // Aquí le atacaríamos, pero por ahora simplemente cambiamos la animación
            anim.SetFloat("movX", dir.x);
            anim.SetFloat("movY", dir.y);
            anim.Play("Enemy_Walk", -1, 0);  // Congela la animación de andar
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
}
