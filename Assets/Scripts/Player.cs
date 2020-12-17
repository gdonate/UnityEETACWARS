using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 3f;
    Animator anim;
    Rigidbody2D rb2d;
    Vector2 mov; //Ahora es visible entre los metodos
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
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
        anim.SetFloat("movX", mov.x);
        anim.SetFloat("movY", mov.y);
        
    }
    void FixedUpdate(){
        //Nos movemos en el fixed por las fisicas
        rb2d.MovePosition(rb2d.position + mov * speed * Time.deltaTime);
    }
}
