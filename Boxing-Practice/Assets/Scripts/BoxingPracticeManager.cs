using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingPracticeManager : MonoBehaviour
{
    public List<GameObject> BoxingAttacks;

    [Tooltip("Pick one of below three")]
    [Header("Audio Cue Of Attacks")]
    public bool numbers;
    public bool names;
    public bool both;

    [Header("Other Attack Variables")]
    public bool rollsOn;
    public bool speedIncreases;
    public float speed;
    
    [Header("Combos")]
    public bool combosOn;
    public int amountOfCombos;
    public int hitsPerCombo;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartBoxingPractice());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetRandomAttack(){
        int randomNumber = Random.Range(0, BoxingAttacks.Count);
        return BoxingAttacks[randomNumber];
    }

    public void PlaySoundEffectName(GameObject NextAttack){
        Debug.Log(NextAttack.GetComponent<BoxingAttack>().attackName);                 
        //Play Attack Name
        //NextAttack.GetComponent<BoxingAttack>()PlaySoundEffectName();
    }

    public void PlaySoundEffectNumber(GameObject NextAttack){
         Debug.Log(NextAttack.GetComponent<BoxingAttack>().attackNumber);           
                //Play Attack Number
                //NextAttack.GetComponent<BoxingAttack>()PlaySoundEffectNumber();
    }

    public IEnumerator StartBoxingPractice(){

        bool on = true;

        while(on){

            GameObject NextAttack = GetRandomAttack();

            if(numbers){
                PlaySoundEffectNumber(NextAttack);  
            }
            else if(names){
               PlaySoundEffectName(NextAttack);  
            }
            else{
                int nameOrNumber = Random.Range(0, 1);
                if(nameOrNumber == 0){
                    PlaySoundEffectNumber(NextAttack);  
                }
                else{
                    PlaySoundEffectName(NextAttack);  
                }
            }
             yield return new WaitForSeconds(speed);
             if(speedIncreases){
                 speed =- 0.2f;
             }
        }
    }
}
