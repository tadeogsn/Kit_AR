using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class Grafica
{
    public string NombreGrafica;//esta variable es simbolica para que sepan cual es el nombre de la grafica
    public Text TextUiNombreGrafica;
    public Text textUINumero;
    public int valoMaximoGrafica;
    public int RangoCriticoMax;
    public int RangoCriticoMin;
    public int RangoDeAbvertenciaMax;
    public int RangoDeAbvertenciaMin;
    
    public int RangoEstableMax;
    public int RangoEstableMin;
    public Image grafica;
//     
    public Color ColorCritico;
    public Color ColorAbvertencia;
    public Color ColorEstable;

    public GameObject doughnutModel;
    public  Material material;
    public  Renderer renderer;

    // Referencia al Material del modelo 3D


    // Arrastra el modelo 3D aquí desde el Inspector
    //    public void ActualizarFillAmount(float fillAmount)
    ////    {
    //////Material materialGraficaDona = grafica.material; // Obtener el material de la gráfica (asegúrate de haber asignado el material correctamente)
    ////        materialGraficaDona.SetFloat("_FillAmount", fillAmount); // Actualizar el valor del "_FillAmount" en el material de la gráfica
    //    }

}
    public class Graficas : MonoBehaviour
    {
    public Grafica[] datosGraficas;
    
    // Start is called before the first frame update
    // Update is called once per frame

    private void Start() 
    {
        for (int i = 0; i < datosGraficas.Length; i++)
        {
         datosGraficas[i].TextUiNombreGrafica.text=datosGraficas[i].NombreGrafica;
            // Obtener el Renderer del modelo 3D
         datosGraficas[i].renderer = datosGraficas[i].doughnutModel.GetComponent<Renderer>();
            // Obtener el Material del modelo 3D y guardarlo en una variable
            datosGraficas[i].material = datosGraficas[i].renderer.material;
        }
    }
    void Update()
    {
        
        for (int i = 0; i < datosGraficas.Length; i++)
        {   
            for (int x= 0; x < WebServicesPaginaWeb.servicio.varibles.Length; x++)// esta varible viene de otro script "WebServicesPaginaWeb"
            {   
            //Debug.Log("CONTAR CARACTEES DE 'CONTEO PIEZAS' "+" "+ WebServicesPaginaWeb.servicio.varibles[x].AgregarSimboloDeInidicador+ " tamaño de string "+ WebServicesPaginaWeb.servicio.varibles[x].AgregarSimboloDeInidicador.Length);
            // Debug.Log("valor de i= "+i+" valor de X= "+x);
            
             // en el substring vamos a obtner el valor completo de string ejemplo= "10%" y el weservicePaginaWb.... nos servira para obtener el final del caracte ejemplo= "%" y cortar sin importar el numero de string ejemplo="pza/h"
                if(x==0&& datosGraficas[i].NombreGrafica =="OEE")//OEE
                {
                    float valorConvetido = float.Parse(datosGraficas[i].textUINumero.text.Substring(0,datosGraficas[i].textUINumero.text.Length-WebServicesPaginaWeb.servicio.varibles[0].AgregarSimboloDeInidicador.Length));
                    Debug.Log("valor convertido "+ valorConvetido);
                    datosGraficas[i].grafica.fillAmount = valorConvetido / datosGraficas[i].valoMaximoGrafica * 1;
                    datosGraficas[i].material.SetFloat("_FillAmount", valorConvetido / datosGraficas[i].valoMaximoGrafica * 1);
                    //se activan funciones dependiendo del valor actual
                    //if(valorConvetido>datosGraficas[i].RangoCritico||valorConvetido<datosGraficas[i].RangoEstable)
                   if (valorConvetido<=datosGraficas[i].RangoCriticoMax&&valorConvetido>=datosGraficas[i].RangoCriticoMin)
                   {
                        FunctionCritico();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoDeAbvertenciaMax&&valorConvetido>=datosGraficas[i].RangoDeAbvertenciaMin)
                   {
                        FunctionAbvertencia();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoEstableMax && valorConvetido>=datosGraficas[i].RangoEstableMin)
                   {
                        FunctionEstable();
                   }

                }
                if(x==1&& datosGraficas[i].NombreGrafica=="TEMPERATURA")//TEMPERATURA
                {
                    float valorConvetido = float.Parse(datosGraficas[i].textUINumero.text.Substring(0,datosGraficas[i].textUINumero.text.Length-WebServicesPaginaWeb.servicio.varibles[1].AgregarSimboloDeInidicador.Length));
                    Debug.Log("valor convertido "+ valorConvetido);
                    datosGraficas[i].grafica.fillAmount = valorConvetido / datosGraficas[i].valoMaximoGrafica * 1;
                    datosGraficas[i].material.SetFloat("_FillAmount", valorConvetido / datosGraficas[i].valoMaximoGrafica * 1);
                    //se activan funciones dependiendo del valor actual
                    //if(valorConvetido>datosGraficas[i].RangoCritico||valorConvetido<datosGraficas[i].RangoEstable)
                    if (valorConvetido<=datosGraficas[i].RangoCriticoMax&&valorConvetido>=datosGraficas[i].RangoCriticoMin)
                   {
                        FunctionCritico();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoDeAbvertenciaMax&&valorConvetido>=datosGraficas[i].RangoDeAbvertenciaMin)
                   {
                        FunctionAbvertencia();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoEstableMax && valorConvetido>=datosGraficas[i].RangoEstableMin)
                   {
                        FunctionEstable();
                   }

                }
                if(x==2 && datosGraficas[i].NombreGrafica=="PRESIÓN")//PORESION
                {
                    float valorConvetido = float.Parse(datosGraficas[i].textUINumero.text.Substring(0,datosGraficas[i].textUINumero.text.Length-WebServicesPaginaWeb.servicio.varibles[2].AgregarSimboloDeInidicador.Length));
                    Debug.Log("valor convertido "+ valorConvetido);
                    datosGraficas[i].grafica.fillAmount = valorConvetido / datosGraficas[i].valoMaximoGrafica * 1;
                    datosGraficas[i].material.SetFloat("_FillAmount", valorConvetido / datosGraficas[i].valoMaximoGrafica * 1);
                    //se activan funciones dependiendo del valor actual
                    //if(valorConvetido>datosGraficas[i].RangoCritico||valorConvetido<datosGraficas[i].RangoEstable)
                    if (valorConvetido<=datosGraficas[i].RangoCriticoMax&&valorConvetido>=datosGraficas[i].RangoCriticoMin)
                   {
                        FunctionCritico();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoDeAbvertenciaMax&&valorConvetido>=datosGraficas[i].RangoDeAbvertenciaMin)
                   {
                        FunctionAbvertencia();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoEstableMax && valorConvetido>=datosGraficas[i].RangoEstableMin)
                   {
                        FunctionEstable();
                   }

                }
                if(x==3 && datosGraficas[i].NombreGrafica=="CONTEO DE PIEZAS")//CONTEO DE PIEZAS
                {
                    float valorConvetido = float.Parse(datosGraficas[i].textUINumero.text.Substring(0,datosGraficas[i].textUINumero.text.Length-WebServicesPaginaWeb.servicio.varibles[3].AgregarSimboloDeInidicador.Length));
                    Debug.Log("valor convertido "+ valorConvetido);
                    datosGraficas[i].grafica.fillAmount = valorConvetido / datosGraficas[i].valoMaximoGrafica * 1;
                    datosGraficas[i].material.SetFloat("_FillAmount", valorConvetido / datosGraficas[i].valoMaximoGrafica * 1);
                    //se activan funciones dependiendo del valor actual
                    //if(valorConvetido>datosGraficas[i].RangoCritico||valorConvetido<datosGraficas[i].RangoEstable)
                    if (valorConvetido<=datosGraficas[i].RangoCriticoMax&&valorConvetido>=datosGraficas[i].RangoCriticoMin)
                   {
                        FunctionCritico();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoDeAbvertenciaMax&&valorConvetido>=datosGraficas[i].RangoDeAbvertenciaMin)
                   {
                        FunctionAbvertencia();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoEstableMax && valorConvetido>=datosGraficas[i].RangoEstableMin)
                   {
                        FunctionEstable();
                   }

                }
                if(x==4 && datosGraficas[i].NombreGrafica=="NUMEROACCESO")//CONTEO DE PIEZAS
                {
                    float valorConvetido = float.Parse(datosGraficas[i].textUINumero.text.Substring(0,datosGraficas[i].textUINumero.text.Length-WebServicesPaginaWeb.servicio.varibles[4].AgregarSimboloDeInidicador.Length));
                    Debug.Log("valor convertido "+ valorConvetido);
                    datosGraficas[i].grafica.fillAmount = valorConvetido / datosGraficas[i].valoMaximoGrafica * 1;
                    datosGraficas[i].material.SetFloat("_FillAmount", valorConvetido / datosGraficas[i].valoMaximoGrafica * 1);
                    //se activan funciones dependiendo del valor actual
                    //if(valorConvetido>datosGraficas[i].RangoCritico||valorConvetido<datosGraficas[i].RangoEstable)
                    if (valorConvetido<=datosGraficas[i].RangoCriticoMax&&valorConvetido>=datosGraficas[i].RangoCriticoMin)
                   {
                        FunctionCritico();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoDeAbvertenciaMax&&valorConvetido>=datosGraficas[i].RangoDeAbvertenciaMin)
                   {
                        FunctionAbvertencia();
                   }
                   if(valorConvetido<=datosGraficas[i].RangoEstableMax && valorConvetido>=datosGraficas[i].RangoEstableMin)
                   {
                        FunctionEstable();
                   }

                }



                
            }
           
        }
    }

    private void FunctionCritico()
    {
        for (int i = 0; i < datosGraficas.Length; i++)
        {
            datosGraficas[i].grafica.color= datosGraficas[i].ColorCritico;
        }
        
    }
    private void FunctionAbvertencia()
    {
        for (int i = 0; i < datosGraficas.Length; i++)
        {
            datosGraficas[i].grafica.color= datosGraficas[i].ColorAbvertencia;
        }
        
    }
    private void FunctionEstable()
    {
        for (int i = 0; i < datosGraficas.Length; i++)
        {
            datosGraficas[i].grafica.color= datosGraficas[i].ColorEstable;
        }
        
    }
    
    
}
