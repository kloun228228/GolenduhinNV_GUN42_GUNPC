using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using TMPro;


public class InputManager : MonoBehaviour
{
    
    
    private Controls _controls;
    [SerializeField] private Image _fillBar;
    [SerializeField] private float _resetSpeed = 1f;
   

    public void Awake()
    {
        _controls = new Controls();
    }
    public void OnEnable()
    {
        _controls.Enable();
    }
    public void OnDisable()
    {
        _controls.Disable();
    }



    public void Update()
    {
        if (_controls.Game.Restart.IsPressed())
        {
            _fillBar.fillAmount += _resetSpeed * Time.deltaTime; 
            if(_fillBar.fillAmount >= 1)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            
        }
        else
        {
            _fillBar.fillAmount = 0f;
        }
    }




















}

