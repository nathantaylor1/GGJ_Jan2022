using System.Collections;
using UnityEngine;

public class MonkeyStateSwitcher : MonoBehaviour
{
    public static MonkeyStateSwitcher instance;

    private void Awake()
    {
        instance = this;
    }

    public KeyCode switchKey = KeyCode.F;
    public KeyCode downWaterKey = KeyCode.S, upWaterKey = KeyCode.W;
    public GameObject redMonkey, blueMonkey, waterForm;
    private bool _isRed = false, _canSwitch = true, _isWater = false;

    public bool IsRed()
    {
        return _isRed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(switchKey) && _canSwitch && !_isWater)
        {
            ToggleState();
        }

        if (!_isRed && !_isWater && Input.GetKeyDown(downWaterKey))
        {
            _isWater = true;
            blueMonkey.SetActive(false);
            waterForm.SetActive(true);
        }

        if (!_isRed && _isWater && Input.GetKeyDown(upWaterKey))
        {
            _isWater = false;
            blueMonkey.SetActive(true);
            waterForm.SetActive(false);
        }
    }
    
    private void ToggleState()
    {
        if (_isWater) return;
        if (_isRed)
        {
            // Change to Blue Form:
            redMonkey.SetActive(false);
            blueMonkey.SetActive(true);
            _isRed = false;
        }
        else
        {
            // Change to Red Form:
            blueMonkey.SetActive(false);
            redMonkey.SetActive(true);
            _isRed = true;
        }
        _canSwitch = false;
        StartCoroutine(CO_StateSwitchCooldown());
    }

    private IEnumerator CO_StateSwitchCooldown()
    {
        yield return new WaitForSeconds(3.0f);
        _canSwitch = true;
    }
}
