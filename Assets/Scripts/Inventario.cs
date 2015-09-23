using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {
	public GameObject [] inventario = new GameObject[10];//array com os itens do heroi
	private GameObject armaAtual;
	public GameObject posicaoArma;
	public GameObject player;
	private bool estaComArma=false; 

	// Use this for initialization
	void Start () {
		armaAtual = (GameObject) Resources.Load("Prefabs/Armas/EspadaBasica", typeof(GameObject));
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I) && estaComArma==false) {
			Vector3 posicao = player.transform.position+(player.transform.position-posicaoArma.transform.position);
			estaComArma=true;
			armaAtual = Instantiate(armaAtual,posicao,armaAtual.transform.rotation) as GameObject;
			armaAtual.transform.parent=posicaoArma.transform;
		}
	
	}
}
