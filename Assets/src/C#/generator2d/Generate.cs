using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eu.parada.common;

namespace eu.parada.generator {
    public class Generate : MonoBehaviour {
        public GameObject parentObject;
        public int simpleConstant;
        public List<GameObject> objects;

        private int numberOfCols = 10;
        private bool init = true;
        private int objectsToDuplicate;

        // Update is called once per frame
        void Update() {

            if (!init) {
                Debug.Log("Initializing!!!");
                for (int i = 0; i < objectsToDuplicate; i++) {
                    GameObject kid = Instantiate(parentObject);
                    //kid.transform.position = new Vector2(-44.288842f + (i%numberOfCols)*3f,(i/ numberOfCols) * 3f);
                    kid.transform.position = new Vector2((-0 + (simpleConstant * 10)) + (i % numberOfCols) * 1f, (i / numberOfCols) * 1f);
                    objects.Add(kid);
                }
                init = true;
            }
        }

        public void newInit(int numberOfObjects) {
            Debug.Log("New objects number " + numberOfObjects);
            foreach (GameObject obj in objects) {
                DestroyObject(obj);
            }

            objectsToDuplicate = numberOfObjects;
            init = false;
        }



        /*
            if (idx < 0) {
                if (Time.time < nextSpawn) {
                    randomX = Randomizer.getRandomNumber(-30 + (simpleConstant * 10) , -30 + (simpleConstant+1 * 10))*1.0f;

                }

                if (Time.time >= nextSpawn) {
                    randomY = (Randomizer.getRandomNumber(-30 + (simpleConstant * 10), -30 + (simpleConstant + 1 * 10)) * 1.0f);
                    //move randomly
                    ///objects[Randomizer.getRandomNumberMax(objects.Count)].transform.position = new Vector2(randomX, randomY);
                    objects[idx++].transform.position = new Vector2(randomX, randomY);

                    nextSpawn = Time.time + (0.2f);
                    Debug.Log(nextSpawn);
                }
            }

        }

        private void addDelay(double seconds) {
            int i = 0;
            foreach (GameObject kid in objects) {
                kid.transform.position = new Vector2(((Randomizer.getRandomNumber(-20, i % 20) * 1.0f) * 1.0f),  (Randomizer.getRandomNumber(-20, i % 20) * 1.0f));
                //kid.transform.position = new Vector2(0,0);
                i++;
            }

        }
    */
    }
}