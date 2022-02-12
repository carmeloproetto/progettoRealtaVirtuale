using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlashLight : MonoBehaviour
{
    private Light _light;

    // Start is called before the first frame update
    void Start()
    {
        _light = this.GetComponentInChildren<Light>();
        GameObject torch = gameObject;
        torch.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            if (_light.enabled)
            {
                _light.enabled = false;
                FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            }
            else
            {
                _light.enabled = true;
                FindObjectOfType<AudioManager>().Play("BottoneAscensore");
            }
        }
    }
}
