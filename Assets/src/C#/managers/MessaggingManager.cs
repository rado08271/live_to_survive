using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace eu.parada.manager
{
    public class MessaggingManager : MonoBehaviour
    {
        public GameObject MessaggeBox;
        public Text MessaggeBoxText;
        public string messagge;
        

        public void ShowMessagge(string messagge)
        {
            Debug.Log(messagge);
            StartCoroutine(showMessaggeFor(messagge, 2));
        }

        private IEnumerator showMessaggeFor(string messagge, int time)
        {
            MessaggeBox.SetActive(true);
            this.MessaggeBoxText.text = messagge;
            yield return new WaitForSeconds(time);
            MessaggeBox.SetActive(false);
        }
    }
}
