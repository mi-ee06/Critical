using UnityEngine;

public class SquareSelector : MonoBehaviour
{
    public RectTransform[] squares; // 正方形3つ
    public float upOffset = 20f;    // 上に動かす距離

    private Vector2[] originalPositions;

    void Start()
    {
        // 初期位置を保存
        originalPositions = new Vector2[squares.Length];
        for (int i = 0; i < squares.Length; i++)
        {
            originalPositions[i] = squares[i].anchoredPosition;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1)) SelectSquare(0);
        else if (Input.GetKeyDown(KeyCode.Alpha2)) SelectSquare(1);
        else if (Input.GetKeyDown(KeyCode.Alpha3)) SelectSquare(2);
    }

    void SelectSquare(int index)
    {
        for (int i = 0; i < squares.Length; i++)
        {
            // 選択中のものだけ上に、それ以外は元の位置に戻す
            float posY = (i == index) ? originalPositions[i].y + upOffset : originalPositions[i].y;
            squares[i].anchoredPosition = new Vector2(originalPositions[i].x, posY);
        }
    }
}
