using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;
using UnityEngine;

public class UxManager : MonoBehaviour, IPointerClickHandler
{
    // Metodo para controlar cuando hace un toque
    public void OnPointerClick(PointerEventData eventData)
    {
        // Si el objeto tocado tiene el nombre Play        
        if(gameObject.name == "Play"){

            SceneManager.LoadScene(3);

        }
        // Si el objeto tocado tiene el nombre Statistics   
        else if(gameObject.name == "Statistics"){
            SceneManager.LoadScene(2);
        }
        // Si el objeto tocado tiene el nombre Exit   
        else if(gameObject.name == "Exit"){
            Application.Quit();

        }
        // Si el objeto tocado tiene el nombre Game1   
        else if(gameObject.name == "Game1"){
            SceneManager.LoadScene(1);
        }
        
        
         
    }
}
