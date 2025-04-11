using Ink.Runtime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Assets.Scripts;

public class InkManager : MonoBehaviour
{

    [SerializeField]
    private TextAsset _inkJsonAsset;
    private Story _story;

    [SerializeField]
    private TMP_Text _textField;

    [SerializeField]
    private VerticalLayoutGroup _choiceButtonsContainer;

    [SerializeField]
    private Button _choiceButtonPrefab;

    [SerializeField]
    private Color _normalTextColor;

    [SerializeField]
    private Color _pensamientoTextColor;

    [SerializeField]
    private FontStyle _pensamientoTextStyle;

    [SerializeField]
    private Color _aellTextColor;


    [SerializeField]
    private FontStyle _normalTextStyle;

    private CharacterManager _characterManager;

    public float typingSpeed;
    private Coroutine _displayNextLineCoroutine;

    private AudioManager _audioManager;

    private FondoManager _fondoManager;

    // Start is called before the first frame update
    void Start()
    {
        _characterManager = FindObjectOfType<CharacterManager>();
        _audioManager = FindObjectOfType<AudioManager>();
        _fondoManager = FindObjectOfType<FondoManager>();
        StartStory();
    }

   

    void StartStory()
    {
        _story = new Story(_inkJsonAsset.text);
        _story.BindExternalFunction("ShowCharacter", (string name, string position, string mood) => 
        _characterManager.CreateCharacter(name, position, mood));

        _story.BindExternalFunction("HideCharacter", (string name) => _characterManager.HideCharacter(name));

        _story.BindExternalFunction("ChangeMood", (string name, string mood) => _characterManager.ChangeMood(name, mood));
        _story.BindExternalFunction("SwitchSong1", () => _audioManager.SwitchSong1());
        _story.BindExternalFunction("SwitchSong2", () => _audioManager.SwitchSong2());
        _story.BindExternalFunction("ActivaCasa", () => _fondoManager.ActivaCasa());
        _story.BindExternalFunction("ActivaTurbio", () => _fondoManager.ActivaTurbio());
        _story.BindExternalFunction("ActivaBonito", () => _fondoManager.ActivaBonito());
        DisplayNextLine();
    }

    public void DisplayNextLine() //muestra la siguiente linea
    {
        if (_story.canContinue)
        {
            string text = _story.Continue(); //Recoge la siguiente linea
            text = text?.Trim(); //recortar el espacio blanco del texto
            ApplyStyling();
            _textField.text = text; //muestra en la cajita de texto el nuevo texto

            if (_displayNextLineCoroutine != null)
            {
                StopCoroutine(_displayNextLineCoroutine); //si la corutina está activamente encendida, párala antes de encenderla otra vez
            }
            _displayNextLineCoroutine = StartCoroutine(DisplayLineLetterByLetter(text));
        } 

        else if (_story.currentChoices.Count > 0)
        {
            DisplayChoices();
        }
        
    }

    private void DisplayChoices()
    {
        if (_choiceButtonsContainer.GetComponentsInChildren<Button>().Length > 0) return;
        for (int i = 0; i < _story.currentChoices.Count; i++)
        {
            var choice = _story.currentChoices[i];
            var button = CreateChoiceButton(choice.text);

            button.onClick.AddListener(()=> OnClickButtonChoice(choice));
        }
    }

    Button CreateChoiceButton(string text)
    {
        var choiceButton = Instantiate(_choiceButtonPrefab);
        choiceButton.transform.SetParent(_choiceButtonsContainer.transform, false);

        var buttonText = choiceButton.GetComponentInChildren<TMP_Text>();
        buttonText.text = text; 

        return choiceButton;
    }

    void OnClickButtonChoice(Choice choice)
    {
        _story.ChooseChoiceIndex(choice.index);
        ClearChoiceView();
        _story.Continue();
        DisplayNextLine();
        
    }

    void ClearChoiceView()
    {
        if (_choiceButtonsContainer != null)
        {
            foreach (var button in _choiceButtonsContainer.GetComponentsInChildren<Button>())
            {
                Destroy(button.gameObject);
            }
        }
    }

    private void ApplyStyling()
    {
        if (_story.currentTags.Contains("pensamiento"))
        {
            _textField.color = _pensamientoTextColor;
            //se pone cursiva
            _textField.fontStyle = (FontStyles)_pensamientoTextStyle;
        }
        else if (_story.currentTags.Contains("aell"))
        {
            _textField.color = _aellTextColor;
            
        }
        else
        {
            _textField.color = _normalTextColor;
            //estilo normal

            _textField.fontStyle = (FontStyles)_normalTextStyle;
        }
    }

    private IEnumerator DisplayLineLetterByLetter(string line)
    {
        _textField.text = " "; //vacía el cuadro de texto

        foreach (char letter in line.ToCharArray()) //por cada letra de la línea, súmala al texto y espera la cantidad de tiempo "typingSpeed" para
        {                                           // escribir la siguiente línea
            if (Input.GetKeyDown(KeyCode.K)) // si pulsas la tecla K (en este caso), sáltate el letra a letra y muestra la línea entera de golpe.
            {
                _textField.text = line;
                break;
            }
            _textField.text += letter;
            yield return new WaitForSeconds(typingSpeed);
        }
    }
}
