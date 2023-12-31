using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickButtonVolume : MonoBehaviour
{
    public GameObject volumeText;
    public Button volume;
    public bool clicked;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        volume=GetComponent<Button>();
        this.volume.onClick.AddListener(settingVolume);
        this.volumeText=GameObject.Find("audio");
        volumeText.gameObject.SetActive(false);
        this.gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void settingVolume()
    {
        Debug.Log(volume.gameObject.name+" was clicked");
        if(clicked)
        {

            volumeText.gameObject.SetActive(true);
            clicked=false;

        }
        else
        {
            volumeText.gameObject.SetActive(false);
            clicked=true;
        }
        
    }
}
