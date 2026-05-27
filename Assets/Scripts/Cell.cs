using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.EventSystems;

public class Cell : MonoBehaviour, IPointerEnterHandler, IPointerClickHandler, IPointerExitHandler
{
    [SerializeField]
    public MeshRenderer _focus;
    [SerializeField]
    public MeshRenderer _selected;
    public event Action<Cell> OnPointerClickEvent;

    public void SetSelect(Material material)
    {
        _selected.enabled = true;
        _selected.material = material;
    }
    public void ResetSelect()
    {
        _selected.enabled = false;
    }



    public void OnPointerClick(PointerEventData eventData)
    {
        OnPointerClickEvent?.Invoke(this);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        _focus.enabled = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        _focus.enabled = false;
    }

}



