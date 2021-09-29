using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    public List<TileInfo> tileInfos;
    public int row = 13, col = 14;

    public Transform leftTop;
    public GameObject tilePre;
    private MyTile[,] LeftTopTiles;

    int[,] levelMap =
    {
    {1,2,2,2,2,2,2,2,2,2,2,2,2,7},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,4},
    {2,5,3,4,4,3,5,3,4,4,4,3,5,4},
    {2,6,4,0,0,4,5,4,0,0,0,4,5,4},
    {2,5,3,4,4,3,5,3,4,4,4,3,5,3},
    {2,5,5,5,5,5,5,5,5,5,5,5,5,5},
    {2,5,3,4,4,3,5,3,3,5,3,4,4,4},
    {2,5,3,4,4,3,5,4,4,5,3,4,4,3},
    {2,5,5,5,5,5,5,4,4,5,5,5,5,4},
    {1,2,2,2,2,1,5,4,3,4,4,3,0,4},
    {0,0,0,0,0,2,5,4,3,4,4,3,0,3},
    {0,0,0,0,0,2,5,4,4,0,0,0,0,0},
    {0,0,0,0,0,2,5,4,4,0,3,4,4,0},
    {2,2,2,2,2,1,5,3,3,0,4,0,0,0},
    {0,0,0,0,0,0,5,0,0,0,4,0,0,0},
    };

    void Start()
    {
        LeftTopTiles = new MyTile[row, col];
        GenerateMap();
    }

    void GenerateMap()
    {
        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                GameObject tileGo = Instantiate(tilePre, leftTop);
                tileGo.SetActive(true);
                tileGo.name = r + "-" + c;
                MyTile tile = tileGo.GetComponent<MyTile>();
                int id = levelMap[r, c];
                TileInfo tileInfo = tileInfos[id];
                tile.InitTile(tileInfo);
                tileGo.transform.position = new Vector3(c-col+0.5f, row - r, 0);
                if (tileInfo.tileType != TileType.None && tileInfo.tileType != TileType.PowerPllet &&
                    tileInfo.tileType != TileType.Pellet)
                {
                    LeftTopTiles[r, c] = tile;
                }
            }
        }

        for (int r = 0; r < row; r++)
        {
            for (int c = 0; c < col; c++)
            {
                MyTile curTile = LeftTopTiles[r, c];
                MyTile leftTile = null;
                MyTile rightTile = null;
                MyTile downTile = null;
                MyTile upTile = null;

                int left = c - 1;
                int right = c + 1;
                int down = r + 1;
                int up = r - 1;

                if (left >= 0)
                    leftTile = LeftTopTiles[r, left];
                if (right < col)
                    rightTile = LeftTopTiles[r, right];
                if (up >= 0)
                    upTile = LeftTopTiles[up, c];
                if (down < row)
                    downTile = LeftTopTiles[down, c];
                if (curTile != null)
                SetRotation(curTile, leftTile, rightTile, downTile, upTile);
            }
        }

        GameObject leftBottom = Instantiate(leftTop.gameObject,leftTop.parent);
        leftBottom.transform.rotation = Quaternion.Euler(180,0,0);
        leftBottom.name = "leftBottom";

        GameObject rightTop = Instantiate(leftTop.gameObject, leftTop.parent);
        rightTop.transform.rotation = Quaternion.Euler(0, 180, 0);
        rightTop.name = "rightTop";

        GameObject rightBottom = Instantiate(rightTop, leftTop.parent);
        rightBottom.transform.rotation = Quaternion.Euler(180, 180, 0);
        rightBottom.name = "rightBottom";
    }

    void SetRotation(MyTile _cur, MyTile _left, MyTile _right, MyTile _down, MyTile _up)
    {
        Debug.Log(_cur);
        switch (_cur.info.tileType)
        {
            case TileType.Wall_CornerLeft:
            case TileType.Sephere_CornerLeft:

                if (_left == null && _up == null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 0);
                if (_left == null && _down == null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 90);
                if (_right == null && _up == null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 270);
                if (_right == null && _down == null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 180);
                break;
            case TileType.Wall_LeftStr:
            case TileType.Sephere_LeftStr:

                if (_left != null && _right != null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 0);

                if (_up != null && _down != null)
                    _cur.transform.rotation = Quaternion.Euler(0, 0, 90);

                break;
            case TileType.T_Left:
                break;
            default:
                break;
        }
    }
    void Update()
    {

    }

}
