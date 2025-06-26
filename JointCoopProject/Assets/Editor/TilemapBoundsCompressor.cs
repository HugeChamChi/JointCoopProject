using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEditor; // Editor ����� ����ϱ� ���� �ʿ�

// �� ��ũ��Ʈ�� Tilemap ������Ʈ�� Inspector�� �߰����� ����� �����ϵ��� ����
[CustomEditor(typeof(Tilemap))]
public class TilemapBoundsCompressor : Editor
{
    // �⺻ Inspector UI�� �׸��ϴ�.
    public override void OnInspectorGUI()
    {
        DrawDefaultInspector(); // ���� Tilemap Inspector�� �׸��ϴ�.

        Tilemap tilemap = (Tilemap)target; // ���� ���õ� Tilemap ������Ʈ�� �����ɴϴ�.

        // "Compress Bounds" ��ư�� �׸��ϴ�.
        if (GUILayout.Button("Compress Bounds"))
        {
            // ���� Tilemap�� Bounds�� �����մϴ�.
            tilemap.CompressBounds();

            // ���� ����Ǿ����� Unity�� �˷� ������ �� �ֵ��� �մϴ�.
            EditorUtility.SetDirty(tilemap);
            Debug.Log($"Tilemap '{tilemap.name}' bounds compressed.");
        }

        // �߰������� ��� Ÿ���� ����� ��ư�� ������ �� �ֽ��ϴ�.
        if (GUILayout.Button("Clear All Tiles and Compress Bounds"))
        {
            if (EditorUtility.DisplayDialog("Clear Tilemap?",
                                            "Are you sure you want to clear ALL tiles from this Tilemap and compress its bounds? This action cannot be undone.",
                                            "Yes", "No"))
            {
                tilemap.ClearAllTiles(); // ��� Ÿ�� �����
                tilemap.CompressBounds(); // ���� �� �ٿ ����
                EditorUtility.SetDirty(tilemap);
                Debug.Log($"Tilemap '{tilemap.name}' cleared and bounds compressed.");
            }
        }
    }
}
