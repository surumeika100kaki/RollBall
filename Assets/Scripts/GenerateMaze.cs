using UnityEngine;

public class GenerateMaze : MonoBehaviour
{
    [SerializeField]
    private CreateMaze createMaze;
    
    [SerializeField]
    private GameObject wall; // ★インスペクターで指定するプレハブ

    private void Start()
    {
        // ゲーム開始時に壁を生成する
        GenerateWallObjects();
    }

    /// <summary>
    /// maze配列がtrueの場所にCubeを生成し、このオブジェクトの子にする
    /// </summary>
    private void GenerateWallObjects()
    {
        // 参照チェック
        if (createMaze == null)
        {
            Debug.LogError("CreateMaze がアサインされていません！");
            return;
        }
        if (wall == null)
        {
            Debug.LogError("Wall プレハブがアサインされていません！");
            return;
        }

        // 親オブジェクトの基準座標を取得
        Vector3 basePosition = transform.position;

        // createMaze.Maze から配列を取得してループ処理
        for (int x = 1; x <= 20; x++)
        {
            for (int y = 1; y <= 20; y++)
            {
                // ★ createMaze.Maze を参照
                if (createMaze.Maze[x, y])
                {
                    // 1マスのサイズが 1*1*1 なので、インデックスをそのまま座標のズレにする
                    Vector3 spawnPosition = basePosition + new Vector3(x, 0, y);

                    // プレハブを生成（変数名の衝突を避けるためインスタンス名は wallInstance に変更）
                    GameObject wallInstance = Instantiate(wall, spawnPosition, Quaternion.identity);

                    // 生成したCubeをこのオブジェクト（親）の子オブジェクトにする
                    wallInstance.transform.SetParent(this.transform);
                }
            }
        }
    }
}