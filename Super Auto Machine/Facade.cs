using Super_Auto_Machine;

public class Facade
{
    public Store StoreGame {get;set;} = Store.Current;
    public Fight FightGame {get;set;} = Fight.Current;

    public void Game(Player player)
    {
        while (Player.Hearts > 0 || Player.Trophies < 10)
        {
            if (FightGame.FightTurn() == 1)
            {
                Player.Trophies += 1;
                Player.Round += 1;
            }
            else if (FightGame.FightTurn() == 2)
            {
                Player.Hearts -= 1;
                Player.Round += 1;
            }
            Store.New();
        }
    }

}