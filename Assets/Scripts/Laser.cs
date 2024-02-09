using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float danno;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position += new Vector3(10, 0, 0) * Time.deltaTime;
        if (this.transform.position.x > 20.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
