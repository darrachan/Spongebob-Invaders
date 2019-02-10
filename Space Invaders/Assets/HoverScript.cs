using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems; 

public class HoverScript : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    // Start is called before the first frame update
    public void OnPointerEnter(PointerEventData eventData)
     {
         this.GetComponent<Text>().color = Color.red;
     }
 
     public void OnPointerExit(PointerEventData eventData)
     {
         this.GetComponent<Text>().color = Color.white;
     }
}
