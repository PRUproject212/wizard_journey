using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIShopController : MonoBehaviour
{
    public TextMeshProUGUI coinText;

    private void Start()
    {
        coinText.text = GameManager.Instance.coin.ToString();
    }
}
