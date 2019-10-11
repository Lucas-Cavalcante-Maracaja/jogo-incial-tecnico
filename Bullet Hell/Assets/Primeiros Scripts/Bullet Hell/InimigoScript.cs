using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InimigoScript : MonoBehaviour {

	    

	    public float minSpeed;
	    public float maxSpeed;
	    public float currentSpeed;

		public int cod;

	    public GameObject tiroInimigoPrefab;
	    private float x, y , z;
        public int pontos;



	    // Use this for initialization
	    void Start () {
		        currentSpeed = Random.Range (minSpeed, maxSpeed);

		        if (gameObject.tag == "enemy") {
			            StartCoroutine ("Atirar");
			        }
		    }
	    
	    // Update is called once per frame
	    void Update () {
                if ((gameObject.tag == "nuvem")||(gameObject.tag=="caixa")|| (gameObject.tag == "vida")) {
			            float amtToMove = currentSpeed * Time.deltaTime;
			            transform.Translate (Vector3.down * amtToMove);
		        } else {
			            float amtToMove = currentSpeed * Time.deltaTime;
			            transform.Translate (Vector3.up * amtToMove);
			        }


		if ((transform.position.y < -6.74f) && (gameObject.name != "inimigoPrefab") && (gameObject.name != "Caixa_vida") && (gameObject.name !="inimigo2Prefab") && (gameObject.name !="nuvem") && (gameObject.name != "nuvem2")) {
			            Destroy (this.gameObject);
			        }

		    




		    }




	    public IEnumerator Atirar(){
				yield return new WaitForSeconds (1f);
                                
                                if (cod == 1) {
                                        GetComponent<AudioSource> ().Play ();
					Vector3 position = new Vector3 (transform.position.x, transform.position.y);
					Instantiate (tiroInimigoPrefab, transform.position, Quaternion.identity);
				} else if (cod == 2) {
			                Vector3 position = new Vector3 (transform.position.x, transform.position.y);
					Instantiate (tiroInimigoPrefab, transform.position, Quaternion.identity);
                                        GetComponent<AudioSource> ().Play ();
					yield return new WaitForSeconds (0.3f);
					position = new Vector3 (transform.position.x , transform.position.y);
                                        GetComponent<AudioSource> ().Play ();
                                        Instantiate (tiroInimigoPrefab, transform.position, Quaternion.identity);
				}
		        StartCoroutine ("Atirar");

	}


        public int scoreValue(){


                        return pontos;
  
        }

} 






