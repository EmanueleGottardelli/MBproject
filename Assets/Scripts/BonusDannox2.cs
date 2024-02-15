using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BonusDannox2 : MonoBehaviour
{
    public float velocita;
    public GameObject explosion;
    public float lifepoints;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            Destroy(other.gameObject);
            lifepoints -= other.gameObject.GetComponent<Laser>().danno;
            if (lifepoints <= 0)
            {
                Destroy(this.gameObject);
                GameObject explosionInstance = Instantiate(explosion, transform.position, transform.rotation);

                // Distruggi l'oggetto di esplosione dopo 0.3 secondi
                Destroy(explosionInstance, 0.3f);               
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position -= new Vector3(velocita, 0, 0) * Time.deltaTime;

        if (this.transform.position.x <= -9.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
