package eu.rafig.covid.core.ui;

import eu.rafig.covid.core.game.GamePlay;
import eu.rafig.covid.core.game.GameState;
import eu.rafig.covid.core.game.entities.alive.organs.Organ;
import eu.rafig.covid.core.game.entities.effects.Effect;
import eu.rafig.covid.core.game.entities.effects.GameEffects;
import eu.rafig.covid.core.game.entities.placeable.Cell;
import eu.rafig.covid.core.utilities.Reader;

public class Console {
    private GamePlay gamePlay;
    private ConsoleStatus status = ConsoleStatus.CONNECTED;

    public Console() {
        this.gamePlay = new GamePlay("default");
        int choice = init();

        if (choice == 1) {
            play();
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
                "2 \t QUIT");
    }

    private void printUI() {
        // TODO: Consider creating Thread only for this instead...
        System.out.println("+===================================================================================+");
        System.out.println("| " + gamePlay.getTurn().getCurrentDay().getDayNumber() + " =================== " + gamePlay.getUser().getName() + " = " + gamePlay.getUser().getScore() + " |");
        System.out.println("| HEALTH: " + gamePlay.getHuman().getVitals().getHealth().getCurrentHealth() + " ===== INFECTION: " + gamePlay.getHuman().getVitals().getInfection().getCurrectInfectionValue() + " |");

        for (Organ organ: gamePlay.getHuman().getHumanOrgans()) {
            System.out.println("| " + organ.getDesctiption() + " |");
            System.out.println(organ.getStats());
        }

        System.out.println();

        for (Effect effect: GameEffects.getEffectList()) {
            System.out.println("| " + effect.getDesciption() + " == " + effect.isActive() + " |");
        }

        System.out.println("+===================================================================================+");
    }

    private void passCommand() {
        String command = Reader.readLine("Please execute your command:");

        if (command.equalsIgnoreCase("W")) {
            gamePlay.newDay();
        } else if (command.equalsIgnoreCase("S")) {
            GameEffects.buyEffect(GameEffects.getEffectList().get(Reader.readInt("Please insert 0-5 to buy effect")));
        }else if (command.equalsIgnoreCase("Q")) {
            quit();
        }
    }

    public void loop() {
        while (gamePlay.getGameState() == GameState.PLAYING && status == ConsoleStatus.WORKING){
            printUI();
            passCommand();
        }
        printUI();
    }

    private int init() {
        if (Reader.readLine("Press y  to jump right into game").equalsIgnoreCase("y")) {
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
