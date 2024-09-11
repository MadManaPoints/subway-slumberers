using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField]
    GameObject bigMap;
    
    Player player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        //bigMap.SetActive(false);
    }

    void Update()
    {
        
    }
}
