using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
namespace SupSystem
{
    public class SoundController : MonoBehaviour
    {
        // Start is called before the first frame update
        public List<AudioClip> BGM;
        public List<AudioClip> SE;
        public List<AudioClip> Sound;
        public List<AudioClip> Special;
        public bool WipSence;
        public List<GameObject> playingAudio;
        [SerializeField] GameObject AudioSource;
        [SerializeField] AudioMixer Mixer;
        void Start()
        {

            
            
            if (FindObjectsByType<SoundController>(0).Length > 1)
            {
                Destroy(gameObject);
            }
            if (WipSence)
            {
                DontDestroyOnLoad(gameObject);
            }
        }
        
        // Update is called once per frame
        public void PlayAudio(AudioClip sound, AudioType audioType, bool isLoop = false)
        {
            GameObject audio = Instantiate(AudioSource,transform);
            AudioSource source = audio.GetComponent<AudioSource>();
            source.outputAudioMixerGroup = Mixer.FindMatchingGroups(Enum.GetName(typeof(AudioType), audioType))[0];
            source.loop = isLoop;
            source.clip = sound;
            source.Play();

        }
        public void PlayAudio(string sound, AudioType audioType, bool isLoop = false)
        {
            GameObject audio = Instantiate(AudioSource, transform);
            AudioSource source = audio.GetComponent<AudioSource>();
            source.outputAudioMixerGroup = Mixer.FindMatchingGroups(Enum.GetName(typeof(AudioType), audioType))[0];
            source.loop = isLoop;
            List<AudioClip> TargetList=null;
            switch (audioType)
            {
                
                case AudioType.BGM:
                    TargetList = BGM;
                    break;
                case AudioType.SE:
                    TargetList = SE;

                    break;
                case AudioType.Sound:

                    TargetList = Sound;
                    break;
                case AudioType.Special:
                    TargetList = Special;
                    break;
                default:
                    Debug.LogError("Don't input other type without List.");
                    break;
            }
            foreach (AudioClip clip in TargetList)
            {
                if (sound == clip.name)
                {
                    source.clip = clip;
                    break;
                }
            }
            if (source.clip == null)
            {
                Debug.LogWarning("Can't find the music in this list.");
            }
            source.Play();

        }
        public void ControllMixerVolume(AudioType audioType, float vol)
        {
            Mixer.SetFloat(Enum.GetName(typeof(AudioType), audioType) + "Vol", vol);
        }
        public enum AudioType
        {
            Master,
            BGM,
            SE,
            Sound,
            Special
        }
    }
}