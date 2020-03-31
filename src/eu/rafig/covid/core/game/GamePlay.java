package eu.rafig.covid.core.game;

import eu.rafig.covid.core.entities.User;
import eu.rafig.covid.core.game.entities.alive.Human;
import eu.rafig.covid.core.game.entities.alive.State;
import eu.rafig.covid.core.game.time.Turn;

public class GamePlay {
    private User user;
    private GameState gameState = GameState.PLAYING;
    private Human human;
    private Turn turn;

    public GamePlay(String userName) {
        user = new User(userName);

        human = new Human();
        turn = new Turn(14);
    }

    private boolean nextDay() {
        return turn.skipTurn();
    }

    public void newDay() {
        human.goToBed();
        user.setScore(user.getScore()+1);

        if (human.getState() == State.CURED) {
            gameState = GameState.WON;
        }

        if (human.getState() == State.DEAD) {
            gameState = GameState.FAILED;
        }

        if (!nextDay()) {
            gameState = GameState.FAILED;
        }
    }

    public User getUser() {
        return user;
    }

    public Human getHuman() {
        return human;
    }

    public Turn getTurn() {
        return turn;
    }

    public GameState getGameState() {
        return gameState;
    }

    public void setGameState(GameState gameState) {
        this.gameState = gameState;
    }
}
