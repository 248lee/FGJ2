using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SupSystem
{
    public class VolumeController : MonoBehaviour
    {
        [SerializeField] SoundController.AudioType volumeName;
        // Start is called before the first frame update
        SoundController soundController;
        Slider volumeSlider;
        void Start()
        {
            soundController=FindObjectOfType<SoundController>();
            Debug.Log(soundController.gameObject.name);
            volumeSlider =GetComponent<Slider>();
            volumeSlider.minValue = -40;
            volumeSlider.maxValue = 0;
            VolumeChange();
        }

        // Update is called once per frame
        public void VolumeChange()
        {
            soundController.ControllMixerVolume(volumeName, volumeSlider.value);
        }
    }
}