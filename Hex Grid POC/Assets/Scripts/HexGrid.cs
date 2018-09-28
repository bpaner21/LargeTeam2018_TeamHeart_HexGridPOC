using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HexGrid : MonoBehaviour
{
    public int Width = 12;
    public int Height = 6;

    public HexCell CellPrefab;

    private HexCell[] cells;

    public Text CellLabelPrefab;

    [SerializeField]
    private Canvas gridCanvas;

    [SerializeField]
    private HexMesh hexMesh;

    [SerializeField]
    private float gridOffset = 0.2f;

    private void Awake()
    {
        gridCanvas = GetComponentInChildren<Canvas>();
        hexMesh = GetComponentInChildren<HexMesh>();

        cells = new HexCell[Height * Width];

        for (int z = 0, i = 0; z < Height; ++z)
        {
            for (int x = 0; x < Width; ++x)
            {
                CreateCell(x, z, i++);
            }
        }
    }

    private void Start()
    {
        hexMesh.Triangulate(cells);
    }

    private void CreateCell(int x, int z, int i)
    {
        // Establish cell position in the grid
        Vector3 position;
        //position.x = (x + (z * 0.5f) - (z / 2.0)) * (HexMetrics.InnerRadius * 2f);
        position.x = x * (HexMetrics.OuterRadius * (1.5f + gridOffset));
        position.y = 0f;
        //position.z = z * (HexMetrics.OuterRadius * 1.5f);
        position.z = (z + (x * 0.5f) - (x / 2)) * (HexMetrics.InnerRadius * (2.0f + gridOffset));


        // Instantiate the cell 
        HexCell cell = cells[i] = Instantiate<HexCell>(CellPrefab);
        cell.transform.SetParent(transform, false);
        cell.transform.localPosition = position;
        //*/

        // Create the label for the cell's coordinates
        Text label = Instantiate<Text>(CellLabelPrefab);
        label.rectTransform.SetParent(gridCanvas.transform, false);
        label.rectTransform.anchoredPosition = new Vector2(position.x, position.z);
        label.text = "X: " + x.ToString() + "\nZ: " + z.ToString();
    }
}
