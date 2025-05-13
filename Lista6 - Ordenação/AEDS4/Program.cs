using System;
using System.IO;
using System.Text;
using System.Collections.Generic;

class Jogador {
    public int id;
    public string nome;
    public int altura;
    public int peso;
    public string universidade;
    public int anoNasc;
    public string cidadeNasc;
    public string estadoNasc;

    public Jogador(int id, string nome, int altura, int peso, string universidade,int anoNasc, string cidadeNasc, string estadoNasc) {
        this.id = id;
        this.nome = nome;
        this.altura = altura;
        this.peso = peso;
        this.universidade = universidade;
        this.anoNasc = anoNasc;
        this.cidadeNasc = cidadeNasc;
        this.estadoNasc = estadoNasc;
    }

    public void Mostrar() {
        Console.WriteLine($"{id}, {nome}, {altura}, {peso}, {universidade}, {anoNasc}, {cidadeNasc}, {estadoNasc}");
    }

    public string ToCsv() {
        return $"{id},{nome},{altura},{peso},{universidade},{anoNasc},{cidadeNasc},{estadoNasc}";
    }
}

class Program {
    static void Main() {
        string caminho = "players.csv"; // arquivo de entrada
        string caminhoSaida = "players_ordenado.csv"; // arquivo de saída
        List<Jogador> listaJogadores = new List<Jogador>();

        try {
            string[] linhas = File.ReadAllLines(caminho, Encoding.UTF8);

            for (int i = 1; i < linhas.Length; i++) { // Ignora o cabeçalho
                string[] campos = SepararCamposCSV(linhas[i]);

                int id = int.Parse(campos[0]);
                string nome = campos[1];
                int altura = int.TryParse(campos[2], out int h) ? h : 0;
                int peso = int.TryParse(campos[3], out int p) ? p : 0;
                string universidade = string.IsNullOrWhiteSpace(campos[4]) ? "nao informado" : campos[4];
                int anoNasc = int.TryParse(campos[5], out int a) ? a : 0;
                string cidadeNasc = campos.Length > 6 && !string.IsNullOrWhiteSpace(campos[6]) ? campos[6] : "nao informado";
                string estadoNasc = campos.Length > 7 && !string.IsNullOrWhiteSpace(campos[7]) ? campos[7] : "nao informado";

                Jogador jogador = new Jogador(id, nome, altura, peso, universidade, anoNasc, cidadeNasc, estadoNasc);
                listaJogadores.Add(jogador);
            }

            Jogador[] jogadores = listaJogadores.ToArray();

            InsertionSort(jogadores);

            using (StreamWriter writer = new StreamWriter(caminhoSaida, false, Encoding.UTF8)) {
                // Escreve o cabeçalho
                writer.WriteLine("id,nome,altura,peso,universidade,anoNascimento,cidadeNascimento,estadoNascimento");
                foreach (var jogador in jogadores) {
                    writer.WriteLine(jogador.ToCsv());
                }
            }

            Console.WriteLine($"Arquivo '{caminhoSaida}' gerado com sucesso.");

        } catch (Exception e) {
            Console.WriteLine("Erro ao ler o arquivo: " + e.Message);
        }
    }

    static void InsertionSort(Jogador[] array) {
        for (int i = 1; i < array.Length; i++) {
            Jogador atual = array[i];
            int j = i - 1;

            while (j >= 0 && (
                array[j].anoNasc > atual.anoNasc ||
                (array[j].anoNasc == atual.anoNasc && string.Compare(array[j].nome, atual.nome, StringComparison.Ordinal) > 0)
            )) {
                array[j + 1] = array[j];
                j--;
            }
            array[j + 1] = atual;
        }
    }

    // Função para tratar vírgulas dentro de campos com aspas
    static string[] SepararCamposCSV(string linha) {
        List<string> campos = new List<string>();
        bool entreAspas = false;
        string campo = "";

        foreach (char c in linha) {
            if (c == '\"') {
                entreAspas = !entreAspas;
            } else if (c == ',' && !entreAspas) {
                campos.Add(campo);
                campo = "";
            } else {
                campo += c;
            }
        }

        campos.Add(campo); // último campo
        return campos.ToArray();
    }
}
