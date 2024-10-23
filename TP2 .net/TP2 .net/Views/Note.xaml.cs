using TP2_.net.Models;

namespace TP2_.net.Views;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class Note : ContentPage
{

    public string ItemId
    {
        set { ChargerNote(value); }
    }


    private string _fileName = Path.Combine(FileSystem.AppDataDirectory, $"{Path.GetRandomFileName()}.notes.txt");


    public Note()
	{
		InitializeComponent();

        if (File.Exists(_fileName))
            TextEditor.Text = File.ReadAllText(_fileName);


        string appDataPath = FileSystem.AppDataDirectory;
        string sFileName = $"{Path.GetRandomFileName()}.notes.txt";

        ChargerNote(Path.Combine(appDataPath, sFileName));

        Routing.RegisterRoute($"{nameof(Note)}", typeof(Note));
        Routing.RegisterRoute(nameof(ListeNotes), typeof(ListeNotes));


    }

    private async void ButtonEnregistrer_Clicked(object sender, EventArgs e)
    {
        //File.WriteAllText(_fileName, TextEditor.Text);
        if (BindingContext is Models.CNote note)
        {
            File.WriteAllText(note.Filename, TextEditor.Text);
                   
        }
        
        await Shell.Current.GoToAsync(nameof(ListeNotes));
        //await Shell.Current.GoToAsync(".."); //utiliser avec le OnAppearing() dans ListeNotes

    }

    private async void ButtonSupprimer_Clicked(object sender, EventArgs e)
    {   if (BindingContext is Models.CNote note) { 
        if (File.Exists(note.Filename))
        {
            File.Delete(note.Filename);
            TextEditor.Text = string.Empty;
        }
        }

        await Shell.Current.GoToAsync(nameof(ListeNotes));
    }

    private void ChargerNote(string fileName)
    {
        Models.CNote noteModel = new Models.CNote();
        noteModel.Filename = fileName;
        if (File.Exists(fileName))
        {
            noteModel.Date = File.GetCreationTime(fileName);
            noteModel.Text = File.ReadAllText(fileName);
        }
        BindingContext = noteModel;
    }

    private async void Ajouter_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(Note));
    }
}