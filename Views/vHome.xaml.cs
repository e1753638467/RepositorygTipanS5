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


    private void btnActualizar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.UpdatePerson(id, txtNuevoNombre.Text);
            statusMessage.Text = App.personRepo.StatusMessage;
        }
        else
        {
            statusMessage.Text = "ID inválido";
        }
    }

    private void btnEliminar_Clicked(object sender, EventArgs e)
    {
        statusMessage.Text = "";
        if (int.TryParse(txtId.Text, out int id))
        {
            App.personRepo.DeletePerson(id);
            statusMessage.Text = App.personRepo.StatusMessage;
        }
        else
        {
            statusMessage.Text = "ID inválido";
        }
    }
    private void btnListar_Clicked(object sender, EventArgs e)
    {
        RefreshPersonList();
    }

    private void RefreshPersonList()
    {
        statusMessage.Text = "";
        List<Persona> people = App.personRepo.GetAllPeople();
        ListaPersonas.ItemsSource = people;
    }

}
