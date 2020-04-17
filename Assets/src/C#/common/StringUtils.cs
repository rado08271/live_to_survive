using System.Collections;
using System.Collections.Generic;

namespace eu.parada.common {

	public class StringUtils {
        private static StringUtils INSTANCE = null;
        private IList<string> stack = new List<string>();
        private bool hasMessages = false;
        private StringUtils() {}

        public static StringUtils getInstance() {
            if (INSTANCE == null) {
                INSTANCE = new StringUtils();
            }

            return INSTANCE;
        }

        public string getStackedMessage() {
            string lastMessage = stack[stack.Count - 1];
            stack.RemoveAt(stack.Count - 1);

            if (stack.Count <= 0) hasMessages = false;
            return lastMessage;
        }

        public bool hasMessage() {
            return hasMessages;
        }

        public bool addMessage(string message) {
            if (stack.Contains(message)) return false;
            stack.Add(message);
            if (stack.Contains(message)) return false;

            return true;
            
        }
	}
}