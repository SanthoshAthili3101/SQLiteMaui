using SQLiteMaui.Views;
namespace SQLiteMaui
{
    public partial class AppShell : Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ContactListView), typeof(ContactListView));
            Routing.RegisterRoute(nameof(AddNewContact), typeof(AddNewContact)); 
            Routing.RegisterRoute(nameof(UpdateContact), typeof(Views.UpdateContact));
        }
    }
}