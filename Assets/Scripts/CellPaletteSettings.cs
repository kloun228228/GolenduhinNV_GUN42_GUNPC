using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CellPaletteSettings", menuName = "Tactics/Cell Palette Settings")]
public class CellPaletteSettings : ScriptableObject
{
    [Header("Материалы для подсветки клеток")]
    [SerializeField] private Material _defaultMaterial;
    [SerializeField] private Material _selectedMaterial;
    [SerializeField] private Material _walkableMaterial;
    [SerializeField] private Material _attackableMaterial;

   
    public Material GetMaterial(NeighbourType type)
    {
        return type switch
        {
            NeighbourType.Selected => _selectedMaterial,
            NeighbourType.Walkable => _walkableMaterial,
            NeighbourType.Attackable => _attackableMaterial,
            _ => _defaultMaterial 
        };
    }
}