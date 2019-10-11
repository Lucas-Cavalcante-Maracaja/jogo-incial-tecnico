using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Principal : MonoBehaviour {
	public  GameObject pontuacaoGUI;
	public  GameObject tempoGUI;
        public  GameObject vidaGUI;
        private int tempo_total;
	public int tempo_inicial = 0;
        private int pontuacaoAtual = 0;




        public GameObject player; //jogador
	    public GameObject pontosPerKill; //pontos por unidade do inimigoScript

		void Awake(){
			
			

			StartCoroutine ("Tempo");
		}


	    // Use this for initialization
	    void Start () {
                player = GameObject.FindGameObjectWithTag ("Player");
				tempo_total = 120;
		    }
	    
	    // Update is called once per frame
	    void Update () {
			
                        cont_vida ();
	    }


        public void pontos(int pontuacao){
                
                pontuacaoAtual += pontuacao;
                pontuacaoGUI.GetComponent<Text> ().text = "Pontos: " + pontuacaoAtual;
			
	}
        public void cont_vida(){

                vidaGUI.GetComponent<Text> ().text = "Vidas: " +  player.GetComponent<Movimento> ().vidas;
        }
		




        public IEnumerator Tempo(){
                        tempoGUI.GetComponent<Text> ().text = "Tempo: " + tempo_total;
                        tempo_total--;
                        
                        if (tempo_total == 0) {
				//fim de jogo
			}
			yield return new WaitForSeconds (1f);
			StartCoroutine ("Tempo");
		}
       
      
} 