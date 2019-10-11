using UnityEngine;
using System.Collections;

public class InstantiateInimigo : MonoBehaviour {
	    public GameObject inimigoPrefab;
	    public float enemySpawnRatio = 1.5f; //1,5 s de spawn de inimigo
	    public int enemySpawnChance; //chance de 8% de chance de aparecer

	    public int enemiesSpawned = 0; //qtd de inimigos que apareceram

	    public int unitCount; //contador para mudar dificuldade
		public int caixaRatio; //solta uma nova caixa de vida 

	    public int countdown;
	    public double unitRatio;
		public int incraseDifficult;
		public int countdownCaixa;

	    // Use this for initialization
	    void Start () {
		        


		    }

	    // Update is called once per frame
	    void Update () {

		        StartCoroutine ("Spawn");
				spawnCaixa ();	   
	
	}




	    public IEnumerator Spawn(){
			




				if (countdown == 0) {
			            countdown++;


						if (gameObject.tag == "nuvem") {
								if (gameObject.name == "nuvem(Clone)") {
											//yield return new WaitForSeconds (Random.Range (0.5f, 1f));
                                        Instantiate (inimigoPrefab, new Vector3 (Random.Range (-6.20f, 5.80f), 4.83f, -0.16f), Quaternion.Euler (0, 0, 0));

								} else {
											yield return new WaitForSeconds (Random.Range (0.5f, 1f));
                                        Instantiate (inimigoPrefab, new Vector3 (Random.Range (-6.20f, 5.80f), 4.83f, -0.16f), Quaternion.Euler (0, 0, 0));

								}








						}else if (gameObject.tag == "enemy") { 
				                if (Random.Range (1f, 100f) <= enemySpawnChance) {
					                    yield return new WaitForSeconds (Random.Range (0.5f, 1f));

                                        Instantiate (inimigoPrefab, new Vector3 (Random.Range (-6.20f, 5.80f), 4.83f, -0.16f), Quaternion.Euler (0, 0, 180));
					                    enemiesSpawned++;
					                }
				                if (enemiesSpawned >= unitCount) {
										enemySpawnChance += incraseDifficult;
					                    unitCount += 10;
					                }
				            }








		        }else{
			            countdown++;
			            if (countdown == unitRatio) {
				                countdown = 0;
				            }

			        }




		    }

	private void spawnCaixa(){


		if (gameObject.tag == "vida") {
			if (countdownCaixa == 0) {
				countdownCaixa++;
                                Instantiate (inimigoPrefab, new Vector3 (Random.Range (-6.20f, 5.80f), 4.83f, -0.16f), Quaternion.Euler (0, 0, 0));
			} else {
				countdownCaixa++;
				if (countdownCaixa == caixaRatio) {
					countdownCaixa = 0;
				}

                        }





                }else if(gameObject.tag == "caixa"){


                }
	}

}









