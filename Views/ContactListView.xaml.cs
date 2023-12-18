using SQLiteMaui.Data;
using SQLiteMaui.Models;

namespace SQLiteMaui.Views;

public partial class ContactListView : ContentPage
{
    private readonly DatabaseContext _details;
    public ContactListView()
	{
		InitializeComponent();

        _details = new DatabaseContext("Details.db");
        personListView.ItemsSource = _details.GetAll<PersonContact>();


    }
    private void addNewContact_Clicked(object sender, EventArgs e)
    {
        Shell.Current.GoToAsync(nameof(AddNewContact), true);
    }

    private void personListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
    {
        App.Current.MainPage.Navigation.PushModalAsync(new UpdateContact((PersonContact)e.SelectedItem));
    }

    private void deleteButon_Clicked(object sender, EventArgs e)
    {
        

        if (sender is Button button && button.CommandParameter is PersonContact selectedPerson)
        {
            // Access the properties of the selected PersonContact
            _details.DeleteItem<PersonContact>(selectedPerson);
            personListView.ItemsSource = _details.GetAll<PersonContact>();
        }
    }
}