using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonController : MonoBehaviour, IPointerClickHandler
{
    public GameObject background;
    public GameObject resume;
    public GameObject exit;
    public GameObject text_Pause;

    // Metodo para controlar cuando hace un toque
    public void OnPointerClick(PointerEventData eventData)
    {
        // Si el objeto tocado tiene el nombre Menu  
        if(gameObject.name == "Menu"){

            // Para el tiempo en el juego
            Time.timeScale = 0;

            // Muestra objetos al usuario
            background.SetActive(true);

            resume.SetActive(true);

            exit.SetActive(true);

            text_Pause.SetActive(true);

        }

        // Si el objeto tocado tiene el nombre Resume      
        else if (gameObject.name == "Resume"){
            
            // Reanuda el tiempo en el juego
            Time.timeScale = 1;

            // Esconde objetos al usuario
            background.SetActive(false);

            resume.SetActive(false);

            exit.SetActive(false);

            text_Pause.SetActive(false);
            
        }

        // Si el objeto tocado tiene el nombre Exit  
        else if(gameObject.name == "Exit"){

            // Carga otra escena 
            SceneManager.LoadScene(0);

        }
        
        
         
    }
}

