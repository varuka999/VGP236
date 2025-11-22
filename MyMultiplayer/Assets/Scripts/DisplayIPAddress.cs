using TMPro;
using Unity.Netcode;
using Unity.Netcode.Transports.UTP;
using UnityEngine;

public class DisplayIPAddress : MonoBehaviour
{
    [SerializeField] private TMP_Text _ipText = null;

    private void Start()
    {
        _ipText.text = IPAddressFinder.GetLocalIPv4Address();
    }

    private void JoinAsClient()
    {
        UnityTransport unityTransport = NetworkManager.Singleton.GetComponent<UnityTransport>();
        unityTransport.ConnectionData.Address = "10.198.224.145"; //"Address Given From Host";
        NetworkManager.Singleton.StartClient();
    }
}
