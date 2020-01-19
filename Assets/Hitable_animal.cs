
using UnityEngine;
public class Hitable_animal : HitableObject {
    public int m_hits = 10;
    public int m_axeHitValue = 3;
    public int m_stoneFragmentHitValue = 2;
    public int m_hammerHitValue = 3;
   
    public GameObject m_woodSpawns;
    public GameObject m_stickSpawns;

    public GameObject m_woodPrefab;
    public GameObject m_stickPrefab;    
    public override void HandleHit (ToolType toolType) {
        if (m_audioSource)
            m_audioSource.Play();

        if (toolType == ToolType.Axe || toolType == ToolType.StoneFragment || toolType ==ToolType.Hammer )

        if (toolType == ToolType.Axe) // axe chops better
            m_hits -= m_axeHitValue;
        else if (toolType == ToolType.StoneFragment)
            m_hits -= m_stoneFragmentHitValue;
        if (toolType == ToolType.Hammer)
            m_hits -= m_hammerHitValue;
            if (m_hits <= 0)
        {
            //instantiate logs and sticks
            for (int i = 0; i < m_woodSpawns.transform.childCount; ++i)
                Instantiate(m_woodPrefab, m_woodSpawns.transform.GetChild(i).position, m_woodSpawns.transform.GetChild(i).rotation);
            for (int i = 0; i < m_stickSpawns.transform.childCount; ++i)
                Instantiate(m_stickPrefab, m_stickSpawns.transform.GetChild(i).position, m_stickSpawns.transform.GetChild(i).rotation);
            Destroy(gameObject);
        }
    }
}
