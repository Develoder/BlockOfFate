using UnityEngine;

[ExecuteInEditMode]
public class EditorGrid : MonoBehaviour
{
    [SerializeField] private Transform[] _childrenTransforms;
    [SerializeField] private Transform[] _cellTransforms;
    
    private static  Transform obj;
    
    public void Update()
    {
        if (Application.isPlaying)
            return;
        
        for (int i = 0; i < _childrenTransforms.Length; i++)
        {
            for (int j = 0; j < _childrenTransforms[i].childCount; j++)
            {
                obj = _childrenTransforms[i].GetChild(j);
                obj.position = RoundVector(obj.position);
            }
        }
        
        for (int i = 0; i < _cellTransforms.Length; i++)
        {
            _cellTransforms[i].position = RoundVector(_cellTransforms[i].position);
        }
        
    }

    private static Vector3 RoundVector(Vector3 vector)
    {
        Vector3 retVector = new Vector3(vector.x - (vector.x + Grid.offsetCell.x) % Grid.sizeCell.x, 0,
            vector.z - (vector.z + Grid.offsetCell.y) % Grid.sizeCell.y);
        return retVector;
    }
}
