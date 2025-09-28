global using System.Diagnostics.CodeAnalysis;

global using Microsoft.Extensions.DependencyInjection;
global using Microsoft.Extensions.Configuration;

global using Vinder.Comanda.Domain.Contracts;
global using Vinder.Comanda.Common.Configurations;

global using Vinder.Comanda.Application.Payloads.Customer;
global using Vinder.Comanda.Application.Payloads.Owner;

global using Vinder.Comanda.Application.Validators.Customer;
global using Vinder.Comanda.Application.Validators.Owner;

global using Vinder.Comanda.Infrastructure.Repositories;

global using MongoDB.Driver;
global using FluentValidation;