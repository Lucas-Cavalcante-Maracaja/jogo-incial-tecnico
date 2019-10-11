﻿using UnityEngine;
using System.Collections;

public class FundoScript : MonoBehaviour {
	   
        private Material materialAtual;
        public float velocidade;
        private float offset;



        // Use this for initialization
	    void Start () {
                materialAtual = GetComponent<Renderer> ().material;

		    }
	    
	    // Update is called once per frame
	    void Update () {
                offset -= 0.01f;
                materialAtual.SetTextureOffset ("_MainTex", new Vector2(0, offset * velocidade));
}
}