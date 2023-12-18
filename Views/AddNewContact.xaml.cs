using SQLiteMaui.Data;
using SQLiteMaui.Models;

namespace SQLiteMaui.Views;

public partial class AddNewContact : ContentPage
{
    private readonly DatabaseContext _details; 
    public AddNewContact()
    {
        InitializeComponent();
        _details = new DatabaseContext("Details.db");
    }
    private void submit_Clicked(object sender, EventArgs e)
    {
        var contact = new PersonContact();
        contact.Name = name.Text;
        contact.Gender = gender.Text;
        contact.Description = description.Text;

        _details.AddItem<PersonContact>(contact);
        Shell.Current.GoToAsync(nameof(ContactListView), true);
    }
   
}