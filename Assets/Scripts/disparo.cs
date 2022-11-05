using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class disparo : MonoBehaviour
{
    public float Speed;
    public AudioClip Sound;
    private Rigidbody2D Rigidbody2D;
    private Vector3 Direction;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D = GetComponent<Rigidbody2D>();
        Camera.main.GetComponent<AudioSource>().PlayOneShot(Sound);
    }

    // Update is called once per frame
    private void FixedUpdate() {
   Rigidbody2D.velocity = Direction * Speed;     
    }

    public void SetDirection(Vector2 direction) {
        
            Direction = direction;
        
    }

    public void Destroybala()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
         personaje persona =   collision.GetComponent<personaje>();
       villano vill = collision.GetComponent<villano>();
   
   if( persona != null)
   {
    persona.Hit();
   }
   if(vill != null)
    {
        vill.Hit();
    }  

    Destroybala(); 
    }

    }
