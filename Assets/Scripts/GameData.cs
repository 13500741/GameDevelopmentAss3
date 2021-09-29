using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class AudioName
{
    public const string gameIntro = "gameIntro";
    public const string ghostNormal = "ghostNormal";
    public const string ghostScared = "ghostScared";
    public const string ghostDead = "ghostDead";
}

public enum GameState
{
    Play,
    Pause,
    Stop
}
public enum Sides
{
    Top,
    Bottom,
    Left,
    Right
}
public enum TileType
{
    Wall_CornerLeft,
    Wall_LeftStr,
    Sephere_CornerLeft,
    Sephere_LeftStr,
    T_Left,
    Pellet,
    PowerPllet,
    None
}

[System.Serializable]
public class TileInfo
{
    public TileType tileType;
    public Sprite sprite;
}

public class Neighbor
{
    public Sides sides;
    public MyTile tile;

    public Neighbor(Sides _sides, MyTile _tile)
    {
        this.sides = _sides;
        this.tile = _tile;
    }
}

