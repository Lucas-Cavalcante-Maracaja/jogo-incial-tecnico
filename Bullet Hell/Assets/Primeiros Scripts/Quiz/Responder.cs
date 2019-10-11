using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;


public class Responder : MonoBehaviour {
        
        public Text pergunta;
        public Text respostaA;
        public Text respostaB;
        public Text respostaC;
        public Text respostaD;
        public Text info;

        //armazenador das perguntas, alternativas das questões e corretas
        public string[] perguntas;
        public string[] alternativasA;
        public string[] alternativasB;
        public string[] alternativasC;
        public string[] alternativasD;
        public string[] corretas;



        private int idPergunta;

        private float acertos, questoes, media;
        private int notaFinal;

	// Use this for initialization
	void Start () {
                idPergunta = 0;
                questoes = perguntas.Length;


                pergunta.text = perguntas [idPergunta];
                respostaA.text = alternativasA [idPergunta];
                respostaB.text = alternativasB [idPergunta];
                respostaC.text = alternativasC [idPergunta];
                respostaD.text = alternativasD [idPergunta];

                info.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
	}
	
	
        public void resposta(string alternativa){
                if (alternativa == "A") {
                        if (alternativasA [idPergunta] == corretas [idPergunta]) {
                                acertos++;
                        }
                }else if (alternativa == "B") {
                        if (alternativasB [idPergunta] == corretas [idPergunta]) {
                                acertos++;
                        }
                }else if (alternativa == "C") {
                        if (alternativasC [idPergunta] == corretas [idPergunta]) {
                                acertos++;
                        }
                }else if (alternativa == "D") {
                        if (alternativasD [idPergunta] == corretas [idPergunta]) {
                                acertos++;
                        }
                }
                proximaPergunta ();
        }


        void proximaPergunta (){
                idPergunta++;
                if (idPergunta <= (questoes - 1)) { 
                        pergunta.text = perguntas [idPergunta];
                        respostaA.text = alternativasA [idPergunta];
                        respostaB.text = alternativasB [idPergunta];
                        respostaC.text = alternativasC [idPergunta];
                        respostaD.text = alternativasD [idPergunta];

                        info.text = "Respondendo " + (idPergunta + 1).ToString () + " de " + questoes.ToString () + " perguntas.";
                
                
                } else {

                        media = 10 * (acertos / questoes);
                        notaFinal = Mathf.RoundToInt (media);


                        if(notaFinal > PlayerPrefs.GetInt ("notaFinal".ToString ())){
                                PlayerPrefs.SetInt("notaFinal".ToString (), notaFinal);
                                PlayerPrefs.SetInt ("acertos".ToString (), (int) acertos);
                        }

                        PlayerPrefs.SetInt("notaFinalTemp".ToString (), notaFinal);
                        PlayerPrefs.SetInt ("acertosTemp".ToString (), (int) acertos);
                        Application.LoadLevel ("notaFinal");
                }
        }




}
