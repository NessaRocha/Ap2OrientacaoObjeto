using Data.Context;
using TrabalhoPooBanco.Data.Repositories;
using TrabalhoPooBanco.Domain.Entities;
using TrabalhoPooBanco.Domain.Interface;
using TrabalhoPooBanco.Domain.Interfaces;
using TrabalhoPooBanco.Migrations;


var db = new DataContext();

var clienteRepository = new ClienteRepository(db);

var geovaneChange = clienteRepository.GetById(3);
geovaneChange.Nome = "Ricardo Lucio";
clienteRepository.Update(geovaneChange);

