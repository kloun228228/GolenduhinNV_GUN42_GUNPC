// Файл: CellManager.cs
using System.Collections.Generic;
using UnityEngine;

public class CellManager : MonoBehaviour
{
    // Синглтон для быстрого доступа из других скриптов
    public static CellManager Instance { get; private set; }

    [Header("Настройки палитры")]
    [SerializeField] private CellPaletteSettings _paletteSettings;

    // Списки клеток по ТЗ
    private List<Cell> _allCells = new List<Cell>();
    private List<Cell> _selectedCells = new List<Cell>();

    private void Awake()
    {
        // Настройка Синглтона
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    
    public void RegisterCell(Cell cell)
    {
        if (!_allCells.Contains(cell))
        {
            _allCells.Add(cell);
        }
    }

    
    public void ClearSelect()
    {
       
        foreach (var cell in _selectedCells)
        {
            if (cell != null)
            {
               
                Material defaultMat = _paletteSettings.GetMaterial(NeighbourType.None);
                cell.SetSelect(defaultMat);
            }
        }

     
        _selectedCells.Clear();
    }

    public void SetSelectNeighbors(Cell centerCell, int radius, NeighbourType type)
    {
        
        ClearSelect();

        if (centerCell == null) return;

        Material targetMaterial = _paletteSettings.GetMaterial(type);

       
        foreach (var cell in _allCells)
        {
           
            float distance = Vector3.Distance(centerCell.transform.position, cell.transform.position);

            
            if (distance <= radius + 0.1f)
            {
                cell.SetSelect(targetMaterial); 
                _selectedCells.Add(cell);       
            }
        }
    }
}