using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;

namespace eu.parada.manager {
    public class LogsManager : MonoBehaviour {

        public Text firstLog;
        public Text secondLog;
        public Text thirdLog;
        public Text fourthLog;
        public Text fifthLog;

        public Game game;

        // Update is called once per frame
        void Update() {
            if (game.isLoaded()) {

                List<string> logs = StringUtils.getInstance().getLogs(5);
                if (logs != null) {
                    switch (logs.Count) {
                        case 5:
                            firstLog.text = logs[4];
                            secondLog.text = logs[3];
                            thirdLog.text = logs[2];
                            fourthLog.text = logs[1];
                            fifthLog.text = logs[0];
                            break;
                        case 4:
                            firstLog.text = "";
                            secondLog.text = logs[3];
                            thirdLog.text = logs[2];
                            fourthLog.text = logs[1];
                            fifthLog.text = logs[0];
                            break;
                        case 3:
                            firstLog.text = "";
                            secondLog.text = "";
                            thirdLog.text = logs[2];
                            fourthLog.text = logs[1];
                            fifthLog.text = logs[0];
                            break;
                        case 2:
                            firstLog.text = "";
                            secondLog.text = "";
                            thirdLog.text = "";
                            fourthLog.text = logs[1];
                            fifthLog.text = logs[0];
                            break;
                        case 1:
                            firstLog.text = "";
                            secondLog.text = "";
                            thirdLog.text = "";
                            fourthLog.text = "";
                            fifthLog.text = logs[0];
                            break;
                        default:
                            return;
                    }
                }

            }
        }
    }
}