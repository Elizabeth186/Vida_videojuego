using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class personaje : MonoBehaviour
{    
     public GameObject bala;
    public float speed;
    public float Jumpfuerza;
    private Rigidbody2D Rigidbody2D;
    private Animator Animator;
    private float Horizontal;
    private bool Grounded;
private float tiempodedisparo;
private int Health  = 5;
   
    // Start is called before the first frame update
    void Start()
    {
      Rigidbody2D = GetComponent<Rigidbody2D>(); 
      Animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Horizontal = Input.GetAxisRaw("Horizontal");

        if(Horizontal < 0.0f)
        { transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
        }
        else if (Horizontal > 0.0f){ transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);

        }

        Animator.SetBool("correr", Horizontal != 0.0f); 
        Debug.DrawRay(transform.position, Vector3.down * 0.1f, Color.red);
         if(Physics2D.Raycast(transform.position, Vector3.down, 0.1f))
         {
            Grounded = true;
         }else Grounded = false;
         if(Input.GetKeyDown(KeyCode.W) && Grounded)
         {
            Jump();
         }
         if(Input.GetKey(KeyCode.Space) && Time.time > tiempodedisparo + 0.25)
         {
            Shoot();
            tiempodedisparo = Time.time;
         }
    }

private void Jump()
{
    Rigidbody2D.AddForce(Vector2.up * Jumpfuerza);
}


private void Shoot(){

   Vector3 direction;
   if(transform.localScale.x == 1.0f){
    direction = Vector3.right;
   }else{
    direction = Vector3.left;
   }

   GameObject balas = Instantiate(bala, transform.position + direction * 0.2f, Quaternion.identity);
   balas.GetComponent<disparo>().SetDirection(direction);
}
    private void FixedUpdate() {
        Rigidbody2D.velocity = new Vector2(Horizontal, Rigidbody2D.velocity.y);
    }
public void Hit() {
    {
        Health = Health -1;
        if(Health == 0){
            Destroy(gameObject);
        }
    }
}
}
