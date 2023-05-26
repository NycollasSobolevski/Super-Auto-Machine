using Super_Auto_Machine;

public class Facade
{
    public Store StoreGame {get;set;} = Store.Current;
    public Fight FightGame {get;set;} = Fight.Current;

    public void Game(Player player)
    {
        while (player.Hearts > 0 || player.Trophies < 10)
        {
            if (FightGame.FightTurn() == 1)
            {
                player.Trophies += 1;
                player.Levels += 1;
            }
            else if (FightGame.FightTurn() == 2)
            {
                player.Hearts -= 1;
                player.Levels += 1;
            }
            Store.New();
        }
    }

}