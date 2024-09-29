using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    private GameManager GM;

    // 지금은 견갑 1단계 기준으로 작성. 나중에 단계를 선택하는 기능을 추가할 때 보완
    private int maxRow = 6;
    private int maxColumn = 6;
    private float tileSize = 0.8f;
    
    void Start()
    {
        GM = GameManager.Instance;
        
        GenerateGrid();
    }
    
    void Update()
    {
        
    }

    private void GenerateGrid()
    {
        Vector3 gridOffset = new Vector3((maxColumn - 1) * tileSize / 2, (maxRow - 1) * tileSize / 2, 1f);
        
        for (int row = 0; row < maxRow; row++)
        {
            for (int column = 0; column < maxColumn; column++)
            {
                Vector3 pos = new Vector3(column * tileSize, row * tileSize, 1f) - gridOffset;

                var tempUnclickableTile = Instantiate(GM.normalTile, pos, quaternion.identity);
                tempUnclickableTile.name = $"Tile_{row}_{column}";
                tempUnclickableTile.transform.parent = transform;
            }
        }

        transform.position = new Vector3(0f, 1.5f, 0f);
    }
}
