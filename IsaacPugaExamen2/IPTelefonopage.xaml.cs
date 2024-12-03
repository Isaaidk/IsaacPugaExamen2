namespace IsaacPugaExamen2;
[QueryProperty(nameof(ItemId), nameof(ItemId))]

public partial class IPTelefonopage : ContentPage
{

	public IPTelefonopage()
	{
		InitializeComponent();
        string appDataPath = FileSystem.AppDataDirectory;
        string randomFileName = $"{Path.GetRandomFileName()}.telefono.txt";

        LoadNote(Path.Combine(appDataPath, randomFileName));



    }
    private async void SaveButton_Clicked(object sender, EventArgs e)
    {
        if (BindingContext is IsaacPugaExamen2.Resources.Models.IPTelefono telefono)
            File.WriteAllText(telefono.Telefono, TelefonoEdit.Text);
            File.WriteAllText(telefono.Nombre, NombreEdit.Text);


        await Shell.Current.GoToAsync("..");
    }

    private void LoadNote(string fileName)
    {
        IsaacPugaExamen2.Resources.Models.IPTelefono noteModel = new IsaacPugaExamen2.Resources.Models.IPTelefono();
        noteModel.Filename = fileName;

        if (File.Exists(fileName))
        {
            noteModel.Telefono = File.ReadAllText(fileName);
            noteModel.Nombre = File.ReadAllText(fileName);
        }

        BindingContext = noteModel;
    }


    public string ItemId
    {
        set { LoadNote(value); }
    }
}