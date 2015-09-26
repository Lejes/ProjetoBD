using UnityEngine;
using System.Collections;

public class Inventario : MonoBehaviour {
	public GameObject [,] inventario = new GameObject[5,5];//matriz com os itens do heroi
	private GameObject armaAtual;
	public GameObject posicaoArma;
	public GameObject player;
	private bool estaComArma=false;
	public TextMesh texto;
	//variaveis da GUI do inventario
	private Rect janelaInventario;
	private int tamJanelaX = 400;
	private int tamJanlelaY = 220;
	private int espacoBotaoX=20;
	private int espacoBotaoY=0;
	private bool gerarInv = false;//variavel de controle para exibir a inventario.

	void OnGUI() {
		if (gerarInv) {
			janelaInventario = GUI.Window (0, new Rect (300, 150, tamJanelaX, tamJanlelaY), GUIinventario, "Inventario");
		}
		}

	// Use this for initialization
	void Start () {
		armaAtual = (GameObject)Resources.Load ("Prefabs/Armas/EspadaBasica", typeof(GameObject));
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.I)) {
			if(gerarInv){
				gerarInv=false;
			}else{
				gerarInv=true;
			}
			/*Vector3 posicao = player.transform.position+(player.transform.position-posicaoArma.transform.position);
			armaAtual = Instantiate(armaAtual,posicao,armaAtual.transform.rotation) as GameObject;
			armaAtual.transform.parent=posicaoArma.transform;
			Arma arma = armaAtual.GetComponent("Arma") as Arma;
			texto.text= arma.status.ataque.ToString();*/
		}
	
	}

	void GUIinventario(int windowID){//funçao que cria a GUI do inventario
		GUI.BeginGroup (new Rect(0,20, 200, 200));
		GUI.Box(new Rect(0, 0, 200, 200), "");
		for (int i=0; i<5; i++) {
			for(int j=0;j<5;j++){
				if(GUI.Button (new Rect (40*j, 40*i, 40, 40), ""+i)){
				}
			}
		}
		GUI.EndGroup();
		GUI.Box(new Rect(200, 20, 200, 200), "");//box de informaçao dos itens

	}

}
