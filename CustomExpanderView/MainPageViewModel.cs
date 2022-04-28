
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using CustomExpanderView.Models;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Windows.Input;

namespace CustomExpanderView;

public partial class MainPageViewModel : ObservableObject
{
    public ObservableCollection<ViewGroup> Groups { get; set; } = new();

    public ICommand TapCommand => new Command<MyItem>(RemoveLocation);
    public MainPageViewModel()
    {
        List<MyItem> Items = new()
        {
            new MyItem() { Image = "Image1", Title = "Test Line 10" },
            new MyItem() { Image = "Image2", Title = "Test Line 11" },
            new MyItem() { Image = "Image3", Title = "Test Line 12" },
            new MyItem() { Image = "Image4", Title = "Test Line 13" },
            new MyItem() { Image = "Image5", Title = "Test Line 14" },
            new MyItem() { Image = "Image6", Title = "Test Line 15" }
        };
        Groups.Add(new ViewGroup() { Id=1,Name = "Group 1", SavedLocations = Items });
        Groups.Add(new ViewGroup() { Id=2,Name = "Group 2", SavedLocations = Items });
        Groups.Add(new ViewGroup() { Id=3,Name = "Group 3", SavedLocations = Items });
        foreach (var item in Groups)
        {
            foreach (var loc in item.SavedLocations)
                loc.GroupKey = item.Id;
        }
    }
    //[ICommand]
    public void RemoveLocation(MyItem item)
    {
        var groupWithLocation = Groups.Where(ep => ep.Id == item.GroupKey).FirstOrDefault();
        Debug.WriteLine($"Remove Location : {item.Title} from group {groupWithLocation.Name}", "Info");

        groupWithLocation.SavedLocations.Remove(item);

        OnPropertyChanged(nameof(Groups));
    }
}
