using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField]GameObject spaceShip;
    SpaceShip spaceShipscript;
    public void Start()
    {
        spaceShipscript = spaceShip.GetComponent<SpaceShip>();
    }
    private void Update()
    {
        //Debug.Log(spaceShip.transform.rotation.z);
        Debug.Log(spaceShipscript.isGrounded);

        if ((spaceShip.transform.localRotation.z > 0.4 || spaceShip.transform.localRotation.z< -0.4) && spaceShipscript.isGrounded)
        {
            Lose();
            Debug.Log("SideCrush");
        }
        if (spaceShipscript.isGrounded)
        {
           
        }
    }
    public bool crushCheck(float impact)
    {


        return (impact > 0.1f||impact<-0.5f);
        
    }
    public void Lose()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


}
