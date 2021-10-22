using UnityEngine;
using UnityEngine.Networking;

public class PlayerShoot : NetworkBehaviour
{
    public Weapon _weapon;

    [SerializeField] private LayerMask mask;
    [SerializeField] private Camera _cam;

    void Start()
    {
        if(!_cam)
        {
            Debug.LogError("Camera not setup");
            this.enabled = false;
        }
        if (_cam)
        {
            Debug.Log("IsCam true");
        }
    }

    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }    
    }

    [Client]
    private void Shoot()
    {
        RaycastHit _hit;
        if (Physics.Raycast(_cam.transform.position, _cam.transform.forward, out _hit, _weapon._range, mask))
        {
            if(_hit.collider.gameObject.TryGetComponent<PlayerMotor>(out PlayerMotor _))
            //if (_hit.collider.tag == "Player")
            {
                CmdPlayerShoot(_hit.collider.name);
            }
            else Debug.Log("Popali v " + _hit.collider.name);
        }
    }

    [Command]
    private void CmdPlayerShoot(string _id)
    {
        Debug.Log(" shooted to " + _id);
    }

}
