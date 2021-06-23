
using UnityEngine;

public class minicamfollow : MonoBehaviour
{

    public Transform player;
    public Vector3 offset;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = player.position + offset;

        Vector3 rot = new Vector3(90, player.eulerAngles.y, 0);

        transform.rotation = Quaternion.Euler(rot);
    }
}
