using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class Math_SetTile : MonoBehaviour
{
    public GameObject tilePrefab;
    public int col = 5;
    public int row = 5;

    public Button[] buttons;

    public static int turretIndex;

    void Awake()
    {
        // buttons[0].onClick.AddListener((() => ChangeIndex(0)));
        // buttons[1].onClick.AddListener((() => ChangeIndex(1)));
        // buttons[2].onClick.AddListener((() => ChangeIndex(2)));
        // buttons[3].onClick.AddListener((() => ChangeIndex(3)));
        // buttons[4].onClick.AddListener((() => ChangeIndex(4)));

        for (int i = 0; i < buttons.Length; i++)
        {
            int j = i; 
            buttons[j].onClick.AddListener((() => ChangeIndex(j)));
            // buttons[i].onClick.AddListener((() => ChangeIndex(i))); 클로저 문제 발생
        }
    }

    IEnumerator Start()
    {
        for (int i = 0; i < row; i++)
        {
            for (int j = 0; j < col; j++)
            {
                var pos = new Vector3(j, 0, i);
                GameObject tile = Instantiate(tilePrefab, pos, Quaternion.identity);
                Renderer renderer = tile.GetComponent<Renderer>();
                if ((i + j) % 2 == 0) // 짝수
                {
                    renderer.material.color = Color.white;
                }
                else // 홀수
                {
                    renderer.material.color = Color.black;
                }

                yield return new WaitForSeconds(0.2f);
            }
        }
    }

    void ChangeIndex(int index)
    {
        turretIndex = index;
    }
}
