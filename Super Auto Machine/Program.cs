using Super_Auto_Machine;

Player player = new(5, 10, 0);


Store.New();
var StoreGame = Store.Current;

Fight.New();
var FightGame = Fight.Current;



while(player.Hearts > 0 || player.Trophies < 10){
    if(FightGame.FightTurn() == 1){
        player.Trophies += 1;
        player.Levels += 1;
    }
    else if(FightGame.FightTurn() == 2){
        player.Hearts -= 1;
        player.Levels += 1;
    }
}


App app = new ExampleApp();
app.Run();

