using static Android.Provider.ContactsContract.CommonDataKinds;

namespace TP2_.net.Views;

public partial class ListeNotes : ContentPage
{
	public ListeNotes()
	{
		InitializeComponent();

        BindingContext = new Models.CListeNotes();

        Routing.RegisterRoute($"{nameof(Note)}", typeof(Note));
    }

    //Utiliser avec Note et await Shell.Current.GoToAsync("..");
    protected override async void OnAppearing()
    {
        base.OnAppearing();
        BindingContext = new Models.CListeNotes();
    }
    private async void Ajouter_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Note));

    }

    private async void CollectionDeNotes_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        
        if (e.CurrentSelection.Count > 0) {
            var maVar = e.CurrentSelection[0] as Models.CNote;            
            await Shell.Current.GoToAsync($"{nameof(Note)}?{nameof(Note.ItemId)}={maVar.Filename}");
        }

        CollectionDeNotes.SelectedItem = null;

    }
}