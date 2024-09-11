using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Buttons : MonoBehaviour
{
    AccessMap map;
    ChooseNumber value;
    [SerializeField]
    Button hit, stay, restart;
    [SerializeField]
    GameObject hitObj, stayObj, restartObj;
    void Start()
    {
        map = GameObject.Find("SmallMap").GetComponent<AccessMap>();
        value = GameObject.Find("Test").GetComponent<ChooseNumber>();

        hit.onClick.AddListener(map.CloseMap);
        hit.onClick.AddListener(value.HitMe);

        stay.onClick.AddListener(map.StayUp);

        restartObj.SetActive(false);
        restart.onClick.AddListener(map.RestartGame);
    }

    
    void Update()
    {
        if(map.win || map.lose){
            hitObj.SetActive(false);
            stayObj.SetActive(false);
            restartObj.SetActive(true);
        }
    }
}
