using System;

namespace QuestGame
{
    class Program
    {
        public class Person
        {
            public string name; // Имя персонажа
            public double health = 100.00; // Здоровье персонажа
            public double force = 0.00; // Сила персонажа
            public double agility = 0.00; // Ловкость персонажа
            public double stamina = 0.00; // Выносливость персонажа
            public double damage; // Урон, зависит от силы персонажа
            public int critdamage; // Критический урон, зависит от выносливости
            public int less; // Шанс промаха, зависит от ловкости персонажа
            public int bonus = 10; // Очки опыта

            public void UpgradeForce()
            {
                force++;
                Console.WriteLine("Сила увеличена!\a");
            }
            public void UpgradeAgility()
            {
                agility++;
                Console.WriteLine("Ловкость увеличена!\a");
            }
            public void UpgradeStamina()
            {
                stamina++;
                Console.WriteLine("Выносливость увеличена!\a");
            }
            public void UpgradeHealth()
            {
                health = health + 100.00;
                Console.WriteLine("Ваше здоровье увеличено!");
            }
            public void Death()
            {
                if (health <= 0)
                {
                    Console.WriteLine("Вы проиграли.");
                    Environment.Exit(0);
                }
            }
        }

        public class Entity : Person
        {
            public string name; // Имя враждебного существа
            public double health; // Здоровье враждебного существа
            public int damage; // Урон, наносимый враждебным существом

            public void Fight(Person pers, Entity entity) // Боевой метод
            {
                Random rnd = new Random();
                if ((pers.force == 1) || (pers.agility == 1) || (pers.stamina == 1))
                {
                    Console.WriteLine("Очков недостаточно. \nРаспределите больше очков.");
                    Environment.Exit(0);
                }
                else if ((pers.force >= 2 && pers.force <= 3) || (pers.agility >= 2 && pers.agility <= 3) || (pers.stamina >= 2 && pers.stamina <= 3))
                {
                    string a = Convert.ToString(Console.ReadLine());
                    pers.less = rnd.Next(0, 99); // agility
                    pers.critdamage = rnd.Next(0, 99); // stamina
                    if (pers.critdamage < 10)
                    {
                        pers.damage = pers.damage + 10;
                        Console.WriteLine("КРИТИЧЕСКИЙ УРОН!");
                    }
                    else
                    {
                        pers.damage = 7;
                    }
                    if (pers.less < 30)
                    {
                        pers.damage = 2;
                        Console.WriteLine("Вы промахнулись. Урон уменьшен.");
                        // меньше 30%
                    }
                    else
                    {
                        pers.damage = 7;
                        // больше 30%
                    }
                    do
                    {
                        if (a == "F")
                        {
                            entity.health = entity.health - pers.damage;
                            Console.WriteLine("У " + entity.name + " осталось " + entity.health + " здоровья");
                            pers.health = pers.health - entity.damage;
                            Console.WriteLine(entity.name + " нанёс вам урон!\nУ вас осталось " + pers.health + " здоровья");

                            a = Convert.ToString(Console.ReadLine());
                        }

                    }
                    while ((entity.health > 0) && (pers.health > 0));
                    if (entity.health <= 0)
                    {
                        Console.WriteLine(entity.name + " побеждён!");
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeAgility();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeForce();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeHealth();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeStamina();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                        Console.WriteLine("Характеристики персонажа " + pers.name + "\nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n" + "Здоровье: " + pers.health);
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                else if ((pers.force >= 4 && pers.force <= 6) || (pers.agility >= 4 && pers.agility <= 6) || (pers.stamina >= 4 && pers.stamina <= 6))
                {
                    string a = Convert.ToString(Console.ReadLine());
                    pers.less = rnd.Next(0, 99); // agility
                    pers.critdamage = rnd.Next(0, 99);
                    if (pers.critdamage < 15)
                    {
                        pers.damage = pers.damage + 10;
                        Console.WriteLine("КРИТИЧЕСКИЙ УРОН!");
                    }
                    else
                    {
                        pers.damage = 11;
                    }
                    if (pers.less < 20)
                    {
                        pers.damage = 4;
                        Console.WriteLine("Вы промахнулись. Урон уменьшен.");
                        // меньше 30%
                    }
                    else
                    {
                        pers.damage = 11;
                        // больше 30%
                    }
                    
                    do
                    {
                        if (a == "F")
                        {
                            entity.health = entity.health - pers.damage;
                            Console.WriteLine("У " + entity.name + " осталось " + entity.health + " здоровья");
                            pers.health = pers.health - entity.damage;
                            Console.WriteLine(entity.name + " нанёс вам урон!\nУ вас осталось " + pers.health + " здоровья");

                            a = Convert.ToString(Console.ReadLine());
                        }
                    }
                    while ((entity.health > 0) && (pers.health > 0));
                    if (entity.health <= 0)
                    {
                        Console.WriteLine(entity.name + " побеждён!");
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeAgility();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeForce();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeHealth();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeStamina();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                        Console.WriteLine("Характеристики персонажа " + pers.name + "\nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                else if ((pers.force >= 6 && pers.force <= 8) || (pers.agility >= 6 && pers.agility <= 8) || (pers.stamina >= 6 && pers.stamina <= 8))
                {
                    string a = Convert.ToString(Console.ReadLine());

                    pers.less = rnd.Next(0, 99); // agility
                    pers.critdamage = rnd.Next(0, 99);
                    if (pers.critdamage < 20)
                    {
                        pers.damage = pers.damage + 10;
                        Console.WriteLine("КРИТИЧЕСКИЙ УРОН!");
                    }
                    else
                    {
                        pers.damage = 15;
                    }
                    if (pers.less < 15)
                    {
                        pers.damage = 6;
                        Console.WriteLine("Вы промахнулись. Урон уменьшен.");
                        // меньше 30%
                    }
                    else
                    {
                        pers.damage = 15;
                        // больше 30%
                    }
                    
                    do
                    {
                        if (a == "F")
                        {
                            entity.health = entity.health - pers.damage;
                            Console.WriteLine("У " + entity.name + " осталось " + entity.health + " здоровья");
                            pers.health = pers.health - entity.damage;
                            Console.WriteLine(entity.name + " нанёс вам урон!\nУ вас осталось " + pers.health + " здоровья");

                            a = Convert.ToString(Console.ReadLine());
                        }

                    }
                    while ((entity.health > 0) && (pers.health > 0));
                    if (entity.health <= 0)
                    {
                        Console.WriteLine(entity.name + " побеждён!");
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeAgility();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeForce();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeHealth();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeStamina();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                        Console.WriteLine("Характеристики персонажа " + pers.name + "\nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
                else if ((pers.force > 8 && pers.force < 20) || (pers.agility > 8 && pers.agility < 20) || (pers.stamina > 8 && pers.stamina < 20))
                {
                    string a = Convert.ToString(Console.ReadLine());
                    // Шанс крит. урона
                    pers.less = rnd.Next(0, 99); // agility
                    pers.critdamage = rnd.Next(0, 99);
                    if (pers.critdamage < 25)
                    {
                        pers.damage = pers.damage + 10;
                        Console.WriteLine("КРИТИЧЕСКИЙ УРОН!");
                    }
                    else
                    {
                        pers.damage = 18;
                    }
                    if (pers.less < 10)
                    {
                        pers.damage = 8;
                        Console.WriteLine("Вы промахнулись. Урон уменьшен.");
                    }
                    else
                    {
                        pers.damage = 18;
                    }
                    
                    do
                    {
                        if (a == "F")
                        {
                            entity.health = entity.health - pers.damage;
                            Console.WriteLine("У " + entity.name + " осталось " + entity.health + " здоровья");
                            pers.health = pers.health - entity.damage;
                            Console.WriteLine(entity.name + " нанёс вам урон!\nУ вас осталось " + pers.health + " здоровья");

                            a = Convert.ToString(Console.ReadLine());
                        }

                    }
                    while ((entity.health > 0) && (pers.health > 0));
                    if (entity.health <= 0)
                    {
                        Console.WriteLine(entity.name + " побеждён!");
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeAgility();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeForce();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeHealth();
                        System.Threading.Thread.Sleep(500);
                        pers.UpgradeStamina();
                        System.Threading.Thread.Sleep(2000);
                        Console.Clear();

                        Console.WriteLine("Характеристики персонажа " + pers.name + "\nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n");
                        System.Threading.Thread.Sleep(1000);
                        Console.Clear();
                    }
                }
            }


        static void Main(string[] args)
        {
                Person pers = new Person();
                Entity Bes = new Entity();
                Bes.name = "Бес";
                Bes.health = 15;
                Bes.damage = 5;

                Entity Abbadon = new Entity();
                Abbadon.name = "Аббадон";
                Abbadon.health = 30;
                Abbadon.damage = 6;

                Entity Dagon = new Entity();
                Dagon.name = "Дагон";
                Dagon.health = 35;
                Dagon.damage = 8;

                Entity Mammon = new Entity();
                Mammon.name = "Маммон";
                Mammon.health = 40;
                Mammon.damage = 10;

                Entity Sithri = new Entity();
                Sithri.name = "Ситри";
                Sithri.health = 45;
                Sithri.damage = 12;

                Entity Sukkubus = new Entity();
                Sukkubus.name = "Суккубус";
                Sukkubus.health = 50;
                Sukkubus.damage = 13;

                Entity Leviaphan = new Entity();
                Leviaphan.name = "Левиафан";
                Leviaphan.health = 60;
                Leviaphan.damage = 15;

                Entity Lucipher = new Entity();
                Lucipher.name = "Люцифер";
                Lucipher.health = 65;
                Lucipher.damage = 17;

                Entity Astaroth = new Entity();
                Astaroth.name = "Астарот";
                Astaroth.health = 70;
                Astaroth.damage = 20;

                Entity Satan = new Entity();
                Satan.name = "Сатана";
                Satan.health = 80;
                Satan.damage = 25;

                Console.WriteLine("Приветствуем вас в квестовой игре! Введите имя персонажа: ");
            pers.name = Console.ReadLine();
            Console.WriteLine("Начать игру? (Y/N)");

            char but = Convert.ToChar(Console.ReadLine());

            if (but == 'Y')
            {
                Console.Clear();
                Console.WriteLine("Добро пожаловать в квестовую игру! Вам предстоит сразиться с основными демонами Ада! Вас зовут " + pers.name + ".");
            }
            else if (but != 'Y') 
            {
                Console.Clear();
                Console.WriteLine("Выход из игры...");
                return;
            }


            Console.WriteLine("Умения: \nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n");
            Console.WriteLine("Распределите очки опыта по умениям. Доступно - " + pers.bonus);

            do
            {
                if (pers.bonus >= 0)
                {
                    Console.WriteLine("Сила ?");
                    int n = Convert.ToInt32(Console.ReadLine());
                    pers.force = n;
                    Console.WriteLine("Теперь Сила = " + pers.force + "\n");
                    pers.bonus = pers.bonus - n;
                    Console.WriteLine("Осталось очков:" + pers.bonus);
                }
                if (pers.bonus > 0)
                {
                    Console.WriteLine("Ловкость ?");
                    int n = Convert.ToInt32(Console.ReadLine());
                    pers.agility = n;
                    Console.WriteLine("Теперь Ловкость = " + pers.agility + "\n");
                    pers.bonus = pers.bonus - n;
                    Console.WriteLine("Осталось очков:" + pers.bonus);
                }
                if (pers.bonus > 0)
                {
                    Console.WriteLine("Выносливость ?");
                    int n = Convert.ToInt32(Console.ReadLine());
                    pers.stamina = n;
                    Console.WriteLine("Теперь Выносливость = " + pers.stamina + "\n");
                    pers.bonus = pers.bonus - n;
                    Console.WriteLine("Осталось очков:" + pers.bonus);
                }
            }
            while (pers.bonus == 10);
            if (pers.bonus < 0)
                {
                    Console.Clear();
                    Console.WriteLine("Больше 10 очков распределить нельзя.");
                    Environment.Exit(0);
                }

            Console.Clear();

            Console.WriteLine("Вы использовали очки опыта. Осталось - " + pers.bonus);
            Console.WriteLine("Умения: \nСила - " + pers.force + "\n" + "Ловкость - " + pers.agility + "\n" + "Выносливость - " + pers.stamina + "\n" + "Здоровье: " + pers.health);

            System.Threading.Thread.Sleep(2000);
            Console.Clear();

            Console.WriteLine("Управление: \nБить - F");
            System.Threading.Thread.Sleep(2000);
            Console.Clear();

                    Console.WriteLine("Обнаружен первый враг! " + Bes.name + "\nОн имеет: " + Bes.health + " здоровья");
                    Bes.Fight(pers, Bes);
                    pers.Death();
                    Console.WriteLine("Обнаружен второй враг! " + Abbadon.name + "\nОн имеет: " + Abbadon.health + " здоровья");
                    Abbadon.Fight(pers, Abbadon);
                    pers.Death();
                    Console.WriteLine("Обнаружен третий враг! " + Dagon.name + "\nОн имеет: " + Dagon.health + " здоровья");
                    Dagon.Fight(pers, Dagon);
                    pers.Death();
                    Console.WriteLine("Обнаружен четвёртый враг! " + Mammon.name + "\nОн имеет: " + Mammon.health + " здоровья");
                    Mammon.Fight(pers, Mammon);
                    pers.Death();
                    Console.WriteLine("Обнаружен пятый враг! " + Sithri.name + "\nОн имеет: " + Sithri.health + " здоровья");
                    Sithri.Fight(pers, Sithri);
                    pers.Death();
                    Console.WriteLine("Обнаружен шестой враг! " + Sukkubus.name + "\nОн имеет: " + Sukkubus.health + " здоровья");
                    Sukkubus.Fight(pers, Sukkubus);
                    pers.Death();
                    Console.WriteLine("Обнаружен седьмой враг! " + Leviaphan.name + "\nОн имеет: " + Leviaphan.health + " здоровья");
                    Leviaphan.Fight(pers, Leviaphan);
                    pers.Death();
                    Console.WriteLine("Обнаружен восьмой враг! " + Lucipher.name + "\nОн имеет: " + Lucipher.health + " здоровья");
                    Lucipher.Fight(pers, Lucipher);
                    pers.Death();
                    Console.WriteLine("Обнаружен девятый враг! " + Astaroth.name + "\nОн имеет: " + Astaroth.health + " здоровья");
                    Astaroth.Fight(pers, Astaroth);
                    pers.Death();
                    Console.WriteLine("Обнаружен десятый враг! Босс! " + Satan.name + "\nОн имеет: " + Satan.health + " здоровья");
                    Satan.Fight(pers, Satan);
                    pers.Death();

                if (pers.health > 0)
                {
                    Console.WriteLine("Вы прошли текстовый квест!");
                    Environment.Exit(0);
                }
                else if (pers.health <= 0)
                {
                    Console.WriteLine("Вы проиграли.");
                    Environment.Exit(0);
                }
            }
        }
    }
}

