using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vita : MonoBehaviour
{
    public float velocita;
    public GameObject explosion;
    public float lifepoints;
    public MiaNavicella player;
    

    // Start is called before the first frame update
    void Start()
    {
        // Verifica se player � null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player � null!");
        }
    }

    void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.tag.Equals("laser"))
        {
            Destroy(other.gameObject);
            lifepoints -= other.gameObject.GetComponent<Laser>().danno;
            if (lifepoints <= 0)
            {
                if(player.viteAttuali <= 2)
                {
                    player.viteAttuali++;
                    Debug.Log("Numero di vite: " + player.viteAttuali);               
                }
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
        // Verifica se player � null
        if (player == null)
        {
            Debug.LogWarning("Il riferimento a player � null!");
        }
        this.transform.position -= new Vector3(velocita, 0, 0) * Time.deltaTime;

        if (this.transform.position.x <= -9.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
