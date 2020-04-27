using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace eu.parada.common {
    public class StringMessage {

        private bool wasShown = false;
        private bool clickable = false;
        private bool titled = false;
        private int length = 0;
        private string title = "";
        private string content = "";
        private bool loggable = false;

        public StringMessage(string content, bool loggable) {
            this.wasShown = true;
            this.loggable = loggable;
            this.content = content;
        }

        public StringMessage(string content) {
            this.content = content;
            this.clickable = true;
        }

        public StringMessage(string content, int length) {
            this.content = content;
            this.length = length;
        }

        public StringMessage(string content, string title) {
            this.content = content;
            this.title = title;
            this.clickable = true;
            this.titled = true;
        }

        public StringMessage(string content, string title, int length) {
            this.content = content;
            this.title = title;
            this.length = length;
            this.titled = true;
        }

        public void setLoggable(bool loggable) {
            this.loggable = loggable;
        }
        public void show() {
            this.wasShown = true;
        }

        public bool messageWasShown() {
            return this.wasShown;
        }

        public bool isLoggable() {
            return this.loggable;
        }

        public bool isTitled() {
            return this.titled;
        }

        public bool isClickable() {
            return this.clickable;
        }

        public string getTitle() {
            return this.title;
        }

        public string getContent() {
            return this.content;
        }

        public int getLength() {
            return this.length;
        }

    }
}