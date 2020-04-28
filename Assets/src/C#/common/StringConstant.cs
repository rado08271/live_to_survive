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

        public const string LEARNING_BUTTON_INFO = "Buy new achievment LEARNING \nPrice: 5";
        public const string WASHING_HANDS_BUTTON_INFO = "Buy new achievment WASHING HANDS. \nPriace: 15";
        public const string WEARING_PROTECTION_BUTTON_INFO = "Buy new achievment WEARING PROTECTION. \nPrice: 25";
        public const string SOCIAL_DISTENCING_BUTTON_INFO = "Buy new achievment SOCIAL DISTENCING. \nPrice: 35";
        public const string HEALTHY_REGIME_BUTTON_INFO = "Buy new achievment HEALTHY REGIME. \nPrice: 45";

        public const string FIGHT_BUTTON_INFO = "This button is used to start fight with a current value of bought immunities \nAfter fight day will continue in next phase.";
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

        // BURKO's FACTS
        public const string FACT_1_TITLE = "There are 2 main virus types.";
        public const string FACT_1_TEXT = "A virus may contain either a single or double-stranded DNA basis for its genetic material. Some viruses also contain single or double-stranded RNA. Additionally, their genetic formation is organized to form a straight strand. Others may also have circular molecules.";

        public const string FACT_2_TITLE = "Viruses can remain dormant in a host body for years.";
        public const string FACT_2_TEXT = "Viruses undergo multiple life cycles. The virus enters the host by fusion with other cells. This causes the host’s cells to replicate the virus DNA and grow. This cycle repeats until it takes over the entire host’s system.";

        public const string FACT_3_TITLE = "Viruses are beautiful physical objects";
        public const string FACT_3_TEXT = "Despite their destructiveness as disease agents, viruses are quite beautiful as physical objects under the microscope. “Viruses have higher symmetry than any other thing in nature,” Gelbart said. Most viruses have icosahedral symmetry, like an old-fashioned soccer ball with its 12 black pentagons and 20 white hexagons.";

        public const string FACT_4_TITLE = "Viruses do not fly";
        public const string FACT_4_TEXT = "Viruses do not have wings, legs or arms. They cannot move in the environment they were expelled in. If they want to contaminate someone, they need to rely on the host to touch a contaminated surface and bring the hand to a sensitive area (mainly mouth, nose or eyes). They can also trigger expelling symptoms such as cough to spread more easily and increase the chance to reach a new host. The SARS-CoV 2 virus responsible for CoVID-19 (CoronaVirus Disease 2019) does not spread in the air nor in the water.";

        public const string FACT_5_TITLE = "Examples of viruses and death rate";
        public const string FACT_5_TEXT = "Spanish flu 50M+\nHIV/AIDS    36M\nSwine flu   200 000 \nEBOLA       11 000\nCOVID-19    207 722+";

        public const string FACT_6_TITLE = "How viruses follow in human body";
        public const string FACT_6_TEXT = "1.A virus particle attaches to a host cell.\n2.The particle releases its genetic instructions into the host cell.\n3.The injected genetic material recruits the host cell's enzymes.\n4.The enzymes make parts for more new virus particles.\n5.The new particles assemble the parts into new viruses.\n6.The new particles break free from the host cell.";

        public const string FACT_7_TITLE = "How human infects others";
        public const string FACT_7_TEXT = "Human can infection other people when coughs, sneezes, or talks. Viruses contained in these droplets can infect other people via the eyes, nose, or mouth—either when they land directly on somebody’s face or when they’re transferred there by people touching their face with contaminated hands.";

        public const string FACT_8_TITLE = "Virus transmission";
        public const string FACT_8_TEXT = "Viruses spread in many ways. One transmission pathway is through disease-bearing organisms  known as vectors: for example, viruses are often transmitted from plant to plant by insects that feed on plant sap, such as aphids; and viruses in animals can be carried by blood-sucking insects. Influenza viruses are spread by coughing and sneezing. Norovirus and rotavirus, common causes of viral gastroenteritis, are transmitted by the faecal–oral route, passed by contact and entering the body in food or water. HIV is one of several viruses transmitted through sexual contact and by exposure to infected blood. The variety of host cells that a virus can infect is called its \"host range\". This can be narrow, meaning a virus is capable of infecting few species, or broad, meaning it is capable of infecting many.";

        public const string FACT_9_TITLE = "How vaccine works";
        public const string FACT_9_TEXT = "A vaccine works by training the immune system to recognize and combat pathogens, either viruses or bacteria. To do this, certain molecules from the pathogen must be introduced into the body to trigger an immune response. These molecules are called antigens, and they are present on all viruses and bacteria. By injecting these antigens into the body, the immune system can safely learn to recognize them as hostile invaders, produce antibodies, and remember them for the future. If the bacteria or virus reappears, the immune system will recognize the antigens immediately and attack aggressively well before the pathogen can spread and cause sickness.";

        public const string FACT_10_TITLE = "What is virology";
        public const string FACT_10_TEXT = "Virology is the study of viruses – submicroscopic, parasitic particles of genetic material contained in a protein coat – and virus-like agents. It focuses on the following aspects of viruses: their structure, classification and evolution, their ways to infect and exploit host cells for reproduction, their interaction with host organism physiology and immunity, the diseases they cause, the techniques to isolate and culture them, and their use in research and therapy.";

        public const string FACT_11_TITLE = "Types of Coronaviruses";
        public const string FACT_11_TEXT = "Coronaviruses are a group of related viruses. In humans, coronaviruses cause respiratory tract infections that can range from mild to lethal.Between varieties of corona belongs to SARS, MERS, and COVID-19.";

        public const string FACT_12_TITLE = "What does COVID-19 stand for?";
        public const string FACT_12_TEXT = "‘CO’ stands for corona, ‘VI’ for virus, ‘D’ for disease, and 19 refers to 2019, the year in which it was first discovered.";

        public const string FACT_13_TITLE = "What are the symptoms of COVID-19?";
        public const string FACT_13_TEXT = "Symptoms of COVID-19 include respiratory illness with fever, cough, and difficulty breathing. In more severe cases, it can cause pneumonia and severe acute respiratory syndrome. People with chronic health conditions and the elderly are more likely than others to have a life-threatening case of the disease.";

        public const string FACT_14_TITLE = "Fact about spain flu";
        public const string FACT_14_TEXT = "Spain flu is a biggest viral epidemic in a world.It killed more people than World War One combined. More American soldiers died from the 1918 flu than were killed in battle during the First World War. In fact, the flu claimed more lives than all of the World War One battles combined.";

        public const string FACT_15_TITLE = "Word quarantine";
        public const string FACT_15_TEXT = "The word \"quarantine\" comes from the Italian word \"quarantina,\" meaning a period of 40 days. During the  Black Death, the city of Venice required ships suspected of carrying disease to sit at anchor for 40 days before they could land.";
        
        public const string FACT_16_TITLE = "First pandemic";
        public const string FACT_16_TEXT = "The Antonine Plague, sometimes referred to as the Plague of Galen, erupted in 165 CE, at the height of Roman power throughout the Mediterranean world during the reign of the last of the Five Good Emperors, Marcus Aurelius Antoninus (161-180 CE). The first phase of the outbreak would last until 180 CE affecting the entirety of the Roman Empire, while a second outbreak occurred in 251-266 CE, compounding the effects of the earlier outbreak. It has been suggested by some historians that the plague represents a useful starting point for understanding the beginning of the decline of the Roman Empire in the West but also the underpinning to its ultimate fall.";

        // BUYING EFFECTS
        public const string LEARNING_TITLE = "You turned of shitty news!";
        public const string LEARNING_TEXT_1 = "There are so many \"alternatives\" to facts (well lies) in age of crisis. Just listen to those who give you the official information. Possibility that they are wrong is minimal. On the other hand \"alternative\" are wrong almost all the time";
        public const string LEARNING_TEXT_2 = "Now you know that injecting disinfectant to your lungs internally will not benefit you. Just don't do it even when you admire President Trump. He sometimes get a bit angry at not being right.";
        public const string LEARNING_TEXT_3 = "Like seriusly? Vaccinations is a way to monitor people? They are ridiculous you must agree... well done you for turning that off. Starting reading true facts is better for your health and for fighting this virus";

        public const string WASHING_HANDS_TITLE = "You started to wash your hands!";
        public const string WASHING_HANDS_TEXT_1 = "It is incredibly important to wash your hands everyday not just in time of pandemic. \n1. Wash your hands for at least 20 seconds and at key times. \n2. Use alcohol-based handrub if water and soap are not available. \n3. Regular soap is just as effective as antibacterial soap. \n4. Minimize contact with potentially contaminated surfaces. \n5. Ideally use hot tap water viruse patogenss hate it!";
        public const string WASHING_HANDS_TEXT_2 = "Washing hands is important in any age, why do you need to do it? Answer may be complex but the easiest one is that there are bilions of organisms on your body some gives you benefits but other may give you dissease or infeection. Just use tap water and put soap on your hands after playing this game";
        public const string WASHING_HANDS_TEXT_3 = "You should consider putting soap on your hands when doing everytime you do the following: Before leaving the bathroom, after shaking hands during flu season or outbreaks, before eating food, after preparing raw food, after touching garbage, before treating wounds...\nYou ask why? Well we are not animals at least";

        public const string WEARING_PROTECTION_TITLE = "You are now wearing face mask";
        public const string WEARING_PROTECTION_TEXT_1 = "It looks stupid, but it helps protect your health. There are many ways to create it yourself, any kind of face protection is good for you. And even consider using protection gloves. Just don't forget to wash it!";
        public const string WEARING_PROTECTION_TEXT_2 = "Research on SARS, found that N95 masks were highly effective at blocking transmission of that virus. Even ill-fitting medical face masks have been found to interrupt airborne particles and viruses, keeping them from reaching as far when someone sneezes.";
        public const string WEARING_PROTECTION_TEXT_3 = "Use anything to cover your respiratory system and health of other. Any face masks will do the job! While masks made out of cotton T-shirts were far less effective than manufactured surgical masks in preventing wearers from expelling droplets, they did reduce droplets and were better than no protection at all.";

        public const string SOCIAL_DISTANCING_TITLE = "You decided to quarantine yourself";
        public const string SOCIAL_DISTANCING_TEXT_1 = "Streets are empty, you would like to go for one (;)) beer, but decided not to. You value your life, life of others and your own country economical growth. Just stay at home, outbreak will end, but we are going to need you afterwards.";
        public const string SOCIAL_DISTANCING_TEXT_2 = "Social distancing, also called \"physical distancing,\" means keeping space between yourself and other people outside of your home. To practice social or physical distancing: \n1. Stay at least 2m from other people \n2.Do not gather in groups \n3. Stay out of crowded places and avoid mass gatherings";
        public const string SOCIAL_DISTANCING_TEXT_3 = "Keeping space between you and others is one of the best tools we have to avoid being exposed to this virus and slowing its spread. Everyone has a role to play in slowing the spread and protecting themselves, their family, and their community. Social distancing helps limit contact with infected people and contaminated surfaces.";

        public const string HEALTHY_REGIME_TITLE = "You decided to live halthy";
        public const string HEALTHY_REGIME_TEXT_1 = "Being healthy in general is beneficial for you. It doesn't necesarilly means you should do as many excercise as you can. It would be prefferable tho, just enjoy any physical activity. Try to eliminate stress. Being healthy is not crucial only in times of outbreak. Stay healthy and safe!";
        public const string HEALTHY_REGIME_TEXT_2 = "Immunity is very important in fighing dissease. When you actually catch the dissease, who may save you, is your body. The thing that you nurture your whole life. In case of any dissease it will give you the picture of what mistakes you did. I hope you will not catch it but now you know that being healthy is super important";
        public const string HEALTHY_REGIME_TEXT_3 = "Experts say, that people should exercise, eat healthy, have alcohol-free days and quit smoking mainly during outbreaks. Such measures could make it less likely they'd be admitted to intensive care or worse.";
    }
}