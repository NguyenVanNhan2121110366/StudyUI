using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public Rigidbody target;
    float posY=10f;
    float posYY=13.5f;
    float torque=10f;
    float posItem=3.5f;
    float ySpawpos = 0f;
    public GameManager gamemanagerr;
    public ParticleSystem particlesystem;
    // Start is called before the first frame update
    void Start()
    {
        this.target = GetComponent<Rigidbody>();

        this.target.AddForce(targetforce(),ForceMode.Impulse);
        this.target.AddTorque(targetTorque(),targetTorque(),targetTorque(),ForceMode.Impulse);
        //Vector3 pos = targetpos();
        transform.position = targetpos();
        this.gamemanagerr=GameObject.Find("Game Manager").GetComponent<GameManager>();
        
    }

    Vector3 targetforce()
    {
        return Vector3.up*Random.Range(posY,posYY);
    }

    float targetTorque()
    {
        return Random.Range(-torque,torque);
    }

    Vector3 targetpos()
    {
        return new Vector3(Random.Range(-posItem,posItem),ySpawpos);
    }

    void destroyObject()
    {
        if(gamemanagerr.ggameOver==false)
        {
            Destroy(gameObject);
            Instantiate(particlesystem,transform.position,particlesystem.transform.rotation);
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.destroyObject();
    }
}
