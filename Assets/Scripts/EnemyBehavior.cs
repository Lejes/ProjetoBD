using UnityEngine;
using System.Collections;

public enum Estado_Do_Inimigo{
	idle,
	attack,
	morrer,
}

public class EnemyBehavior : MonoBehaviour {
	
	public GameObject objBarraHP;//guarda o gameObject da barra de hp do inimigo
	public GameObject objStatus;// '' Status do inimigo
	public GameObject objArma;
	public Animator enemyAnimator;
	public float velocidade;
	private Status status;
	private HP_Bar barraHP;
	private PlayerBehavior player;//variavel que guarda o jogador
	private Estado_Do_Inimigo estadoAtual;
	private float posicaoDir;
	public TextMesh teste;
	float distanciaDoPlayer;//pega a distancia do inimigo para o jogador
	// Use this for initialization
	void Start () {
		status = objStatus.GetComponent ("Status") as Status;
		barraHP = objBarraHP.GetComponent ("HP_Bar") as HP_Bar;
		player = FindObjectOfType (typeof(PlayerBehavior)) as PlayerBehavior;
		Arma armaInimigo = objArma.GetComponent ("Arma") as Arma;
		armaInimigo.setPortador (objStatus);
		//teste.text = armaInimigo.getDanoBase () + "";
		distanciaDoPlayer = Vector3.Distance(transform.position,player.transform.position);//pega a distancia do inimigo para o jogador
		setEstado (Estado_Do_Inimigo.idle);
	}
	
	// Update is called once per frame
	void Update () {
		comportamento ();
	}
	
	public void tomarDano(int dano){
		if (dano >= status.hpAtual) {
			status.hpAtual = 0;
		} else {
			status.hpAtual = status.hpAtual - dano;
		}
		barraHP.alterarHP ();
	}
	
	void comportamento(){
		distanciaDoPlayer = Vector3.Distance(transform.position,player.transform.position);//pega a distancia do inimigo para o jogador
		switch (estadoAtual) {
		case Estado_Do_Inimigo.idle:{
			distanciaDoPlayer = Vector3.Distance(transform.position,player.transform.position);//pega a distancia do inimigo para o jogador
			if(distanciaDoPlayer < 100 && distanciaDoPlayer > 0){
				if(distanciaDoPlayer<20.5){
					setEstado(Estado_Do_Inimigo.attack);
				}
				else{
					seguirPlayer(true);
				}

			}
			else{
					seguirPlayer(false);
			}
		}break;
		case Estado_Do_Inimigo.attack:{
			if(distanciaDoPlayer>=20.5){
				setEstado(Estado_Do_Inimigo.idle);
				enemyAnimator.SetBool("attack",false);
			}else{
				enemyAnimator.SetBool("attack",true);
			}
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
