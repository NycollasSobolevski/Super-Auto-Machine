using Super_Auto_Machine;
Player player = new(5, 10, 0);
Store.New();
var StoreGame = Store.Current;
Fight.New();
var FightGame = Fight.Current;

Facade Game = new Facade();





App app = new ExampleApp();
app.Run();

