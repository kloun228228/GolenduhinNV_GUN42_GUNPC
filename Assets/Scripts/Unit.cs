using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;
using System;

public class Unit : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    [SerializeField, Range(3f, 15f)]
    public float _moveSpeed = 5f;
    public Cell CurrentCell {  get; set; }
    public void Move(Cell targetCell, Action OnMoveEndCallback)
    {
        StartCoroutine(MoveRoutine(targetCell, OnMoveEndCallback));
    }
    IEnumerator MoveRoutine(Cell targetCell, Action OnMoveEndCallback)
    {
        while (Vector3.Distance(transform.position, targetCell.transform.position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, targetCell.transform.position, _moveSpeed * Time.deltaTime);
            yield return null;
            
           
        }
        transform.position = targetCell.transform.position;
        CurrentCell = targetCell;
        OnMoveEndCallback?.Invoke();

    }
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        CurrentCell?.OnPointerEnter(eventData);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        CurrentCell?.OnPointerExit(eventData);
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        CurrentCell?.OnPointerClick(eventData);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
