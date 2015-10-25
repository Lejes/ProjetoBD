using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;

public class Cadastro : MonoBehaviour {
	private ConexaoBanco banco;
	
	private Rect windowRect;
	private string _login = "";
	private string _senha = "";
	private string _confirmaSenha = "";
	private bool _verificar;
	public float altura;
	public float largura;
	
	// Use this for initialization
	void Start () {
		//janela no centro da tela
		windowRect = new Rect ((Screen.width / 2) - (largura/2), (Screen.height/2)- (altura/2), largura, altura);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//inicia a gui
	void OnGUI() {
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "Cadastro");

		if (_verificar) {
		
			GUI.Label((new Rect((Screen.width/2)-180,Screen.height-30,360,30)),"as senhas nao sao iguais ou login ja foi utilizado");
		}
	}

	//o que aparece dentro da janela
	void DoMyWindow(int windowID) {

		GUI.Box(new Rect(10,20,largura-20,altura-30),"");
		//labels
		GUI.Box(new Rect(15,35,140,25),"Login");
		GUI.Box(new Rect(15,65,140,25),"Senha");
		GUI.Box(new Rect(15,95,140,25),"Confirmar senha");

		//campos de texto
		_login = GUI.TextField(new Rect(largura-175,35,160,25),_login,(20));
		_senha = GUI.PasswordField(new Rect(largura-175,65,160,25),_senha,"*"[0],(10));
		_confirmaSenha = GUI.PasswordField(new Rect(largura-175,95,160,25),_confirmaSenha,"*"[0],(10));
		
		// rect(deslocamento horizontal,deslocamento vertical,largura,altura)
		if (GUI.Button (new Rect (15,altura-45 , 100, 30), "Voltar")) {
			Application.LoadLevel(0);
			print ("login");
		}
		
		if (GUI.Button (new Rect (largura-115, altura-45, 100, 30), "Cadastrar")) {
			if(_senha == _confirmaSenha){
				
				banco = new ConexaoBanco();
				banco.inserirJogador(_login,_senha);
			
				_verificar = false;
				Application.LoadLevel(0);
				print ("cadastro");



			}else{
				_verificar = true;
				print("nao cadastro");
				_login = "";
				_senha = "";
				_confirmaSenha = "";

			}


		}
		
	}
}
