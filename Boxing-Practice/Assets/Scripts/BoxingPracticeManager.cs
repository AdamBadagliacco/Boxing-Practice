using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingPracticeManager : MonoBehaviour
{
    public List<GameObject> BoxingAttacks;
    public List<GameObject> Rolls;

    [Tooltip("Pick one of below three")]
    [Header("Audio Cue Of Attacks")]
    public bool numbers;
    public bool names;

    [Header("Other Attack Variables")]
    public float speed;
    public bool rollsOn;
    public bool speedIncreases;
    public float speedIncreaseAmount;
    
    [Header("Combos (Not yet supported)")]
    public bool combosOn;
    public int amountOfCombos;
    public int hitsPerCombo;

    // Start is called before the first frame update
    void Start()
    {
        if(rollsOn){
            BoxingAttacks.AddRange(Rolls);

        }
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

            if(numbers && names){
                int nameOrNumber = Random.Range(0, 2);
                if(nameOrNumber == 0){
                    PlaySoundEffectNumber(NextAttack);  
                }
                else if(nameOrNumber == 1){
                    PlaySoundEffectName(NextAttack);  
                }
                else{
                    throw new System.ArgumentException("Random number should be either 0 or 1");
                }
            }
            else if(names){
               PlaySoundEffectName(NextAttack);  
            }
            else if(numbers){
               PlaySoundEffectNumber(NextAttack);  
            }
            else{
                throw new System.ArgumentException("Either name or number audio cue must be turned on");
            }

             yield return new WaitForSeconds(speed);
             if(speedIncreases){
                 speed =- speedIncreaseAmount;
             }
        }
    }
}
