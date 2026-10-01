using UnityEngine;
using UnityEngine.InputSystem;

public class StageMove : MonoBehaviour
{
    private InputAction _playerInput;
    [SerializeField] private GameObject _stage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _playerInput = InputSystem.actions.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(_playerInput.ReadValue<Vector2>());

        //回転させる処理
        //水平方向の入力の取得
        float horizontalInput = _playerInput.ReadValue<Vector2>().x;
        //垂直方向の入力の取得
        float verticalInput = _playerInput.ReadValue<Vector2>().y;

        //オブジェクトを回転させる処理
        _stage.transform.Rotate(verticalInput, 0, horizontalInput * -1);
    }
}
