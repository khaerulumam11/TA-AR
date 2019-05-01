using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Vuforia
{

    public class dataTarget : MonoBehaviour
    {
        public Transform TextTargetName;
        public Transform TextDescription;
        public Transform ButtonPlay;
        public Transform ButtonPause;
        public Transform ButtonStop;
        public Transform PanelDescription;

        public AudioSource soundTarget;
        public AudioClip clipTarget;
        public AudioListener audioListener;

        public SpriteRenderer sprite;
        public Sprite soundPlay;
        public Sprite soundPause;

        // Use this for initialization
        void Start()
        {
            //add Audio Source as new game object component
            soundTarget = (AudioSource)gameObject.AddComponent<AudioSource>();
         
          
        }

        // Update is called once per frame
        void Update()
        {
            StateManager sm = TrackerManager.Instance.GetStateManager();
            IEnumerable<TrackableBehaviour> tbs = sm.GetActiveTrackableBehaviours();

            foreach (TrackableBehaviour tb in tbs)
            {
                string name = tb.TrackableName;
                ImageTarget it = tb.Trackable as ImageTarget;
                Vector2 size = it.GetSize();

                Debug.Log("Active image target:" + name + "  -size: " + size.x + ", " + size.y);

                //Evertime the target found it will show “name of target” on the TextTargetName. Button, Description and Panel will visible (active)

                TextTargetName.GetComponent<Text>().text = name;
                ButtonPlay.gameObject.SetActive(true);
                ButtonPause.gameObject.SetActive(true);
                ButtonStop.gameObject.SetActive(true);
                TextDescription.gameObject.SetActive(true);
                PanelDescription.gameObject.SetActive(true);


                //If the target name was “zombie” then add listener to ButtonAction with location of the zombie sound (locate in Resources/sounds folder) and set text on TextDescription a description of the zombie

                if (name == "2018")
                {  
                    if (AudioListener.pause == true)
                    {
                        ButtonPause.GetComponent<Button>().onClick.AddListener(delegate { playSoundPause(); });
                    }
                    else {
                        ButtonPlay.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/zombie"); });
                    }
                    ButtonStop.GetComponent<Button>().onClick.AddListener(delegate { playSoundStop("sounds/zombie"); });
                   
                    TextDescription.GetComponent<Text>().text = "A zombie (Haitian French: zombi, Haitian Creole: zonbi) is a fictional undead being created through the reanimation of a human corpse. Zombies are most commonly found in horror and fantasy genre works.";
                }



                //If the target name was “unitychan” then add listener to ButtonAction with location of the unitychan sound (locate in Resources/sounds folder) and set text on TextDescription a description of the unitychan / robot

                if (name == "2018-2")
                {
                    ButtonPlay.GetComponent<Button>().onClick.AddListener(delegate { playSound("sounds/zombie"); });
                    ButtonPause.GetComponent<Button>().onClick.AddListener(delegate { playSoundPause(); });
                    ButtonStop.GetComponent<Button>().onClick.AddListener(delegate { playSoundStop("sounds/zombie"); });
                    TextDescription.GetComponent<Text>().text = "A robot is a mechanical or virtual artificial agent, usually an electromechanical machine that is guided by a computer program or electronic circuitry, and thus a type of an embedded system.";
                }
            }
        }

        //function to play sound
        public void playSound(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = true;
            soundTarget.Play();
            AudioListener.pause = false;
           
        
        }

       public void playSoundPause()
        {
            soundTarget.Pause();
            AudioListener.pause = true;
        }

       public void playSoundStop(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.Stop();
        }

       public void playSoundUnPause(string ss)
        {
            clipTarget = (AudioClip)Resources.Load(ss);
            soundTarget.clip = clipTarget;
            soundTarget.loop = false;
            soundTarget.playOnAwake = false;
            soundTarget.UnPause();


        }

    }
}
