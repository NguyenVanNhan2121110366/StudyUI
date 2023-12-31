using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ClickButtonPause : MonoBehaviour
{
    public Button pauseText;
    public GameManager gamemanager;
    // Start is called before the first frame update
    void Start()
    {
        this.pauseText=GetComponent<Button>();
        pauseText.onClick.AddListener(ckeckButton);
        this.gamemanager=GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void ckeckButton()
    {
        Debug.Log(pauseText.gameObject.name+ " was clicked");
        this.gamemanager.pauseGame();
    }
}
