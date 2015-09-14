using UnityEngine;
using System.Collections;
using MySql.Data.MySqlClient;

public class ConexaoBanco : MonoBehaviour{

	private MySqlConnection con;
	private string stConexao = "Server=localhost;Database=rpgbd;Uid=root;Pwd=root;";
	private MySqlCommand cmd;
	private MySqlDataReader reader;


	public ConexaoBanco(){

		con = new MySqlConnection(stConexao);
		cmd = new MySqlCommand();

	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void inserirJogador(string _login, string _senha){
			//con = new MySqlConnection(stConexao);
			//cmd = new MySqlCommand();
			cmd.CommandText = "INSERT INTO rpgbd.jogador(jog_login,jog_senha) VALUES('"+_login+"','"+_senha+"')";
			cmd.Connection = con;
			con.Open();
			cmd.ExecuteNonQuery();
			con.Close();
	}

	public bool verificarLogin(string _login, string _senha){
		bool valor  = false;
		cmd.CommandText = "SELECT jog_login,jog_senha FROM jogador WHERE jog_login='"+_login+"' AND jog_senha='"+_senha+"';";
		cmd.Connection = con;
		con.Open();
		reader = cmd.ExecuteReader();

		if (reader.Read()) {
			string login = reader ["jog_login"].ToString();
			string senha = reader ["jog_senha"].ToString();
			if(login == _login){
				valor = true;
			}

		}
		reader.Close ();
		con.Close();
		return valor;
	}








}
