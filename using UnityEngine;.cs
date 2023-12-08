using UnityEngine;

public class SandboxGame : MonoBehaviour
{
    public GameObject blockPrefab;  // Prefab of the block to be placed in the game world

    private Camera mainCamera;  // Reference to the main camera
    private bool isPlacingBlock;  // Flag to indicate if the player is currently placing a block

    void Start()
    {
        mainCamera = Camera.main;
        isPlacingBlock = false;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (!isPlacingBlock)
            {
                RaycastHit hit;
                Ray ray = mainCamera.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out hit))
                {
                    // Check if the raycast has hit a block in the game world
                    if (hit.collider.CompareTag("Block"))
                    {
                        Destroy(hit.collider.gameObject);
                    }
                    else
                    {
                        // Place a new block in the game world
                        Vector3 spawnPosition = hit.point + hit.normal;
                        Instantiate(blockPrefab, spawnPosition, Quaternion.identity);
                    }
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            isPlacingBlock = !isPlacingBlock;
        }
    }
}
