using UnityEngine;
using System.Collections;

public class PlayerBehavior : MonoBehaviour {

	public GameObject player;
	public Animator playerAnimator;
	public float velocidade;
	private bool olharParaDir = true;
	private Vector3 posicaoDir;
	private Vector3 posicaoEsq;


	// Use this for initialization
	void Start () {
		posicaoDir = playerAnimator.transform.localScale;
		posicaoEsq = posicaoDir;
		posicaoEsq.x = -1 * posicaoDir.x;
	
	}
	
	// Update is called once per frame
	void Update () {
		movimentacao ();
		if (Input.GetKey(KeyCode.Space)) {
			attack ();
		}

	}

	void movimentacao(){

		//Recebe as teclas padrao para o movimento do personagem
		float direcaoX = Input.GetAxis("Horizontal")*velocidade*Time.deltaTime;//teclas:A e D ou <- e ->
		float direcaoY = Input.GetAxis("Vertical")*velocidade*Time.deltaTime;//teclas: W e S ou setaCima e setaBaixo
		player.transform.Translate (direcaoX,direcaoY,0);//Move o personagem

		if (direcaoX>0){
			olharParaDir = true;
		}
		if (direcaoX<0){
			olharParaDir = false;
		}

		if(olharParaDir){
			playerAnimator.transform.localScale = posicaoDir;
		}
		else{
			playerAnimator.transform.localScale = posicaoEsq;
		}

		playerAnimator.SetFloat ("velocidade", Mathf.Abs(direcaoX));//Chama a animaçao de andar
	}

	void attack(){
		playerAnimator.SetTrigger ("attack");

	}
}