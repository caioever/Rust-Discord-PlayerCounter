
Rust-Discord-PlayerCounter

## Descrição

- Esse bot e plugin são um conjunto que conta e envia esses dados para a atividade do bot no Discord, tendo um contador realtime.

## Prerequsitos

- Nodejs (v7.3.0 ou mais recente) e NPM.
- Oxide precisa estar instalado no seu servidor.
- Um bot registrado do Discord.

## Instalação

Clonando o repositorio

`$ git clone https://github.com/caioever/Rust-Discord-PlayerCounter && cd Rust-Discord-PlayerCounter`

Instalando os modulos

`$ npm install`

Iniciando o bot

`$ node playerCounterBot.js`

## Configuration
Dentro do arquivo de configuraçao `config.json` você verá a seguinte estrutura:

```json
{
  "token": "DISCORD-TOKEN",
  "porta": "3000"
}
```

Como pode ver é bem intuitivo, você define o token do seu bot registrado e a porta que deseja que o bot fique ouvindo.

No plugin você verá bem no inicio a seguinte linha:
```cs
  string enderecoServidor = "localhost";
  string porta = "3000";
```
Para configurar você só precisa definir o endereço e a porta do host do bot.

## Teste
Após devidamente configurado e instalado você pode testar via curl conforme o exemplo abaixo:
```curl
curl -X POST \
  http://localhost:3000/atualizarContador \
  -H 'Cache-Control: no-cache' \
  -H 'Content-Type: application/json' \
  -H 'Postman-Token: 4114d22a-0ede-d4b8-d02a-657e6532693a' \
  -d '{
	"numeroDePLayersAgora": "10",
	"numeroDePlayersTotal": "200"
}'
```
