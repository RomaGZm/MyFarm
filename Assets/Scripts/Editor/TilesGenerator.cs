using UnityEngine;
using UnityEditor;

namespace Core.Editor
{
    public class TilesGenerator : EditorWindow
    {

        public Object rootGo;
        public Object tilePref;

        float offsetEvenX = -9.5f;
        float offsetEvenZ = -9.5f;
        float offsetEvenY = 0;
        float countX = 20;
        float countY = 20;


        [MenuItem("Window/GameHelper/TilesSettings")]
        static void Init()
        {

            TilesGenerator window = (TilesGenerator)EditorWindow.GetWindow(typeof(TilesGenerator));
            window.Show();

        }

        void OnGUI()
        {
            EditorGUILayout.BeginHorizontal();
            GUILayout.Label("TileRoot");
            rootGo = EditorGUILayout.ObjectField(rootGo, typeof(GameObject), true);

            GUILayout.Label("TilePrefab");
            tilePref = EditorGUILayout.ObjectField(tilePref, typeof(GameObject), true);
            EditorGUILayout.EndHorizontal();

            countX = EditorGUILayout.FloatField("Count X", countX);
            countY = EditorGUILayout.FloatField("Count Y", countY);

            offsetEvenX = EditorGUILayout.FloatField("Offset X", offsetEvenX);
            offsetEvenZ = EditorGUILayout.FloatField("Offset Z", offsetEvenZ);
            offsetEvenY = EditorGUILayout.FloatField("Offset Y", offsetEvenY);


            if (GUILayout.Button("Generate Tiles"))
            {
                if (rootGo == null) return;
                int tileCounter = 0;
                for (int x = 0; x < countX; x++)
                {
                    for (int y = 0; y < countY; y++)
                    {
                        tileCounter++;
                        GameObject tile = (GameObject)PrefabUtility.InstantiatePrefab(((GameObject)(tilePref)), ((GameObject)(rootGo)).transform);

                        tile.name = "Tile" + tileCounter;
                        tile.transform.localPosition = new Vector3(x + offsetEvenX, y + offsetEvenY, offsetEvenZ);

                    }
                }
            }


        }
 
    }

}
