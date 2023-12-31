using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickDestroy : MonoBehaviour
{
   public ParticleSystem explosionParticle;
   public int point;
   public int sender;
   GameManager gamemanager;
   void Start()
   {
      this.gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
   }
   void OnMouseDown()
   {
       if(gameObject.CompareTag("Bad")&&gamemanager.ggameOver&&gamemanager.live==0)
        {
          gamemanager.gameOver();
          //gamemanager.ggameOver=false;
        }
        
   }
   void OnTriggerEnter(Collider other)
   {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad")&&gamemanager.ggameOver)
        {
            //gamemanager.gameOver();
            //gamemanager.ggameOver=false;
            gamemanager.livesPlayer(1);
            
        }
   }
   public void destroyTarget()
    {
        Destroy(gameObject);
        gamemanager.scoreUpdate(point);
        Instantiate(explosionParticle,transform.position,explosionParticle.transform.rotation);
        gamemanager.livesPlayer(sender);
        
    }
}
