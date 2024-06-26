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
        status.Text = "";
        App.PersonRepository.AddNewPerson(txtNombre.Text);
        status.Text = App.personRepository.StatusMessage;
    }

    private void btnlistar_Clicked(object sender, EventArgs e)
    {
        status.Text = "";
        List<Persona> people =App.personRepository.GetAllPeople();
        ListaPersonas.ItemsSourse = people;
    }
}