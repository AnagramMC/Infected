using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class PowerUpManager : MonoBehaviour
{
    public Text powerText;
    public Slider powerSlider;

    private float timeLeft = 30;

    private bool startTimer = false;
	// Use this for initialization
	void Start ()
    {
        powerSlider.gameObject.SetActive(false);
	}
	
	// Update is called once per frame
	void Update ()
    {
		if(startTimer)
        {
            timeLeft -= Time.deltaTime;
            powerSlider.value = timeLeft;

            if(timeLeft <= 0)
            {
                powerSlider.gameObject.SetActive(false);
                powerText.text = "";

                PlayerShooting playerShot = FindObjectOfType<PlayerShooting>();

                if (playerShot)
                {
                    playerShot.ChangeWeaponType(PlayerShooting.WeaponTypes.MachineGun);
                }

                timeLeft = 30;

                startTimer = false;
            }
        }
	}

    public void setPowerText(string text)
    {
        powerText.text = text;
    }

    public void setPowerSlider()
    {
        powerSlider.gameObject.SetActive(true);
        powerSlider.value = powerSlider.maxValue;
        timeLeft = 30;
        startTimer = true;
    }


}
