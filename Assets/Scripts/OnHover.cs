using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class OnHover : MonoBehaviour
{

    public TextMeshProUGUI myTextArray;

    public void OnPointerEnter(PointerEventData eventData)
    {
        myTextArray.color = Color.yellow;
        Debug.Log("entered");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        myTextArray.color = Color.white;
        Debug.Log("exited");
    }
}
