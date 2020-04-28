using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using eu.parada.common;

namespace eu.parada.manager {
    public class PopupInfo : MonoBehaviour {

        public Text title;
        public Button action;
        public Text content;
        public GameObject titlePanel;
        public GameObject contentPanel;
        public GameObject actionPanel;

        private bool timed = false;
        private bool start = false;
        private bool resolved = true;

        private bool showTitle = false;
        private bool showContent = false;
        private bool showAction = false;
        private int length = 0;

        // Update is called once per frame
        void Update() {
            if (start) {
                if (timed) {
                    StartCoroutine(showForSeconds(length));
                } else {
                    showMessage();
                }
            }
        }

        private void showit(bool showAction) {
            titlePanel.SetActive(showTitle);
            contentPanel.SetActive(true);
            actionPanel.SetActive(showAction);
        }


        private void hideIt() {
            this.gameObject.SetActive(false);
            titlePanel.SetActive(false);
            contentPanel.SetActive(false);
            actionPanel.SetActive(false);
        }

        private IEnumerator showForSeconds(int length) {
            showit(false);

            yield return new WaitForSeconds(length);
            hideIt();

            start = false;
            resolved = true;
        }

        private void showMessage() {
            showit(true);

            action.onClick.AddListener(() => {
                hideIt();
                start = false;
                resolved = true;
            });
        }

        public bool isResolved() {
            return resolved;
        }

        public void show() {
            this.gameObject.SetActive(true);
            resolved = false;
            start = true;
        }

        private void setContent(string content) {
            this.content.text = content;
        }

        private void setTitle(string title) {
            this.title.text = title;
        }

        private void setLength(int length) {
            this.length = length;
        }

        private bool simpleMessage(string content, int length) {
            setContent(content);
            setLength(length);
            timed = true;
            return (this.content.text == content && this.length == length);
        }

        private bool simpleTitledMessage(string title, string content, int length) {
            setTitle(title);
            setContent(content);
            setLength(length);
            timed = true;
            return (this.content.text == content && this.title.text == title && this.length == length);
        }

        private bool advancedMessage(string content) {
            setContent(content);
            timed = false;
            return (this.content.text == content);
        }

        private bool advancedTitledMessage(string title, string content) {
            setTitle(title);
            setContent(content);
            timed = false;
            return (this.content.text == content && this.title.text == title);
        }

        public void addStrignMessage(StringMessage message) {
            if (message.isClickable()) {
                if (message.isTitled()) {
                    advancedTitledMessage(message.getTitle(), message.getContent());
                    showTitle = true;
                } else {
                    advancedMessage(message.getContent());
                    showTitle = false;
                }
            } else {
                if (message.isTitled()) {
                    showTitle = true;
                    simpleTitledMessage(message.getTitle(), message.getContent(), message.getLength());
                } else {
                    simpleMessage(message.getContent(), message.getLength());
                    showTitle = false;
                }
            }
        }
    }
}