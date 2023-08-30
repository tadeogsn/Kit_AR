using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;
using Random=UnityEngine.Random;
using UnityEngine.SceneManagement;

public class RamdomNumeber : MonoBehaviour
{
    public Text TextUIRamdom;
    //public Text TextUI_log;
    string NumeroRandom;//NUMERO RAMDOM
    string sms;
    string _numeroUno;
    bool stopped;

    int _random1;
    int _random2;
    int _random3;
    int _random4;

    bool pararCorutine=false;

    string ID_dato;
    public GameObject loading;

    public string ULR_host;

    public bool hostGSN;



    // Start is called before the first frame update
    void Start()
    {
       
        _random1=UnityEngine.Random.Range(10,99);
        _random2=UnityEngine.Random.Range(10,99);
        _random3=UnityEngine.Random.Range(10,99);
        _random4=UnityEngine.Random.Range(10,99);
        NumeroRandom =_random1.ToString()+_random2.ToString()+_random3.ToString()+_random4.ToString();
        Debug.Log(NumeroRandom);
        TextUIRamdom.text=_random1.ToString()+"-"+_random2.ToString()+"-"+_random3.ToString()+"-"+_random4.ToString();;
        StartCoroutine(existNumEnBD(NumeroRandom));
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(sms);
        //sms="2";
        if(sms=="1")//1=NUMERO RANDOM YA EXISTE EN LA BD
        {
            StopCoroutine(existNumEnBD(NumeroRandom));// PARA LA CONSULTA 
            _numeroUno= NumeroRandom;
            TextUIRamdom.text=_numeroUno;
            Debug.Log("Numero ya existe en la base de datos");
            StartCoroutine(insertNumRandomBD(_numeroUno));
        }
        if(sms=="2")//2= NUMERO RANDOM SE INSERTO CORRECTAMENTE 
        {
            StopCoroutine(insertNumRandomBD(_numeroUno));
            _numeroUno=NumeroRandom;
            StartCoroutine(LoginSession(_numeroUno));
        }
        if(sms=="4")//4 =EL USUARIO INGRESO DESDE LA PAGINA WEB
        {
            
            loading.SetActive(true);// IMG DE CARGA PARA PASAR A LA OTRA SCENA
            StopCoroutine(LoginSession(_numeroUno));
            PlayerPrefs.SetString("IDdato", ID_dato);// lo mando al archivo webServicesPaginaWeb
            SceneManager.LoadScene("IOT_TARGET");
            pararCorutine=true;
        }
         if(sms=="5")//EL USUARIO NO HA INGRESADO DESDE LA PAGINA WEB
        {
            loading.SetActive(false);
        }
        
    }
    //VERIFICA SI EXISTE EL NUMERO RANDOM EN LA BD 
        IEnumerator existNumEnBD(string numero){
        stopped = false;
        string url;
        if(hostGSN==false)
        {
             url = ULR_host+"/select_unityRandom.php";
        }
        else
        {
             url = "http://192.168.8.38/MarcadorSilberhorn/select_unityRandom.php";
        }
        

        WWWForm form = new WWWForm();
        form.AddField("NumRamdom", numero);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
   
            string[] stringSeparators = new string[] { "+" };
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            sms = result[0].Replace(" ", String.Empty);
            Debug.Log(sms);
            
             yield break;
    }
    //INSERTA EL NUMERO CREADO EN LA BD
     IEnumerator insertNumRandomBD(string numero)
    {
        Debug.Log(numero);
        string url;
        if(hostGSN==false)
        {
             url = ULR_host+"/select_unityRandom.php";
        }
        else
        {
             url = "http://192.168.8.38/MarcadorSilberhorn/select_unityRandom.php";
        }

        WWWForm form = new WWWForm();
        //form.AddField("id", id);
        form.AddField("NumRamdom", numero);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
   
            string[] stringSeparators = new string[] { "+" };
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            sms = result[0].Replace(" ", String.Empty);
            Debug.Log(sms);
            // yield return www.SendWebRequest();
            //StartCoroutine(unity(numero));
            yield break;
    
    
    }
    //VERIFICA SI EL NUMERO RANDOM DE LA APLICACION EXISTE EN LA BD PARA DEJARLOS ENTRAR O NO.
     IEnumerator LoginSession(string numero)
    {
        Debug.Log(numero);
        string url;
        if(hostGSN==false)
        {
             url = ULR_host+"/select_UnityLoginSesion.php";
        }
        else
        {
             url = "http://192.168.8.38/MarcadorSilberhorn/select_UnityLoginSesion.php";
        }

        WWWForm form = new WWWForm();
        //form.AddField("id", id);
        form.AddField("NumRamdom", numero);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
   
            string[] stringSeparators = new string[] { "+" };
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            sms = result[0];//PUEDE DEVOLVER 4 O 5
            ID_dato=result[1];//IMPORTANTE QUE LO TENGA YA QUE LO USO PARA VERIFICAR AL USUARIO Y OBTENER LOS VALORES QUE INSERTARA DE LA WEB Y SE REFLEJARA EN LA SIGUIENTE SCENEA 
            Debug.Log(result[1]+"numero de ID");
            // yield break;
            if(pararCorutine==false)
            {
            yield return www.SendWebRequest();
            StartCoroutine(LoginSession(numero));
            }
           
    
    
    }
}
