using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    
    

    [SerializeField]
    private bool _isDead;

    public bool isDead 
    {
        get { return _isDead; }
        set 
        {
            _isDead = value;
            if (_isDead == true)
            { 
                
            }
        }
    
    }


    public List<SpriteRenderer> heart;
    [SerializeField]
    private int _lifeCount;
    public int lifeCount
    {
        get
        {
            return _lifeCount; 
        }
        set
        {
            _lifeCount = value;
            ChangeHeartSprite(_lifeCount);
            if (_lifeCount == 0)
            {
                isDead = true;
            }
            else
            {
                
                isDead = false;
            }
        }
    }

    void Start()
    {
            
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            lifeCount--;
        }
        
    }

    public void ChangeHeartSprite(int lifeCount)
    {
        for (int i = 0; i < heart.Count; i++)
        {
            if (i < lifeCount)
            {
                heart[i].color = new Color(1, 1, 1, 1);
            }
            else
            { 
                heart[i].color = new Color(0, 0, 0, 0.4f);
            }
        }
    
    
    }


}
