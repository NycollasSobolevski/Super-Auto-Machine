using Super_Auto_Machine;

public class Game{

    public void StoreGraphic(Store storegame){
        System.Console.WriteLine(" ------------------ SESSÃO DE COMPRA ------------------ ");
        storegame.OpenStore();


        int machine = 1;
        foreach (var item in storegame.Sales)
        {
            System.Console.WriteLine("name -------- Life -------- Damage");
            System.Console.WriteLine($"{machine} => {nameof(item)}:", $"{item.Life} |", $" {item.Power}");
            machine += 1;
        }
        System.Console.Write("Qual maquina deseja comprar?");
        int index = int.Parse(Console.ReadLine());


        storegame.Sell(storegame.Sales[index-1]);
        
    }


    public void FightGraphic(Fight fightgame){
        System.Console.WriteLine(" ------------------ SESSÃO DE LUTA ------------------");
        fightgame.FightTurn();

        for (int i = fightgame.MyMachines.Count()-1; i >= 0; i--)
        {
            var item = fightgame.MyMachines[i];
            System.Console.WriteLine($"{nameof(item)}: {item.Power}|{item.Life}");
        }


        foreach (var item in fightgame.EnemieMachines)
        {
            Console.WriteLine($"{nameof(item)}: {item.Power}|{item.Life}");
        }
    }

    public void GraphicGame(Player player, Store storegame, Fight fightgame){
        StoreGraphic(storegame);
        FightGraphic(fightgame);
    }
}