using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPool : MonoBehaviour
{
    public GameObject enemyPrefeb;
    GameObject instance;
    bool count=true;
    
    int num = 0;
    public delegate void PlayerScore(int temp);
    public event PlayerScore GetScore;
    
   

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("EnemyGenerator", 2f, 2f);
        
        
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.childCount==1&&num>=2&&count)//�ڳ������Ѿ�ˢ��2���ҵ��˱�����Ϊһ��ʱ�����¼�
        {
            
              GetScore(1);
            count = false;//��ֹһֱ����
            EnemyGenerator();


        }
  

    }
    private void EnemyGenerator()
    {
        if (transform.childCount<2)
        {
             instance = GameObject.Instantiate(enemyPrefeb, new Vector3(7f, -1.0f, 0f), Quaternion.identity);
            instance.transform.parent=this.transform;
            num++;
            if (num>2)
            {
                count = true;
            }


            //if (Num>2)
            //{
            //    GetScore(1);
            //}
        }
    }

}
