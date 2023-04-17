namespace MAU.Notes.Views;

public partial class AllNotesPages : ContentPage
{
	public AllNotesPages()
	{
		InitializeComponent();

        BindingContext = new Models.AllNotes();
	}

    protected override void OnAppearing()
    {
       ((Models.AllNotes)BindingContext).LoadNotes();
    }

    private void ToolbarItem_Clicked(object sender, EventArgs e)
    {

    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(NotePage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if(e.CurrentSelection.Count != 0)
        {
            var note = (Models.Note)e.CurrentSelection[0];
            //NotePage?ItemId=fileName
            await Shell.Current.GoToAsync($"{nameof(NotePage)}?{nameof(NotePage.ItemId)}={note.FileName}");
        }
    }
}