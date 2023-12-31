using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class random : MonoBehaviour
{
    public GameObject []prefab;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("spawnrandom",0.5f,1f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    protected void spawnrandom()
    {
        int index=Random.Range(0,this.prefab.Length);
        Instantiate(this.prefab[index],new Vector3(0,0,0),this.prefab[index].transform.rotation);
    }
}
