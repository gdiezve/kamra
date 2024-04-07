using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class AudioManager : MonoBehaviour
{
    public AudioListener audioListener;
    
    // Start is called before the first frame update
    void Start()
    {
        audioListener.enabled = true;
    }
}
