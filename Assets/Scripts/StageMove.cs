using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    // プレイヤーの入力(WASD, 矢印キー)が入力されたらStageを回転させる
    private InputAction _playerInput;
    // 回転させたい対称のオブジェクト
    [SerializeField]
    private GameObject _stage;
    // _playerInput <- 変数：データを保管する箱
    // void Start() <- 関数(メソッド)：処理を入れる箱
    void Start()
    {
        // InputSystem.actions.FindAction("Move")
        // ↑InputSystemのアクションマップから"Move"という名前のアクションを探して取得する
        _playerInput = InputSystem.actions.FindAction("Move");
        }
    // １フレーム毎にこの関数が呼ばれる
    void Update()
    {
        Debug.Log(_playerInput.ReadValue<Vector2>());

        //回転させる処理
        //水平方向の入力の取得
        float horizontalInput = _playerInput.ReadValue<Vector2>().x;
        //垂直方向の入力の取得
        float verticalInput = _playerInput.ReadValue<Vector2>().y;

        //オブジェクトを回転させる処理
        _stage.transform.Rotate(verticalInput * 0.2f, 0, horizontalInput * -1 * 0.2f);
    }
}
