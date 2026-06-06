using GameOfWar;
using System.Collections.Generic;

GameState state = new GameState();

state.CardDeck.Shuffle();

state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
state.ComputerDeck.PushCards(state.CardDeck.Deal(26));

Lib.RunGame(state, PlayCards);

static bool PlayCards(GameState state, int playerCardIndex)
{
    Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
    Card computerCard = state.ComputerDeck.PullCardAtIndex(0);

    if (playerCard > computerCard)
    {
        state.PlayerDeck.PushCard(playerCard);
        state.PlayerDeck.PushCard(computerCard);
        state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else if (computerCard > playerCard)
    {
        state.ComputerDeck.PushCard(playerCard);
        state.ComputerDeck.PushCard(computerCard);
        state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
    }
    else
    {
        state.TableDeck.PushCard(playerCard);
        state.TableDeck.PushCard(computerCard);
    }

    if (state.ComputerDeck.Count == 0)
    {
        state.Winner = "Player";
    }
    else if (state.PlayerDeck.Count == 0)
    {
        state.Winner = "Computer";
    }

    return true;
}
