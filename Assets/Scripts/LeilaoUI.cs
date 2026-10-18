using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using JetBrains.Annotations;

public class LeilaoUI : MonoBehaviour
{
    public TMP_InputField inputItem;
    public Slider sliderLance;
    public Leilao leilao;

    public TMP_Text textoResultado;
    public TMP_InputField inputVendedor;

    void Start()
    {
        int valor = Mathf.RoundToInt(sliderLance.value);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnviarLance()
    {
        string item = inputItem.text;
        int lance = Mathf.RoundToInt(sliderLance.value);

        bool sucesso = leilao.DarLance(item, lance);
        if (sucesso)
        {
            textoResultado.text = $"Lance bem sucedido!";
        }
        else
        {
            textoResultado.text = $"Lance falhou";
        }
    }

    public void ConsultarLance()
    {
        string item = inputItem.text;
        int? lanceAtual = leilao.LanceAtual(item);
        if(lanceAtual.HasValue)
        {
            textoResultado.text = $"Lance atual de {item}: {lanceAtual.Value}";
        }
        else
        {
            textoResultado.text = $"Item {item} não encontrado no leilão";
        }
    }

    public void FecharVenda()
    {
        string item = inputItem.text;

        bool sucesso = leilao.RemoverLote(item);
        if(sucesso)
        {
            textoResultado.text = $"Lance {item} vendido";
        }
        else
        {
            textoResultado.text = $"{item} não foi vendido ou não existe.";
        }
    }
    public void AnunciarUI()
    {
        string item = inputItem.text;
        string vendedor = inputVendedor.text;
        int lance = Mathf.RoundToInt(sliderLance.value);

        bool adicionar = leilao.Anunciar(item, lance, vendedor);

        if (adicionar)
        {
            textoResultado.text = $"Lance {item} foi anunciado";
        }

        else
        {
            textoResultado.text = $"Lance {item} já existe ou é um valor inválido (Seu vendedor tem nome?)";
        }
    }

}
