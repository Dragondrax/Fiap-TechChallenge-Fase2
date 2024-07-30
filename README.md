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
9. Configurar Grafana: 
  - Acesse localhost:3000
  - Vá em Connection adicione o datasource do zabbix no grafana
  - Em Zabbix Connection, configurar URL: 
    - http://ipMaquinaIPV4:8081/api_jsonrpc.php (Utilizar ipv4 da maquina local)
      ![image](https://github.com/user-attachments/assets/dc7b2347-4dbb-4ebf-b0e3-8edc80208b05)
  - O usuario padrão que foi utilizado para logar no Zabbix Web
    - Usuario: Admin
    - Senha: zabbix
      ![image](https://github.com/user-attachments/assets/3aed0509-c918-4fe9-90ee-abeb737151eb)
      
11. Dentro do Grafana: 
  - Acesse o menu de Data Source
  - Adicione um novo data source do Prometheus
  - DataSource Prometheus: http://ipMaquinaIPV4:9090/
    ![image](https://github.com/user-attachments/assets/b4a7dc1f-a38b-4e03-9315-02fec9d78012)
  - Save e Test

12.Dentro do Grafana Menu esquerdo:
  - Entrar em Dashboard:
  - 
    ![image](https://github.com/user-attachments/assets/dd9b036a-7b0b-4c38-b5c6-1764db04801a)
  - Na solução em src => Services => Fiap.TechChallenge.Fase1.Infraestructure => Grafana => existe um arquivo .json, nele contem a importação do dashboard do grafana.
    - Pegar essa configuração e clicar em New -> Import
      - ![image](https://github.com/user-attachments/assets/52ff883f-675a-4d96-b407-3513aa31715f)
    - Colar o conteúdo do arquivo .json e deposi Load
      ![image](https://github.com/user-attachments/assets/92c39a80-9df1-4d3e-a59f-68f19667167e)
    - Import:
      ![image](https://github.com/user-attachments/assets/8fb8c860-f616-4846-97c1-f6a0d43b0366)
      
13. Apos configurar o Prometheus: 
  - Ir em Administration 
  - Plugins and Data 
  - Plugins 
  - Pesquisar por Zabbix 
  - Habilitar o plugin, clicando o botao em "Enabled"
14. Resultado Grafana
    ![image](https://github.com/user-attachments/assets/5c5dcc2b-1f42-45d0-9198-31cc6fa8a979)

15. Rodar o projeto
16. Autenticar se utilizando o usuário abaixo:
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
