﻿using Discord;
using Discord.Commands;
using Discord.WebSocket;
using EvilMortyBot.Common;
using EvilMortyBot.Common.Collections;
using EvilMortyBot.Core.Services;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace EvilMortyBot.Modules.Gambling.Common.CurrencyEvents
{
    //public class SneakyEvent : ICurrencyEvent
    //{
    //    public event Action OnEnded;
    //    public string Code { get; private set; } = string.Empty;
    //    private readonly ConcurrentHashSet<ulong> _sneakyGameAwardedUsers = new ConcurrentHashSet<ulong>();

    //    private readonly char[] _sneakyGameStatusChars = Enumerable.Range(48, 10)
    //        .Concat(Enumerable.Range(65, 26))
    //        .Concat(Enumerable.Range(97, 26))
    //        .Select(x => (char)x)
    //        .ToArray();

    //    private readonly ICurrencyService _cs;
    //    private readonly DiscordSocketClient _client;
    //    private readonly IBotConfigProvider _bc;
    //    private readonly long _length;

    //    public SneakyEvent(ICurrencyService cs, DiscordSocketClient client,
    //        IBotConfigProvider bc, long len)
    //    {
    //        _cs = cs;
    //        _client = client;
    //        _bc = bc;
    //        _length = len;
    //    }

    //    public override async Task Start(IUserMessage msg, ICommandContext channel)
    //    {
    //        GenerateCode();

    //        //start the event
    //        _client.MessageReceived += SneakyGameMessageReceivedEventHandler;
    //        await _client.SetGameAsync($"type {Code} for " + _bc.BotConfig.CurrencyPluralName)
    //            .ConfigureAwait(false);
    //        await Task.Delay((int)_length * 1000).ConfigureAwait(false);
    //        await Stop().ConfigureAwait(false);
    //    }

    //    private void GenerateCode()
    //    {
    //        var rng = new EvilMortyRandom();

    //        for (var i = 0; i < 5; i++)
    //        {
    //            Code += _sneakyGameStatusChars[rng.Next(0, _sneakyGameStatusChars.Length)];
    //        }
    //    }

    //    public override async Task Stop()
    //    {
    //        try
    //        {
    //            _client.MessageReceived -= SneakyGameMessageReceivedEventHandler;
    //            Code = string.Empty;
    //            _sneakyGameAwardedUsers.Clear();
    //            await _client.SetGameAsync(null).ConfigureAwait(false);
    //        }
    //        catch { }
    //        finally
    //        {

    //            OnEnded?.Invoke();
    //        }
    //    }

    //    private Task SneakyGameMessageReceivedEventHandler(SocketMessage arg)
    //    {
    //        if (arg.Content == Code &&
    //            _sneakyGameAwardedUsers.Add(arg.Author.Id))
    //        {
    //            var _ = Task.Run(async () =>
    //            {
    //                await _cs.AddAsync(arg.Author, "Sneaky Game Event", 100, false)
    //                    .ConfigureAwait(false);

    //                try { await arg.DeleteAsync(new RequestOptions() { RetryMode = RetryMode.AlwaysFail }).ConfigureAwait(false); }
    //                catch
    //                {
    //                    // ignored
    //                }
    //            });
    //        }

    //        return Task.CompletedTask;
    //    }
    //}
}
