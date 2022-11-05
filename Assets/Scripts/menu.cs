using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class menu : MonoBehaviour
{

    public bool pasarnivel;
    public int indicemenu;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
         if(pasarnivel)
        {
        jugar(indicemenu);
        }
    }

    public void jugar(int indicemenu)
    {
        SceneManager.LoadScene(indicemenu);
    }

   
}
