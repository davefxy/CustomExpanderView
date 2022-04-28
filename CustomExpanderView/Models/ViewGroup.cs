
namespace CustomExpanderView.Models;

public class ViewGroup
{
    public int Id { get; set; }
    public string Name { get; set; }

    public List<MyItem> SavedLocations { get; set; } = new();
}
