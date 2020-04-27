using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using eu.parada.common;

namespace eu.parada.manager {
    public class PopupManager : MonoBehaviour {
        public PopupInfo popupPanel;
        private const int LENGTH_OF_MESSAGE = 2;
        void Update() {
            if (popupPanel.isResolved()) {
                StringMessage message = StringUtils.getInstance().getStackedMessage();
                if (message != null) {
                    if (StringUtils.getInstance().showStackedMessage(message)) {
                        popupPanel.addStrignMessage(message);
                        popupPanel.show();
                    }
                }
            }
        }

        public void anyInfo(int number) {
            switch (number) {
                case 1:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.DECREASE_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 2:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.BUY_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 3:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.INCREASE_bUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 4:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.MAX_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 5:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.LEARNING_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 6:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.WASHING_HANDS_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 7:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.WEARING_PROTECTION_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 8:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.SOCIAL_DISTENCING_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 9:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.HEALTHY_REGIME_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 10:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.FIGHT_BUTTON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 11:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.NEXT_DAY_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 12:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.HEALTH_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 13:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.ENERGY_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 14:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.CELLS_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 15:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.VIRUS_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 16:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.IMMS_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 17:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.DNA_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 18:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.DAYS_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                case 19:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.DAY_PHASE_ICON_INFO, LENGTH_OF_MESSAGE));
                    break;
                default:
                    StringUtils.getInstance().addMessage(new StringMessage(StringConstant.NO_MESSAGE_FOUND, LENGTH_OF_MESSAGE));
                    break;
            }
        }
    }
}