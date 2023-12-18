using SQLiteMaui.Data;
using SQLiteMaui.Models;

namespace SQLiteMaui.Views;

public partial class UpdateContact : ContentPage
{
    private readonly DatabaseContext _details;
    public UpdateContact(PersonContact contact)
	{
		InitializeComponent();
        Preferences.Set("Id", contact.Id);
        name.Text = contact.Name;
		gender.Text = contact.Gender;
		description.Text = contact.Description;
        _details = new DatabaseContext("Details.db");
    }

    private void update_Clicked(object sender, EventArgs e)
    {
        var contact = new PersonContact();
        contact.Id = Preferences.Get("Id", -1);
        contact.Name = name.Text;
        contact.Gender = gender.Text;
        contact.Description = description.Text;

        _details.UpdateItem<PersonContact>(contact);
        Shell.Current.GoToAsync(nameof(ContactListView), true);
    }
}