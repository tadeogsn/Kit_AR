using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using UnityEngine.Networking;

[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class servicio
{
    public string NombreVariable;
    public Text Text3D_Dato;
    public string AgregarSimboloDeInidicador;

    

    
}
public class WebServicesPaginaWeb : MonoBehaviour
{
    public static WebServicesPaginaWeb servicio;
    public static WebServicesPaginaWeb Instance { get { return servicio; } }
    public string url_host;
     public bool hostGSN;
    public servicio[] varibles;

    private string getID_dato;

    public static string OEE;
    public static string Temperatura;

    public static string conteoPiezas;
    public static string presion;

//animacion numero
   public int[] valorActual;
   public int[] valorAnterior;
   public int intOEE;
    
    //   public Text dato_x;
    // public Text dato_y;
    // public Text dato_z;
    // public Text rotar;
    // Use this for initialization
    private void Awake()
    {
        if (servicio != null && servicio != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            servicio = this;
        }
    }
    void Start () {
        // string objectName = gameObject.name;
        getID_dato=PlayerPrefs.GetString("IDdato");//obtengo un valor del archivo de RamdomNumber
        StartCoroutine(unity(getID_dato));
    }
	
	// Update is called once per frame
	void Update () {
        
		Debug.Log(PlayerPrefs.GetString("IDdato")+" Dato cargado exitosamenete");
         
            ///CONDICIONES DE ANIMACIION NUMEROS 
            //esta insparido en el script "animacionNumerica" lo use como borrador
        for(int i=0; i<varibles.Length; i++)
        {
            if(valorAnterior[i]<valorActual[i])
            {
                if(valorAnterior[i]==valorActual[i])
                {
                     varibles[i].Text3D_Dato.text=valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
                else if(valorAnterior[i]>valorActual[i])
                {
                     valorAnterior[i]= valorAnterior[i]-1;
                     varibles[i].Text3D_Dato.text = valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
                else if(valorAnterior[i]<valorActual[i])
                {
                     valorAnterior[i]= valorAnterior[i]+1;
                     varibles[i].Text3D_Dato.text = valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
            }
            if(valorAnterior[i]>valorActual[i])
            {
                if(valorAnterior[i]==valorActual[i])
                {
                     varibles[i].Text3D_Dato.text = valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
                else if(valorAnterior[i]>valorActual[i])
                {
                     valorAnterior[i]= valorAnterior[i]-1;
                     varibles[i].Text3D_Dato.text = valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
                else if(valorAnterior[i]<valorActual[i])
                {
                     valorAnterior[i]= valorAnterior[i]-1;
                     varibles[i].Text3D_Dato.text = valorAnterior[i]+varibles[i].AgregarSimboloDeInidicador;
                }
            }
        }
            ///fin de la condicion de numeros

	}
    //ESTE INUMERATOR PRIMERO VERIFICA EL ID DEL USUARIO PARA PODER OBTENER LOS VALORES DE ESE USUARIO EN ESPECIFICO
    IEnumerator unity(string id_USUARIO)
    {
        //no usar http con version de android pie por que se rompe la aplicacion.
        string url;
        if(hostGSN==false)
        {
             url = url_host+"/select_unity.php";
        }
        else
        {
             url = "http://192.168.8.38/MarcadorSilberhorn/select_unity.php";
        }
        WWWForm form = new WWWForm();
        //form.AddField("id", id);
        form.AddField("usuario", id_USUARIO);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
     
            string[] stringSeparators = new string[] {"+"};
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            Debug.Log(result[4] + "hola");

            //codigo viejo cuando los valores se cambiaban de golpe
            // for(int i=0; i<varibles.Length; i++)
            // {
            //     varibles[i].Text3D_Dato.text=result[i]+varibles[i].AgregarSimboloDeInidicador;
            // }
////////////////////////////////

            //este codigo ejecuta el codigo del objeto "variables" solo su tamaño pero
            //se usa para para guardar el valor de las varibles(result[]) que recibe del webservice
            //para guardarlo en una variable actual se se usara en la funcion de Update para 
            //generar una serie de condiciones para que funcione la animacion de numeros
             for(int i=0; i<varibles.Length; i++)
            {
               valorActual[i]=int.Parse(result[i]);
            }
/////////////////////////
           
            
             OEE          = result[0];//oee
             Temperatura  = result[1];//temperatura
             presion      = result[2];//presion
             conteoPiezas = result[3];//CONTEO PEIZAS
        Debug.Log("oee "+OEE);
            // dato_z.text = result[2];
            // rotar.text  = result[3];

            
            
            yield return new WaitForSeconds(1);
            StartCoroutine(unity(id_USUARIO));

       
       
        
        

    }
}
