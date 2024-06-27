using gTipanS5.Modelos;

namespace gTipanS5.Views;

public partial class vHome : ContentPage
{
	public vHome()
	{
		InitializeComponent();
	}

    private void btnInsertar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        App.personRepo.AddNewPerson(txtNombre.Text);
        statusMessage.Text = App.personRepo.StatusMessage;
    }

    private void btnlistar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        List<Persona> people =App.personRepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }
}