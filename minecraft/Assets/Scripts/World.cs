using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class World : MonoBehaviour
{

    public Material material;
    public BlockType[] blocktype;

}

[System.Serializable]
public class BlockType
{
    public string blockName;
    public bool isSolid;

    // back frond top bottom left right
    [Header("Texture Values")]
    public int backFaceTexture;
    public int frondFaceTexture;
    public int topFaceTexture;
    public int bottomFaceTexture;
    public int leftFaceTexture;
    public int rightFaceTexture;

    public int GetTextureID(int faceIndex)
    {
        switch (faceIndex)
        {
            case 0:
                return backFaceTexture;
            case 1:
                return frondFaceTexture;
            case 2:
                return topFaceTexture;
            case 3:
                return bottomFaceTexture;
            case 4:
                return leftFaceTexture;
            case 5:
                return rightFaceTexture;
            default:
                Debug.Log("Error faceIdex");
                return 0;
        }

    }

}
