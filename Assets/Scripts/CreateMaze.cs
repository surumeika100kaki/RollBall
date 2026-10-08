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
        //スタートとゴールを決める
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
        // 3. ループや分岐を作るためのランダム穴あけ（孤立した道を作らないよう、既存の道に隣接する壁のみを対象にする）
        for (int x = 1; x <= 20; x++)
        {
            for (int y = 1; y <= 20; y++)
            {
                if (maze[x, y] == true)
                {
                    // 上下左右のいずれかが道(false)である壁のみ、確率で道にする（孤立した道の防止）
                    if (HasPathNeighbor(x, y) && Random.value < 0.5f)
                    {
                        maze[x, y] = false;
                    }
                }
            }
        }
        RemoveIsolatedWalls();
    }
        /// <summary>
    /// 上下左右に「道(false)」が隣接しているか判定する
    /// </summary>
    private bool HasPathNeighbor(int x, int y)
    {
        if (x > 0 && !maze[x - 1, y]) return true;
        if (x < maxHorizon - 1 && !maze[x + 1, y]) return true;
        if (y > 0 && !maze[x, y - 1]) return true;
        if (y < maxVertical - 1 && !maze[x, y + 1]) return true;
        return false;
    }

    /// <summary>
    /// 四方をすべて道に囲まれた孤立した壁を道に変換する
    /// </summary>
    private void RemoveIsolatedWalls()
    {
        for (int x = 1; x <= 20; x++)
        {
            for (int y = 1; y <= 20; y++)
            {
                if (maze[x, y] == true)
                {
                    // 上下左右すべてが道(false)の場合、孤立した壁となるため道に変更する
                    bool up = (y < maxVertical - 1) && !maze[x, y + 1];
                    bool down = (y > 0) && !maze[x, y - 1];
                    bool left = (x > 0) && !maze[x - 1, y];
                    bool right = (x < maxHorizon - 1) && !maze[x + 1, y];

                    if (up && down && left && right)
                    {
                        maze[x, y] = false;
                    }
                }
            }
        }
    }
}