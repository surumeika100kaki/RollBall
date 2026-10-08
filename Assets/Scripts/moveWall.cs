using UnityEngine;

public class moveWall : MonoBehaviour
{
    private int muki = 1;
    void Update()
    {
        this.transform.position += new Vector3(muki * 0.1f,0,0);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Wall")
        {
            muki = muki * -1;
        }
    }
}
