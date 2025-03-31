using UnityEngine;

public class ChildCollisionReporter : MonoBehaviour
{
    [HideInInspector]
    public ParentCollisionManager manager;

    void OnCollisionEnter(Collision collision)
    {
        // 只报告兄弟物体之间的碰撞
        if (manager == null) return;

        Transform myParent = transform.parent;
        Transform otherParent = collision.transform.parent;

        if (myParent == otherParent && collision.gameObject != this.gameObject)
        {
            manager.OnChildCollision(this.gameObject, collision.gameObject);
        }
    }
}

