using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Text
    public Text cashText;
    public Text cashPerSecText;
    public Text clickCashText;
    public Text clickUpgrade1Text;
    public Text clickUpgrade1MaxText;
    public Text clickUpgrade2Text;
    public Text productionUpgrade1Text;
    public Text productionUpgrade2Text;
    public Text rareRockText;
    public Text rareRockBoostText;
    public Text rareRockToGetText;

    // UI
    public double cash;
    public double rareRock;
    public double rareRockBoost;
    public double rareRockToGet;
    public double prestige;
    public double cashPerSecond;
    public double cashClickValue;
    public Image clickUpgrade1Bar;
    public Image clickUpgrade2Bar;
    public Image productionUpgrade1Bar;
    public Image productionUpgrade2Bar;

    // Click Upgrade 1
    public double clickUpgrade1Cost;
    public int clickUpgrade1Level;

    // Production Upgrade 1
    public double productionUpgrade1Cost;
    public int productionUpgrade1Level;

    // Click Upgrade 2
    public double clickUpgrade2Cost;
    public int clickUpgrade2Level;

    // Production Upgrade 2
    public double productionUpgrade2Cost;
    public double productionUpgrade2Power;
    public int productionUpgrade2Level;

    public void Start()
    {
        Load();
    }

    public void Load()
    {
        // UI Defaults
        cash = double.Parse(PlayerPrefs.GetString("cash", "0"));
        cashClickValue = double.Parse(PlayerPrefs.GetString("cashClickValue", "1"));
        rareRock = double.Parse(PlayerPrefs.GetString("rareRock", "0"));
        rareRockBoost = double.Parse(PlayerPrefs.GetString("rareRockBoost", "0"));
        // Click Upgrades
        clickUpgrade1Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade1Cost", "10"));
        clickUpgrade2Cost = double.Parse(PlayerPrefs.GetString("clickUpgrade2Cost", "25"));
        // Production Upgrades
        productionUpgrade1Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade1Cost", "25"));
        productionUpgrade2Power = double.Parse(PlayerPrefs.GetString("productionUpgrade2Power", "5"));
        productionUpgrade2Cost = double.Parse(PlayerPrefs.GetString("productionUpgrade2Cost", "100"));
        // Upgrade Levels
        clickUpgrade1Level = (PlayerPrefs.GetInt("clickUpgrade1Level", 0));
        clickUpgrade2Level = (PlayerPrefs.GetInt("clickUpgrade2Level", 0));
        productionUpgrade1Level = (PlayerPrefs.GetInt("productionUpgrade1Level", 0));
        productionUpgrade2Level = (PlayerPrefs.GetInt("productionUpgrade2Level", 0));
    }

    public void Save()
    {
        // UI Defaults
        PlayerPrefs.SetString("cash", cash.ToString());
        PlayerPrefs.SetString("cashClickValue", cashClickValue.ToString());
        PlayerPrefs.SetString("rareRock", rareRock.ToString());
        PlayerPrefs.SetString("rareRockBoost", rareRockBoost.ToString());
        // Click Upgrades
        PlayerPrefs.SetString("clickUpgrade1Cost", clickUpgrade1Cost.ToString());
        PlayerPrefs.SetString("clickUpgrade2Cost", clickUpgrade2Cost.ToString());
        // Production Upgrades
        PlayerPrefs.SetString("productionUpgrade1Cost", productionUpgrade1Cost.ToString());
        PlayerPrefs.SetString("productionUpgrade2Power", productionUpgrade2Power.ToString());
        PlayerPrefs.SetString("productionUpgrade2Cost", productionUpgrade2Cost.ToString());
        // Upgrade Levels
        PlayerPrefs.SetInt("clickUpgrade1Level", clickUpgrade1Level);
        PlayerPrefs.SetInt("clickUpgrade2Level", clickUpgrade2Level);
        PlayerPrefs.SetInt("productionUpgrade1Level", productionUpgrade1Level);
        PlayerPrefs.SetInt("productionUpgrade2Level", productionUpgrade2Level);
    }

    public void Update()
    {
        cashPerSecond = (productionUpgrade1Level + (productionUpgrade2Power * productionUpgrade2Level)) * rareRockBoost;
        cash += cashPerSecond * Time.deltaTime;

        // Click Value Exponent System
        if (cashClickValue > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(cashClickValue))));
            var mantissa = (cashClickValue / System.Math.Pow(10, exponent));
            clickCashText.text = "Click: \n" + mantissa.ToString("F2") + "e" + exponent + " Cash";
        }
        else
            clickCashText.text = "Click: \n" + cashClickValue.ToString("F0") + " Cash";

        // Cash Value Exponent System
        if (cash > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(cash))));
            var mantissa = (cash / System.Math.Pow(10, exponent));
            cashText.text = "Cash: " + mantissa.ToString("F2") + "e" + exponent;
        }
        else
            cashText.text = "Cash: " + cash.ToString("F0");

        // Click Upgrade 1 Cost Exponent System
        string clickUpgrade1CostString;

        var clickUpgrade1Cost = 10 * System.Math.Pow(1.1, clickUpgrade1Level);
        if (clickUpgrade1Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade1Cost))));
            var mantissa = (clickUpgrade1Cost / System.Math.Pow(10, exponent));
            clickUpgrade1CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
            clickUpgrade1CostString = clickUpgrade1Cost.ToString("F0");

        // Click Upgrade 2 Cost Exponent System
        string clickUpgrade2CostString;
        if (clickUpgrade2Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(clickUpgrade2Cost))));
            var mantissa = (clickUpgrade2Cost / System.Math.Pow(10, exponent));
            clickUpgrade2CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
            clickUpgrade2CostString = clickUpgrade2Cost.ToString("F0");

        // Production Upgrade 1 Cost Exponent System
        string productionUpgrade1CostString;
        if (productionUpgrade1Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgrade1Cost))));
            var mantissa = (productionUpgrade1Cost / System.Math.Pow(10, exponent));
            productionUpgrade1CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
            productionUpgrade1CostString = productionUpgrade1Cost.ToString("F0");

        // Production Upgrade 2 Cost Exponent System
        string productionUpgrade2CostString;
        if (productionUpgrade2Cost > 1000)
        {
            var exponent = (System.Math.Floor(System.Math.Log10(System.Math.Abs(productionUpgrade2Cost))));
            var mantissa = (productionUpgrade2Cost / System.Math.Pow(10, exponent));
            productionUpgrade2CostString = mantissa.ToString("F2") + "e" + exponent;
        }
        else
            productionUpgrade2CostString = productionUpgrade2Cost.ToString("F0");

        // UI
        cashPerSecText.text = cashPerSecond.ToString("F2") + " cash/s";
        // Click Upgrade 1
        clickUpgrade1Text.text = "Click Upgrade 1\nCost: " + clickUpgrade1CostString + " cash\n+1 Cash per Click";
        clickUpgrade1MaxText.text = "Buy Max (" + BuyClickUpgrade1MaxCount() +")";
        // Click Upgrade 2
        clickUpgrade2Text.text = "Click Upgrade 2\nCost: " + clickUpgrade2CostString + " cash\n+5 Cash per Click";
        // Production Upgrade 1
        productionUpgrade1Text.text = "Production Upgrade 1\n Cost: " + productionUpgrade1CostString + " cash\n+" + rareRockBoost.ToString("F2") + " cash/s";
        // Production Upgrade 2
        productionUpgrade2Text.text = "Production Upgrade 2\n Cost: " + productionUpgrade2CostString + " cash\n+" + (productionUpgrade2Power * rareRockBoost).ToString("F2") + " cash/s";
        // Cash per Click
        clickCashText.text = "Click\n+" + cashClickValue.ToString("F0") + " Cash";
        // Rare Rock Currency
        rareRockToGet = (150 * System.Math.Sqrt(cash / 1e7));
        rareRockToGetText.text = "Prestige:\n+" + System.Math.Floor(rareRockToGet).ToString("F0") + " Rare Rock";
        rareRockText.text = "Rare Rock: " + System.Math.Floor(rareRock).ToString("F0");
        rareRockBoostText.text = rareRockBoost.ToString("F2") + "x Boost";
        // Gem Boost
        rareRockBoost = (rareRock * 0.05) + 1;
        // Progress Bars
        // Click Upgrade 1 Bar
        if (cash / clickUpgrade1Cost < 0.01)
            clickUpgrade1Bar.fillAmount = 0;
        else if (cash / clickUpgrade1Cost > 10)
            clickUpgrade1Bar.fillAmount = 1;
        else
            clickUpgrade1Bar.fillAmount = (float)(cash / clickUpgrade1Cost);
        // Click Upgrade 2 Bar
        if (cash / clickUpgrade2Cost < 0.01)
            clickUpgrade2Bar.fillAmount = 0;
        else if (cash / clickUpgrade2Cost > 10)
            clickUpgrade2Bar.fillAmount = 1;
        else
            clickUpgrade2Bar.fillAmount = (float)(cash / clickUpgrade2Cost);
        // Save
        Save();
    }

    // Buttons
    public void Click()
    {
        cash += cashClickValue;
    }

    // Prestige
    public void Prestige()
    {
        if (cash > 1000)
        {
            // UI Defaults
            cash = 0;
            cashClickValue = 1;
            // Click Upgrades
            clickUpgrade1Cost = 10;
            clickUpgrade2Cost = 25;
            // Production Upgrades
            productionUpgrade1Cost = 25;
            productionUpgrade2Power = 5;
            productionUpgrade2Cost = 100;
            // Upgrade Levels
            clickUpgrade1Level = 0;
            clickUpgrade2Level = 0;
            productionUpgrade1Level = 0;
            productionUpgrade2Level = 0;

            rareRock += rareRockToGet;
        }
    }

    // Click Upgrade 1
    public void BuyClickUprade1()
    {
        if (cash >= clickUpgrade1Cost)
        {
            clickUpgrade1Level++;
            cash -= clickUpgrade1Cost;
            clickUpgrade1Cost *= 1.1;
            cashClickValue++;
        }
    }

    // Click Upgrade 1 Max
    public void BuyClickUpgrade1Max()
    {
        var b = 10;
        var c = cash;
        var r = 1.1;
        var k = clickUpgrade1Level;
        var n = System.Math.Floor(System.Math.Log((c * (r - 1)) / (b * System.Math.Pow(r, k)) + 1, r));

        var cost = b * (System.Math.Pow(r, k) * (System.Math.Pow(r, n) - 1) / (r - 1));

        if (cash >= clickUpgrade1Cost)
        {
            clickUpgrade1Level += (int)n;
            cash -= cost;
            cashClickValue += n;
        }
    }

    // Click Upgrade 1 Max Count
    public double BuyClickUpgrade1MaxCount()
    {
        var b = 10;
        var c = cash;
        var r = 1.1;
        var k = clickUpgrade1Level;
        var n = System.Math.Floor(System.Math.Log((c * (r - 1)) / (b * System.Math.Pow(r, k)) + 1, r));
        return n;
    }


    // Click Upgrade 2
    public void BuyClickUpgrade2()
    {
        if (cash >= clickUpgrade2Cost)
        {
            clickUpgrade2Level++;
            cash -= clickUpgrade2Cost;
            clickUpgrade2Cost *= 2;
            cashClickValue += 5;
        }
    }

    // Production Upgrade 1
    public void BuyProductionUprade1()
    {
        if (cash >= productionUpgrade1Cost)
        {
            productionUpgrade1Level++;
            cash -= productionUpgrade1Cost;
            productionUpgrade1Cost *= 1.1;
        }
    }

    // Production Upgrade 2
    public void BuyProductionUprade2()
    {
        if (cash >= productionUpgrade2Cost)
        {
            productionUpgrade2Level++;
            cash -= productionUpgrade2Cost;
            productionUpgrade2Cost *= 2;
        }
    }
}
