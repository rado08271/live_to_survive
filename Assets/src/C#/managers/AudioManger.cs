using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using eu.parada.enums;

namespace eu.parada.manager {
    public class AudioManger : MonoBehaviour {
        public AudioSource source;

        public AudioClip fight;
        public AudioClip moneyClick;
        public AudioClip noOrError;
        public AudioClip newDay;
        public AudioClip sleepingSound;
        public AudioClip tired;
        public AudioClip timeTicking;
        public AudioClip boughtImmunity;

        public AudioClip learning;
        public AudioClip washingHands;
        public AudioClip wearingFaceMask;
        public AudioClip socialDistancing;
        public AudioClip healthyRegime;

        public AudioClip fastHearthBeat;
        public AudioClip slowHearthBeat;
        public AudioClip noHearthBeat;

        public bool play = false;

        void Update() {
            if (play) {
                play = false;
                source.Play();
            }

        }

        public void playFightSound() {
            source.clip = fight;
            play = true;
        }

        public void playMoneyClickSound() {
            source.clip = moneyClick;
            play = true;
        }

        public void playNoSound() {
            source.clip = noOrError;
            play = true;
        }

        public void playNewDaySound() {
            Debug.Log("new Day sounds");
            source.clip = newDay;
            play = true;
        }

        public void playSleepingSound() {
            source.clip = sleepingSound;
            play = true;
        }

        public void playTiredSound() {
            source.clip = tired;
            play = true;
        }
        
        public void playTimeTickingSound() {
            source.clip = timeTicking;
            play = true;
        }

        public void playBoughtImmunitySound() {
            source.clip = boughtImmunity;
            play = true;
        }

        public void playLearningSound() {
            source.clip = learning;
            play = true;
        }

        public void playWashingHandsSound() {
            source.clip = washingHands;
            play = true;
        }

        public void playWearingFaceMaskSound() {
            source.clip = wearingFaceMask;
            play = true;
        }
        public void playSocialDistancing() {
            source.clip = socialDistancing;
            play = true;
        }
        public void playHealthyRegime() {
            source.clip = healthyRegime;
            play = true;
        }

        public void playSlowHeartBeat() {
            source.clip = slowHearthBeat;
            play = true;
        }
        public void playFastHeartBeat() {
            source.clip = fastHearthBeat;
            play = true;
        }

        public void playNNoHeartBeat() {
            source.clip = noHearthBeat;
            play = true;
        }
    }
}