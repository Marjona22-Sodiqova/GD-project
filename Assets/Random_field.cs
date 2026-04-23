using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randam_gen : MonoBehaviour
{
    public int x;
    public int y;
    public float probability = 0.4f;
    public bool create = false;

    public bool destroy = false;
    private bool destroyed = true;
    private bool[,] dungeon;
    public GameObject prephab;
    private GameObject[,] dungeon_block;

    private int[,] maze;


    private float ran(bool check)
    {
        if (check)
        {
            return UnityEngine.Random.Range(0f, 0.6f);
        }
        else
        {
            return UnityEngine.Random.Range(0f, 0.3f);
        }
    }

    private float chance(int i, int j )
    {
        if (i == 0 && j != 0)
            {
                return ran(dungeon[i, j-1]) + ran(dungeon[i, j]);
                
            }
        else if (i != 0 && j == 0)
        {
            return ran(dungeon[i, j]) + ran(dungeon[i-1, j]);
        }
        else if (i == 0 && j == 0)
        {
            return 1f;
        }
        else
        {
            return ran(dungeon[i, j]) + 0.5f*ran(dungeon[i-1, j]) + 0.5f*ran(dungeon[i-1, j-1]);
        }
    }
    private void generate_D()
    {
        
        for (int i=0; i<x; i++)
        {
            for (int j=0; j<y; j++)
            {
                
                    
                    dungeon[i, j] = (chance(i, j) > probability);
                    //Debug.Log("chance");
                    if (dungeon[i, j])
                        {
                            dungeon_block[i, j] = Instantiate(prephab, new Vector3(i, 1, j), Quaternion.identity);
                        }
                    else
                    {
                        dungeon_block[i, j] = null;
                    }
                
            }
        }
    }
    
    private void Delete()
    {
        for (int i=0; i<x; i++)
                {
                for (int j=0; j<y; j++)
                    {
                    if (dungeon_block[i, j] != null)
                        {
                            //dungeon[i, j] = false;
                            DestroyImmediate(dungeon_block[i, j]);
                            dungeon_block[i, j] = null;
                        }
                    }
                }
        
    }


    void OnDrawGizmos()
    {
        
        
        if (create && destroyed)
        {
            dungeon_block = new GameObject[x, y];
            
            destroyed = false;
            dungeon = new bool[x, y];
            
            generate_D();
            create = false;
        }
        if (destroy)
        {
            destroyed = true;
            destroy = false;
            Delete();
            }
    }
}