# RPA.AeC.Alura

- Projeto: Worker Service, .NET 7
- Banco de dados SQLite
	- Para visualizar os dados utilize uma ferramenta de banco de dados e abra o arquivo Curso.db. 
- Fluxo: O servi�o come�a pegando as categorias que seram pesquisadas, logo em seguida iniciar as task(quantidade de task definida no arquivo appsettings), no m�todo DoWork ele ira inicar o ChromeDriver e consultar os curso,
	Ap�s carregar os cursos pesquisado com a categoria, ele vai abrir uma pagina adicional para cada curso, pegando as informa��es necessarias.
	em seguida fechando as abas criadas. Ao final ele ira finalizar o driver e possiveis processos que ficara abertos
	e salvando seus dados no banco.
- Observa��es:
	- Foi minha primeira vez usando migration, foi o que mais deu dificuldade em entender, mas fico feliz que tenha dado certo.
	
