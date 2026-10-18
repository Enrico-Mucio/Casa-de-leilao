using System.Linq;
using System.Collections.Generic;
using UnityEngine;

public class Leilao : MonoBehaviour
{
    public List<LoteInicial> lotesIniciais; // aparece no Inspector
    Dictionary<string, Lote> lotes = new Dictionary<string, Lote>
        (System.StringComparer.OrdinalIgnoreCase);
    void Awake()
    {
        foreach (LoteInicial l in lotesIniciais)
        {
            if (lotes.ContainsKey(l.item))
            {
                Debug.LogWarning($"Item {l.item} já existe no leilão");
            }
            else
            {
                lotes.Add(l.item, new Lote(l.item, l.lance, l.vendedor));
            }
        }
    }

    public void MostrarTotal()
    {
        Debug.Log($"Total de lotes no leilão: {lotes.Count}");
    }
    public bool Anunciar(string item, int lanceInicial, string vendedor)
    {
        if (lotes.ContainsKey(item) || string.IsNullOrWhiteSpace(item) 
            || lanceInicial <= 0 || string.IsNullOrWhiteSpace(vendedor))
        {
            return false;
        }

        lotes.Add(item, new Lote(item, lanceInicial, vendedor));
        return true;
    }
    public bool RemoverLote(string item)
    {
        return lotes.Remove(item);
    }

    public bool DarLance(string item, int valor)
    {
        Lote lote;
        if (!lotes.TryGetValue(item, out lote) || valor <= lote.Lance)
        {
            return false;
        }
        lote.Lance = valor; // altera o lote DENTRO
        return true;
    }

    public int? LanceAtual(string item)
    {
        if (lotes.TryGetValue(item, out Lote lote))
        {
            Debug.Log($"Lance atual para {item}: {lote.Lance}");
            return lote.Lance;
        }

        else
        {
            Debug.LogWarning($"Item {item} não encontrado no leilão");
            return null;
        }
    }

    public void MostrarCatalogo()
    {
        lotes.OrderBy(par => par.Key);
        foreach (var par in lotes.OrderBy(par => par.Key))
        {
            Debug.Log (par.Key);
        }
    }
}
