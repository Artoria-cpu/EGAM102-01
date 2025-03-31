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
        HandleUndo();
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

            // ✅ 检查是否在禁止区域内
            Collider previewCol = previewDomino.GetComponent<Collider>();
            if (previewCol != null)
            {
                Vector3 center = previewDomino.transform.position;
                Vector3 halfExtents = previewCol.bounds.extents;
                Quaternion rotation = previewDomino.transform.rotation;

                // 检查是否碰到任何带有 NoPlacementZone 的触发器
                Collider[] hits = Physics.OverlapBox(center, halfExtents, rotation);
                foreach (Collider hit in hits)
                {
                    if (hit.GetComponent<NoPlacementZone>() != null)
                    {
                        Debug.LogWarning("🚫 禁止在这个区域内放置骨牌！");
                        return; // 不允许放置
                    }
                }
            }

            // ✅ 通过检测，执行正常放置逻辑
            //GameObject newDomino = Instantiate(dominoPrefab, previewDomino.transform.position, previewDomino.transform.rotation);
            // 其余放置代码不变...

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

    void HandleUndo()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            if (placedDominoes.Count > 0)
            {
                GameObject lastDomino = placedDominoes[placedDominoes.Count - 1];

                if (lastDomino != null)
                {
                    Destroy(lastDomino); // 销毁场景中的骨牌
                    Debug.Log("🗑️ 撤销了最后一块骨牌：" + lastDomino.name);
                }

                placedDominoes.RemoveAt(placedDominoes.Count - 1); // 从列表中移除
                UIscript.Addleft();
            }
            else
            {
                Debug.Log("⚠️ 当前没有骨牌可撤销！");
            }
        }
    }



}

