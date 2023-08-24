using UnityEngine;

public class Offseter : MonoBehaviour
{
    public float scrollSpeed = 0.5f;
    public string texturePropertyName = "Arrow Simple Right"; // Change this to match the name of the texture property in your shader

    [SerializeField] Material material;
    private Vector2 currentOffset;
    
    private void Start()
    {
        currentOffset = material.GetTextureOffset(texturePropertyName);
        
    }

    private void Update()
    {
        float offsetChange = Time.deltaTime * scrollSpeed;
        currentOffset.x -= offsetChange;
        // currentOffset.y += offsetChange;

        // Make sure to wrap the offset values to keep them between 0 and 1
        currentOffset.x = Mathf.Repeat(currentOffset.x, 1f);
        // currentOffset.y = Mathf.Repeat(currentOffset.y, 1f);

        material.SetTextureOffset(texturePropertyName, currentOffset);
    }
}
