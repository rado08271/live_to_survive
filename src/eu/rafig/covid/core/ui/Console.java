package eu.rafig.covid.core.ui;

import com.sun.xml.internal.bind.v2.runtime.reflect.opt.Const;
import eu.rafig.covid.core.game.GamePlay;
import eu.rafig.covid.core.game.GameState;
import eu.rafig.covid.core.game.common.Constants;
import eu.rafig.covid.core.game.entities.alive.organs.LungsState;
import eu.rafig.covid.core.game.entities.effects.Effect;
import eu.rafig.covid.core.game.entities.effects.PositiveEffects;
import eu.rafig.covid.core.utilities.Reader;

public class Console {
    private GamePlay gamePlay;
    private ConsoleStatus status = ConsoleStatus.CONNECTED;
    private Commands commands;

    public Console() {
        this.gamePlay = new GamePlay("default");
        int choice = init();

        if (choice == 1) {
            play();
        } else if (choice == 2) {
            about();
            quit();
        } else if (choice == 3) {
            help();
            quit();
        } else {
            quit();
        }

    }

    private String askForName() {
        return Reader.readLine("Please provide your name first");
    }

    private int askForChoice() {
        return Reader.readInt(
                "1 \t PLAY \n" +
                "2 \t ABOUT \n" +
                "3 \t HELP \n" +
                "4 \t QUIT");
    }

    private void printUI() {
        // TODO: Consider creating Thread only for this instead...
        System.out.println("+============================ USER: " + gamePlay.getUser().getName() + " = " + gamePlay.getUser().getScore() + " ============================+");
        System.out.println("| DAY:    : \t\t\t" + gamePlay.getCurrentDay() + " - " + gamePlay.getLungs().getDayTime());
        System.out.println("| HEALTH: : \t\t\t" + gamePlay.getLungs().getVitals().getHealth().getCurrentHealth());
        System.out.println("| ENERGY: : \t\t\t" + gamePlay.getLungs().getVitals().getEnergy().getEnergy());
        System.out.println("| DNA     : \t\t\t" + gamePlay.getLungs().getVitals().getMoney().getCurrentMoney());

        System.out.println("+-----------------------------------------------------------------------------------+");

        System.out.println("| " + gamePlay.getLungs().getDesctiption() + "\t" + gamePlay.getLungs().getLungsState().name() + " |");
        System.out.println("| CELL    : \t\t\t" + gamePlay.getLungs().getCells().size());
        System.out.println("| VIRUS   : \t\t\t" + gamePlay.getLungs().getViruses().size());
        System.out.println("| IMMUNITY: \t\t\t" + gamePlay.getLungs().getImunities().size());

        System.out.println("+===================================================================================+");
    }

    private void passCommand() {
        String command = Reader.readLine("Please execute your command: ? to see commands");

        if (command.equalsIgnoreCase("1")) {
            commands = Commands.NEWDAY;
            gamePlay.newDay();
        } else if (command.equalsIgnoreCase("2")) {
            commands = Commands.BUY;
            showShop();
            gamePlay.buy(Reader.readInt("Press what would you like to buy 0-4 press 9 to leave shop"));
        } else if (command.equalsIgnoreCase("3")) {
            commands = Commands.ATTACK;
            gamePlay.attack();
        } else if (command.equalsIgnoreCase("4")) {
            commands = Commands.BUYIMMUNITY;
            gamePlay.buySomeImmunity(Reader.readInt("What amount of immunity would you like to buy? One immunity cost " + Constants.IMMUNITY_PRICE + " DNA"));
        } else if (command.equalsIgnoreCase("?")) {
            commands = Commands.HELP;
            help();
        } else if (command.equalsIgnoreCase("Q")) {
            commands = Commands.QUIT;
            quit();
        }
    }

    public void showShop() {
        System.out.println("| WELCOME TO EFFECTS SHOP");

        int it = 0;
        for (Effect effect: PositiveEffects.getEffectList()) {
            System.out.println("| " + it++ + " =\t=" + effect.getDesciption() + " =\t= " + effect.isActive() + " =\t= " + effect.getDnaPrice() + "DNA");
        }
    }

    public void help() {
        System.out.println("BLBABLABLA:" +
                "\nTo skip turn and go to the next day press 1 - When you skip your day your immunities will give you DNA points used for buying stuff" +
                "\nTo buy something from shop press 2 and choose what would you like to buy - Every bought bonus gives you better chance to fight the virus and decreasing it's spreading " +
                "\nTo attack press 3 be carefull not to give virus great chance to spread because once there is no chance to take cells it will fight you " +
                "\nTo buy immunity press 4 1 Cell/" + Constants.IMMUNITY_PRICE + " DNA" +
                "\nTo quit press Q "
                /// TODO: CONSIDER! fight...each dead virus means you get one DNA point
        );
    }

    public void about() {
        System.out.println("Created by Parada Team 2020\n" +
                "Product Owners, Development and enthusiasts:" +
                "\n\tRadoslav Figura" +
                "\n\tDominik Bural" +
                "\n\tPavol Telepak" +
                "\n\tVladimir Benadik" +
                "\nGuided by GameDev Lector doc. Ing. Branislav Sobota PhD." +
                "\n\tSTAY SAFE!" +
                "");
    }

    public void loop() {
        while (gamePlay.getGameState() == GameState.PLAYING && status == ConsoleStatus.WORKING){
            printUI();
            passCommand();
        }

        printUI();
        printMessage();
    }

    private void printMessage() {
        if (status != ConsoleStatus.WORKING) {
            if (status == ConsoleStatus.STOPPED) {
                System.out.println("Thank you for playing this game. I hope you just enjoyed it :)");
            } else {
                System.out.println("Something unexpected");
            }
            return;
        }

        if (gamePlay.getGameState() == GameState.FAILED ) {
            System.out.println("Sorry virus beaten you...*Nearer My Go to Thee* plays in the background. Your corpse smells terrible.\n You should be more concise in the future! Look at the man next to you he is also dead. Good news is that there are not many like you");
        } else if (gamePlay.getGameState() == GameState.NOTIME) {
            System.out.println("You finished the game!");

            if (gamePlay.getLungs().getLungsState() == LungsState.CURED) {
                System.out.println("And you won! Congratulation there are many like you!");
            } else if (gamePlay.getLungs().getLungsState() == LungsState.INFECTED) {
                System.out.println("And you are still infected. But good fight, but you are still infected I don't think you will be able to survive next days");
            } else if (gamePlay.getLungs().getLungsState() == LungsState.WORKING) {
                System.out.println("And you didn't get infected?! You cheater! Okay I think it's honest to say that you find your own way to beating this game");
            } else if (gamePlay.getLungs().getLungsState() == LungsState.DESTROYED) {
                System.out.println("*Nearer My Go to Thee* plays in the background. Your corpse smells terrible");
            }
        } else if (gamePlay.getGameState() == GameState.PLAYING) {
            System.out.println("You broke me again...stop that!");
        } else {
            System.out.println("Uhm I don't know how, but you reached matrix");
        }
    }

    private int init() {
        if (Reader.readLine("Please use numbers where needed. Otherwise you are killing the game.\n" +
                "We do not like fun-killers so please carefully read help when needed\n" +
                "Game crashes are on you!\n" +
                "Have fun in this crazy times, stay safe and healthy!\n\n" +
                "Press y  to jump right into game").equalsIgnoreCase("y")) {
            return 1;
        }

        this.gamePlay = new GamePlay(askForName());
        return askForChoice();
    }

    private void play() {
        status = ConsoleStatus.WORKING;
        loop();
    }

    private void quit() {
        status = ConsoleStatus.STOPPED;
    }

    public ConsoleStatus getStatus() {
        return status;
    }
}
