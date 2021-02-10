# RentNow

Passo a Passo para rodar o projeto.

  1° Passo - Abrir o Console do Gerenciador de Pacotes. <br>
  2° Passo - Executar o comando add-migration NomeDaMigration para criar uma migration do mapeamento atual. <br>
  3° Passo - Executar o comando update-database para criar o base de dados SQL Server. <br>
  Obs.: Na camada Presentation -> Presentation.Webapi abrir o arquivo appsettings.json, o mesmo está apontando para o localhost 
  então a base de dados RentNow vai ser criada no localhost do SQL Server.
  
  Após base criada, podemos agora rodar a aplicação (caso o projeto Presentation.Webapi não esteja como inicializador, favor apontar para esse projeto!). <br>
  Com a aplicação já rodando podemos criar clientes e operadores através das rotas /api/Client e /api/Operator utilizando o swagger, em seguinte podemos
  fazer o login e será retornado um JWT para assim poder acessar as outras rotas, então a partir dai utilize o token em todas as requisições para ter 
  autorização nas rotas.
<br><br>
Percentual de acréscimo por categoria.<br>
Tomei a liberdade de acrescentar um percentual extra de acordo com a categoria do veículo. <br>
Categorias: <br>
    Básico = Não tem acrescimo. <br>
    Completa = 50% do valor. <br>
    Luxo = 80% do valor.
      
