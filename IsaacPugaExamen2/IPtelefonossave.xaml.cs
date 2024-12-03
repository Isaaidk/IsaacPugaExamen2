using IsaacPugaExamen2.Resources.Models;

namespace IsaacPugaExamen2;

public partial class IPtelefonossave : ContentPage
{
	public IPtelefonossave()
	{
        BindingContext = new IsaacPugaExamen2.Resources.Models.Telefonos();
    }

    protected override void OnAppearing()
    {
        ((IsaacPugaExamen2.Resources.Models.Telefonos)BindingContext).LoadNotes();
    }

    private async void Add_Clicked(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync(nameof(IPTelefonopage));
    }

    private async void notesCollection_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.Count != 0)
        {
            // Get the note model
            var note = (IsaacPugaExamen2.Resources.Models.Telefonos)e.CurrentSelection[0];

            // Should navigate to "NotePage?ItemId=path\on\device\XYZ.notes.txt"
            await Shell.Current.GoToAsync($"{nameof(IPTelefonopage)}?{nameof(IPTelefonopage.ItemId)}={IPTelefono.Filename}");

            // Unselect the UI
            notesCollection.SelectedItem = null;
        }
    }

}