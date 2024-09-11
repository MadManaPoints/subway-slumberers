using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChooseNumber : MonoBehaviour
{
    AccessMap map;
    // not accurate number for blackjack, but I'm accommodating for lack of dealer 
    private int[] cards = {1, 1, 2, 2, 2, 3, 3, 3, 4, 4, 4, 5, 5, 5, 6, 6, 6, 7, 7, 7, 8, 8, 8, 9, 9, 9, 10, 10, 10, 10, 10, 10, 10, 10, 10};
    private bool[] cardsUsed = new bool[35];
    [SerializeField]
    private int number;
    private int rando;
    private int index = 0;
    public int value = 0;
    public AudioSource aud;
    void Start()
    {
        map = GameObject.Find("SmallMap").GetComponent<AccessMap>();
        aud = GetComponent<AudioSource>();
        // sets all cards to unused(false)
        for(int i = 0; i < cards.Length; i++){
            cardsUsed[i] = false;
        }
    }

    void Update()
    {
        //print(aud.isPlaying);
    }

    public void HitMe(){
        if(index < 35){
            aud.Play();
            // index will keep the whileloop from breaking once all cards are used
            index++;
            rando = PickRandomNumber();
            MarkUsedCard(rando);
            value = cards[rando];
            //print(value);
            map.stationIndex += value;
            map.stopsLeft -= value;
        }
    }

    void MarkUsedCard(int n){
        // will mark that number as used in bool array
        for(int i = 0; i < cards.Length; i++){
            cardsUsed[n] = true;
        }
    }

    int PickRandomNumber(){
        // will choose a random item from the cards array
        // won't pick same item twice
        do{
            number = UnityEngine.Random.Range(0, cards.Length);
        } while(cardsUsed[number]);
        
        return number;
    }
}
