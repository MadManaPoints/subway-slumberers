using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class AccessMap : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text, endText;
    AccessMap map;
    Player player;
    ChooseNumber num;
    [SerializeField]
    GameObject bigMap;
    bool canClick;
    bool bigMapActive;
    public bool win, lose;
    public int stationIndex = 0;
    public int stopsLeft = 21;
    float targetTime = 0.5f;
    [SerializeField]
    GameObject[] stations;
    Color col = Color.green;
    [SerializeField]
    Slider slider;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<Player>();
        bigMap.SetActive(false);
        endText.text = "";
    }

    
    void Update()
    {
        if(stopsLeft < 0){
            endText.text = "Missed your stop!";
            lose = true;
        } else if(stopsLeft == 0){
            win = true;
            endText.text ="Perfect!";
        }

        if(stationIndex > 22){
            stationIndex = 22;
            stopsLeft = -1;
        }

        text.text = stopsLeft.ToString();

        if(canClick && Input.GetMouseButtonDown(0) && !bigMapActive){
            bigMap.SetActive(true);
            bigMapActive = true;
        }

        ChangeStationColor();

        slider.value = stationIndex + 3;
    }

    void ChangeStationColor(){
        targetTime -= Time.deltaTime;
        if(targetTime < 0){
            if(col == Color.green){
                col = Color.white;
            } else{
                col = Color.green;
            }
            targetTime = 0.5f;
        }

        for(int i = 0; i < stations.Length; i++){
            if(i != stationIndex){
                stations[i].GetComponent<Image>().color = Color.white;
            } else{
                stations[i].GetComponent<Image>().color = col;
            }
        }
    }

    public void CloseMap(){
        //stationIndex += num.value; 
        bigMap.SetActive(false);
        bigMapActive = false;
        player.sleeping = true;
        
    }

    public void RestartGame(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StayUp(){
        endText.text = "Not risking it.";
        lose = true;
    }

    void OnMouseEnter(){
        canClick = true;
    }

    void OnMouseExit(){
        canClick = false;
    }
}
