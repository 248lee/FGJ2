using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace SupSystem
{
    public class TestScript : MonoBehaviour
    {
        // Start is called before the first frame update
        SoundController soundController;
        void Start()
        {
            soundController=FindObjectOfType<SoundController>();
        }

        // Update is called once per frame
        public void PlayBGM()
        {
            soundController.PlayAudio("遠い夜明け", SoundController.AudioType.BGM, true);
        }
        public void PlaySE()
        {
            soundController.PlayAudio(soundController.SE[0], SoundController.AudioType.SE, false);
        }
        public void PlaySpecial()
        {
            soundController.PlayAudio(soundController.Special[0], SoundController.AudioType.Special, false);
        }
    }
}
