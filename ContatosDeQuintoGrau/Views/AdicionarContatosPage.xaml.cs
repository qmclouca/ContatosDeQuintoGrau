using UseCases.Intefaces;
using Contato = ContatosDeQuintoGrau.CoreBusiness.Contato;
namespace ContatosDeQuintoGrau.Views;

public partial class AdicionarContatosPage : ContentPage
{
    private readonly IAddContactUseCase _addContactUseCase;

	public AdicionarContatosPage(IAddContactUseCase addContactUseCase)
	{
		InitializeComponent();
        _addContactUseCase = addContactUseCase;
    }

    private async void contatoControle_OnSave(object sender, EventArgs e)
    {
        try { 
            Contato contatoParaSalvar = new Contato(contatosControle.Name, contatosControle.Email, contatosControle.Phone, contatosControle.Address);
            await _addContactUseCase.ExecuteAsync(contatoParaSalvar); }
        catch (Exception ex) 
        {
            DisplayAlert("Error ao adicionar contato", ex.ToString(), "Ok");
        }
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