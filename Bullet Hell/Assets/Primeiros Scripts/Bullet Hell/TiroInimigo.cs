using UnityEngine;
using System.Collections;

public class TiroInimigo : MonoBehaviour {
	    public float fireSpeed;

	    
	    // Update is called once per frame
	    void Update () {
		        float movimento = fireSpeed * Time.deltaTime;
		        transform.Translate (Vector3.down * movimento);





		        if (transform.position.y < -6.74f) {
			            Destroy (this.gameObject);
			        }
		    }
} 






