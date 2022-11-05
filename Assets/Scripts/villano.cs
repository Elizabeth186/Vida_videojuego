using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class villano : MonoBehaviour
{
    public GameObject bala;
    public GameObject personaje;
    private float LastShoot;
    private int Health = 3;
    // Update is called once per frame
   private void Update()
    {

        if(personaje == null) return;
      Vector3 direction = personaje.transform.position - transform.position;
if(direction.x >= 0.0f){ transform.localScale = new Vector3(1.0f,1.0f, 1.0f);}
    else{
        transform.localScale = new Vector3(-1.0f, 1.0f, 1.0f);
    }
    
    float distance = Mathf.Abs(personaje.transform.position.x - transform.position.x);

    if(distance < 1.0f && Time.time > LastShoot + 1f)
    {
        Shoot();
        LastShoot = Time.time;
    }
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

public void Hit() {
    {
        Health = Health -1;
        if(Health == 0){
            Destroy(gameObject);
        }
    }
}


    }

