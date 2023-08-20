using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tileCheck : MonoBehaviour
{
    public GameObject goneTile;
    public GameObject tile_CornerPiece;
    public GameObject tile_CornerPiece90;
    public GameObject tile_CornerPiece180;
    public GameObject tile_CornerPiece270;
    public GameObject tile_roadStraight;
    public GameObject tile_roadStraight90;
    static public GameObject prefabToInstantiate = null;
    public bool cornerPc;
/*    public int reverseTile = 1;
*/    // Start is called before the first frame update
    void Start()
    {
        cornerPc = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PrefabPicker(int prefab_num)
    {
        switch (prefab_num)
        {


            case -1:                                    
                prefabToInstantiate = goneTile;
                break;
            case 0:                                    
                prefabToInstantiate = tile_roadStraight;
                break;
            case 90:
                prefabToInstantiate = tile_CornerPiece90;
                break;
            case 180:
                prefabToInstantiate = tile_CornerPiece180;
                break;
            case 270:
                prefabToInstantiate = tile_CornerPiece270;
                break;
            case -90:
                prefabToInstantiate = tile_roadStraight90;
                break;
            case 1:
                prefabToInstantiate = tile_CornerPiece;
                break;
            default:
                prefabToInstantiate = tile_roadStraight;
                break;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("basicTile"))
        {
/*            prefabToInstantiate.transform.localScale =new Vector3(
                prefabToInstantiate.transform.localScale.x, 
                prefabToInstantiate.transform.localScale.y, 
                prefabToInstantiate.transform.localScale.z * reverseTile);
*/         Instantiate(prefabToInstantiate, other.transform.localPosition, Quaternion.identity);
            Destroy(other.gameObject);
            cornerPc = true;
/*            reverseTile = 1;
*/        }
    }

    public void SetTile(Collider obj)
    {
        GameObject newTile = Instantiate(prefabToInstantiate, obj.transform.localPosition, Quaternion.identity);
        newTile.transform.parent = obj.transform.parent;
        Destroy(obj.gameObject);
    }
}
