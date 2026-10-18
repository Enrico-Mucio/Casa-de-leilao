using System;
using UnityEngine;

public class Lote
{
    public string Item; // a CHAVE da busca
    public int Lance;
    public string Vendedor;
    public Lote(string item, int lance, string vendedor)
    {
        Item = item;
        Lance = lance;
        Vendedor = vendedor;
    }
    public static int HashPolinomial(string chave)
    {
        unchecked // estouro proposital
        {
            int hash = 0;
            foreach (char c in chave)
                hash = hash * 31 + c;
            return hash;
        }
    }

    public static int Indice(int hash, int tamanho)
    {
        return Math.Abs(hash % tamanho);
    }


}
