package eu.rafig.covid.core.game;

import eu.rafig.covid.core.entities.User;
import eu.rafig.covid.core.game.common.Constants;
import eu.rafig.covid.core.game.common.DayCounter;
import eu.rafig.covid.core.game.entities.alive.organs.Lungs;
import eu.rafig.covid.core.game.entities.alive.organs.LungsState;
import eu.rafig.covid.core.game.entities.effects.Event;
import eu.rafig.covid.core.game.entities.effects.PositiveEffects;

public class GamePlay {
    private User user;
    private GameState gameState;
    private Lungs lungs;
    private Event event;

    public GamePlay(String userName) {
        user = new User(userName);
        gameState = GameState.PLAYING;
        lungs = new Lungs(Constants.LUNGS_CELL_CAPACITY, "Lungs");
        event = new Event(lungs);
    }

    private int nextDay() {
        return DayCounter.increaseDay();
    }

    public void newDay() {
        user.setScore(user.getScore()+1);
        nextDay();

        event.addVirus();
        lungs.endDay();

        if (lungs.getLungsState() == LungsState.CURED) {
            gameState = GameState.WON;
        }

        if (lungs.getLungsState() == LungsState.DESTROYED) {
            gameState = GameState.FAILED;
        }

        if (DayCounter.getDayCount() >= Constants.GAME_LENGTH) {
            gameState = GameState.NOTIME;
        }
    }

    public boolean buy(int choice) {
        if (choice >= PositiveEffects.getEffectList().size()) return false;
        return lungs.buyEffect(PositiveEffects.getEffectList().get(choice));
    }

    public boolean buySomeImmunity(int count) {
        return event.buyImmunity(count);
    }

    public boolean attack() {
        return lungs.fight();
    }


    public User getUser() {
        return user;
    }

    public GameState getGameState() {
        return gameState;
    }

    public int getCurrentDay() {
        return DayCounter.getDayCount();
    }

    public Lungs getLungs() {
        return lungs;
    }
}
