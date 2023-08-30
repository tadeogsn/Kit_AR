using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class transparenciaModelo
{
    public GameObject TransparenciaMesh;
    public GameObject canvasError;
    public Material[] defaultMaterials; // Array de materiales originales
    public Material transparentMaterial; // Material transparente

}
[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class eventoOEE
{
    // public string NombreVariable="OEE";
    public GameObject objetoEvento;
    public GameObject graficaOEE;
    public GameObject camaraOBJ;
    public GameObject objetoRotate;
    public bool banderaOEE;
    // public string AgregarSimboloDeInidicador;
  

    
}
[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class eventoContPieazs
{
     public Text getvalueText;  
     public GameObject temperatura;//para extraer el mesh
     public GameObject graficaConteoPiezas;
     public Color[] defaultColor;
     public Color colorRojo = Color.red;
  

    
}
[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity

public class Presion
{
    public Text getvalueText;  
     public GameObject temperatura;//para extraer el mesh
     public GameObject graficaPresion;
     public Color[] defaultColor;
     public Color colorRojo = Color.red;

    
}

[System.Serializable]//esta parte es para mi objeto sirva en el entorno grafico de unity
public class eventoTemperature
{
    // public string NombreVariable="Temperatura";
    public Text getvalueText;  
     public GameObject temperatura;//para extraer el mesh
     public GameObject graficaTemperatura;
     public Color[] defaultColor;
     public Color colorRojo = Color.red;
    
}
public class IOTevents : MonoBehaviour
{
   
    public eventoOEE[] objOEE;
    public eventoTemperature[] objtemperatura;

    public Presion[] objPresion;
    public eventoContPieazs[] objConteoPiezas;

    public transparenciaModelo[] ModeloTranparente;
    float parpadeoTemp=.5f;
    float parpadeoTemp2=.5f;

    float parpadeoPresion=.5f;
    float parpadeoPresion2=.5f;

    float parpadeoConteoPiezas=.5f;
    float parpadeoConteoPiezas2=.5f;
   
    // Start is called before the first frame update
    public bool bandera=false;

     public Material materialTransparente;
     //public Material materialDefault;

     //public Text logScreen;

     public List<Renderer> ejemplo = new List<Renderer>();

     //VALORES BOLEANOS PARA CONDICIONAR LA APRICION DEL MODELO TRANAPARENTE DEL MODELO 

     private bool boolPresion;
     private bool boolOEE;
     private bool boolConteoPiezas;
     private bool boolTemperature;

    
     bool bandera1=false;
     bool bandera2= false;


    //variables de objeto modelo
     private MeshRenderer[] hijos;
     private Color[] default_color;
     public void Awake() {
         
     }
    void Start()
    {
        // Dentro del método Start()
        for (int x = 0; x < ModeloTranparente.Length; x++)
        {
            hijos = ModeloTranparente[x].TransparenciaMesh.GetComponentsInChildren<MeshRenderer>();
            ModeloTranparente[x].defaultMaterials = new Material[hijos.Length];
            for (int y = 0; y < hijos.Length; y++)
            {
                ModeloTranparente[x].defaultMaterials[y] = hijos[y].material;
            }
        }

        //OBJETO TEMPERATURA
        for (int x = 0; x <objtemperatura.Length; x++)
        {  
                    objtemperatura[x].defaultColor = new Color[objtemperatura[x].temperatura.GetComponent<Renderer>().materials.Length];
                   // Debug.Log("X= "+x+" Y= "0" length de colores");
                   //ModeloTranparente[x].defaultColor = new Color[ModeloTranparente[x].TransparenciaMesh.GetComponent<MeshRenderer>().materials.Length];
                for (int i = 0; i < objtemperatura[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
                {
                     objtemperatura[x].defaultColor[i]  = objtemperatura[x].temperatura.GetComponent<Renderer>().materials[i].GetColor("_Color");//material color
                      
                }
        } 
        //OBJETO PRESION
        for (int x = 0; x <objPresion.Length; x++)
        {  
                    objPresion[x].defaultColor = new Color[objPresion[x].temperatura.GetComponent<Renderer>().materials.Length];
                   // Debug.Log("X= "+x+" Y= "0" length de colores");
                   //ModeloTranparente[x].defaultColor = new Color[ModeloTranparente[x].TransparenciaMesh.GetComponent<MeshRenderer>().materials.Length];
                for (int i = 0; i < objPresion[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
                {
                     objPresion[x].defaultColor[i]  = objPresion[x].temperatura.GetComponent<Renderer>().materials[i].GetColor("_Color");//material color
                      
                }
        } 

        //OBJETO Conteo de peizas
        for (int x = 0; x <objConteoPiezas.Length; x++)
        {  
                    objConteoPiezas[x].defaultColor = new Color[objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials.Length];
                   // Debug.Log("X= "+x+" Y= "0" length de colores");
                   //ModeloTranparente[x].defaultColor = new Color[ModeloTranparente[x].TransparenciaMesh.GetComponent<MeshRenderer>().materials.Length];
                for (int i = 0; i < objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
                {
                     objConteoPiezas[x].defaultColor[i]  = objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials[i].GetColor("_Color");//material color
                      
                }
        }
        //FIN
        
        //OBJETO TRNASPARENCIA MODELO 
           
        //FIN
    }

    // Update is called once per frame
    void Update()
    {
        
        //Dato TEMPERATURA
       
         var intTemperature =int.Parse(WebServicesPaginaWeb.Temperatura); 
         var intOEE         =int.Parse(WebServicesPaginaWeb.OEE);
         var intPresion     =int.Parse(WebServicesPaginaWeb.presion);
         var intConteoPiezas=int.Parse(WebServicesPaginaWeb.conteoPiezas);
      
        
          
        if(intTemperature>60)//Valor critico
        {
            Debug.Log(intTemperature);
            funcTemperaturaColorTransparencia();
            boolTemperature=true;   
        }else
        {
            funcTemperaturaColorDefault();
            boolTemperature=false;
        }
        if(intPresion<60)
        {
            funcPresionTransparencia();
            boolPresion=true;
        }else
        {
            funcPresionColorDefault();
            boolPresion=false;
        }
        if(intOEE<80)
        {
            //funcion de oee
            enableTransparenciaOEE();
            boolOEE=true;
        }
        else
        {

            defaultColorOEE();
             boolOEE=false;
            //func de oee
        }
        if(intConteoPiezas<90)
        {
            boolConteoPiezas=true;
            funcConteoPiezasTransparencia();
        }else
        {
            funcConteoPiezasColorDefault(); 
            boolConteoPiezas=false;   
        }
        //Cualquier bool activado hara que el modelo se vuelba tranparente 
        if(boolConteoPiezas==true || boolPresion==true || boolTemperature==true || boolOEE==true)
        {       
           
            if(bandera1==false)
            {
                enableTransparenciaModel();
                bandera1=true;
            }
             
        }
        else
        {
           if(bandera1==true)
            {
            defaultColorModel();
            bandera1=false;
            }
        
        }

        

        // funcTemperaturaColorTransparencia();
        // funcPresionTransparencia();
        // funcConteoPiezasTransparencia();
    


    void funcTemperaturaColorTransparencia()
    {
        for (int x = 0; x <objtemperatura.Length; x++)
        {   
            //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objtemperatura[x].graficaTemperatura.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=10;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
            for (int i = 0; i < objtemperatura[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {
                //funcion del modelo
                    parpadeoTemp-=Time.deltaTime;
                    // sDebug.Log(parpadeo);
                    if(parpadeoTemp<0f)
                    {
                        objtemperatura[x].temperatura.GetComponent<Renderer>().materials[i].color = objtemperatura[x].colorRojo;
                        parpadeoTemp2-=Time.deltaTime;

                        if(parpadeoTemp2<0f)
                        {
                            objtemperatura[x].temperatura.GetComponent<Renderer>().materials[i].color = objtemperatura[x].defaultColor[i];
                            parpadeoTemp=.5f;
                            parpadeoTemp2=.5f;
                            Debug.Log("entro");
                        }
                        
                    } 
                 //objtemperatura[x].temperatura.GetComponent<Renderer>().materials[i].color = objtemperatura[x].defaultColor[i];
              
            }    
        }
    }
    void funcTemperaturaColorDefault()
    {
        for (int x = 0; x <objtemperatura.Length; x++)
        {   
             //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objtemperatura[x].graficaTemperatura.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                         all[i].gameObject.layer=0;//0 pertenece al layer de default
                }
            //FIN LAYER
            for (int i = 0; i < objtemperatura[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {
              
                
                objtemperatura[x].temperatura.GetComponent<Renderer>().materials[i].color = objtemperatura[x].defaultColor[i];
                
            }    
        }
    }



    void funcPresionTransparencia()
    {
        for (int x = 0; x <objPresion.Length; x++)
        {   
            //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objPresion[x].graficaPresion.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=10;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
            for (int i = 0; i < objPresion[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {  //funcion del modelo
                    parpadeoPresion-=Time.deltaTime;
                    // sDebug.Log(parpadeo);
                    if(parpadeoPresion<0f)
                    {
                            objPresion[x].temperatura.GetComponent<Renderer>().materials[i].color = objPresion[x].colorRojo;
                            parpadeoPresion2-=Time.deltaTime;

                        if(parpadeoPresion2<0f)
                        {
                            objPresion[x].temperatura.GetComponent<Renderer>().materials[i].color = objPresion[x].defaultColor[i];
                            parpadeoPresion =.5f;
                            parpadeoPresion2=.5f;
                            Debug.Log("entro");
                        }
                        
                    }
               
            }    
        }
    }
    void funcPresionColorDefault()
    {
        for (int x = 0; x <objPresion.Length; x++)
        {   
            //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objPresion[x].graficaPresion.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=0;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
            for (int i = 0; i < objPresion[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {
               
                objPresion[x].temperatura.GetComponent<Renderer>().materials[i].color = objPresion[x].defaultColor[i];
                
            }    
        }
    }
    void funcConteoPiezasTransparencia()
    {
        for (int x = 0; x <objConteoPiezas.Length; x++)
        {   
            //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objConteoPiezas[x].graficaConteoPiezas.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=10;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
            for (int i = 0; i < objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {  //funcion del modelo
                    parpadeoConteoPiezas-=Time.deltaTime;
                    // sDebug.Log(parpadeo);
                    if(parpadeoConteoPiezas<0f)
                    {
                            objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials[i].color = objConteoPiezas[x].colorRojo;
                            parpadeoConteoPiezas2-=Time.deltaTime;

                        if(parpadeoConteoPiezas2<0f)
                        {
                            objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials[i].color = objConteoPiezas[x].defaultColor[i];
                            parpadeoConteoPiezas =.5f;
                            parpadeoConteoPiezas2=.5f;
                            Debug.Log("entro");
                        }
                        
                    }
               
            }    
        }
    }
    void funcConteoPiezasColorDefault()
    {
        for (int x = 0; x <objConteoPiezas.Length; x++)
        {   
            // //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objConteoPiezas[x].graficaConteoPiezas.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=0;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
            for (int i = 0; i < objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials.Length; i++)
            {
               
                objConteoPiezas[x].temperatura.GetComponent<Renderer>().materials[i].color = objConteoPiezas[x].defaultColor[i];
                
            }    
        }
    }
    ////FUNCIONES DE MODELOS TRANSPARENCIA Y COLOR DEFAULT DEL MISMO MODELO
    void enableTransparenciaModel()
    {
      for (int x = 0; x <ModeloTranparente.Length; x++)
       {    
           ModeloTranparente[x].canvasError.SetActive(true);
           ejemplo.AddRange(ModeloTranparente[x].TransparenciaMesh.GetComponentsInChildren<Renderer>());
           foreach (var gameobject in ejemplo)
               gameobject.sharedMaterial = materialTransparente;
       } 
    }


        void defaultColorModel()
        {
            for (int x = 0; x < ModeloTranparente.Length; x++)
            {
                ModeloTranparente[x].canvasError.SetActive(false);
                for (int y = 0; y < hijos.Length; y++)
                {
                    if (ModeloTranparente[x].defaultMaterials.Length > y)
                    {
                        Material material = hijos[y].material;

                        // Restaurar el material original
                        Material defaultMaterial = ModeloTranparente[x].defaultMaterials[y];
                        material.CopyPropertiesFromMaterial(defaultMaterial);

                        // Cambiar a transparente si es necesario
                        if (bandera1)
                        {
                            material.shader = ModeloTranparente[x].transparentMaterial.shader;
                        }
                    }
                }
            }
        }



        void enableTransparenciaOEE()
    {
       for (int x = 0; x <objOEE.Length; x++)
       {
           //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objOEE[x].graficaOEE.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=10;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
             objOEE[x].objetoEvento.SetActive(true);
             //objOEE[x].enableOrDisable.enabled=true;
             ///rotation del modelo deacuerdo a la rotacion de la camara 
         if(objOEE[x].banderaOEE==false)
         {
            // Vector3 anguloY = objOEE[x].camaraOBJ.GetComponent<Transform>().rotation.eulerAngles;
            // //Debug.Log(OBJcamera.GetComponent<Transform>().rotation.eulerAngles);

            // anguloY.z = 0;
            // anguloY.x = 0;
            //ESTA ROTACION NO SIRVE, EN LA APLICACION SE VE ESTATICA, SI SE NECESITA MODIFICAR ESTE SERIA EL PUNTO, LA LINEA DE CODIGO QUE ESTA NO CAUSA NADA EN LA APLICACION
            objOEE[x].objetoRotate.transform.localRotation = Quaternion.Euler(0,objOEE[x].camaraOBJ.transform.rotation.y,0);
            objOEE[x].banderaOEE=true;
         }
         
       }
      
    }
    void defaultColorOEE()
    {
       for (int x = 0; x <objOEE.Length; x++)
       {
           objOEE[x].banderaOEE=false;//bandera para poner el valor predeterminado en la funcion enableTransparenciaOEE
           //LAYER
                 //activar el layer numero 10 que es el que pertene a su propiedad("temperatura")
                //Este layer sirve para descativar o activar los paneles cuando hay un valor critico 
                //este layer se actvia desde el scrip "Example class" que esta en la camara "ARcamera" en el apartado "Exculde layers"
                Transform[] all = objOEE[x].graficaOEE.GetComponentsInChildren<Transform>();
                for(int i=0; i<all.Length; i++)
                {
                     all[i].gameObject.layer=0;//10 pertenece al layer de temperartura
                }
            //FIN LAYER
         objOEE[x].objetoEvento.SetActive(false);
         //objOEE[x].enableOrDisable.enabled=false;
         objOEE[x].objetoRotate.transform.localRotation= Quaternion.Euler(0,0,0);

       }
    }
}
}
