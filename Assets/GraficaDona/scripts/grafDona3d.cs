using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class grafDona3d : MonoBehaviour
{
    public GameObject doughnutModel; // Arrastra el modelo 3D aquí desde el Inspector
    public  Material materialGraficaDona; // Referencia al Material del modelo 3D
    public int valoMaximoGrafica;
    public int RangoCriticoMax;
    public int RangoCriticoMin;
    public int RangoDeAbvertenciaMax;
    public int RangoDeAbvertenciaMin;

    public int RangoEstableMax;
    public int RangoEstableMin;
    public Color ColorCritico;
    public Color ColorAbvertencia;
    public Color ColorEstable;
    void Start()
    {
        // Obtener el Renderer del modelo 3D
        Renderer renderer = doughnutModel.GetComponent<Renderer>();

        // Obtener el Material del modelo 3D y guardarlo en una variable
        materialGraficaDona = renderer.material;
    }

    void Update()
    {
        // Asignar el valor del Slider a la propiedad Fill Amount
        if (gameObject.name== "OEE")
        {
            float valorConvetido = int.Parse(WebServicesPaginaWeb.OEE);
            Debug.Log("valor " + gameObject.name + " =" + valorConvetido);
            materialGraficaDona.SetFloat("_FillAmount", valorConvetido / valoMaximoGrafica * 1);

            if (valorConvetido <= RangoCriticoMax && valorConvetido >= RangoCriticoMin)
            {
                FunctionCritico();
            }
            if (valorConvetido <= RangoDeAbvertenciaMax && valorConvetido >= RangoDeAbvertenciaMin)
            {
                FunctionAbvertencia();
            }
            if (valorConvetido <= RangoEstableMax && valorConvetido >= RangoEstableMin)
            {
                FunctionEstable();
            }
        }
        if (gameObject.name == "TEMPERATURA")
        {
            float valorConvetido = int.Parse(WebServicesPaginaWeb.Temperatura);
            Debug.Log("valor " + gameObject.name + " =" + valorConvetido);
            materialGraficaDona.SetFloat("_FillAmount", valorConvetido / valoMaximoGrafica * 1);
            if (valorConvetido <= RangoCriticoMax && valorConvetido >= RangoCriticoMin)
            {
                FunctionCritico();
            }
            if (valorConvetido <= RangoDeAbvertenciaMax && valorConvetido >= RangoDeAbvertenciaMin)
            {
                FunctionAbvertencia();
            }
            if (valorConvetido <= RangoEstableMax && valorConvetido >= RangoEstableMin)
            {
                FunctionEstable();
            }
        }
        if (gameObject.name == "PRESION")
        {
            float valorConvetido = int.Parse(WebServicesPaginaWeb.presion);
            Debug.Log("valor " + gameObject.name + " =" + valorConvetido);
            materialGraficaDona.SetFloat("_FillAmount", valorConvetido / valoMaximoGrafica * 1);
            if (valorConvetido <= RangoCriticoMax && valorConvetido >= RangoCriticoMin)
            {
                FunctionCritico();
            }
            if (valorConvetido <= RangoDeAbvertenciaMax && valorConvetido >= RangoDeAbvertenciaMin)
            {
                FunctionAbvertencia();
            }
            if (valorConvetido <= RangoEstableMax && valorConvetido >= RangoEstableMin)
            {
                FunctionEstable();
            }
        }
        if (gameObject.name == "CONTEO PIEZAS")
        {
            float valorConvetido = int.Parse(WebServicesPaginaWeb.conteoPiezas);
            Debug.Log("valor " + gameObject.name + " =" + valorConvetido);
            materialGraficaDona.SetFloat("_FillAmount", valorConvetido / valoMaximoGrafica * 1);
            if (valorConvetido <= RangoCriticoMax && valorConvetido >= RangoCriticoMin)
            {
                FunctionCritico();
            }
            if (valorConvetido <= RangoDeAbvertenciaMax && valorConvetido >= RangoDeAbvertenciaMin)
            {
                FunctionAbvertencia();
            }
            if (valorConvetido <= RangoEstableMax && valorConvetido >= RangoEstableMin)
            {
                FunctionEstable();
            }
        }
            
        
        
    }
    private void FunctionCritico()
    {

            materialGraficaDona.color = ColorCritico;
        
    }
    private void FunctionAbvertencia()
    {
       
            materialGraficaDona.color = ColorAbvertencia;
        

    }
    private void FunctionEstable()
    {
            materialGraficaDona.color  = ColorEstable;
        
            
    }
}