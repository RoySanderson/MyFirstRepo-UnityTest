using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask crossHair = new LayerMask();
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform firePoint;

    void Update()
    {
        if (TurnManager.GetInstance().PlayerIsActive(playerIndex))
        {
            Vector3 mousePosition = Vector3.zero;
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = cam.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, crossHair))
            {
                mousePosition = raycastHit.point;
            }

            if (Input.GetButtonDown("Fire1"))
            {
                Vector3 aimDir = (mousePosition - firePoint.position).normalized;
                Instantiate(projectilePrefab, firePoint.position, Quaternion.LookRotation(aimDir, Vector3.up));
            }
        }
    }
}
