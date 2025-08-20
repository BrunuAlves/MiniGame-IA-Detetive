class NPC
{
    public string Nome { get; }
    public bool EhAssassino { get; }
    public int Suspeita { get; set; } = 0;

    public NPC(string nome, bool assassino)
    {
        Nome = nome; EhAssassino = assassino;
    }

    public string Falar(Random rnd)
    {
        if (EhAssassino)
        {
            string[] falas = {
                "Pare de me acusar!",
                "Não lembro de nada naquela praça.",
                "Isso não tem nada a ver comigo."
            };
            return falas[rnd.Next(falas.Length)];
        }
        else
        {
            string[] falas = {
                "Eu estava em casa.",
                "Não sei, talvez tenha visto alguém correndo.",
                "Eu não lembro direito a hora."
            };
            return falas[rnd.Next(falas.Length)];
        }
    }
}
