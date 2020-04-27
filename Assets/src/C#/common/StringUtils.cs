using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {

	public class StringUtils {
        private static StringUtils INSTANCE = null;
        private List<StringMessage> stack = new List<StringMessage>();
        private bool hasMessages = false;
        private StringUtils() {}

        public static StringUtils getInstance() {
            if (INSTANCE == null) {
                INSTANCE = new StringUtils();
            }

            return INSTANCE;
        }

        //TODO: Fix this...
        public StringMessage getStackedMessage() {
            if (stack.Count == 0) return null;
            return stack[0];
        }

        public bool showStackedMessage(StringMessage message) {
            if (message.messageWasShown() || !stack.Contains(message)) return false;

            message.show();
            return true;
        }

        public bool hasMessage() {
            return hasMessages;
        }

        public List<string> getLogs(int numberOfMsgs) {
            if (stack.Count == 0) return null;
            int count = 0;

            List<string> logs = new List<string>();

            for (int i = 0; i < stack.Count; i++) {
                if (stack[i].isLoggable()) {
                    logs.Add(stack[i].getContent());
                    if (count++ == numberOfMsgs -1) {
                        break;
                    }
                }
            }

            return logs;
        }

        public bool addMessage(StringMessage message) {
            stack.Insert(0, message);
            if (stack.Contains(message)) return false;

            return true;
            
        }

        public void clearLog() {
            stack = new List<StringMessage>();
        }
	}
}