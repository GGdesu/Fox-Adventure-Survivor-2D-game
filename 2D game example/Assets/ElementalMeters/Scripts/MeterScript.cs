using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MeterScript : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fill;

    private float currentHealth;
    private float coolDown = 5f;

    private bool isCooldown = false;

    void Start()
    {
        //currentHealth = 0f;
        fill.fillAmount = 0;
        //SetMaxHealth(maxHealth);
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.F) && !isCooldown){
            isCooldown = true;
            fill.fillAmount = 1;
            //SetMaxHealth(maxHealth);
        }

        if(isCooldown){
            fill.fillAmount -= 1 / coolDown * Time.deltaTime;
            //currentHealth -= 10 / maxHealth * Time.deltaTime;
            //SetHealth(currentHealth);

            if(fill.fillAmount <= 0){
                fill.fillAmount = 0;
                //SetMaxHealth(maxHealth);
                isCooldown = false;
            }
        }


    }

    public void SetMaxHealth(float health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f);

    }

    public void SetHealth(float health)
    {
        slider.value = health;
        fill.color = gradient.Evaluate(slider.normalizedValue);

    }

}
