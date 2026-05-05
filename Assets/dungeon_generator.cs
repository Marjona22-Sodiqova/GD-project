using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{ 
    public Screen_Manager SM;
    public int width;
    public int height;
    public bool create = false;

    // public bool destroy = false;
    private bool destroyed = true;
    public GameObject prephab;
    public GameObject[] traps;
    public GameObject Enemy;
    public GameObject exitBlock;
    public GameObject Chest;
    public GameObject Task;
    public GameObject trigger;
    public float difficulty = 0.1f;
    private GameObject[,] dungeon_block;

    private int[,] maze;

    private void Delete()
    {
        for (int i = transform.childCount - 1; i >= 0; i--)
        {
            DestroyImmediate(transform.GetChild(i).gameObject);
        }
        for (int i=0; i<width; i++)
                {
                for (int j=0; j<height; j++)
                    {
                    if (dungeon_block[i, j] != null)
                        {
                            dungeon_block[i, j] = null;
                        }
                    }
                }
        
        
    }

    void GenerateMaze()
    {       
        // 1 = стены
        for (int i = 0; i < width; i++)
            for (int j = 0; j < height; j++)
            {
                float chance = Random.Range(0f, 1f);
                if (IsInside(new Vector2Int(i, j)) && chance <= difficulty)
                {
                    maze[i, j] = 2;
                }
                // else if (IsInside(new Vector2Int(i, j)) && Random.Range(0f, 1f) <= 0.4)
                // {
                //     maze[i, j] = 3;
                // }
                // else if (IsInside(new Vector2Int(i, j)) && Random.Range(0f, 1f) <= 0.3)
                // {
                //     maze[i, j] = 4;
                // }
                else
                {
                    maze[i, j] = 1;
                }
            }

        Stack<Vector2Int> stack = new Stack<Vector2Int>();

        Vector2Int start = new Vector2Int(0, 1);
        Vector2Int finish = new Vector2Int(0, 1);
        maze[start.x, start.y] = 0;

        stack.Push(start);

        while (stack.Count > 0)
        {
            Vector2Int current = stack.Peek();

            List<Vector2Int> neighbors = GetNeighbors(current);

            if (neighbors.Count > 0)
            {
                Vector2Int next = neighbors[Random.Range(0, neighbors.Count)];
                
                Vector2Int wall = (current + next) / 2;
                maze[wall.x, wall.y] = 0;

                maze[next.x, next.y] = 0;
                finish = next;
                stack.Push(next);
            }
            else
            {
                stack.Pop();
            }
            
        }

        for (int i=0; i<width; i++)
        {
            for (int j=0; j<height; j++)
            {
                
                if (maze[i, j]==2)
                {
                    float angle = 0;
                    List<Vector2Int> neighbors = GetNeighbors(new Vector2Int(i, j), 1, 0, false, false);
                    if (neighbors.Count > 0)
                    {
                        Vector2Int side = neighbors[Random.Range(0, neighbors.Count)];
                        angle = side.x * side.x * (90 + side.x * 90) + side.y * 90 ;
                        maze[i+side.x, j + side.y] = 3;
                        dungeon_block[i+side.x, j + side.y] = Instantiate(trigger, new Vector3(2 * (i + side.x), 1, 2 * (j + side.y)), Quaternion.identity, transform);
                        
                        dungeon_block[i, j] = Instantiate(traps[0], new Vector3(2*i, 1, 2*j), Quaternion.Euler(0, angle, 0), transform);
                        //Instantiate(Enemy, new Vector3(2*i, 1, 2*j), Quaternion.Euler(0, angle, 0), transform);
                        //dungeon_block[i, j].GetComponent<Cage>().trigger = dungeon_block[i+side.x, j + side.y].GetComponent<TrapTrigger>();
                        TrapTrigger trig = dungeon_block[i+side.x, j + side.y].GetComponent<TrapTrigger>();

                        if (trig == null)
                        {
                            Debug.LogError("На trigger prefab нет TrapTrigger!");
                        }
                        else
                        {
                            dungeon_block[i, j].GetComponent<Cage>().trigger = trig;
                        }
                        // Cage c = dungeon_block[i, j].GetComponent<Cage>();
                        // foreach (Vector2Int t in neighbors)
                        // {
                        //     c.text += t.x + " " + t.y + "\n";
                        // }
                        // c.text += side.x + " " + side.y;
                    }
                    else
                    {
                        maze[i, j]=1;
                    }
                }
                if (maze[i, j]==1)
                {
                    dungeon_block[i, j] = Instantiate(prephab, new Vector3(2*i, 1, 2*j), Quaternion.identity, transform);
                }
                else if (i == finish.x && j == finish.y)
                {
                    dungeon_block[i, j] = Instantiate(exitBlock, new Vector3(2*i, 1, 2*j), Quaternion.identity, transform);
                }
                
                
                else
                {
                    float chance = Random.Range(0f, 1f);
                    if (dungeon_block[i, j] == null)
                    {
                        if (chance <= 0.1)
                        {
                            dungeon_block[i, j] = Instantiate(Chest, new Vector3(2*i, 0.4f, 2*j), Quaternion.identity, transform);
                        }
                        else if (chance >= 0.9)
                        {
                            dungeon_block[i, j] = Instantiate(Task, new Vector3(2*i, 0.03f, 2*j), Quaternion.identity, transform);
                        }
                        else if (chance <= 0.6 && chance >= 0.5)
                        {
                            dungeon_block[i, j] = Instantiate(trigger, new Vector3(2 * i, 1, 2 * j), Quaternion.identity, transform);
                            TrapTrigger TT = dungeon_block[i, j].GetComponent<TrapTrigger>();
                            TT.set_SM(SM);
                            TT.MathTrap = true;
                        }
                        else  dungeon_block[i, j] = null;
                    }
                    
                }
            }
        }
        string map = "";
        for (int i = 0; i < maze.GetLength(0); i++)
        {
        string row = "";

        for (int j = 0; j < maze.GetLength(1); j++)
            {
                row += maze[i, j] + " ";
            }

            map +="\n"+ row;

        }
        //Debug.Log(map);
    }

    List<Vector2Int> GetNeighbors(Vector2Int cell, int step = 2, int check = 1, bool more = true, bool nextCord = true)
    {
        List<Vector2Int> result = new List<Vector2Int>();

        Vector2Int[] directions = {
            new Vector2Int(step, 0),
            new Vector2Int(-step, 0),
            new Vector2Int(0, step),
            new Vector2Int(0, -step)
        };

        foreach (var dir in directions)
        {
            Vector2Int next = cell + dir;

            if (IsInside(next) && ((maze[next.x, next.y] >= check && more) ||  (maze[next.x, next.y] == check && !more)))
            {
                if (nextCord) result.Add(next);
                else result.Add(dir);
            }
        }

        return result;
    }

    bool IsInside(Vector2Int p)
    {
        return p.x > 0 && p.x < width - 1 &&
               p.y > 0 && p.y < height - 1;
    }
    void OnDrawGizmos()
    {
        if (create && destroyed)
        {
            maze = new int[width, height];
            dungeon_block = new GameObject[width, height];
            GenerateMaze();
            
            destroyed = false;
            // dungeon = new bool[x, y];
            // 
            // generate_D();
            //create = false;
        }
        if (!create && !destroyed)
        {
            destroyed = true;
            // destroy = false;
            Delete();
            }
    }
    void Awake()
    {
        
    }

    void Start()
    {
        maze = new int[width, height];
        dungeon_block = new GameObject[width, height];
        GenerateMaze();
        create = true;
        destroyed = false;
    }
}