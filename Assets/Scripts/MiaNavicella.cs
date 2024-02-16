using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiaNavicella : MonoBehaviour
{
    public GameObject mynav;
    public int viteIniziali = 1;
    public int viteAttuali;
    float shootTimer;
    public GameObject laser;
    public GameObject laserDannox2;
    public BonusDannox2 AttivazioneDannox2;

    // Start is called before the first frame update
    void Start()
    {
        viteAttuali = viteIniziali;
        Debug.Log("Numero di vite: " + viteAttuali);
        Debug.Log("Bonus: " + AttivazioneDannox2.bonusDannox2Corrente);

    }

    // Update is called once per frame
    void Update()
    {
        shootTimer -= Time.deltaTime;
        if (shootTimer <= 0) 
        {
            if (Input.GetButton("Fire1"))
            {
                if (AttivazioneDannox2.bonusDannox2Corrente == false)
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                       new Vector3(-5.0f, Input.mousePosition.y, 8));
                    Instantiate(laser, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
                else
                {
                    Vector3 spawnLaserPos = Camera.main.ScreenToWorldPoint(
                        new Vector3(-5.0f, Input.mousePosition.y, 8));
                    Instantiate(laserDannox2, spawnLaserPos, Quaternion.identity);
                    shootTimer = 0.3f;
                }
            }
        }
    }
   

}
