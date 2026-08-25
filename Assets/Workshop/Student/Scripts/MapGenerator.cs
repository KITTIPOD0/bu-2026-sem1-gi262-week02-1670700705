using System;
using UnityEngine;

namespace Workshop.Student
{
    public class MapGenerator : MonoBehaviour
    {
        public int columns = 10;
        public int rows = 10;

        public GameObject[] floorTiles;
        public GameObject[] wallTiles;
        public GameObject[] foodTiles;
        public GameObject[] player;
        public GameObject[] exit;
        public GameObject[] obstacles;

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };
        // √È“ß°”·æßµ√ß°≈“ß Ÿß§√÷Ëßπ÷ß¢Õß©“°playerµË”·ÀπËß0,0(¡ÿ¡≈Ë“ß´È“¬) exit Õ¬ŸË¡ÿ¡∫π¢«“·¡æ
        // 1. declare Players variable

        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map
            int a =UnityEngine.Random.Range(0, player.Length);
          Instantiate(player[a], new Vector2(0,0), Quaternion.identity);
            // 2. create obstacles
            int n_obstacles = UnityEngine.Random.Range(0, obstacles.Length);
            int Y_obstacles_final = rows / 2;
            int X_obstacles = columns/2;
            for (int Y_obstacles = 0; Y_obstacles < Y_obstacles_final; Y_obstacles++)
            {
               Instantiate(obstacles[n_obstacles], new Vector2(X_obstacles, Y_obstacles), Quaternion.identity);

            }
            // 3. create floor
            //∂È“colums‡ªÁπ10®–√—π0-9
            for (int y = 0; y < rows; y++) 
            {
                for (int x = 0; x < columns; x++)
                {
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);// ÿË¡µ“¡floorTitles
                    GameObject title = Instantiate(floorTiles[r], new Vector2(x, y), Quaternion.identity);
                    title.name = "Floor" + x + "_" +y ;
                }
            }
            // 4. create walls
            for (int y = -1; y < rows+1; y++)
            {
                for (int x = -1; x < columns+1; x++)
                {
                    if (x == -1 || x == columns || y == -1 || y == rows)
                    {
                        int r = UnityEngine.Random.Range(0, wallTiles.Length);// ÿË¡µ“¡floorTitles
                        GameObject title = Instantiate(wallTiles[r], new Vector2(x, y), Quaternion.identity);
                        title.name = "wall" + x + "_" + y;
                    }
                }
            }

            // 5. random foods
            int numberOfFoods =UnityEngine.Random.Range(1,3);
            for (int i = 0; i < numberOfFoods; i++)
            {
                int x_food = UnityEngine.Random.Range(0, columns);
                int y_food = UnityEngine.Random.Range(0, rows);
                int r = UnityEngine.Random.Range(0,floorTiles.Length);
                Instantiate(foodTiles[0], new Vector2(x_food, y_food), Quaternion.identity);
            }
            // 6. generate item along with the saveItemMap
            for(int y = 0;y< saveItemMap.GetLength(0);y++)
            {
                for ( int x = 0; x < saveItemMap.GetLength(1);x++)
                {
                    string item = saveItemMap[x,y];
                    if(!string.IsNullOrEmpty(item))
                    {
                        foreach(var foodTilte in foodTiles)
                        {
                            if(foodTilte.name == item)
                            {
                                GameObject food = Instantiate(foodTilte,new Vector2(x,y),Quaternion.identity);
                                break;
                            }
                        }
                    }
                }
            }
            // 7. place exit
            int x_Exit = columns - 1;
            int y_Exit = columns - 1;
            Instantiate(exit[0], new Vector2(x_Exit, y_Exit), Quaternion.identity);

        }
    }

}