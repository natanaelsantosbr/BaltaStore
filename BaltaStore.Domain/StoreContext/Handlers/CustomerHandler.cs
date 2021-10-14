using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Inputs;
using BaltaStore.Domain.StoreContext.Commands.CustomerCommands.Outputs;
using BaltaStore.Domain.StoreContext.Entities;
using BaltaStore.Domain.StoreContext.Repositories;
using BaltaStore.Domain.StoreContext.Services;
using BaltaStore.Domain.StoreContext.ValueObjects;
using BaltaStore.Shared.Commands;
using FluentValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaltaStore.Domain.Handlers
{
    public class CustomerHandler : Notifiable, ICommandHandler<CreateCustomerCommand>, ICommandHandler<AddAddressCommand>
    {
        private readonly ICustomerRepository _customerRepository;
        private readonly IEmailService _emailService;
        public CustomerHandler(ICustomerRepository customerRepository, IEmailService emailService)
        {
            this._customerRepository = customerRepository;
            this._emailService = emailService;

        }

        public ICommandResult Handle(CreateCustomerCommand command)
        {
            //Verificar se o CPF ja existe na base de dados
            if (this._customerRepository.CheckDocument(command.Document))
                AddNotification("Document", "Este CPF ja esta em uso");

            //Verificar se o E-mail ja existe na base de dados
            if (this._customerRepository.CheckEmail(command.Email))
                AddNotification("Email", "Este Email ja esta em uso");

            //Criar os VOs
            var name = new Name(command.FirstName, command.LastName);
            var document = new Document(command.Document);
            var email = new Email(command.Email);

            //Criar as entidade
            var customer = new Customer(name, document, email, command.Phone);

            //Validar as entidades e VOs
            AddNotifications(name.Notifications);
            AddNotifications(document.Notifications);
            AddNotifications(email.Notifications);
            AddNotifications(customer.Notifications);

            if (Invalid)
            {
                return new CommandResult(false, "Por favor, corrija os campos abaixos",
               new
               {
                   Notifications
               });
            }

            //Persistir o cliente
            this._customerRepository.Save(customer);

            //Enviar um E-mail de boas vindas
            this._emailService.Send(email.Address, "natanaelsantosbr@gmail.com", "Bem vindo", "Seja Bem vindo ");

            //Retornar o resultado para a tela
            return new CommandResult(true, "Bem vindo ao balta Store!",
                new
                {
                    Id = customer.Id,
                    Name = name.ToString(),
                    email = email.ToString()
                });
        }

        public ICommandResult Handle(AddAddressCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
