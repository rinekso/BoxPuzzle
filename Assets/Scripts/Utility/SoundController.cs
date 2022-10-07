using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundController : MonoBehaviour
{
    public static SoundController Instance;
    [SerializeField]
    List<AudioClip> listSoundEffect;
    [SerializeField]
    AudioSource effect;
    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }
    public void PlayEffect(int index){
        if(!effect.isPlaying){
            effect.clip = listSoundEffect[index];
            effect.Play();
        }
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
