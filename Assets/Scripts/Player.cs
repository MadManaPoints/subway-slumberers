using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour
{
    ChooseNumber num;
    [SerializeField]
    GameObject upperEyelid, lowerEyelid;
    Vector2 upperEyePos;
    Vector2 lowerEyePos;

    Vector2 startPos1;
    Vector2 startPos2;
    float speed = 10.0f;
    float openThreshold = 8.5f;
    public bool sleeping;
    public bool eyesOpen, eyesClosed;
    void Start()
    {
        num = GameObject.Find("Test").GetComponent<ChooseNumber>();

        upperEyePos = upperEyelid.transform.position;
        lowerEyePos = lowerEyelid.transform.position;
        startPos1 = upperEyelid.transform.position;
        startPos2 = lowerEyelid.transform.position;
    }

    
    void Update()
    {
        upperEyelid.transform.position = upperEyePos;
        lowerEyelid.transform.position = lowerEyePos;

        if(sleeping && eyesClosed && !num.aud.isPlaying){
            sleeping = false;
        }

        if(!sleeping){
            OpenEyes();
        } else{
            CloseEyes();
        }
    }

    void OpenEyes(){
        if(upperEyePos.y < openThreshold){
                upperEyePos.y += speed * Time.deltaTime;
            } else{
                upperEyePos.y = openThreshold;
            }
            if(lowerEyePos.y > -openThreshold){
                lowerEyePos.y -= speed * Time.deltaTime;
            } else{
                lowerEyePos.y = -openThreshold;
            }

        if(upperEyePos.y == openThreshold && lowerEyePos.y == -openThreshold){
            eyesOpen = true;
            eyesClosed = false;
        }
    }

    void CloseEyes(){
        if(upperEyePos.y > startPos1.y){
            upperEyePos.y -= speed * Time.deltaTime;
        } else{
            upperEyePos.y = startPos1.y;
        }
        if(lowerEyePos.y < startPos2.y){
            lowerEyePos.y += speed * Time.deltaTime;
        } else{
            lowerEyePos.y = startPos2.y;
        }

        if(upperEyePos.y == startPos1.y && lowerEyePos.y == startPos2.y){
            eyesClosed = true;
            eyesOpen = false;
        }
    }
}
