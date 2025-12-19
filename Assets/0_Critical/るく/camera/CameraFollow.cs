using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;  // プレイヤーのTransform（Inspectorで指定）
    public Vector3 offset;    // プレイヤーとの相対位置
    public Vector2 minPos;    // カメラの移動範囲の最小値（x, y）
    public Vector2 maxPos;    // カメラの移動範囲の最大値（x, y）

    private void Start()
    {
        offset = transform.position - player.transform.position;
    }
    void LateUpdate()
    {
        // プレイヤー位置にオフセットを加えたカメラの目標位置
        Vector3 targetPos = player.position + offset;

        // カメラのx, yを範囲内に制限（Clamp）
        float clampX = Mathf.Clamp(targetPos.x, minPos.x, maxPos.x);
        float clampY = Mathf.Clamp(targetPos.y, minPos.y, maxPos.y);

        // 実際のカメラ位置を更新
        transform.position = new Vector3(clampX, clampY, transform.position.z);
    }
}

