using UnityEngine;

public class CreateBall : MonoBehaviour
{
    public GameObject Ball;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Vector3 pos = (this.transform.position + new Vector3(0, 3, 0));
        Instantiate(Ball,pos,Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
