using System.Collections;
using UnityEngine;
public class SpawnerManager : MonoBehaviour
{
    [SerializeField] private GameObject[] monsters; // 몬스터 종류가 이미 정해진 상태
    // n초 마다 몬스터를 랜덤으로 생성하는 기능
    [SerializeField] private GameObject[] itemPrefab;
    IEnumerator Start()
    {
        while (true)
        {
            yield return new WaitForSeconds(3f);
            
            // 몬스터를 생성할 좌표
            var randomIndex = Random.Range(0, monsters.Length);
            float randomX = Random.Range(-8f, 9f);
            float randomY = Random.Range(-3f, 5f);

            Vector3 createPos = new Vector3(randomX, randomY, 0);
            
            Instantiate(monsters[randomIndex], createPos, Quaternion.identity); // 몬스터 생성
        }
    }


    public void DropItem(Vector3 dropPos)
    {
        var randomIndex = Random.Range(0, itemPrefab.Length); // 랜덤 인덱스 설정
        GameObject item = Instantiate(itemPrefab[randomIndex], dropPos, Quaternion.identity); // 아이탬 생성
        Rigidbody2D itemRB = item.GetComponent<Rigidbody2D>();
        
        itemRB.AddForceX(Random.Range(-2f,2f), ForceMode2D.Impulse);
        itemRB.AddForceY(3f, ForceMode2D.Impulse);

        float ranPower = Random.Range(-1.5f, 1.5f);
        itemRB.AddTorque(ranPower, ForceMode2D.Impulse);
        
    }
}
