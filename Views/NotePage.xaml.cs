namespace MAU.Notes.Views;

[QueryProperty(nameof(ItemId), nameof (ItemId))]
public partial class NotePage : ContentPage
{
	

    public string ItemId { set { LoadNote(value); } }
    public NotePage()
	{
		InitializeComponent();

		string appDataPath = FileSystem.AppDataDirectory;
		string ramdomFile = $"{Path.GetRandomFileName()}.notes.txt";
		LoadNote(Path.Combine(appDataPath, ramdomFile));
	}
	private void LoadNote(string fileName)
	{
		Models.Note note = new Models.Note();
		note.FileName = fileName;

		if (File.Exists(fileName))
		{
			note.Date = File.GetCreationTime(fileName);
			note.Text = File.ReadAllText(fileName);

		}

		BindingContext = note;
	}
    private async void SaveButton_Cliked(object sender, EventArgs e)
    {
		if(BindingContext is Models.Note note) 
		File.WriteAllText(note.FileName, TextEditor.Text);
        
		await Shell.Current.GoToAsync("..");
    }

    private async void DelteButton_clicked(object sender, EventArgs e)
    {
        if (BindingContext is Models.Note note)
		{
			if (File.Exists(note.FileName))
			File.Delete(note.FileName);
		}

		await Shell.Current.GoToAsync("..");


	}
}