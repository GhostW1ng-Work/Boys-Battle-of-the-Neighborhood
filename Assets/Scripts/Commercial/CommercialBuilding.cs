using UnityEngine;
[CreateAssetMenu(fileName ="Building", menuName ="Commercial Buildings/ Building")]
public class CommercialBuilding : ScriptableObject
{
    [SerializeField] private string _buildingName;
    [SerializeField] private int _price;
    [SerializeField] private int _revenue;

    public string BuildingName => _buildingName;
    public int Price => _price;
    public int Revenue => _revenue;
}
