using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Oxide.Core.Libraries.Covalence;
using Oxide.Core.Libraries;
using Oxide.Core;

namespace Oxide.Plugins
{
  [Info("PlayerCounterPlugin", "caio.barcelos", 1.0)]
  [Description("Contador de Players para um bot do discord")]

  class PlayerCounterPlugin : CovalencePlugin
  {
    string enderecoServidor = "localhost";
    string porta = "3000";
    int maximoDePlayers = 10;

    void OnPlayerConnected(Network.Message packet)
    {
      //int agora = global.BasePlayer.activePlayerList.Count;
      var payload = new BotPayload
      {
        numeroDePLayersAgora = $"{BasePlayer.activePlayerList.Count}",
        numeroDePlayersTotal = $"{maximoDePlayers}"
      };

      NotificarBot(payload);
    }

    void OnPlayerDisconnected(BasePlayer player, string reason)
    {
      var payload = new BotPayload
      {
        numeroDePLayersAgora = $"{BasePlayer.activePlayerList.Count}",
        numeroDePlayersTotal = $"{maximoDePlayers}"
      };

      NotificarBot(payload);
    }

    void NotificarBot(BotPayload payload)
    {
      string webhook = $"http://{enderecoServidor}:{porta}/atualizarContador";
      Dictionary<string, string> header = new Dictionary<string, string>();
      header.Add("Content-Type", "application/json");
      Puts(JsonConvert.SerializeObject(payload));
      if (payload == null || string.IsNullOrEmpty(webhook)) return;
      webrequest.Enqueue(webhook, JsonConvert.SerializeObject(payload), (code, response) => ServerDetailsCallback(code, response), this, RequestMethod.POST, header);
    }

    void ServerDetailsCallback(int codigo, string callback)
    {
      int[] codigosDeErro = {200, 201, 202, 203, 204};
      int contains = Array.IndexOf(codigosDeErro, codigo);
      if (callback == null || contains > 0)
      {
        Puts($"ERRO: {codigo} - NAO FOI POSSIVEL CONECTAR COM O BOT | callback: {callback}");
        return;
      }
      Puts("Bot respondeu com codigo " + codigo + ": " + callback);
    }

    class BotPayload
    {
      public string numeroDePLayersAgora { get; set; }
      public string numeroDePlayersTotal { get; set; }
    }
  }
}
