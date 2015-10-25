using UnityEngine;
using System.Collections;

public class Login : MonoBehaviour {
	private ConexaoBanco banco;

	private Rect windowRect;
	private string _login = "";
	private string _senha = "";
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
		windowRect = GUI.Window(0, windowRect, DoMyWindow, "Login");
	}
	//o que aparece dentro da janela
	void DoMyWindow(int windowID) {

		GUI.Box(new Rect(10,20,largura-20,altura-30),"");

		GUI.Box(new Rect(15,35,100,25),"Login");
		GUI.Box(new Rect(15,65,100,25),"Senha");

		_login = GUI.TextField(new Rect(largura-175,35,160,25),_login,(20));
		_senha = GUI.PasswordField(new Rect(largura-175,65,160,25),_senha,"*"[0],(10));

		// rect(mover horizontal,mover vertical,largura,altura)
		if (GUI.Button (new Rect (15,altura-45 , 100, 30), "Login")) {

			banco = new ConexaoBanco();

			if(banco.verificarLogin(_login,_senha)){;
				Application.LoadLevel(2);
				print("login bem sucedido");
			}
		}

		if (GUI.Button (new Rect (largura-115, altura-45, 100, 30), "Cadastro")) {
			Application.LoadLevel(1);
		}
		
	}
}
