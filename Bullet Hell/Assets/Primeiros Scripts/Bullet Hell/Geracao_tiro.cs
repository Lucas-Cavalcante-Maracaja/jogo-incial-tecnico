using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Geracao_tiro : MonoBehaviour {
	    
        public GameObject principal;

        public GameObject player;
                


	    public float fireSpeed;
     
	    // Update is called once per frame
        void Start(){
                player = GameObject.FindGameObjectWithTag ("Player");
                principal = GameObject.FindGameObjectWithTag ("MainCamera");


        }


        void Update () {
		        float movimento = fireSpeed * Time.deltaTime;
		        transform.Translate (Vector3.up * movimento);
		        if ((transform.position.y > 5.06f) && (gameObject.name != "tiroPrefab")){
			            Destroy (this.gameObject);
			        }
		    }


	void OnTriggerEnter(Collider otherObject){
		        

        if (otherObject.tag == "enemy") {
                        principal.gameObject.GetComponent<Principal>().pontos(otherObject.gameObject.GetComponent<InimigoScript>().scoreValue());

                        Destroy (otherObject.gameObject);
			Destroy (this.gameObject);
			ExplosaoScript.Instance.Explosion (transform.position);
						
		} else if (otherObject.tag == "caixa") {
                        principal.gameObject.GetComponent<Principal>().pontos(otherObject.gameObject.GetComponent<InimigoScript>().scoreValue());

			Destroy (otherObject.gameObject);
			Destroy (this.gameObject);
			ExplosaoScript.Instance.Explosion (transform.position);

                }else if (otherObject.tag == "vida"){
                        player.GetComponent<Movimento> ().gainLife ();
                        principal.gameObject.GetComponent<Principal>().pontos(otherObject.gameObject.GetComponent<InimigoScript>().scoreValue());

                        Destroy (otherObject.gameObject);
                        Destroy (this.gameObject);
                        ExplosaoScript.Instance.Explosion (transform.position);
                }
	}






}