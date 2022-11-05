using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camara : MonoBehaviour
{
    // Start is called before the first frame update
  public GameObject personaje;

    // Update is called once per frame
    void Update()
    {

if(personaje != null){
        Vector3 position = transform.position;
        position.x = personaje.transform.position.x;
        transform.position = position;
        
    }
    }
}
