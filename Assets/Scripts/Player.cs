using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov; //Ahora es visible entre los metodos
    CircleCollider2D attackCollider;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();

        attackCollider =transform.GetChild(0).GetComponent<CircleCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //Detectamos el movimiento en un vector 2D
        mov = new Vector2(
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical")
        );
        /*
        Vector3 mov = new Vector3( 
            Input.GetAxisRaw("Horizontal"),
            Input.GetAxisRaw("Vertical"),
            0
        );
        transform.position = Vector3.MoveTowards(
            transform.position,
            transform.position + mov,
            speed * Time.deltaTime
        );
        */
        if (mov != Vector2.zero){
        anim.SetFloat("movX", mov.x);
        anim.SetFloat("movY", mov.y);
        anim.SetBool("walking", true);
        }else{
            anim.SetBool("walking", false);
        }

        //Buscamos el estado actual miranod la informacion del animador
        AnimatorStateInfo stateInfo = anim.GetCurrentAnimatorStateInfo(0);
        bool attacking = stateInfo.IsName("PlayerAttack");
        //Detectamos el ataque, tiene prioridad por lo que va abajo del todo
        if (Input.GetKeyDown("space") && !attacking)
        {
            anim.SetTrigger("attacking");
        }
        
        //Vamos actualizando la posicion del vector de ataque
        if (mov != Vector2.zero) 
        {
            attackCollider.offset = new Vector2(mov.x/2, mov.y/2);
        }
    }
    void FixedUpdate(){
        //Nos movemos en el fixed por las fisicas
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
