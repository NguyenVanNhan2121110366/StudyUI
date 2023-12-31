using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DifficultButton : MonoBehaviour
{
    [SerializeField] private Button button;
    [SerializeField] private GameManager gamemanage;
    [SerializeField] private int difficult;
    // Start is called before the first frame update
    void Start()
    {
        this.button = GetComponent<Button>();
        this.button.onClick.AddListener(SetDifficult);
        this.gamemanage = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void SetDifficult()
    {
        Debug.Log(button.gameObject.name + " was clicked");
        this.gamemanage.StartGame(difficult);
    }
}
