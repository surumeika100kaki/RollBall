using System;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;

public class GoaleArea : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI Text;
    private void Awake() {
        Text.gameObject.SetActive(false);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player"){
            Debug.Log("ゴールに触れました");
            Text.gameObject.SetActive(true);
            AudioManeger.instance.SEPlay();
        }
    }
}
