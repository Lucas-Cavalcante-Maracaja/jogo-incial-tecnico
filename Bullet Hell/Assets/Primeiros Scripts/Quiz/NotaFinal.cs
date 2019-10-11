using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Globalization;


public class NotaFinal : MonoBehaviour {

        public Text txtNota;
        public Text txtInfo;

        private int notaFinal, acertos;

        // Use this for initialization
        void Start () {
                notaFinal = PlayerPrefs.GetInt ("notaFinalTemp".ToString ());
                acertos = PlayerPrefs.GetInt ("acertosTemp".ToString ());

                txtNota.text = notaFinal.ToString ();
                txtInfo.text = "Acertou " + acertos.ToString () + " de 10 perguntas";
        }

}
