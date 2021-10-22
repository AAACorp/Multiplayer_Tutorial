using UnityEngine;
using UnityEngine.Networking;

public class PlayerSetup : NetworkBehaviour
{
    private Camera _sceneCamera;
    [SerializeField] private string _remoteLayer = "RemotePlayer";

    [SerializeField] private Behaviour[] _componentsToDisable;

    void Start()
    {
        if(!isLocalPlayer)
        {
            for (int i = 0; i < _componentsToDisable.Length; i++)
            {
                _componentsToDisable[i].enabled = false;
            }
            gameObject.layer = LayerMask.NameToLayer(_remoteLayer);
        }
        else
        {
            _sceneCamera = Camera.main;
            if(_sceneCamera)
            {
                _sceneCamera.gameObject.SetActive(false);
            }
        }

        transform.name = "Player " + GetComponent<NetworkIdentity>().netId;

    }

    void OnDisable()
    {
        if(_sceneCamera)
        {
            _sceneCamera.gameObject.SetActive(true);
        }
    }

}
