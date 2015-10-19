using UnityEngine;
using System.Collections;

public class HP_Bar : MonoBehaviour {

	public GameObject statusPlayer;
	public TextMesh HPMesh;//Guarda a quantidade de HP atual do player
	public SpriteRenderer vida;//variavel para guarda a sprite do HP
	private Status status;
	private float HPTotal;


	// Use this for initialization
	void Start () {
		status = statusPlayer.GetComponent ("Status") as Status;
		HPTotal = status.hp;
	}
	
	// Update is called once per frame
	void Update () {
		exibirHPtext ();
	}

	void exibirHPtext(){
		HPMesh.text = status.hpAtual+"";
	
	}
	//calcula o quanto o eixo x vai se desocar na sprite da vida
	//responsavel pela "animaçao" da barra de vida(faz ela descer) 
	float calcularX(float porcHP){
		float x;//variavel para o eixo x
		x = -2 * (1 - porcHP);
		return x;
	}
	//Funçao responsavel por atualizar a GUI da vida
	public void alterarHP(){
		float porcHP = status.hpAtual / HPTotal;
		float x = calcularX (porcHP);
		Vector2 vec2 = new Vector3 (porcHP, vida.transform.localScale.y, vida.transform.localScale.z);
		vida.transform.localPosition = new Vector3 (x, 0, 0);
		vida.transform.localScale = vec2;//ajusta a escala da barra em funçao da porcentagem de HP

	}
}
