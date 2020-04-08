using System.Collections;
using System.Collections.Generic;
using eu.parada.game;

namespace eu.parada {
    public class Manager {

        private static Manager manager = null;
        private GamePlay game = null;
        private bool started = false;
        private Manager() { }

        public static Manager getInstance() {
            if (manager == null) {
                manager = new Manager();
            }

            return manager;
        }
    
        public void initNewGame(string userName, double difficulty) {
            if (!started && game == null) {
                started = true;
                game = new GamePlay(userName, difficulty);
            } 
        }

        public void stopGame() {
            if (started && game != null) {
                started = false;
                game = null;
            }
        }

        public bool canStart() {
            return started;
        }

        public GamePlay getGamePlay() {
            return game;
        }
    }
}
