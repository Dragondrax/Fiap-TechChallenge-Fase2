# Fiap-TechChallenge-Fase2
Esse projeto foi desenvolvido com intuito de colocar em prática todos os conceitos aprendidos na Fase 2 da Pós Graduação da FIAP.

|Alunos| E-mail|
|------|-------|
|Caio André Macedo Serralvo|caioserralvo182@gmail.com|
|Filipe Rosa da Silva|filipe331@gmail.com|
|Igor Hebling Sallowicz|igor.sallo@hotmail.com|

## 🚀 Começando
Essas instruções permitirão que você obtenha uma cópia do projeto em operação na sua máquina local para fins de desenvolvimento e teste.

## 📋 Pré-requisitos
- .NET 8.0 Link: https://dotnet.microsoft.com/pt-br/download/dotnet/8.0
- Docker Link: https://www.docker.com/products/docker-desktop/
- pgAdmin Link: https://www.pgadmin.org/download/
- GIT Link: https://git-scm.com/downloads

## 🔧 Instalação
1. Iniciar o Docker no seu computador
2. Abrir o prompt de comando na raiz do projeto, onde fica localizado o arquivo "docker-compose.yml" e executar o comando:
~~~docker
docker-compose up -d --build
~~~
3. Certificar-se que o Banco de Dados (Postgres) está rodando no seu docker (Status: "Running")
4. Conectar o pgAdmin ao seu banco de dados (Postgres), utilizando as configurações setadas.
5. Verificar se o appsettings.json está de acordo com as configurações setadas no docker para o Postgres. (Necessário apontar para o ipv4 da sua máquina local)
![image](https://github.com/user-attachments/assets/8fff7658-7f41-448f-ae4e-900252f7fd8f)

6. Abrir o Console do Visual Studio: Ferramentas -> Gerenciador de Pacotes do Nuget -> Console do Gerenciador de Pacotes
7. No Console escolher o projeto padrão Fiap.TechChallenge.Fase1.Data -> Executar o comando: Update-Database
8. Configurar Zabbix:
  - Acesse localhost:8081
  - Utilize a senha padrão do Zabbix
    - Usuario: Admin
    - Senha: zabbix 
  - Vá em Data Collection
  - Vá em Hosts
  - Edite o Host já existente
  - Em interfaces, troque para zabbix-agent e em "Connect to", escolha "DNS" e clique em Update
  ![image](https://github.com/user-attachments/assets/0e66850a-2702-4d48-a12e-68acb8f3a29d)
  - Aguarde alguns minutos até que o host esteja assim
  ![image](https://github.com/user-attachments/assets/ace86001-55fd-45bc-adce-6032d06db228)
9. Adicionando o datasource do zabbix no grafana ->  Connection -> http://192.168.15.6:8081/api_jsonrpc.php (Utilizar ipv4 da maquina local)
  - Em Zabbix Connection, configurar o usuario padrão que foi utilizado para logar no Zabbix Web
    - Usuario: Admin
    - Senha: zabbix
10. Na solução em src => Services => Fiap.TechChallenge.Fase1.Infraestructure => Grafana => existe um arquivo .json, nele contem a importação do dashboard do grafana.
11. Dentro do Grafana: 
  - Acesse o menu de Data Source
  - Adicione um novo data source do Prometheus
  - DataSource Prometheus: http://192.168.15.6:9090/ (ip da maquina)
12. Apos configurar o Prometheus: 
  - Ir em Administration 
  - Plugins and Data 
  - Plugins 
  - Pesquisar por Zabbix 
  - Habilitar o plugin, clicando o botao em "Enabled"
13. Resultado Grafana
    ![image](https://github.com/user-attachments/assets/5c5dcc2b-1f42-45d0-9198-31cc6fa8a979)

14. Rodar o projeto
15. Autenticar se utilizando o usuário abaixo:

Usuario Padrão <br/>

|E-mail| Senha|
|------|-------|
|admin@gmail.com|Teste@102030|

16. Copiar o bearer token que foi retornado em "objeto" e adicionar no Authorize seguindo o exemplo:
![image](https://github.com/Dragondrax/Fiap-TechChallenge-Fase1/assets/18292105/b92dca04-5f63-48d7-aae4-d33a01127166)
~~~
bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6ImFkbWluQGdtYWlsLmNvbSIsIm5iZiI6MTcxNjg2MTI2NCwiZXhwIjoxNzE2ODkwMDY0LCJpYXQiOjE3MTY4NjEyNjR9.vLwIWPVX52Q6dgSq-C-KuLYTEUsiVoHEEBKa7gSgAPk
~~~

![image](https://github.com/Dragondrax/Fiap-TechChallenge-Fase1/assets/18292105/dcce9941-6636-4bbc-b8ac-8ae6315c3188)

## 🚀Utilizar o Sistema 🚀

## 🔩 Analise de Testes
Foi realizado testes unitários utilizando xUnit.
Foi realizado testes de integração utilizando xUnit, Docker e Postgres.

![image](https://github.com/user-attachments/assets/61fe4fe8-c7f6-455c-becc-c8b4e47252fa)


## 🛠️ Construído com
- Postgres
- Docker
- xUnit
- FluentValidattor
- Entity Framework
- Bogus
- Moq
- DotNet 8.0
- BCrypt
- Grafana
- Prometheus
- Zabbix
.
