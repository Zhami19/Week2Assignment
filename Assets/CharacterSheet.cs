using System;
using UnityEngine;

public class CharacterSheet : MonoBehaviour
{

    [SerializeField]
    private string _characterName;

    [SerializeField]
    private int _proficiencyBonus;

    [SerializeField]
    private bool _usingFinesse;

    [SerializeField]
    [Range(-5, 5)] int _STR;

    [SerializeField]
    [Range(-5,5)] int _DEX;

    private int _numRolled;

    private int _AC;

    private int _hitModifier;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _AC = UnityEngine.Random.Range(10, 21);

        _numRolled = UnityEngine.Random.Range(1, 21);

        //Hit modifier calculation
        if (_usingFinesse == false)
        {
            _hitModifier = _STR + _proficiencyBonus;
        }
        else if (_usingFinesse == true) 
        {
            if (_STR > _DEX)
            {
                _hitModifier = _STR + _proficiencyBonus;
            }
            else
            {
                _hitModifier = _DEX + _proficiencyBonus;
            }
        }

        //AC calculation and result display
        if (_hitModifier > 0)
        {
            Debug.Log(_characterName + "'s hit modifier is +" + _hitModifier);
        }
        else
        {
            Debug.Log(_characterName + "'s hit modifier is " + _hitModifier);
        }

        Debug.Log("Enemy AC is " + _AC);

        //D20 result display
        switch(_numRolled)
        {
            case 8:
            case 11:
            case 18:
                Debug.Log(_characterName + " rolled an " + _numRolled);
                break;
            default:
                Debug.Log(_characterName + " rolled a " + _numRolled);
                break;
        }

        //Hit/miss result 
        if ((_numRolled + _hitModifier) >= _AC)
        {
            Debug.Log("Enemy has been decapitated.");
        }
        else
        {
            Debug.Log("Enemy has dodged the attack.");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
