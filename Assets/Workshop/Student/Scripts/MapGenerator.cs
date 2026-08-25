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

        public string[,] saveItemMap = new string[3, 3] {
            { " ", "Soda", " "},
            { " ", " ", " "},
            { " ", " ", "Food"},
        };
        //สร้างกำแพงตรงกลางสูงครึ่งนึงของฉากplayerต่ำแหน่ง0,0(มุมล่างซ้าย) exit อยู่มุมบนขวาแมพ
        // 1. declare Players variable

        // 7. declare Exit variable 


        public void Start()
        {
            // 1. random player at the position <0, 0> map

            // 2. create obstacles

            // 3. create floor
            //ถ้าcolumsเป็น10จะรัน0-9
            for (int y = 0; y < rows; y++) 
            {
                for (int x = 0; x < columns; x++)
                {
                    int r = UnityEngine.Random.Range(0, floorTiles.Length);//สุ่มตามfloorTitles
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
                        int r = UnityEngine.Random.Range(0, wallTiles.Length);//สุ่มตามfloorTitles
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

        }
    }

}