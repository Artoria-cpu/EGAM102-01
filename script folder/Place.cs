using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Place : MonoBehaviour
{
    public GameObject dominoPrefab; 
    public LayerMask placementLayer; 
    public float fixedYPosition = 3f; 
    public int maxDominoCount = 15; 

    private GameObject previewDomino; 
    private Vector3 placementPosition; 
    private float rotationAngle = 0f; 
    private List<GameObject> placedDominoes = new List<GameObject>(); 
    public GameManager UIscript;

    public int lt = 1;

    void Start()
    {
        UIscript = GameObject.FindFirstObjectByType<GameManager>();
    }
    void Update()
    {
        HandlePlacementPreview(); 
        HandleRotation(); 
        HandlePlacement(); 
        ActivateDominoesOnSpace(); 
    }

    void HandlePlacementPreview()
    {
       
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity, placementLayer))
        {
            placementPosition = hit.point;
            placementPosition.y = fixedYPosition; 

            if (previewDomino == null)
            {
                previewDomino = Instantiate(dominoPrefab, placementPosition, Quaternion.Euler(0, rotationAngle, 0));
                SetPreviewMaterial(previewDomino, true);

                
                Collider col = previewDomino.GetComponent<Collider>();
                if (col != null)
                {
                    col.isTrigger = true;
                }
            }
            else
            {
                
                previewDomino.transform.position = placementPosition;
                previewDomino.transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
            }
        }
    }

    void HandleRotation()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            rotationAngle -= 15f;
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            rotationAngle += 15f;
        }

        if (previewDomino != null)
        {
            previewDomino.transform.rotation = Quaternion.Euler(0, rotationAngle, 0);
        }
    }

    void HandlePlacement()
    {
        if (Input.GetMouseButtonDown(0) && previewDomino != null)
        {
            
            if (placedDominoes.Count >= maxDominoCount)
            {
                
                return;
            }

            
            if (dominoPrefab == null)
            {
                
                return;
            }

           
            GameObject newDomino = Instantiate(dominoPrefab, previewDomino.transform.position, previewDomino.transform.rotation);

            if (newDomino == null)
            {
                
                return;
            }

            SetPreviewMaterial(newDomino, false);

            
            GameObject parentObject = GameObject.Find("GameObject"); 
            if (parentObject != null)
            {
                newDomino.transform.SetParent(parentObject.transform);
            }
            

            
            Rigidbody rb = newDomino.GetComponent<Rigidbody>();
            if (rb == null)
            {
                Debug.LogError("nobody");
            }
            else
            {
                rb.isKinematic = true; 
            }

            
            Collider col = newDomino.GetComponent<Collider>();
            if (col == null)
            {
                Debug.LogError("nocollider");
            }
            else
            {
                col.enabled = false; // **放置后暂时禁用碰撞体**
            }

            placedDominoes.Add(newDomino); // **记录放置的骨牌**
            UIscript.Loseleft();
            Debug.Log("placed：" + placedDominoes.Count + "/" + maxDominoCount);
        }
    }


    void ActivateDominoesOnSpace()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            foreach (GameObject domino in placedDominoes)
            {
                if (domino != null)
                {
                    Rigidbody rb = domino.GetComponent<Rigidbody>();
                    Collider col = domino.GetComponent<Collider>();

                    if (rb != null)
                    {
                        rb.isKinematic = false;
                    }
                    if (col != null)
                    {
                        col.enabled = true; 
                    }
                }
            }
            placedDominoes.Clear(); 
        }
    }

    void SetPreviewMaterial(GameObject obj, bool isPreview)
    {
        Renderer renderer = obj.GetComponent<Renderer>();
        if (renderer != null)
        {
            if (isPreview)
            {
                Color previewColor = new Color(1f, 1f, 1f, 0.5f);
                renderer.material.color = previewColor;
            }
            else
            {
                Color normalColor = new Color(1f, 1f, 1f, 1f);
                renderer.material.color = normalColor;
            }
        }
    }
}

