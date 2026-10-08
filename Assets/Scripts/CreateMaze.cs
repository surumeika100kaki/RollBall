using UnityEngine;

public class CreateMaze : MonoBehaviour
{
    [SerializeField] private int maxHorizon = 22;
    [SerializeField] private int maxVertical = 22;

    private bool[,] maze;

    public bool[,] Maze => maze;

    private void Awake()
    {
        //初期化処理（すべてを壁で埋める）
        maze = new bool[maxHorizon, maxVertical];
        for (int x = 0; x < maxHorizon; x++)
        {
            for (int y = 0; y < maxVertical; y++)
            {
                maze[x, y] = true;
            }
        }
        maze[1, 1] = false;
        maze[20, 20] = false;

        //確定ルートの作成
        int currentX = 1;
        int currentY = 1;
        while (currentX != 20 || currentY != 20)
        {
            if (Random.value < 0.5f)
            {
                if (currentX < 20) currentX++;
            }
            else
            {
                if (currentY < 20) currentY++;
            }
            maze[currentX, currentY] = false;
        }
        //ランダムルート用の穴あけ
        for (int x = 1; x <= 20; x++)
        {
            for (int y = 1; y <= 20; y++)
            {
                if (maze[x, y] == true)
                {
                    if (Random.value < 0.3f)
                    {
                        maze[x, y] = false;
                    }
                }
            }
        }
    }
}