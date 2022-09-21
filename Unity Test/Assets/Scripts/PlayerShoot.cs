using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField] private int playerIndex;
    [SerializeField] private Camera cam;
    [SerializeField] private LayerMask crossHair = new LayerMask();
    [SerializeField] private Transform test;

    private PlayerMovement playerMovement;

    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
    }

    void Update()
    {
        if (TurnManager.GetInstance().PlayerIsActive(playerIndex))
        {
            Vector2 screenCenter = new Vector2(Screen.width / 2, Screen.height / 2);
            Ray ray = cam.ScreenPointToRay(screenCenter);

            if (Physics.Raycast(ray, out RaycastHit raycastHit, 999f, crossHair))
            {
                test.position = raycastHit.point;
            }
        }
    }
}
