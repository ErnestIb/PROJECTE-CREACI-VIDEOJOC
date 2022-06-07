using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using Random = UnityEngine.Random;

public class AudioManager : MonoBehaviour
{

    public static AudioManager Instance;

    [SerializeField, Range(0, 1)]
    private float GlobalVolumen_Music;
    [SerializeField, Range(0, 1)]
    private float GlobalVolumen_SFX;

    [SerializeField]
    private AudioSource _audioSourceSFX;
    [SerializeField]
    private AudioSource _audioSourceMusic;

    [SerializeField]
    List<AudioFile> AudioFiles;

    // Start is called before the first frame update
    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

    }


    public static void PlaySound(string v, AudioSource sourceObject = null)
    {
        Instance._PlaySound(v, sourceObject);
    }

    private void _PlaySound(string s, AudioSource sourceObject)
    {
        var file = FindFileByName(s);
        if (file == null)
        {
            Debug.LogError("No existeix aquest fitxer");
            return;
        }

        var source = sourceObject != null ? sourceObject : _audioSourceSFX;
        source.clip = file.GetClip();
        source.volume = file.Volume * GlobalVolumen_SFX;
        source.Play();
    }

    private AudioFile FindFileByName(string s)
    {
        return AudioFiles.First(file => file.Name == s);

        //for (int i = 0; i < AudioFiles.Count; i++)
        //{
        //    if (AudioFiles[i].Name == s)
        //        return AudioFiles[i];
        //}
    }

    // Update is called once per frame

}

[System.Serializable]
public class AudioFile
{
    public string Name;
    public AudioClip[] Clip;
    [Range(0, 1)]
    public float Volume = 0.7f;

    public AudioClip GetClip()
    {
        int rdm = Random.Range(0, Clip.Length);
        return Clip[rdm];
    }
}
//Awa de uwu
