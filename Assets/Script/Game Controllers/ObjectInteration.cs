using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public enum TipoDeTexto
{
    umTexto,
    maisTexto
}

public class ObjectInteration : MonoBehaviour
{
    public string[] texto;

    public TipoDeTexto qntDeTexto;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null)
            {
                Debug.Log("Clicou em: " + hit.collider.name);
                TextMeshProUGUI description = GameObject.FindGameObjectWithTag("Descrição").GetComponent<TextMeshProUGUI>();
                
                if (texto.Length == 0)
                {
                    description.text = texto[0];
                } else
                {
                    description.text = texto[texto.Length - texto.Length + 1];
                }
            }
        }
    }
}
