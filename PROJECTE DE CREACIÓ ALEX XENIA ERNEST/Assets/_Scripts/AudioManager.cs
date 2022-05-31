using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

//public class AudioManager : MonoBehaviour
//{

//    public static AudioManager Instance;  //singleton

//    [SerializeField] private AudioSource _audioSource;


    
//    void Awake()
//    {

//        if (Instance)
//        {
//            Instance = this;
//        }
//        else
//        {
//            Destroy(gameObject);
//        }

//    }

//    private void Start()
//    {
//        _audioSource = gameObject.GetComponent<AudioSource>();
//    }

//    public static void PlaySound(string v)
//    {
//        Instance._PlaySound(v);
//    }

//    private void _PlaySound(string v)
//    {
        
//    }

//    // Update is called once per frame
//    void Update()
//    {
//        AudioManager.PlaySound("s");
//    }
//}
