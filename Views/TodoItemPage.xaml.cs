using TodoSQLite.Data;
using TodoSQLite.Models;

namespace TodoSQLite.Views;

[QueryProperty("Item", "Item")]
public partial class TodoItemPage : ContentPage
{
	TodoItem item;
	public TodoItem Item
	{
		get => BindingContext as TodoItem;
		set => BindingContext = value;
	}
    TodoItemDatabase database;
    private readonly GeoLocation _geoLocation;
    public TodoItemPage(TodoItemDatabase todoItemDatabase, GeoLocation geoLocation)
    {
        InitializeComponent();
        database = todoItemDatabase;
        _geoLocation = geoLocation;
    }

    async void OnSaveClicked(object sender, EventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Item.Name))
        {
            await DisplayAlert("Name Required", "Please enter a name for the todo item.", "OK");
            return;
        }

        await database.SaveItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }
    async void OnGetLocationClicked(object sender, EventArgs e)
    {
        // You might want to show a loading indicator here
        var location = await _geoLocation.GetCurrentLocation();

        if (location != null)
        {
            // Display it in a label
            locationLabel.Text = $"Lat: {location.Latitude:F6}, Long: {location.Longitude:F6}, Altitude: {location.Altitude:F6}";
        }
        else
        {
            await DisplayAlert("Location Error", "Could not retrieve your location.", "OK");
        }
    }

    async void OnDeleteClicked(object sender, EventArgs e)
    {
        if (Item.ID == 0)
            return;
        await database.DeleteItemAsync(Item);
        await Shell.Current.GoToAsync("..");
    }

    async void OnCancelClicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync("..");
    }
}