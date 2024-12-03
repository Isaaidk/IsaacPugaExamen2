namespace IsaacPugaExamen2;

public partial class IPTelefonopage : ContentPage
{

	public IPTelefonopage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.notes.txt";




    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is IsaacPugaExamen2.Resources.Models.IPTelefono telefono)
            File.WriteAllText(telefono.Telefono, TelefonoEdit.Text);

        await Shell.Current.GoToAsync("..");
    }




   
}