using Thirdweb;
using UnityEngine;

public class TestThirdweb : MonoBehaviour
{
    private ThirdwebSDK sdk;

    void Start()
    {
        sdk = new ThirdwebSDK("sepolia"); // Remplacez par la blockchain de votre choix
        Debug.Log("Thirdweb SDK initialisé");
    }
}
