using UnityEngine;
using System.Collections;

public enum Estado_Do_Inimigo{
	idle,
	attack,
	morrer,
}

public class EnemyBehavior : MonoBehaviour {

	public GameObject objBarraHP;//guarda o gameObject da barra de hp do inimigo
	public GameObject objStatus;// '' Statudos do inimigo
	public Animator enemyAnimator;
	public float velocidade;
	private Status status;
	private HP_Bar barraHP;
	private PlayerBehavior player;//variavel que guarda o jogador
	private Estado_Do_Inimigo estadoAtual;
	private float posicaoDir;
	// Use this for initialization
	void Start () {
		status = objStatus.GetComponent ("Status") as Status;
		barraHP = objBarraHP.GetComponent ("HP_Bar") as HP_Bar;
		player = FindObjectOfType (typeof(PlayerBehavior)) as PlayerBehavior;
		setEstado (Estado_Do_Inimigo.idle);

	}
	
	// Update is called once per frame
	void Update () {
		comportamento ();
	}

	public void tomarDano(int dano){
		status.hpAtual = status.hpAtual - dano;
		barraHP.alterarHP ();
	}

	void comportamento(){
		switch (estadoAtual) {
			case Estado_Do_Inimigo.idle:{
			float distanciaDoPlayer = Vector3.Distance(transform.position,player.transform.position);//pega a distancia do inimigo para o jogador
			if(distanciaDoPlayer < 100 && distanciaDoPlayer > 0){
				seguirPlayer(true);
			}
			else{
				seguirPlayer(false);
			}
			}break;
			case Estado_Do_Inimigo.attack:{

			}break;
			
			case Estado_Do_Inimigo.morrer:{

			}break;
		}
	}

	void setEstado(Estado_Do_Inimigo novoEstado){
		estadoAtual = novoEstado;
	}

	void seguirPlayer(bool seguir){
		if (player.gameObject.transform.position.x < transform.position.x) {
			transform.Translate(Vector3.left*velocidade*Time.deltaTime);
			transform.localScale=new Vector3(2,2,2);//faz o inimigo olhar na direçao do player
		} else if (player.gameObject.transform.position.x > transform.position.x) {
			transform.localScale=new Vector3(-2,2,2);
			transform.Translate(Vector3.right*velocidade*Time.deltaTime);
		}


	}


}
