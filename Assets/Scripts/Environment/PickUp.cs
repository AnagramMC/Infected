using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{

    enum pickUpTypes {LIFE, SHOTGUN, TRISHOT, GRENADE}

    [SerializeField]
    pickUpTypes pickUp;
    private PlayerShooting shootScript;
    private ScoreManager ScoreManager;

    private void Awake()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        switch (pickUp)
        {
            case pickUpTypes.LIFE:
                ScoreManager = FindObjectOfType<ScoreManager>();
                break;

            case pickUpTypes.SHOTGUN:
                shootScript = player.GetComponent<PlayerShooting>();
                break;

            case pickUpTypes.TRISHOT:
                shootScript = player.GetComponent<PlayerShooting>();
                break;

            case pickUpTypes.GRENADE:
                //Grenade
                break;
        }
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.tag == "Player")
        {

            switch(pickUp)
            {
                case pickUpTypes.LIFE:
                    ScoreManager.AddLife();
                    Destroy(gameObject);

                    break;

                case pickUpTypes.SHOTGUN:
                    shootScript.ChangeWeaponType(PlayerShooting.WeaponTypes.Shotgun);
                    Destroy(gameObject);

                    break;

                case pickUpTypes.TRISHOT:
                    shootScript.ChangeWeaponType(PlayerShooting.WeaponTypes.TriGun);
                    Destroy(gameObject);

                    break;

                case pickUpTypes.GRENADE:
                    //Grenade
                    break;
            }

        }
    }
}
