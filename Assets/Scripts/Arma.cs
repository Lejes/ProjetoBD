using UnityEngine;
using System.Collections;

public class Arma : Itens {
	public int danoBase;
	public double chanceDeCritico;
	public TextMesh texto;
	// Use this for initialization
	void Start () {
		danoBase = status.ataque * status.forca;
		chanceDeCritico = (status.inteligencia * status.velocidade) * 0.1;
		texto.text = status.ataque.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public int danoReal(){
		int critico = 1;
		if (isCritico ()) {
			critico = 2;
		}
		int danoReal = critico*danoBase;

		return danoReal;
}
	private bool isCritico(){
		bool isCritico = false;
		int qtVetor = 100 / (int)chanceDeCritico;
		int[] vetor = new int[qtVetor];
		for(int i=0; i<qtVetor;i++){
			vetor[i] = 0;
			if(i== qtVetor-1){
				vetor[i]=1;
			}
		}
		int escolha  = (int)Random.Range(0, qtVetor-1);
		if(vetor[escolha]==1){
			isCritico=true;
		}

		return isCritico;

	}

}