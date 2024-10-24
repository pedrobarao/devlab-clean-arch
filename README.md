# DevLab - Clean Architecture 🚀

## O que é o DevLab?

O DevLab é uma série de projetos com objetivo de estudar e aplicar conceitos de arquitetura de software,
boas práticas de programação e tecnologias diversas. O objetivo é criar aplicações **simples**, porém completas, que possam
ser utilizadas como referência para estudos e consultas futuras.

Aqui, vamos estudar e aplicar os conceitos da arquitetura limpa aplicados em uma aplicação **ASP.NET** 💜. A ideia é
termos uma aplicação mais fiel aos conceitos apresentados por Uncle Bob e sempre que possível evitamos o uso de
bibliotecas externas.

Se fizer sentido nos de uma ⭐ e fique a vontade para contribuir com sugestões, melhorias e correções. Será um prazer
aprender com você!
🫡

![./docs/images/clean_arch2.jpg](./docs/images/clean_arch2.jpg)

# Como utilizar? 🤔

Você vai precisar da sua IDE favorita, o [SDK do .NET 8](https://dotnet.microsoft.com/pt-br/download/dotnet/8.0) e um
banco de dados [PostgreSQL](https://www.postgresql.org/download/) configurados no seu ambiente.

Para facilitar o processo de execução no seu ambiente local criamos um docker-compose que irá subir a aplicação e o
banco de dados. Para isso, siga os
passos abaixo:

**1 - Certifique-se de que o [Docker](https://docs.docker.com/engine/install/) esteja rodando em sua máquina.**

**2 - Na raíz do projeto execute o seguinte comando:**

```bash
docker compose -f .\deploy\docker-compose.yaml -p devlab-clean-arch up -d --build
```

Esse comando irá fazer o build da aplicação e subir o container com tudo que é necessário.

**3 - Ao iniciarmos o container da aplicação o [script](./deploy/init.sql) gerado pelo migrations para criação do banco
de dados será executado. Para fazer
isso manualmente execute o seguinte comando:**

```bash
dotnet ef database update -p .\src\Lab.Customers.Infra\Lab.Customers.Infra.csproj -s .\src\Lab.Customers.Api\Lab.Customers.Api.csproj -c CustomerDbContext
```

Pronto! A aplicação está pronta para ser utilizada. 🎉

# Disclaimer ⚠️

- Este projeto é apenas um estudo de caso e não recomendamos o uso em produção.
- Talvez você não precise disso. Evite o over-engineering.
