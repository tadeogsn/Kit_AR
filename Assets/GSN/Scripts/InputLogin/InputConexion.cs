using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class InputConexion : MonoBehaviour
{
    public InputField mainInputField;
    bool boolcambiosDeScena;
    public Text textLOG;
    string sms;
    string boolAcceso;
    string textInput;

    bool isWorking=false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(mainInputField.text!="")
        {
            textLOG.text="";
        }
        if(boolAcceso=="1")
        {
            Debug.Log("si entro");
            textLOG.text="";
            // en esta parte cargara la pagina automaticamente
            // en esta parte se cargara la escena que es correspondiente de RA
        }
         if(boolAcceso!="1")
        {
            textLOG.text=sms;
            
        }
    }
    public void cambioDeScena()
    {
        isWorking=true;
          textInput=mainInputField.text;
            Debug.Log(textInput);
            //Debug.Log(boolcambiosDeScena);
            StartCoroutine(unity(textInput));
            if(mainInputField.text=="")
            {
                textLOG.text="Ingresar la informacion correspondiente";
            }
          
       
           
        

    }

    IEnumerator unity(string numero)
    {
        isWorking=true;
        string url = "http://localhost/MarcadorSilberhorn/loguear.php";
        //string url = "http://192.168.20.22:82/servidor/mabe.php";

        WWWForm form = new WWWForm();
        //form.AddField("id", id);
        form.AddField("usuario", numero);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        //.chunkedTransfer = false;
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
    if (isWorking==true) 
    {
            string[] stringSeparators = new string[] { "+" };
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            //Debug.Log(result + "hola");
            sms = result[2];
            boolAcceso= result[3];

           


            Debug.Log(boolAcceso);
            yield return www.SendWebRequest();
            StartCoroutine(unity(numero));
            isWorking=false;

    
    }
    }
}
