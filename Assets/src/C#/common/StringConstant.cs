using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eu.parada.common {
    public class StringConstant {

        // GAME ICONS HELP
        public const string NO_USER = "User not defined";

        public const string DECREASE_BUTTON_INFO = "This button is use to decrease value of imunity for buy";
        public const string BUY_BUTTON_INFO = "This button is use to buy current value of imunity";
        public const string INCREASE_bUTTON_INFO = "This button is use to increase value of imunity for buy";
        public const string MAX_BUTTON_INFO = "This button set a maximum value of immunity, you can buy";

        public const string LEARNING_BUTTON_INFO = "This button is use to buy new achievment LEARNING ";
        public const string WASHING_HANDS_BUTTON_INFO = "This button is use to buy new achievment WASHING HANDS";
        public const string WEARING_PROTECTION_BUTTON_INFO = "This button is use to buy new achievment WEARING PROTECTION";
        public const string SOCIAL_DISTENCING_BUTTON_INFO = "This button is use to buy new achievment SOCIAL DISTENCING";
        public const string HEALTHY_REGIME_BUTTON_INFO = "This button is use to buy new achievment HEALTHY REGIME";

        public const string FIGHT_BUTTON_INFO = "This button is use to start fight with a current value of bought immunities \n After fight day will continue in next phase";
        public const string NEXT_DAY_INFO = "This button is use to skip current day";

        public const string HEALTH_ICON_INFO = "This icon show current value of your health";
        public const string ENERGY_ICON_INFO = "This icon show current value of your energy \n You use energy to fight";

        public const string CELLS_ICON_INFO = "This icon show you value of cells \n If count of viruses will bigger than count of cells you will die";
        public const string VIRUS_ICON_INFO = "This icon show you count of viruses in your body";
        public const string IMMS_ICON_INFO = "This icon show count of immunities \n immunieties are use to fight with vireses";
        public const string DNA_ICON_INFO = "This icon show count of DNA \n DNA is use to buy ummunities ";

        public const string DAYS_ICON_INFO = "First number is a current day and seconf number is a maximum day you have to destroy virus";
        public const string DAY_PHASE_ICON_INFO = "Icon sho you actual phase of day \n every day have 4 phase \n in every phase of day you can start fight once \n IF you are sleeping you can not fight";

        public const string NO_MESSAGE_FOUND = "No message found";




        // GAME STATES
        public const string LOST_GAME_FAILED_DEAD = "Sorry virus beaten you...*Nearer My Go to Thee * plays in the background.Your corpse smells terrible.\n You should be more concise in the future! Look at the man next to you he is also dead. Good news is that there are not many like you";
        public const string NO_TIME_BASIC = "Almost, but you ran out of time";
        public const string NO_TIME_GAME_WON = "And you won! Congratulation there are many like you!";
        public const string NO_TIME_LOST_INFECTED = "And you are still infected. But good fight, but you are still infected I don't think you will be able to survive next days";
        public const string NO_TIME_LOST_NOT_INFECTED = "And you didn't get infected?! You cheater! Okay I think it's honest to say that you find your own way to beating this game";
        public const string NO_TIME_LOST_DEAD = "*Nearer My Go to Thee* plays in the background. Your corpse smells terrible";
        public const string WON_GAME_STATE = "Congratulation, you did it you beat the virus, try increasing level :P";
        public const string UNKNOWN_GAMESTATE_ERROR = "Uhm I don't know how, but you reached matrix";


    }
}