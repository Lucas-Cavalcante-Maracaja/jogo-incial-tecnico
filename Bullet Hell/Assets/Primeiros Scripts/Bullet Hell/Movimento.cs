using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Movimento : MonoBehaviour {

	    public float velocidadeChar;
	    public GameObject tiroPrefab;
	    public int vidas; // vidas do player



        public int unitsKilled;

	    void Start()
	    {
		        
		        //posiçao inicial do jogador
		        transform.position= new Vector3( 0.02f, -3.45f, -0.16f);
		        
		    }
	    
	    void Update()
	    {            
                death ();
                move ();
                shoot ();
		        if (transform.position.x >= 7.24f) {
			            transform.position = new Vector3 (-7.58f, transform.position.y, transform.position.z);
			        }
		        if (transform.position.x <= -7.59f){
			            transform.position = new Vector3 (7.24f, transform.position.y, transform.position.z);
			        }
		        if(transform.position.y <= -4.45f){
			            transform.position = new Vector3 (transform.position.x, -4.45f,transform.position.z );
			        }

                        


                        

                         

		    }





	        void OnTriggerEnter(Collider otherObject){
		        if (otherObject.tag == "tiroInimigo") {
			            Destroy (otherObject.gameObject);
			            vidas--;
                                        
			           
			        }

		if (otherObject.tag == "enemy") {
				                Destroy (otherObject.gameObject);

				                Vector3 posicao = otherObject.transform.position;
						ExplosaoScript.Instance.Explosion (posicao);

				                vidas--;
				         
			            
			        }
		    }


        public void gainLife(){
                this.vidas++;
        }

        public void death(){
                if (vidas <= 0) {
                        Destroy (gameObject);
                        ExplosaoScript.Instance.Explosion (transform.position);
//                        PlayState.Paused;
                }
        }
        public void move(){
                float movimento1 = Input.GetAxisRaw ("Horizontal") * velocidadeChar;
                float movimento2 = Input.GetAxisRaw ("Vertical") * velocidadeChar;
                transform.Translate (Vector2.right * movimento1);
                transform.Translate (Vector2.up * movimento2);

                transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z);

        }

        public void shoot(){
                if (Input.GetKeyDown ("space")) {
                        GetComponent<AudioSource> ().Play ();

                        Vector3 position = new Vector3 (transform.position.x, transform.position.y + (transform.localScale.y / 2));
                        Instantiate (tiroPrefab, transform.position, Quaternion.identity);



                }
        }

} 



