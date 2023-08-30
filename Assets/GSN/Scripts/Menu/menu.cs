using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

using UnityEngine.SceneManagement;
using UnityEngine.Networking;
using System;

public class menu : MonoBehaviour
{
    public bool hostGSN;
    public string ULR_host;


    //variables que recibira la consulta de la BASE DE DATOS
    string resultNombreEmpresa;
    string numeroAccesoEmpresa;

    public GameObject ObteniendoPermisos;


     // CUIDAR QUE EL NOMBRE COINCIDA CON EL DE LA BASE DE DATOS
     public string NombreEmpresaAcceso;
    // Start is called before the first frame update
    void Start(){
        StartCoroutine(LoginSession(NombreEmpresaAcceso));
    }
   
    public void consultaAccesoEmpresa(string nombreScena)
    {
        
                SceneManager.LoadScene(nombreScena);
        
     

    }
    
    IEnumerator LoginSession(string nombreEmpresa)
    {
        //Debug.Log(numero);
        string url;
        if(hostGSN==false)
        {
             url = ULR_host+"/accesoEmpresa.php";
        }
        else
        {
             url = "http://192.168.8.38/MarcadorSilberhorn/accesoEmpresa.php";
        }

        WWWForm form = new WWWForm();
        //form.AddField("id", id);
        form.AddField("nombreEmpresa", nombreEmpresa);//son los campos que se envian a ala consulta para verificar que existe el numero
        UnityWebRequest www = UnityWebRequest.Post(url, form);
        WWW dataResult = new WWW(url, form);
        yield return dataResult; // wait until data is received
        string data = dataResult.text;
   
            string[] stringSeparators = new string[] { "+" };
            string[] result;
            result = data.Split(stringSeparators, StringSplitOptions.None);
            resultNombreEmpresa = result[1];//PUEDE DEVOLVER 4 O 5
            numeroAccesoEmpresa=result[2];//IMPORTANTE QUE LO TENGA YA QUE LO USO PARA VERIFICAR AL USUARIO Y OBTENER LOS VALORES QUE INSERTARA DE LA WEB Y SE REFLEJARA EN LA SIGUIENTE SCENEA 
            Debug.Log(result[2]+"numero de ID");
            if(numeroAccesoEmpresa=="1"){
                ObteniendoPermisos.SetActive(false);
            }else{
                ObteniendoPermisos.SetActive(true);
            }
             yield return new WaitForSeconds(1f);
            StartCoroutine(LoginSession(nombreEmpresa));
    
    
    }
}
