using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplosaoScript : MonoBehaviour {
	    public static ExplosaoScript Instance;

	    public ParticleSystem explosao;


	    void Awake(){
		        if (Instance != null) {
			            Debug.LogError ("");
			        }

		        Instance = this;
		    }


	    public void Explosion(Vector3 position){
		        InstantiateParticula (explosao, position);
		    }


	    private ParticleSystem InstantiateParticula(ParticleSystem prefab, Vector3 position){
		        ParticleSystem novaParticula = Instantiate (prefab, position, Quaternion.identity) as ParticleSystem;
				GetComponent<AudioSource> ().Play ();
		        Destroy (novaParticula.gameObject, novaParticula.startLifetime);
		        return GetComponent<ParticleSystem>();
		    }


}