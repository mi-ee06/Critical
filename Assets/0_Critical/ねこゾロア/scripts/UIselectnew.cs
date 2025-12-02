using UnityEngine;

public class UIselectnew : MonoBehaviour
{
    public RectTransform[] squares; // 正方形3つ
    public float upOffset = 20f;    // 上に動かす距離

    private Vector2[] originalPositions;
    private int selectedIndex = 0;  // 最初は左の四角を選択

    void Start()
    {
        // 初期位置を保存
        originalPositions = new Vector2[squares.Length];
        for (int i = 0; i < squares.Length; i++)
        {
            originalPositions[i] = squares[i].anchoredPosition;
        }

        // 初期選択を反映
        SelectSquare(selectedIndex);
    }

    void Update()
    {
        // 左へ移動
        if (Input.GetKeyDown(KeyCode.A))
        {
            selectedIndex--;
            if (selectedIndex < 0) selectedIndex = 0;
            SelectSquare(selectedIndex);
        }

        // 右へ移動
        if (Input.GetKeyDown(KeyCode.D))
        {
            selectedIndex++;
            if (selectedIndex >= squares.Length) selectedIndex = squares.Length - 1;
            SelectSquare(selectedIndex);
        }
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
