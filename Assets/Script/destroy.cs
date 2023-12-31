using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class destroy : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // this.des();
    }
    // protected void des()
    // {
    //     if(transform.position.y<-1)
    //     {
    //         Destroy(gameObject);
    //     }
    // }
    void OntriggerEnter(Collider other)
    {
        if(gameObject.CompareTag("Bad"))
        {
            Destroy(gameObject);
        }
    }
}
