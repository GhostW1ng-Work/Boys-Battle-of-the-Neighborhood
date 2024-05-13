using UnityEngine;
[CreateAssetMenu(fileName ="Building", menuName ="Commercial Buildings/ Building")]
public class CommercialBuilding : ScriptableObject
{
    [SerializeField] private string _buildingName;
    [SerializeField] private string _buildingNameEn;
    [SerializeField] private string _buildingNameRu;
    [SerializeField] private string _buildingNameTr;
    [SerializeField] private string _buildingNameEs;
    [SerializeField] private int _price;
    [SerializeField] private int _revenue;

    public string BuildingName => _buildingName;
    public string BuildingNameEn => _buildingNameEn;
    public string BuildingNameRu => _buildingNameRu;
    public string BuildingNameTr => _buildingNameTr;
    public string BuildingNameEs => _buildingNameEs;
    public int Price => _price;
    public int Revenue => _revenue;
}
