# WizFilmes
Sistema de avaliação de filmes, desenvolvido para que os funcionários da Wiz possam cadastrar e avaliar os filmes e séries que assistiram e que mais gostam.

## Descrição
O sistema conta com um cadastro de usuários, onde após o cadastro o usuário poderá cadastrar os filmes que assistiu e avaliá-los.

Após essa avaliação o sistema será capaz de selecionar os filmes com maior pontuação e exibi-los na sua página principal.

## Regras de negócio
Foram definidas algumas regras de negócio para organizar o banco de dados.
* Não podem existir filmes duplicados no banco de dados
* Na criação do filme deverá ser informado:
    * Nome
    * Descrição
    * Ano
    * Diretor
    * Categoria
* Após criados, os filmes poderão ser avaliados e receber notas entre ( 1 e 5) com uma breve descrição.


## Estrutura do projeto
O sistema consiste em 4 projetos:

* WizFilmes.Api => onde se encontram os controllers e a configuração para a execução do sistema.
* WizFilmes.Domain => Onde se encontram as classes ue representaram as tabelas do nosso banco de dados.
* WizFilmesInfra => Aqui esta localizado toda a parte de manipulação no sistema.
    * Context => faz a conexão com o banco de dados, criando as tabelas e definindo os relacionamentos e povoamento das mesmas.
    * Dtos => Classes com intuito de manipular as informações vindas das classes de dompinio. O objetivo com o Dto, é manipular as informações com mais liberdade, sem a necessidade de alterar diretamente as classes de domínio.
    * Repository => São classes que fazem a manipulação dos dados no banco.
    * Services => São responsáveis pelos métodos e regras de negócio.
* WizFilmes.Teste => Aqui serão adicionados testes unitários e de integração para a verificação do correto funcionamento do sistema. (EM CONSTRUÇÃO)

Com essa estrutura, acreditamos, que os sitema se mantenha desacoplado. Facilitando assim a manutenção e leitura do código.

O Projeto foi previamente povoado para faciliar a demonstração.

----------------------------

### 💻 Tecnologias utilizadas

- [.NET 6](https://learn.microsoft.com/pt-br/dotnet/core/whats-new/dotnet-6)
- [AspNetCore](https://learn.microsoft.com/en-us/aspnet/core/?view=aspnetcore-7.0)
- [Swashbuckle](https://learn.microsoft.com/pt-br/aspnet/core/tutorials/getting-started-with-swashbuckle?view=aspnetcore-6.0&tabs=visual-studio): Swaggwer

-----------------------------------

## Rotas Solicitadas

### 1. POST (Criar Filme) 
* Url: `/film`
    * Exemplo: `https://localhost:7014/Film`
* Request:
    * Body:
```
{
  "name": "Homem Aranha",
  "description": "quarto ",
  "year": 2002,
  "directorId": 2,
  "categoryId": 1
}
```
* Response:
    * StatusCode: 201 Created
```
{
	"id": 15,
	"name": "Hulk",
	"description": "quarto ",
	"year": 2002,
	"directorId": 2,
	"categoryId": 1,
	"reviews": [],
	"rating": 0,
	"cast": []
}

```
### 2. POST (Criar Review)
* Url: `/review`
    * Exemplo: `https://localhost:7014/Review`
* Request:
    * Body:
```
{
  "description": "Muito bom esse filme",
  "rating": 5,
  "userId": 2,
  "filmId": 14
}
```
* Response:
    * StatusCode: 201 Created
```
{
	"id": 9,
	"description": "Muito bom esse filme",
	"rating": 5,
	"userId": 2,
	"filmId": 14
}
```

### 3. Get (Buscar Categoria por Id)
* Url: `/Category`
    * Exemplo: `https://localhost:7014/Category/1`

* Response:
    * StatusCode: 200 OK
```
[
	{
		"id": 1,
		"name": "Aventura",
		"films": [
			"Indiana Jones e a Caveira de Cristal",
			"Tomb Raider",
			"Mulher Maravilha",
			"O Senhor dos Anéis 3",
			"O Senhor dos Anéis",
			"Superman",
			"Homem Aranha"
		]
	}
]
```

### 4. Get (Buscar Diretor por Nome)
* Url: `/Director`
    * Exemplo: `https://localhost:7014/Director/Patty`

* Response:
    * StatusCode: 200 OK
```
[
	{
		"id": 2,
		"name": "Patty Jenkins",
		"films": [
			"Tomb Raider",
			"Mulher Maravilha",
			"Oito Mulheres e um segredo",
			"O Senhor dos Anéis 3",
			"O Senhor dos Anéis",
			"Superman",
			"Homem Aranha",
			"Hulk"
		]
	}
]
```

### 5. Get (Buscar Filme por Nome)
* Url: `/Film`
    * Exemplo: `https://localhost:7014/Film?name=aranha`

* Response:
    * StatusCode: 200 OK
```
{
	"films": [
    {
        "id": 14,
        "name": "Homem Aranha",
        "description": "quarto ",
        "year": 2002,
        "directorId": 2,
        "categoryId": 1,
        "reviews": [
            {
                "id": 9,
                "description": "Muito desse filme",
                "rating": 5,
                "userId": 2,
                "filmId": 14
            }
        ],
        "rating": 5,
        "cast": [
            {
                "id": 12,
                "actorId": 3,
                "character": "Peter",
                "filmId": 14
            }
        ]
    }
	],
	"count": 13,
	"pages": 1
}
```

### 6. PUT (Atualizar Filme)
* Url: `/Film`
    * Exemplo: `https://localhost:7014/Film/12`
* Request:
    * Body:
```
{
  "name": "O Senhor das Armas",
  "description": "Filme de traficante de armas",
  "year": 2002,
  "directorId": 3,
  "categoryId": 4
}
```
* Response:
    * StatusCode: 204 No Content

### 7. Post (Adicionar Ator ao Filme)
* Url: `/FilmActor`
    * Exemplo: `https://localhost:7014/FilmActor`
* Request:
    * Body:
```
{
  "actorId": 3,
	"character": "Peter",
  "filmId": 14
}
```
* Response:
    * StatusCode: 201 Created
```
{
	"id": 12,
	"actorId": 3,
	"character": "Peter",
	"filmId": 14
}
```

### 8. Get (Retornar todos os filmes de forma paginada)
* Url: `/Film`
    * Exemplo: `https://localhost:7014/Film?row=5&page=2`

* Response:
    * StatusCode: 200 OK
```
{
	"films": [
		{
			"id": 6,
			"name": "Oito Mulheres e um segredo",
			"description": "Filme dos Ocean",
			"year": 2018,
			"directorId": 2,
			"categoryId": 5,
			"reviews": [],
			"rating": 0,
			"cast": [
				{
					"id": 6,
					"actorId": 6,
					"character": "Ocean sister",
					"filmId": 6
				}
			]
		},
		{
			"id": 7,
			"name": "Exorcista",
			"description": "Filme do capiroto",
			"year": 1978,
			"directorId": 1,
			"categoryId": 2,
			"reviews": [],
			"rating": 0,
			"cast": []
		},
		{
			"id": 9,
			"name": "O Senhor dos Anéis 3",
			"description": "Terceiro ",
			"year": 2002,
			"directorId": 2,
			"categoryId": 1,
			"reviews": [
				{
					"id": 3,
					"description": "Não Gostei Muito desse filme",
					"rating": 4,
					"userId": 1,
					"filmId": 9
				},
				{
					"id": 4,
					"description": "Gostei Muito desse filme",
					"rating": 5,
					"userId": 2,
					"filmId": 9
				}
			],
			"rating": 4.5,
			"cast": [
				{
					"id": 7,
					"actorId": 7,
					"character": "Galadriel",
					"filmId": 9
				},
				{
					"id": 8,
					"actorId": 8,
					"character": "Gandalf",
					"filmId": 9
				}
			]
		},
		{
			"id": 10,
			"name": "O Senhor dos Anéis",
			"description": "primeiro",
			"year": 2002,
			"directorId": 2,
			"categoryId": 1,
			"reviews": [
				{
					"id": 5,
					"description": "Gostei Muito desse filme",
					"rating": 4,
					"userId": 1,
					"filmId": 10
				},
				{
					"id": 6,
					"description": "Gostei Muito desse filme",
					"rating": 3,
					"userId": 2,
					"filmId": 10
				}
			],
			"rating": 3.5,
			"cast": []
		},
		{
			"id": 12,
			"name": "O Senhor das Armas",
			"description": "Filme de traficante de armas",
			"year": 2002,
			"directorId": 3,
			"categoryId": 4,
			"reviews": [
				{
					"id": 7,
					"description": "Gostei Muito desse filme",
					"rating": 3,
					"userId": 1,
					"filmId": 12
				},
				{
					"id": 8,
					"description": "Muito desse filme",
					"rating": 5,
					"userId": 2,
					"filmId": 12
				}
			],
			"rating": 4,
			"cast": [
				{
					"id": 9,
					"actorId": 1,
					"character": "Gandalf",
					"filmId": 12
				},
				{
					"id": 10,
					"actorId": 2,
					"character": "Gandalf",
					"filmId": 12
				},
				{
					"id": 11,
					"actorId": 3,
					"character": "Gandalf",
					"filmId": 12
				}
			]
		}
	],
	"count": 12,
	"pages": 2
}
```

## Swagger

![](/ImagesSwagger/1.png)
![](/ImagesSwagger/2.png)
![](/ImagesSwagger/3.png)

____________________________

Equipe de desenvolvimento:

1. André Luis J. Sousa
* [Linkedin](https://www.linkedin.com/in/andre-luis-sousa/)
* [GitHub](https://github.com/dedojs)
* [Portfólio](https://andresousaprofile.netlify.app/)


2. Angélica Pedroso
* [Linkedin](https://www.linkedin.com/in/angelicapedroso/)
* [GitHub](https://github.com/angelicapedroso)