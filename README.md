# APIClienteV2
Implementação de WebAPI com CRUD para Clientes e Endereços

Para executar o projeto no Visual Studio, verifique antes se o Projeto de Inicialização é o da API, como está na foto abaixo:

![debug projeto visual studio](https://user-images.githubusercontent.com/50251932/105425954-060f1b80-5c29-11eb-92f3-92940fa3193e.png)


Estou utilizando um Base de dados online, caso queria utilizar uma local, altere somente o appsettings.Development , colocando o nome da base na connectionString,s onde está escrito TesteAPI, como na figura abaixo:

![connection string local](https://user-images.githubusercontent.com/50251932/105426118-5d14f080-5c29-11eb-9e8e-722d110186eb.png)

Eu configurei para pode realizar automaticamente a Migração antes de terminar o startup do projeto, caso não possui as tabelas, o método para fazer o migrations está na figura abaixo:

![automatic migrations](https://user-images.githubusercontent.com/50251932/105426356-bf6df100-5c29-11eb-8dfd-56f2a8aa750b.png)
