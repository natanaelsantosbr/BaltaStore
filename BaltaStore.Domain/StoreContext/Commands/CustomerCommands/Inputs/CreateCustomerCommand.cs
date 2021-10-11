using BaltaStore.Shared.Commands;
using FluentValidator;
using FluentValidator.Validation;

namespace BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs
{
    public class CreateCustomerCommand : Notifiable, ICommand
    {
        //Fail Fast Validation (Validação Que Falha rapida)

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Document { get; set; }

        public string Email { get; set; }

        public string Phone { get; set; }

        public bool Valid()
        {
            this.AddNotifications(new ValidationContract()
                .HasMinLen(this.FirstName, 3, "FirstName", "O nome deve conter pelo menos 3 caracteres")
                .HasMaxLen(this.FirstName, 40, "FirstName", "O nome deve conter no maximo 40 caracteres")
                .HasMinLen(this.LastName, 3, "LastName", "O sobrenome deve conter pelo menos 3 caracteres")
                .HasMaxLen(this.LastName, 40, "LastName", "O sobrenome deve conter no maximo 40 caracteres")
                .IsEmail(this.Email, "Email", "O E-mail é invalido")
                .HasLen(this.Document, 11, "document", "CPF Invalido")
                );

            return Valid();
        }



        //Se o usuario existe no banco (Email)

        //SE o usuario existe no banco (CPF)

    }
}
