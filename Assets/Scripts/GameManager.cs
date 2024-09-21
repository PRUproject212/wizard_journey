using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager>
{
    public int coin = 300;
    public int health = 3;
    public int fast = 1;

    public void ResetHealth() => health = 3;
    public void IncreaseHealth() => health = Mathf.Min(health + 1, 3);
    public void DecreaseHealth() => health = Mathf.Max(health - 1, 0);

    public void buyShop(int signal)
    {
        if(signal == 1)
        {
            if ( coin >= 200)
            {
                fast++;
                coin -= 200;
                FindObjectOfType<ShopController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<UIShopController>().coinText.text = GameManager.Instance.coin.ToString();
            }
            else
            {
                FindObjectOfType<ShopController>().buyFailPopup.SetActive(true);
            }
        }
        else
        {
            if (coin >= 300 && GameManager.Instance.health < 3)
            {
                health++;
                FindObjectOfType<ShopController>().buySuccessPopup.SetActive(true);
                coin -= 300;
                FindObjectOfType<UIShopController>().coinText.text = GameManager.Instance.coin.ToString();

            }
            else
            {
                FindObjectOfType<ShopController>().buyFailPopup.SetActive(true);
            }
        }
    }

    public void buyShopPopup(int signal)
    {
        if (signal == 1)
        {
            if (coin >= 200)
            {
                fast++;
                coin -= 200;
                FindObjectOfType<ShopPopupController>().buySuccessPopup.SetActive(true);
                FindObjectOfType<PlayerPoint>().UpdateHealth();
                FindObjectOfType<Energy>().amountText.text = fast.ToString();
            }
            else
            {
                FindObjectOfType<ShopPopupController>().buyFailPopup.SetActive(true);
            }
        }
        else
        {
            if (coin >= 300 && GameManager.Instance.health < 3)
            {
                health++;
                FindObjectOfType<ShopPopupController>().buySuccessPopup.SetActive(true);
                coin -= 300;
                FindObjectOfType<PlayerPoint>().UpdateHealth();
            }
            else
            {
                FindObjectOfType<ShopPopupController>().buyFailPopup.SetActive(true);
            }
        }
    }
}
