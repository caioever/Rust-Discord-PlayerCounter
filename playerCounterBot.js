const express = require('express');
const Discord = require('discord.js');
const bodyParser = require('body-parser')
const config = require('./config.json');

let app = express();
let playersOn = 0;
let playersTotal = 0;

app.use(bodyParser.json());

app.post('/atualizarContador', function (req, res) {
    let dados = req.body;
    playersOn = dados.numeroDePLayersAgora;
    playersTotal = dados.numeroDePlayersTotal;
    let mensage = `${playersOn}/${playersTotal}`;
    client.user.setActivity(mensage);
    res.send(`notificacao recebida com sucesso: ${JSON.stringify(dados)}`);
});

const client = new Discord.Client();
client.login(process.env.TOKEN || config.token);

client.on("ready", () => {
    console.log("Bot Iniciado");
    client.user.setActivity('Waiting...');
});

app.listen(process.env.PORT || config.porta, function () {
  console.log(`O bot está escutando a porta:${config.porta}`);
});
