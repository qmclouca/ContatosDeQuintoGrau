using UseCases.Intefaces;
using Contato = ContatosDeQuintoGrau.CoreBusiness.Contato;
namespace ContatosDeQuintoGrau.Views;

public partial class AdicionarContatosPage : ContentPage
{
    private readonly IAddContactUseCase _addContactUseCase;
	public AdicionarContatosPage()
	{
		InitializeComponent();
	}

    private async void contatoControle_OnSave(object sender, EventArgs e)
    {
        await _addContactUseCase.ExecuteAsync(new Contato(contatosControle.Name, contatosControle.Email, contatosControle.Phone, contatosControle.Address));
        await Shell.Current.GoToAsync($"//{nameof(ContatosPage)}");
    }

    private async void contatoControle_OnCancel(object sender, EventArgs e)
    {
        await Shell.Current.GoToAsync($"//{nameof(ContatosPage)}");
    }

    private void contatoControle_OnError(object sender, string e)
    {
        DisplayAlert("Error ao adicionar contato", e, "Ok");
    }
}