using UnityEngine;
using System.Collections.Generic;

public class CreateMaze : MonoBehaviour
{
    // 全体サイズ 21 × 21 （外周の壁を含み、内部の迷路が 19 × 19 になります）
    [SerializeField] private int maxHorizon = 21;
    [SerializeField] private int maxVertical = 21;

    private bool[,] maze;
    public bool[,] Maze => maze;

    // 上下左右の2マス先の移動量
    private int[] dx = { 0, 0, -2, 2 };
    private int[] dy = { 2, -2, 0, 0 };
    // ランダムな方向のリストを作成
    List<int> directions = new List<int> { 0, 1, 2, 3 };

    private void Awake()
    {
        GenerateMaze();
    }

    private void GenerateMaze()
    {
        #region 1. 初期化
        maze = new bool[maxHorizon, maxVertical];
        for (int x = 0; x < maxHorizon; x++)
        {
            for (int y = 0; y < maxVertical; y++)
            {
                maze[x, y] = true;
            }
        }

        // スタート位置：左上（Unityの座標系に合わせて y を最大値付近に設定）
        int startX = 1;
        int startY = 1; // 左上 (1, 19)

        // ゴール位置：反対側の右下
        int goalX = maxHorizon - 2;   // 右下 (19, 1)
        int goalY = maxVertical - 2;

        // 行き止まりから戻る場所を記録する
        Stack<Vector2Int> stack = new Stack<Vector2Int>();

        // 1. スタート設定: 左上を「通路（スタート）」にする
        maze[startX, startY] = false;
        stack.Push(new Vector2Int(startX, startY));
        #endregion
        // 2. 穴掘りの開始
        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();

            // ランダムな方向のリストをシャッフル
            Shuffle(directions);

            bool foundNext = false;

            foreach (int dir in directions)
            {
                int nx = current.x + dx[dir];
                int ny = current.y + dy[dir];
                int wallX = current.x + dx[dir] / 2;
                int wallY = current.y + dy[dir] / 2;

                // 2マス先が迷路の範囲内（外周の内側）かつ「壁」であるか
                if (nx > 0 && nx < maxHorizon - 1 && ny > 0 && ny < maxVertical - 1)
                {
                    if (maze[nx, ny] == true)
                    {
                        // 2マス先とその間の壁を「通路」に変える
                        maze[wallX, wallY] = false;
                        maze[nx, ny] = false;

                        // 新しいマスをスタックに追加して次へ進む
                        stack.Push(new Vector2Int(nx, ny));
                        foundNext = true;
                        break;
                    }
                }
            }

            // 行き止まりになったら、これまでに通った通路までバックトラック（引き返す）
            if (!foundNext)
            {
                stack.Pop();
            }
        }

        // スタートとゴールを通路に確定
        maze[startX, startY] = false;
        maze[goalX, goalY] = false;
    }

    private void Shuffle<T>(List<T> list)
    {
        for (int i = list.Count - 1; i > 0; i--)
        {
            int j = Random.Range(0, i + 1);
            T temp = list[i];
            list[i] = list[j];
            list[j] = temp;
        }
    }
}