using System.ComponentModel.DataAnnotations;

public class Player
{
    public string Name { get; private set; }
    public int Health { get; private set; }
    public int AttackPower { get; private set; }
    public bool IsDefending { get; private set; }

    public Player(string name, int health, int attackPower)
    {
        Name = name;
        Health = health;
        AttackPower = attackPower;
        IsDefending = false;
    }

    //Le Player attaque et en fonction du choix du player adverse l'attque peut être diviser par deux
    public void Attack(Player opponent)
    {
        int damage = opponent.IsDefending ? AttackPower / 2 : AttackPower;
        opponent.TakeDamage(damage);
        opponent.IsDefending = false;
        Console.WriteLine($"{Name} attaque {opponent.Name} pour {damage} dégâts !");
    }

    public void Defend()
    {
        IsDefending = true;
        Console.WriteLine($"{Name} se défend et réduit les dégâts au prochain tour.");
    }

    // Le heal est fixé a 10 a voir dans le dossier application --> Game monsieurs
    public void Heal(int amount)
    {
        Health += amount;
        Console.WriteLine($"{Name} se soigne de {amount} points de vie.");
    }

    // Le joueurs prends des dégats
    public void TakeDamage(int damage)
    {
        Health -= damage;
        Console.WriteLine($"{Name} subit {damage} dégâts. Points de vie restants : {Health}");
    }

    //méthode qui permet de voir si le joueurs et toujours en vie
    public bool IsAlive()
    {
        return Health > 0;
    }
}
