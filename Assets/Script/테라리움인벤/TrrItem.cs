using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

[CreateAssetMenu(menuName = "Script object/TrrItem")]
public class TrrItem : ScriptableObject
{
    [Header("Only gameplay")]
    public TileBase tile;
    public TrrItemType type;
    public ActionType actionType;
    public Vector2Int range = new Vector2Int(5, 4);

    [Header("Only UI")]
    public bool stackable = true;

    [Header("Both")]
    public Sprite image;

}

public enum TrrItemType
{
    BuildingBlock,
    Tool
}

public enum ActionType
{
    Dig,
    Maine
}