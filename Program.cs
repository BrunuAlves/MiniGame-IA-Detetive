class Program
{
    static void Main()
    {
        var rnd = new Random();
        string[] nomes = { "João", "Maria", "Pedro", "Ana", "Lucas" };
        int assassino = rnd.Next(nomes.Length);

        var npcs = nomes.Select((n, i) => new NPC(n, i == assassino)).ToArray();

        Console.WriteLine("=== Descubra o Assassino (IA simples) ===\n");

        Console.Write("Deseja a ajuda da IA durante o jogo? (s/n): ");
        bool usarIA = Console.ReadLine()?.Trim().ToLower() == "s";

        for (int t = 0; t < 3; t++)
        {
            Console.WriteLine("\nSuspeitos (1-5)");
            for (int i = 0; i < npcs.Length; i++)
                Console.WriteLine($"{i + 1}. {npcs[i].Nome}");

            Console.Write("Escolha um para interrogar: ");
            int esc = int.Parse(Console.ReadLine() ?? "1") - 1;
            var npc = npcs[esc];

            string fala = npc.Falar(rnd);
            Console.WriteLine($"\n{npc.Nome}: \"{fala}\"");

            if (usarIA)
            {
                int delta = 0;
                if (fala.ToLower().Contains("não")) delta += 5;
                if (fala.ToLower().Contains("praça")) delta += 10;
                if (fala.ToLower().Contains("pare")) delta += 7;

                npc.Suspeita += delta;
                Console.WriteLine($"IA: +{delta} pontos (agora {npc.Suspeita})\n");
            }
        }

        Console.WriteLine("\nAcuse o assassino (1-5):");
        int acus = int.Parse(Console.ReadLine() ?? "1") - 1;

        Console.WriteLine(npcs[acus].EhAssassino
            ? $"\nAcertou! {npcs[acus].Nome} era o assassino."
            : $"\nErrou! O assassino era {npcs[assassino].Nome}.");
    }
}