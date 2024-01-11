using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewProjectBarbearia2._0.models
{
public class Cliente
{
    public string Nome { get; set; }
    public string Sobrenome { get; set; }
    public string NumeroTelefone { get; set; }
    public string Login { get; private set; }
    private string senha;

    public Cliente(string nome, string sobrenome, string numeroTelefone, string login, string senha)
    {
        Nome = nome;
        Sobrenome = sobrenome;
        NumeroTelefone = numeroTelefone;
        Login = login;
        SetSenha(senha);
    }

    public bool VerificarSenha(string senha)
    {
        return this.senha == senha;
    }

    private void SetSenha(string senha)
    {
        // Aqui você pode adicionar lógica para validar a senha ou criptografá-la
        this.senha = senha;
    }
}


}