using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxingAttack : MonoBehaviour
{
    public string attackName;
    public string attackNumber;

    //Sound Effect
    public GameObject SoundEffectName;
    public GameObject SoundEffectNumber;

    public void PlaySoundEffectName()
    {
        float soundEffectLength = SoundEffectName.GetComponent<AudioSource>().clip.length;
        GameObject soundEffectInstance = Instantiate(SoundEffectName, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(soundEffectInstance, soundEffectLength);
    }

     public void PlaySoundEffectNumber()
    {
        float soundEffectLength = SoundEffectNumber.GetComponent<AudioSource>().clip.length;
        GameObject soundEffectInstance = Instantiate(SoundEffectNumber, new Vector3(0, 0, 0), Quaternion.identity);
        Destroy(soundEffectInstance, soundEffectLength);
    }


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
