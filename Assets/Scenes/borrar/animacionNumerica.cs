using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class animacionNumerica : MonoBehaviour
{
    // public SpriteRenderer prueba;
   public int velocidadDecambioNumero;// este es el numero inicial y se incrementara mas rapido entre mas grande sea el valor
   public int valorAnterior;
   public int valorActual;
   public Text textnum;
    // Start is called before the first frame update
    void Update()
    {
       // si el "valoranterior" es mayor, sucedera esta serie de condiciones
        //  for(int i=0; i<valorActual; i++)
        //  {

        //      valorAnterior+=i;
        //      textnum.text= valorAnterior.ToString();
        //  }   

        if(valorAnterior<valorActual)
        {
                if(valorAnterior==valorActual)
                {
                    textnum.text=valorAnterior.ToString();
                }
                else if(valorAnterior>valorActual)
                {
                    valorAnterior= valorAnterior-1;
                    textnum.text=valorAnterior.ToString();
                }
                else if(valorAnterior<valorActual)
                {
                    valorAnterior= valorAnterior+1;
                    textnum.text=valorAnterior.ToString();
                }
        }
        // si el valor es menor al "valoranterior" sucederan esta serie de condiciones 
         if(valorAnterior>valorActual)
         {
                if(valorAnterior==valorActual)
                {
                    textnum.text=valorAnterior.ToString();
                }
                else if(valorAnterior>valorActual)
                {
                    valorAnterior= valorAnterior-1;
                    textnum.text=valorAnterior.ToString();
                }
                else if(valorAnterior<valorActual)
                {
                    valorAnterior= valorAnterior-1;
                    textnum.text=valorAnterior.ToString();
                }
        }
    }


}
